using ConvnetSharp;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepQLearning.DRLAgent
{
    // An agent is in state0 and does action0
    // environment then assigns reward0 and provides new state, state1
    // Experience nodes store all this information, which is used in the
    // Q-learning update step
    [Serializable]
    public class ExperienceShared : Experience
    {
        public string agent;

        public ExperienceShared() : base()
        {

        }

        public ExperienceShared(double[] state0, int action0, double reward0, double[] state1, string agent) : base(state0, action0, reward0, state1)
        {
            this.agent = agent;
        }
    }


    // A Brain object does all the magic.
    // over time it receives some inputs and some rewards
    // and its job is to set the outputs to maximize the expected reward
    [Serializable]
    public class DeepQLearnShared : DeepQLearn
    {
        public string instance;
        //static ConcurrentDictionary<string,double> agentAvgRewards = new ConcurrentDictionary<string, double> ();
        static Dictionary<string, double> agentAvgRewards = new Dictionary<string, double>();


        public DeepQLearnShared(int num_states, int num_actions, TrainingOptions opt) : base(num_states, num_actions, opt)
        {

        }

        public void Init(List<Experience> le)
        //public void Init(ConcurrentDictionary<int, ExperienceShared> le)
        {
            //var baseList = new List<ExperienceShared>();
            //le.ForEach(v => baseList.Add((ExperienceShared)v));
            //experienceShared = baseList;

            var baseList = new ConcurrentDictionary<int, ExperienceShared>();
            var lea = le.ToArray();
            for (var i = 0; i < le.Count; i++)
            {
                baseList.TryAdd(i, (ExperienceShared)lea[i]);
            }
            experienceShared = baseList;
        }

        public List<Experience> List()
        //public ConcurrentDictionary<int, ExperienceShared> List()
        {
            var baseList = new List<Experience>();
            //experienceShared.ForEach(v => baseList.Add((Experience)v));
            //return baseList;

            //var baseList = new ConcurrentDictionary<int, ExperienceShared>();
            for (var i = 0; i < experienceShared.Count; i++)
            {
                baseList.Add(experienceShared[i]);
            }
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

                // maintain dictionary of agent average rewards
                //agentAvgRewards.AddOrUpdate(e.agent,this.average_reward_window.get_average());
                //if (agentAvgRewards.ContainsKey(e.agent))
                //{
                //    agentAvgRewards[e.agent] = this.average_reward_window.get_average();
                //}
                //else
                //{
                //    agentAvgRewards.Add(e.agent, this.average_reward_window.get_average());
                //}

                // save experience from the "best" agent with the highest average reward
                //var maxAgent = agentAvgRewards.FirstOrDefault(x => x.Value == agentAvgRewards.Values.ToList().Max()).Key;
                //if (e.agent != minAgent)
                // save experience except from the "worst" agent with the lowest average reward
                //var minAgent = agentAvgRewards.Aggregate((x, y) => x.Value < y.Value ? x : y).Key;
                //if (e.agent != minAgent)

                // save experience from all agents
                if (DeepQLearnShared.experienceShared.Count < this.experience_size)
                {
                    var ix = (DeepQLearnShared.experienceShared.Count == 0) ? 0 : experienceShared.Count;
                    if (e != null ) DeepQLearnShared.experienceShared.TryAdd(ix,e);
                }
                else if (this.experience_size > 0)
                {
                    // replace. finite memory! need to seed random generator per instance, otherwise distribution not even
                    var ri = new Random(Int32.Parse(this.instance)).Next(0, this.experience_size);
                    if (e != null) DeepQLearnShared.experienceShared[ri] = e;
                }
            }

            // learn based on experience, once we have some samples to go on
            // this is where the magic happens...
            if (DeepQLearnShared.experienceShared.Count > this.start_learn_threshold)
            {
                var avcost = 0.0;
                for (var k = 0; k < this.tdtrainer.batch_size; k++)
                {

                    int i = 0;
                    ExperienceShared e;
                    do
                    {
                        var re = util.randi(0, DeepQLearnShared.experienceShared.Count);
                        e = DeepQLearnShared.experienceShared[re];
                        i++;
                    }
                    while (e == null || i > 10);
                    var x = new Volume(1, 1, this.net_inputs);
                    x.w = e.state0;
                    var maxact = this.policy(e.state1);
                    var r = e.reward0 + this.gamma * maxact.value;

                    var ystruct = new Entry { dim = e.action0, val = r };
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
            for (var i = 0; i < DeepQLearnShared.experienceShared.Count; i++)
            {
                if (DeepQLearnShared.experienceShared[i].agent == this.instance) iec++;
                //if (DeepQLearnShared.experienceShared[i]?.agent == this.instance) iec++;  // handle nulls, not needed with threadsafe
            }
            return iec;
        }

        public override string visSelf()
        {
            var t = "";
            t += "experience shared replay size: " + DeepQLearnShared.experienceShared.Count + Environment.NewLine;
            t += "exploration epsilon: " + this.epsilon + Environment.NewLine;
            t += "age: " + this.age + Environment.NewLine;
            t += "average Q-learning loss: " + this.average_loss_window.get_average() + Environment.NewLine;
            t += "smooth-ish reward: " + this.average_reward_window.get_average() + Environment.NewLine;

            return t;
        }
    }
}
