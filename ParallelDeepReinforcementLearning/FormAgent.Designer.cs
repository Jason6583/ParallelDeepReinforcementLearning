namespace DeepQLearning
{
    partial class FormAgent
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.startLearning = new System.Windows.Forms.Button();
            this.displayBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtLearnBurn = new System.Windows.Forms.TextBox();
            this.txtLearnTotal = new System.Windows.Forms.TextBox();
            this.chkCharts = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtLearningL2Decay = new System.Windows.Forms.TextBox();
            this.txtLearningL1Decay = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtLearningMomentum = new System.Windows.Forms.TextBox();
            this.txtLearningRate = new System.Windows.Forms.TextBox();
            this.cboLearningMethod = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLearningBatch = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPunish = new System.Windows.Forms.TextBox();
            this.txtReward = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNumberItems = new System.Windows.Forms.TextBox();
            this.chkObstructItems = new System.Windows.Forms.CheckBox();
            this.chkRandomItems = new System.Windows.Forms.CheckBox();
            this.chkSharedExperience = new System.Windows.Forms.CheckBox();
            this.loadNet = new System.Windows.Forms.Button();
            this.saveNet = new System.Windows.Forms.Button();
            this.PauseBtn = new System.Windows.Forms.Button();
            this.goSlow = new System.Windows.Forms.Button();
            this.goNormal = new System.Windows.Forms.Button();
            this.goFast = new System.Windows.Forms.Button();
            this.goVeryFast = new System.Windows.Forms.Button();
            this.StopLearning = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.canvas = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.SuspendLayout();
            // 
            // startLearning
            // 
            this.startLearning.Location = new System.Drawing.Point(9, 21);
            this.startLearning.Name = "startLearning";
            this.startLearning.Size = new System.Drawing.Size(57, 27);
            this.startLearning.TabIndex = 0;
            this.startLearning.Text = "Start";
            this.startLearning.UseVisualStyleBackColor = true;
            this.startLearning.Click += new System.EventHandler(this.startLearning_Click);
            // 
            // displayBox
            // 
            this.displayBox.Location = new System.Drawing.Point(7, 464);
            this.displayBox.Multiline = true;
            this.displayBox.Name = "displayBox";
            this.displayBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.displayBox.Size = new System.Drawing.Size(569, 175);
            this.displayBox.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtLearnBurn);
            this.groupBox1.Controls.Add(this.txtLearnTotal);
            this.groupBox1.Controls.Add(this.chkCharts);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtLearningL2Decay);
            this.groupBox1.Controls.Add(this.txtLearningL1Decay);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtLearningMomentum);
            this.groupBox1.Controls.Add(this.txtLearningRate);
            this.groupBox1.Controls.Add(this.cboLearningMethod);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtLearningBatch);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtPunish);
            this.groupBox1.Controls.Add(this.txtReward);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtNumberItems);
            this.groupBox1.Controls.Add(this.chkObstructItems);
            this.groupBox1.Controls.Add(this.chkRandomItems);
            this.groupBox1.Controls.Add(this.chkSharedExperience);
            this.groupBox1.Controls.Add(this.loadNet);
            this.groupBox1.Controls.Add(this.saveNet);
            this.groupBox1.Controls.Add(this.PauseBtn);
            this.groupBox1.Controls.Add(this.goSlow);
            this.groupBox1.Controls.Add(this.goNormal);
            this.groupBox1.Controls.Add(this.goFast);
            this.groupBox1.Controls.Add(this.goVeryFast);
            this.groupBox1.Controls.Add(this.StopLearning);
            this.groupBox1.Controls.Add(this.startLearning);
            this.groupBox1.Location = new System.Drawing.Point(12, 667);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1541, 67);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Controls";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(962, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 17);
            this.label9.TabIndex = 31;
            this.label9.Text = "Total";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(964, 43);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 17);
            this.label10.TabIndex = 30;
            this.label10.Text = "Burn";
            // 
            // txtLearnBurn
            // 
            this.txtLearnBurn.Location = new System.Drawing.Point(1021, 41);
            this.txtLearnBurn.Name = "txtLearnBurn";
            this.txtLearnBurn.Size = new System.Drawing.Size(41, 22);
            this.txtLearnBurn.TabIndex = 29;
            // 
            // txtLearnTotal
            // 
            this.txtLearnTotal.Location = new System.Drawing.Point(1021, 13);
            this.txtLearnTotal.Name = "txtLearnTotal";
            this.txtLearnTotal.Size = new System.Drawing.Size(81, 22);
            this.txtLearnTotal.TabIndex = 28;
            // 
            // chkCharts
            // 
            this.chkCharts.AutoSize = true;
            this.chkCharts.Checked = true;
            this.chkCharts.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCharts.Location = new System.Drawing.Point(1330, 17);
            this.chkCharts.Name = "chkCharts";
            this.chkCharts.Size = new System.Drawing.Size(71, 21);
            this.chkCharts.TabIndex = 27;
            this.chkCharts.Text = "Charts";
            this.chkCharts.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1202, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 17);
            this.label7.TabIndex = 26;
            this.label7.Text = "L1 decay";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1200, 44);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 17);
            this.label8.TabIndex = 25;
            this.label8.Text = "L2 decay";
            // 
            // txtLearningL2Decay
            // 
            this.txtLearningL2Decay.Location = new System.Drawing.Point(1270, 42);
            this.txtLearningL2Decay.Name = "txtLearningL2Decay";
            this.txtLearningL2Decay.Size = new System.Drawing.Size(41, 22);
            this.txtLearningL2Decay.TabIndex = 24;
            // 
            // txtLearningL1Decay
            // 
            this.txtLearningL1Decay.Location = new System.Drawing.Point(1271, 14);
            this.txtLearningL1Decay.Name = "txtLearningL1Decay";
            this.txtLearningL1Decay.Size = new System.Drawing.Size(41, 22);
            this.txtLearningL1Decay.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1108, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 17);
            this.label5.TabIndex = 22;
            this.label5.Text = "Rate";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1069, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 17);
            this.label6.TabIndex = 21;
            this.label6.Text = "Momentum";
            // 
            // txtLearningMomentum
            // 
            this.txtLearningMomentum.Location = new System.Drawing.Point(1152, 43);
            this.txtLearningMomentum.Name = "txtLearningMomentum";
            this.txtLearningMomentum.Size = new System.Drawing.Size(41, 22);
            this.txtLearningMomentum.TabIndex = 20;
            // 
            // txtLearningRate
            // 
            this.txtLearningRate.Location = new System.Drawing.Point(1152, 15);
            this.txtLearningRate.Name = "txtLearningRate";
            this.txtLearningRate.Size = new System.Drawing.Size(41, 22);
            this.txtLearningRate.TabIndex = 19;
            // 
            // cboLearningMethod
            // 
            this.cboLearningMethod.FormattingEnabled = true;
            this.cboLearningMethod.Items.AddRange(new object[] {
            "adam",
            "adagrad",
            "windowgrad",
            "adadelta",
            "nesterov",
            "SGD"});
            this.cboLearningMethod.Location = new System.Drawing.Point(321, 21);
            this.cboLearningMethod.Name = "cboLearningMethod";
            this.cboLearningMethod.Size = new System.Drawing.Size(119, 24);
            this.cboLearningMethod.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(847, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 17);
            this.label4.TabIndex = 17;
            this.label4.Text = "Batch";
            // 
            // txtLearningBatch
            // 
            this.txtLearningBatch.Location = new System.Drawing.Point(894, 14);
            this.txtLearningBatch.Name = "txtLearningBatch";
            this.txtLearningBatch.Size = new System.Drawing.Size(62, 22);
            this.txtLearningBatch.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(738, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 15;
            this.label3.Text = "Reward";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(740, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 17);
            this.label2.TabIndex = 14;
            this.label2.Text = "Punish";
            // 
            // txtPunish
            // 
            this.txtPunish.Location = new System.Drawing.Point(797, 42);
            this.txtPunish.Name = "txtPunish";
            this.txtPunish.Size = new System.Drawing.Size(41, 22);
            this.txtPunish.TabIndex = 13;
            // 
            // txtReward
            // 
            this.txtReward.Location = new System.Drawing.Point(797, 14);
            this.txtReward.Name = "txtReward";
            this.txtReward.Size = new System.Drawing.Size(41, 22);
            this.txtReward.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(850, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Items";
            // 
            // txtNumberItems
            // 
            this.txtNumberItems.Location = new System.Drawing.Point(894, 42);
            this.txtNumberItems.Name = "txtNumberItems";
            this.txtNumberItems.Size = new System.Drawing.Size(62, 22);
            this.txtNumberItems.TabIndex = 11;
            // 
            // chkObstructItems
            // 
            this.chkObstructItems.AutoSize = true;
            this.chkObstructItems.Location = new System.Drawing.Point(1414, 15);
            this.chkObstructItems.Name = "chkObstructItems";
            this.chkObstructItems.Size = new System.Drawing.Size(121, 21);
            this.chkObstructItems.TabIndex = 10;
            this.chkObstructItems.Text = "Obstruct Items";
            this.chkObstructItems.UseVisualStyleBackColor = true;
            // 
            // chkRandomItems
            // 
            this.chkRandomItems.AutoSize = true;
            this.chkRandomItems.Location = new System.Drawing.Point(1414, 42);
            this.chkRandomItems.Name = "chkRandomItems";
            this.chkRandomItems.Size = new System.Drawing.Size(120, 21);
            this.chkRandomItems.TabIndex = 0;
            this.chkRandomItems.Text = "Random Items";
            this.chkRandomItems.UseVisualStyleBackColor = true;
            // 
            // chkSharedExperience
            // 
            this.chkSharedExperience.AutoSize = true;
            this.chkSharedExperience.Checked = true;
            this.chkSharedExperience.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSharedExperience.Location = new System.Drawing.Point(1330, 42);
            this.chkSharedExperience.Name = "chkSharedExperience";
            this.chkSharedExperience.Size = new System.Drawing.Size(76, 21);
            this.chkSharedExperience.TabIndex = 9;
            this.chkSharedExperience.Text = "Shared";
            this.chkSharedExperience.UseVisualStyleBackColor = true;
            // 
            // loadNet
            // 
            this.loadNet.Location = new System.Drawing.Point(254, 21);
            this.loadNet.Name = "loadNet";
            this.loadNet.Size = new System.Drawing.Size(57, 27);
            this.loadNet.TabIndex = 8;
            this.loadNet.Text = "Load";
            this.loadNet.UseVisualStyleBackColor = true;
            this.loadNet.Click += new System.EventHandler(this.loadNet_Click);
            // 
            // saveNet
            // 
            this.saveNet.Location = new System.Drawing.Point(197, 21);
            this.saveNet.Name = "saveNet";
            this.saveNet.Size = new System.Drawing.Size(57, 27);
            this.saveNet.TabIndex = 7;
            this.saveNet.Text = "Save";
            this.saveNet.UseVisualStyleBackColor = true;
            this.saveNet.Click += new System.EventHandler(this.saveNet_Click);
            // 
            // PauseBtn
            // 
            this.PauseBtn.Location = new System.Drawing.Point(65, 21);
            this.PauseBtn.Name = "PauseBtn";
            this.PauseBtn.Size = new System.Drawing.Size(77, 27);
            this.PauseBtn.TabIndex = 6;
            this.PauseBtn.Text = "Pause";
            this.PauseBtn.UseVisualStyleBackColor = true;
            this.PauseBtn.Click += new System.EventHandler(this.PauseBtn_Click);
            // 
            // goSlow
            // 
            this.goSlow.Location = new System.Drawing.Point(643, 19);
            this.goSlow.Name = "goSlow";
            this.goSlow.Size = new System.Drawing.Size(64, 27);
            this.goSlow.TabIndex = 5;
            this.goSlow.Text = "Slow";
            this.goSlow.UseVisualStyleBackColor = true;
            this.goSlow.Click += new System.EventHandler(this.goSlow_Click);
            // 
            // goNormal
            // 
            this.goNormal.Location = new System.Drawing.Point(579, 19);
            this.goNormal.Name = "goNormal";
            this.goNormal.Size = new System.Drawing.Size(64, 27);
            this.goNormal.TabIndex = 4;
            this.goNormal.Text = "Normal";
            this.goNormal.UseVisualStyleBackColor = true;
            this.goNormal.Click += new System.EventHandler(this.goNormal_Click);
            // 
            // goFast
            // 
            this.goFast.Location = new System.Drawing.Point(516, 19);
            this.goFast.Name = "goFast";
            this.goFast.Size = new System.Drawing.Size(64, 27);
            this.goFast.TabIndex = 3;
            this.goFast.Text = "Fast";
            this.goFast.UseVisualStyleBackColor = true;
            this.goFast.Click += new System.EventHandler(this.goFast_Click);
            // 
            // goVeryFast
            // 
            this.goVeryFast.Location = new System.Drawing.Point(446, 19);
            this.goVeryFast.Name = "goVeryFast";
            this.goVeryFast.Size = new System.Drawing.Size(72, 27);
            this.goVeryFast.TabIndex = 2;
            this.goVeryFast.Text = "Fastest";
            this.goVeryFast.UseVisualStyleBackColor = true;
            this.goVeryFast.Click += new System.EventHandler(this.goVeryFast_Click);
            // 
            // StopLearning
            // 
            this.StopLearning.Location = new System.Drawing.Point(141, 21);
            this.StopLearning.Name = "StopLearning";
            this.StopLearning.Size = new System.Drawing.Size(57, 27);
            this.StopLearning.TabIndex = 1;
            this.StopLearning.Text = "Stop";
            this.StopLearning.UseVisualStyleBackColor = true;
            this.StopLearning.Click += new System.EventHandler(this.StopLearning_Click);
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(8, 21);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(569, 213);
            this.chart1.TabIndex = 4;
            this.chart1.Text = "chart1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.canvas);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(958, 649);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Visualization";
            // 
            // canvas
            // 
            this.canvas.BackColor = System.Drawing.SystemColors.Info;
            this.canvas.Location = new System.Drawing.Point(6, 21);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(946, 618);
            this.canvas.TabIndex = 0;
            this.canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.canvas_Paint);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chart2);
            this.groupBox3.Controls.Add(this.chart1);
            this.groupBox3.Controls.Add(this.displayBox);
            this.groupBox3.Location = new System.Drawing.Point(976, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(589, 649);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Output";
            // 
            // chart2
            // 
            chartArea2.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart2.Legends.Add(legend2);
            this.chart2.Location = new System.Drawing.Point(7, 240);
            this.chart2.Name = "chart2";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart2.Series.Add(series2);
            this.chart2.Size = new System.Drawing.Size(569, 218);
            this.chart2.TabIndex = 5;
            this.chart2.Text = "chart2";
            // 
            // FormAgent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1565, 758);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormAgent";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Deep Q Learning Agent";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormAgent_FormClosed);
            this.Load += new System.EventHandler(this.FormAgent_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox displayBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        internal System.Windows.Forms.Button startLearning;
        internal System.Windows.Forms.Button StopLearning;
        internal System.Windows.Forms.Button PauseBtn;
        internal System.Windows.Forms.Button goSlow;
        internal System.Windows.Forms.Button goNormal;
        internal System.Windows.Forms.Button goFast;
        internal System.Windows.Forms.Button goVeryFast;
        internal System.Windows.Forms.Button loadNet;
        internal System.Windows.Forms.Button saveNet;
        internal System.Windows.Forms.CheckBox chkSharedExperience;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        internal System.Windows.Forms.CheckBox chkRandomItems;
        internal System.Windows.Forms.Panel canvas;
        internal System.Windows.Forms.CheckBox chkObstructItems;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txtNumberItems;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox txtPunish;
        internal System.Windows.Forms.TextBox txtReward;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.TextBox txtLearningBatch;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.TextBox txtLearningMomentum;
        internal System.Windows.Forms.TextBox txtLearningRate;
        internal System.Windows.Forms.ComboBox cboLearningMethod;
        internal System.Windows.Forms.CheckBox chkCharts;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        internal System.Windows.Forms.TextBox txtLearningL2Decay;
        internal System.Windows.Forms.TextBox txtLearningL1Decay;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        internal System.Windows.Forms.TextBox txtLearnBurn;
        internal System.Windows.Forms.TextBox txtLearnTotal;
    }
}

