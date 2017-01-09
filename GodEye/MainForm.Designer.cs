using SharpPcap;
using System.Drawing;

namespace GodEye
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.dataMonitoringGroupBox = new System.Windows.Forms.GroupBox();
            this.chartflow = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.functionPanel = new System.Windows.Forms.Panel();
            this.emailMonitoringPanel = new System.Windows.Forms.Panel();
            this.emailMonitoringOpenLabel = new System.Windows.Forms.Label();
            this.emailNoticeLabel = new System.Windows.Forms.Label();
            this.qqLoginPanel = new System.Windows.Forms.Panel();
            this.qqLoginOpenLabel = new System.Windows.Forms.Label();
            this.qqNoticeLabel = new System.Windows.Forms.Label();
            this.staffMonitoringPanel = new System.Windows.Forms.Panel();
            this.staffMonitoringOpenLabel = new System.Windows.Forms.Label();
            this.staffNoticeLabel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.stopMonitoring = new System.Windows.Forms.Button();
            this.startMonitoring = new System.Windows.Forms.Button();
            this.deviceComboList = new System.Windows.Forms.ComboBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.dataMonitoringGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartflow)).BeginInit();
            this.functionPanel.SuspendLayout();
            this.emailMonitoringPanel.SuspendLayout();
            this.qqLoginPanel.SuspendLayout();
            this.staffMonitoringPanel.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataMonitoringGroupBox
            // 
            this.dataMonitoringGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataMonitoringGroupBox.Controls.Add(this.chartflow);
            this.dataMonitoringGroupBox.Font = new System.Drawing.Font("华文楷体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dataMonitoringGroupBox.Location = new System.Drawing.Point(407, 31);
            this.dataMonitoringGroupBox.Name = "dataMonitoringGroupBox";
            this.dataMonitoringGroupBox.Size = new System.Drawing.Size(935, 688);
            this.dataMonitoringGroupBox.TabIndex = 0;
            this.dataMonitoringGroupBox.TabStop = false;
            this.dataMonitoringGroupBox.Text = "流量监测";
            // 
            // chartflow
            // 
            this.chartflow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chartflow.ChartAreas.Add(chartArea1);
            legend1.Alignment = System.Drawing.StringAlignment.Far;
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend1.Name = "Legend1";
            legend2.Alignment = System.Drawing.StringAlignment.Far;
            legend2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend2.Name = "Legend2";
            this.chartflow.Legends.Add(legend1);
            this.chartflow.Legends.Add(legend2);
            this.chartflow.Location = new System.Drawing.Point(6, 33);
            this.chartflow.Name = "chartflow";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.IsXValueIndexed = true;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.IsXValueIndexed = true;
            series2.Legend = "Legend2";
            series2.Name = "Series2";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
            this.chartflow.Series.Add(series1);
            this.chartflow.Series.Add(series2);
            this.chartflow.Size = new System.Drawing.Size(923, 649);
            this.chartflow.TabIndex = 0;
            this.chartflow.Text = "chartflow";
            // 
            // functionPanel
            // 
            this.functionPanel.Controls.Add(this.emailMonitoringPanel);
            this.functionPanel.Controls.Add(this.qqLoginPanel);
            this.functionPanel.Controls.Add(this.staffMonitoringPanel);
            this.functionPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.functionPanel.Location = new System.Drawing.Point(3, 30);
            this.functionPanel.Name = "functionPanel";
            this.functionPanel.Size = new System.Drawing.Size(370, 323);
            this.functionPanel.TabIndex = 4;
            // 
            // emailMonitoringPanel
            // 
            this.emailMonitoringPanel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.emailMonitoringPanel.Controls.Add(this.emailMonitoringOpenLabel);
            this.emailMonitoringPanel.Controls.Add(this.emailNoticeLabel);
            this.emailMonitoringPanel.Location = new System.Drawing.Point(3, 215);
            this.emailMonitoringPanel.Name = "emailMonitoringPanel";
            this.emailMonitoringPanel.Size = new System.Drawing.Size(364, 100);
            this.emailMonitoringPanel.TabIndex = 8;
            this.emailMonitoringPanel.Click += new System.EventHandler(this.emailMonitoringPanel_Click);
            // 
            // emailMonitoringOpenLabel
            // 
            this.emailMonitoringOpenLabel.AutoSize = true;
            this.emailMonitoringOpenLabel.Font = new System.Drawing.Font("华文楷体", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.emailMonitoringOpenLabel.Location = new System.Drawing.Point(3, 11);
            this.emailMonitoringOpenLabel.Name = "emailMonitoringOpenLabel";
            this.emailMonitoringOpenLabel.Size = new System.Drawing.Size(121, 30);
            this.emailMonitoringOpenLabel.TabIndex = 2;
            this.emailMonitoringOpenLabel.Text = "邮件监测";
            this.emailMonitoringOpenLabel.Click += new System.EventHandler(this.emailMonitoringOpenLabel_Click);
            // 
            // emailNoticeLabel
            // 
            this.emailNoticeLabel.AutoSize = true;
            this.emailNoticeLabel.Font = new System.Drawing.Font("华文楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.emailNoticeLabel.Location = new System.Drawing.Point(37, 48);
            this.emailNoticeLabel.Name = "emailNoticeLabel";
            this.emailNoticeLabel.Size = new System.Drawing.Size(128, 18);
            this.emailNoticeLabel.TabIndex = 5;
            this.emailNoticeLabel.Text = "今日新增记录0条";
            // 
            // qqLoginPanel
            // 
            this.qqLoginPanel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.qqLoginPanel.Controls.Add(this.qqLoginOpenLabel);
            this.qqLoginPanel.Controls.Add(this.qqNoticeLabel);
            this.qqLoginPanel.Location = new System.Drawing.Point(3, 109);
            this.qqLoginPanel.Name = "qqLoginPanel";
            this.qqLoginPanel.Size = new System.Drawing.Size(364, 100);
            this.qqLoginPanel.TabIndex = 7;
            this.qqLoginPanel.Click += new System.EventHandler(this.qqLoginPanel_Click);
            this.qqLoginPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.qqLoginPanel_Paint);
            // 
            // qqLoginOpenLabel
            // 
            this.qqLoginOpenLabel.AutoSize = true;
            this.qqLoginOpenLabel.Font = new System.Drawing.Font("华文楷体", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.qqLoginOpenLabel.Location = new System.Drawing.Point(3, 10);
            this.qqLoginOpenLabel.Name = "qqLoginOpenLabel";
            this.qqLoginOpenLabel.Size = new System.Drawing.Size(163, 30);
            this.qqLoginOpenLabel.TabIndex = 1;
            this.qqLoginOpenLabel.Text = "QQ登录监测";
            // 
            // qqNoticeLabel
            // 
            this.qqNoticeLabel.AutoSize = true;
            this.qqNoticeLabel.Font = new System.Drawing.Font("华文楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.qqNoticeLabel.Location = new System.Drawing.Point(37, 47);
            this.qqNoticeLabel.Name = "qqNoticeLabel";
            this.qqNoticeLabel.Size = new System.Drawing.Size(128, 18);
            this.qqNoticeLabel.TabIndex = 4;
            this.qqNoticeLabel.Text = "今日新增记录0条";
            // 
            // staffMonitoringPanel
            // 
            this.staffMonitoringPanel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.staffMonitoringPanel.Controls.Add(this.staffMonitoringOpenLabel);
            this.staffMonitoringPanel.Controls.Add(this.staffNoticeLabel);
            this.staffMonitoringPanel.Location = new System.Drawing.Point(3, 3);
            this.staffMonitoringPanel.Name = "staffMonitoringPanel";
            this.staffMonitoringPanel.Size = new System.Drawing.Size(364, 100);
            this.staffMonitoringPanel.TabIndex = 6;
            this.staffMonitoringPanel.Click += new System.EventHandler(this.staffMonitoringOpenLabel_Click);
            // 
            // staffMonitoringOpenLabel
            // 
            this.staffMonitoringOpenLabel.AutoSize = true;
            this.staffMonitoringOpenLabel.Font = new System.Drawing.Font("华文楷体", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.staffMonitoringOpenLabel.Location = new System.Drawing.Point(3, 13);
            this.staffMonitoringOpenLabel.Name = "staffMonitoringOpenLabel";
            this.staffMonitoringOpenLabel.Size = new System.Drawing.Size(175, 30);
            this.staffMonitoringOpenLabel.TabIndex = 0;
            this.staffMonitoringOpenLabel.Text = "员工行为监测";
            this.staffMonitoringOpenLabel.Click += new System.EventHandler(this.staffMonitoringOpenLabel_Click);
            // 
            // staffNoticeLabel
            // 
            this.staffNoticeLabel.AutoSize = true;
            this.staffNoticeLabel.Font = new System.Drawing.Font("华文楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.staffNoticeLabel.Location = new System.Drawing.Point(37, 43);
            this.staffNoticeLabel.Name = "staffNoticeLabel";
            this.staffNoticeLabel.Size = new System.Drawing.Size(128, 18);
            this.staffNoticeLabel.TabIndex = 3;
            this.staffNoticeLabel.Text = "今日新增记录0条";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.functionPanel);
            this.groupBox2.Font = new System.Drawing.Font("华文楷体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(12, 202);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(376, 356);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "功能列表";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.stopMonitoring);
            this.groupBox1.Controls.Add(this.startMonitoring);
            this.groupBox1.Controls.Add(this.deviceComboList);
            this.groupBox1.Font = new System.Drawing.Font("华文楷体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(12, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(376, 165);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设备选择";
            // 
            // stopMonitoring
            // 
            this.stopMonitoring.Location = new System.Drawing.Point(210, 113);
            this.stopMonitoring.Name = "stopMonitoring";
            this.stopMonitoring.Size = new System.Drawing.Size(160, 28);
            this.stopMonitoring.TabIndex = 14;
            this.stopMonitoring.Text = "停止监测";
            this.stopMonitoring.UseVisualStyleBackColor = true;
            this.stopMonitoring.Click += new System.EventHandler(this.stopMonitoring_Click);
            // 
            // startMonitoring
            // 
            this.startMonitoring.Location = new System.Drawing.Point(6, 113);
            this.startMonitoring.Name = "startMonitoring";
            this.startMonitoring.Size = new System.Drawing.Size(160, 28);
            this.startMonitoring.TabIndex = 13;
            this.startMonitoring.Text = "启动监测";
            this.startMonitoring.UseVisualStyleBackColor = true;
            this.startMonitoring.Click += new System.EventHandler(this.startMonitoring_Click);
            // 
            // deviceComboList
            // 
            this.deviceComboList.Font = new System.Drawing.Font("Perpetua", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deviceComboList.FormattingEnabled = true;
            this.deviceComboList.Location = new System.Drawing.Point(6, 33);
            this.deviceComboList.Name = "deviceComboList";
            this.deviceComboList.Size = new System.Drawing.Size(364, 28);
            this.deviceComboList.TabIndex = 12;
            this.deviceComboList.SelectedIndexChanged += new System.EventHandler(this.deviceCombo_SelectedIndexChanged);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button4);
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Font = new System.Drawing.Font("华文楷体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox3.Location = new System.Drawing.Point(12, 564);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(376, 155);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "软件版本";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(46, 100);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(280, 30);
            this.button4.TabIndex = 1;
            this.button4.Text = "关于我们";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(46, 46);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(280, 30);
            this.button3.TabIndex = 0;
            this.button3.Text = "版本更新";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1354, 731);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dataMonitoringGroupBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "GodEye";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.dataMonitoringGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartflow)).EndInit();
            this.functionPanel.ResumeLayout(false);
            this.emailMonitoringPanel.ResumeLayout(false);
            this.emailMonitoringPanel.PerformLayout();
            this.qqLoginPanel.ResumeLayout(false);
            this.qqLoginPanel.PerformLayout();
            this.staffMonitoringPanel.ResumeLayout(false);
            this.staffMonitoringPanel.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox dataMonitoringGroupBox;
        private System.Windows.Forms.Panel functionPanel;
        private System.Windows.Forms.Label emailMonitoringOpenLabel;
        private System.Windows.Forms.Label qqLoginOpenLabel;
        private System.Windows.Forms.Label staffMonitoringOpenLabel;
        private System.Windows.Forms.Label emailNoticeLabel;
        private System.Windows.Forms.Label qqNoticeLabel;
        private System.Windows.Forms.Label staffNoticeLabel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel emailMonitoringPanel;
        private System.Windows.Forms.Panel qqLoginPanel;
        private System.Windows.Forms.Panel staffMonitoringPanel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox deviceComboList;

        private System.Windows.Forms.Button stopMonitoring;
        private System.Windows.Forms.Button startMonitoring;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartflow;

    }
}