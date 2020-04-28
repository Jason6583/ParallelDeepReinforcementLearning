using ConvnetSharp;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace DeepQLearning.DRLAgent
{
    // Singleton to all allow shared experience that is serializable
    // An agent is in state0 and does action0
    // environment then assigns reward0 and provides new state, state1
    // Experience nodes store all this information, which is used in the
    // Q-learning update step
    //https://docs.microsoft.com/en-us/dotnet/api/system.runtime.serialization.iobjectreference?view=netframework-4.8

    [Serializable]
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    public sealed class ExperienceSharedSingleton : ISerializable
    {
        private static readonly ExperienceSharedSingleton _Instance = new ExperienceSharedSingleton();
        public List<ExperienceShared> experienceShared = new List<ExperienceShared>();


        public void Add(ExperienceShared es)
        {
            experienceShared.Add(es);
        }

        public void Update(int index, ExperienceShared es)
        {
            experienceShared[index] = es;
        }

        public ExperienceShared Retrieve(int index)
        {
            return experienceShared[index];
        }

        public ExperienceSharedSingleton()
        {

        }

        public static ExperienceSharedSingleton Instance()
        {
            return _Instance;
        }

        [SecurityPermissionAttribute(SecurityAction.LinkDemand,
        Flags = SecurityPermissionFlag.SerializationFormatter)]
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.SetType(typeof(SingletonSerializationHelper));
        }

        [Serializable]
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        [SecurityPermissionAttribute(SecurityAction.LinkDemand,
        Flags = SecurityPermissionFlag.SerializationFormatter)]
        internal sealed class SingletonSerializationHelper : IObjectReference
        {
            public Object GetRealObject(StreamingContext context)
            {
                return ExperienceSharedSingleton.Instance();
            }
        }

    }

    // A Brain object does all the magic.
    // over time it receives some inputs and some rewards
    // and its job is to set the outputs to maximize the expected reward
    [Serializable]
    public class DeepQLearnSharedSingleton : DeepQLearn
    {
        public string instance;

        public ExperienceSharedSingleton experienceSharedSingleton = ExperienceSharedSingleton.Instance();

        public DeepQLearnSharedSingleton(int num_states, int num_actions, TrainingOptions opt) : base(num_states, num_actions, opt)
        {

        }

        public void Init(List<Experience> le)
        {
            var baseList = new List<ExperienceShared>();
            le.ForEach(v => baseList.Add((ExperienceShared)v));
            experienceSharedSingleton.experienceShared = baseList;
        }

        public List<Experience> List()
        {
            var baseList = new List<Experience>();
            experienceSharedSingleton.experienceShared.ForEach(v => baseList.Add((Experience)v));
            return baseList;
        }

        public override void backward(double reward)
        {
            this.latest_reward = reward;
            this.average_reward_window.add(reward);

            this.reward_window.RemoveAt(0);
            this.reward_window.Add(reward);

            if (!this.learning) { return; }

            // various book-keeping
            this.age += 1;

            // it is time t+1 and we have to store (s_t, a_t, r_t, s_{t+1}) as new experience
            // (given that an appropriate number of state measurements already exist, of course)
            if (this.forward_passes > this.temporal_window + 1)
            {
                var e = new ExperienceShared();
                var n = this.window_size;
                e.state0 = this.net_window[n - 2];
                e.action0 = this.action_window[n - 2];
                e.reward0 = this.reward_window[n - 2];
                e.state1 = this.net_window[n - 1];
                e.agent = this.instance;

                // save experience from all agents
                if (ExperienceSharedSingleton.Instance().experienceShared.Count < this.experience_size)
                {
                    if (e != null) ExperienceSharedSingleton.Instance().experienceShared.Add(e);
                }
                else if (this.experience_size > 0)
                {
                    // replace. finite memory! need to seed random generator per instance, otherwise distribution not even
                    var ri = new Random(Int32.Parse(this.instance)).Next(0, this.experience_size);
                    if (e != null) ExperienceSharedSingleton.Instance().Update(ri, e);
                }
            }

            // learn based on experience, once we have some samples to go on
            // this is where the magic happens...
            if (ExperienceSharedSingleton.Instance().experienceShared.Count > this.start_learn_threshold)
            {
                var avcost = 0.0;
                for (var k = 0; k < this.tdtrainer.batch_size; k++)
                {
                    int i=0;
                    ExperienceShared e;
                    do
                    {
                        var re = util.randi(0, ExperienceSharedSingleton.Instance().experienceShared.Count);
                        e = ExperienceSharedSingleton.Instance().Retrieve(re);
                        i++;
                    }
                    while (e == null || i>10);
                    var x = new Volume(1, 1, this.net_inputs);
                    x.w = e.state0;
                    var maxact = this.policy(e.state1);
                    var r = e.reward0 + this.gamma * maxact.value;

                    var ystruct = new Entry { dim=e.action0, val=r};
                    var loss = this.tdtrainer.train(x, ystruct);
                    avcost += double.Parse(loss["loss"]);
                }

                avcost = avcost / this.tdtrainer.batch_size;
                this.average_loss_window.add(avcost);
            }
        }

        public override int instanceExperienceCount()
        {
            int iec = 0;
            for (var i = 0; i < ExperienceSharedSingleton.Instance().experienceShared.Count; i++)
            {
                if (ExperienceSharedSingleton.Instance().Retrieve(i)?.agent == this.instance) iec++;
            }
            return iec;
        }

        public override string visSelf()
        {
            var t = "";
            t += "experience shared replay size: " + ExperienceSharedSingleton.Instance().experienceShared.Count + Environment.NewLine;
            t += "exploration epsilon: " + this.epsilon + Environment.NewLine;
            t += "age: " + this.age + Environment.NewLine;
            t += "average Q-learning loss: " + this.average_loss_window.get_average() + Environment.NewLine;
            t += "smooth-ish reward: " + this.average_reward_window.get_average() + Environment.NewLine;

            return t;
        }
    }
}
