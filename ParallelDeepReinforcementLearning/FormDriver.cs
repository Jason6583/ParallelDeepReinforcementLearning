using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Timers;
using System.Threading;
using System.Diagnostics;

namespace DeepQLearning
{
    public partial class FormDriver : Form
    {
        // define variables
        int numInstances = 0;
        FormAgent[] formarray;
        string[] args = new string[23];
        bool paused = false;
        Series series1a, series1b, series1at, series1bt, series2;

        public FormDriver()
        {
            InitializeComponent();
        }

        private void frmDriver_Load(object sender, EventArgs e)
        {
            // intialize form
            cboLearningMethod.SelectedItem = "adadelta";
            txtLearningRate.Text = "0.01";
            txtLearningMomentum.Text = "0.9";
            txtLearningBatch.Text = "10";
            txtLearnTotal.Text = "200000";
            txtLearnBurn.Text = "3000";
            txtLearningL1Decay.Text = "0";
            txtLearningL2Decay.Text = "0.001";
            txtNumInstances.Text = "2";
            rdoThread.Checked = true;
            txtExperienceMax.Text = "30000";
            txtExperienceMin.Text = "1000";
            chkSharedExperience.Checked = true;
            rdoStaticExperience.Checked = true;
            txtExplorationMax.Text = "1";
            txtExplorationMin.Text = "0.05";
            txtCanvasWidth.Text = "710";
            txtCanvasHeight.Text = "500";
            txtNumberItems.Text = "30";
            txtReward.Text = "5.0";
            txtPunish.Text = "-6.0";
            txtDuration.Text = "40000";
            txtChartFrequency.Text = "10";
            btnCreate.Select();
            toolStripStatusLabel1.Text = "";

            // initialize timer to refresh charts every 10s
            timer1.Interval = Int32.Parse(txtChartFrequency.Text) * 1000;
        }

        private void txtNumInstances_TextChanged(object sender, EventArgs e)
        {
            if (txtNumInstances.Text != "" && Int32.Parse(txtNumInstances.Text) == 1)
                chkSharedExperience.Checked = false;
            else
                chkSharedExperience.Checked = true;
        }
        private void chkRandomItems_CheckedChanged(object sender, EventArgs e)
        {
            // toggle random items
            for (int i = 0; i < numInstances; i++)
            {
                formarray[i].chkRandomItems.Checked = chkRandomItems.Checked;
            }
        }

        private void chkObstruct_CheckedChanged(object sender, EventArgs e)
        {
            // toggle obstruct items
            for (int i = 0; i < numInstances; i++)
            {
                formarray[i].chkObstructItems.Checked = chkObstructItems.Checked;
            }
        }

        private void chkSharedExperience_CheckedChanged(object sender, EventArgs e)
        {
            // toggle shared experience
            for (int i = 0; i < numInstances; i++)
            {
                formarray[i].chkSharedExperience.Checked = chkSharedExperience.Checked;
            }
            // disable or enable experience types
            if (chkSharedExperience.Checked)
            {
                rdoStaticExperience.Enabled = true;
                rdoSingletonExperience.Enabled = true;
            }
            else
            {
                rdoStaticExperience.Enabled = false;
                rdoSingletonExperience.Enabled = false;
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            // get input num of instances
            numInstances = Int32.Parse(txtNumInstances.Text);
            formarray = new FormAgent[numInstances];

            // create forms and threads or processes
            for (int i = 0; i < numInstances; i++)
            {
                args[0] = i.ToString();
                args[1] = txtExperienceMax.Text;
                args[2] = txtExperienceMin.Text;
                args[3] = cboLearningMethod.SelectedItem.ToString();
                args[4] = txtLearningRate.Text;
                args[5] = txtLearningMomentum.Text;
                args[6] = txtLearningBatch.Text;
                args[7] = txtLearnTotal.Text;
                args[8] = txtLearnBurn.Text;
                args[9] = txtLearningL1Decay.Text;
                args[10] = txtLearningL2Decay.Text;
                args[11] = txtNumberItems.Text;
                args[12] = txtReward.Text;
                args[13] = txtPunish.Text;
                args[14] = chkSharedExperience.Checked.ToString();
                args[15] = chkObstructItems.Checked.ToString();
                args[16] = chkRandomItems.Checked.ToString();
                args[17] = chkInfiniteItems.Checked.ToString();
                args[18] = rdoStaticExperience.Checked.ToString();
                args[19] = txtCanvasWidth.Text;
                args[20] = txtCanvasHeight.Text;
                args[21] = (txtDuration.Text!="") ? txtDuration.Text : "0";

                // create thread
                if (rdoThread.Checked)
                {
                    args[22] = "false";
                    formarray[i] = new FormAgent(args);
                    formarray[i].Show();
                }

                // create process
                if (rdoProcess.Checked)
                {
                    ProcessStartInfo info = new ProcessStartInfo();
                    info.FileName = "DeepQLearning.exe";
                    info.Arguments = string.Join(" ", args) + " true";
                    info.UseShellExecute = true;
                    Process.Start(info);
                }

                // wait 10 milliseconds between instances to guarantee random seed
                Thread.Sleep(10);
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            // display start
            toolStripStatusLabel1.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            
            // start instances
            for (int i = 0; i < numInstances; i++)
            {
                formarray[i].startLearning.PerformClick();

                // wait 10 milliseconds between instances
                Thread.Sleep(10);
            }

            // start charts
            initializeCharts();
            timer1.Enabled = true;
        }

        private void btnPauseContinue_Click(object sender, EventArgs e)
        {
            // pause or continue forms
            for (int i = 0; i < numInstances; i++)
            {
                formarray[i].PauseBtn.PerformClick();
            }

            // set button state
            if (paused)
            {
                btnPauseContinue.Text = "Pause";
                paused = false;
                timer1.Enabled = true;
            }
            else
            {
                btnPauseContinue.Text = "Continue";
                paused = true;
                timer1.Enabled = false;
            }

            // display elapsed
            DateTime start;
            var end = DateTime.Now;
            if (DateTime.TryParse(toolStripStatusLabel1.Text, out start))
            {
                var sb = new StringBuilder().AppendFormat("START(year-month-day_hours:mins:secs):{0} | END(year-month-day_hours:mins:secs):{1} | ELAPSED(day.hours_mins:secs):{2}", start.ToString("yyyy-MM-dd_HH:mm:ss"), end.ToString("yyyy-MM-dd_HH:mm:ss"), (end - start).ToString(@"dd\.hh\_mm\:ss"));
                toolStripStatusLabel1.Text = sb.ToString();
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            // stop forms
            for (int i = 0; i < numInstances; i++)
            {
                formarray[i].StopLearning.PerformClick();
            }
            timer1.Enabled = false;
        }

        private void btnDestroy_Click(object sender, EventArgs e)
        {
            // close forms
            for (int i = 0; i < numInstances; i++)
            {
                formarray[i].Close();
            }
        }

        private void btnFaster_Click(object sender, EventArgs e)
        {
            // faster forms
            for (int i = 0; i < numInstances; i++)
            {
                formarray[i].goVeryFast.PerformClick();
            }
        }

        private void btnFast_Click(object sender, EventArgs e)
        {
            // fast forms
            for (int i = 0; i < numInstances; i++)
            {
                formarray[i].goFast.PerformClick();
            }
        }

        private void btnNormal_Click(object sender, EventArgs e)
        {
            // normal forms
            for (int i = 0; i < numInstances; i++)
            {
                formarray[i].goNormal.PerformClick();
            }
        }

        private void btnSlow_Click(object sender, EventArgs e)
        {
            // slow forms
            for (int i = 0; i < numInstances; i++)
            {
                formarray[i].goSlow.PerformClick();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // save forms
            for (int i = 0; i < numInstances; i++)
            {
                formarray[i].saveNet.PerformClick();
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            // load forms
            for (int i = 0; i < numInstances; i++)
            {
                formarray[i].loadNet.PerformClick();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.btnDestroy.PerformClick();
            this.Close();
        }

        private void rdoThread_CheckedChanged(object sender, EventArgs e)
        {
                // can control processes and use shared memory with threads
                if (rdoThread.Checked)
                {
                    btnDestroy.Enabled = true;
                    btnFast.Enabled = true;
                    btnFastest.Enabled = true;
                    btnLoad.Enabled = true;
                    btnNormal.Enabled = true;
                    btnPauseContinue.Enabled = true;
                    btnSave.Enabled = true;
                    btnSlow.Enabled = true;
                    btnStart.Enabled = true;
                    btnStop.Enabled = true;
                    chkSharedExperience.Enabled = true;
                }
        }

        private void rdoProcess_CheckedChanged(object sender, EventArgs e)
        {
            // cannot control processes or use shared memory with processes, no interprocess communication
            if (rdoProcess.Checked)
            {
                btnDestroy.Enabled = false;
                btnFast.Enabled = false;
                btnFastest.Enabled = false;
                btnLoad.Enabled = false;
                btnNormal.Enabled = false;
                btnPauseContinue.Enabled = false;
                btnSave.Enabled = false;
                btnSlow.Enabled = false;
                btnStart.Enabled = false;
                btnStop.Enabled = false;
                chkSharedExperience.Enabled = false;
                chkSharedExperience.Checked = false;
            }
        }

        private void initializeCharts()
        {
            // create static charts
            this.chart1.Series.Clear();
            this.chart1.Titles.Clear();
            this.chart1.Titles.Add("Agent Accuracy Over Time");
            series1a = this.chart1.Series.Add("Average\\nReward");
            series1a.ChartType = SeriesChartType.Spline;
            series1a.Color = Color.Blue;
            series1b = this.chart1.Series.Add("Average\\nLoss");
            series1b.ChartType = SeriesChartType.Spline;
            series1b.Color = Color.Orange;
            this.chart2.Titles.Clear();
            this.chart2.Series.Clear();
            this.chart2.Titles.Add("Agent Completeness Over Time");
            series2 = this.chart2.Series.Add("Processed\\nItem Count");
            series2.ChartType = SeriesChartType.Spline;
            series2.Color = Color.Orange;
            //this.chart2.Series["Processed\\nItem Count"].IsValueShownAsLabel = true;
            //this.chart1.Series["Average\\nReward"].IsValueShownAsLabel = true;
            //this.chart1.Series["Average\\nLoss"].IsValueShownAsLabel = true;

            // add points for trendline
            series1a.Points.AddXY(0, 0.5);
            series1a.Points.AddXY(0, 0.5);
            series1b.Points.AddXY(0, 0.5);
            series1b.Points.AddXY(0, 0.5);

            // create trend lines
            series1at = chart1.Series.Add("Reward\\nTrend");
            series1at.ChartType = SeriesChartType.Line;
            series1at.Color = Color.Blue;
            series1at.BorderDashStyle = ChartDashStyle.Dash;
            chart1.DataManipulator.FinancialFormula(FinancialFormula.Forecasting, "Linear,1,false,false", series1a, series1at);
            series1bt = chart1.Series.Add("Loss\\nTrend");
            series1bt.ChartType = SeriesChartType.Line;
            series1bt.Color = Color.Orange;
            series1bt.BorderDashStyle = ChartDashStyle.Dash;
            chart1.DataManipulator.FinancialFormula(FinancialFormula.Forecasting, "Linear,1,false,false", series1b, series1bt);

            // create dynamic charts
            this.chart3.Series.Clear();
            this.chart3.Titles.Clear();
            this.chart3.Titles.Add("Experience Allocation Over Time by Instance");
            for (int i = 0; i < numInstances; i++)
            {
                // for each instance add a new series
                this.chart3.Series.Add(i.ToString());
                this.chart3.Series[i.ToString()].ChartType = SeriesChartType.StackedArea;
                //this.chart3.Series[i.ToString()].IsValueShownAsLabel = true;
            }
        }

        private void updateChart(bool label)
        {


            if (formarray?[0].qAgent != null && (chkChartExperience.Checked || chkChartItems.Checked || chkChartReward.Checked))
            {
                double sumOfAgentAvgReward = 0, sumOfAgentAvgLoss = 0, sumOfAgentItemsProcessed = 0;
                var tc = formarray[0].qAgent.getTickCount();

                if (chkChartItems.Checked || chkChartReward.Checked)
                {
                    for (int i = 0; i < numInstances; i++)
                    {
                        sumOfAgentAvgReward = sumOfAgentAvgReward + formarray[i].qAgent.getAvgReward();
                        sumOfAgentAvgLoss = sumOfAgentAvgLoss + formarray[i].qAgent.getAvgLoss();
                        sumOfAgentItemsProcessed = sumOfAgentItemsProcessed + formarray[i].qAgent.getProcessedItemCount();
                    }
                }

                // average agent average rewards and loss
                if (chkChartReward.Checked)
                {
                    DataPoint dp1 = new DataPoint(tc, sumOfAgentAvgReward / numInstances);
                    dp1.IsValueShownAsLabel = label;
                    if (sumOfAgentAvgReward > -1) series1a.Points.Add(dp1);
                    DataPoint dp2 = new DataPoint(tc, sumOfAgentAvgLoss / numInstances);
                    dp2.IsValueShownAsLabel = label;
                    if (sumOfAgentAvgLoss > -1) series1b.Points.Add(dp2);
                    chart1.DataManipulator.FinancialFormula(FinancialFormula.Forecasting, "Linear,1,false,false", series1a, series1at);
                    chart1.DataManipulator.FinancialFormula(FinancialFormula.Forecasting, "Linear,1,false,false", series1b, series1bt);
                    chart1.Update();
                }
                // sum of agent items processed
                if (chkChartItems.Checked)
                {
                    DataPoint dp3 = new DataPoint(tc, sumOfAgentItemsProcessed);
                    dp3.IsValueShownAsLabel = label;
                    series2.Points.Add(dp3);
                    chart2.Update();
                }

                // percent of agents shared experience
                if (chkChartExperience.Checked)
                {
                    DataPoint dp4;
                    for (int i = 0; i < numInstances; i++)
                    {
                        dp4 = new DataPoint(tc, this.formarray[i].qAgent.getExperienceCount());
                        dp4.IsValueShownAsLabel = label;
                        this.chart3.Series[i.ToString()].Points.Add(dp4);
                    }
                    chart3.Update();
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // update chart w/o labels
            updateChart(false);

            // pause threads if duration reached
            if (txtDuration.Text != "" && formarray[0].qAgent.getTickCount() > Int32.Parse(txtDuration.Text))
            {
                // update chart w/ labels
                updateChart(true);

                // pause threads
                btnPauseContinue.PerformClick();
            }
        }
    }
}
