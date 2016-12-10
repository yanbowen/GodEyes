using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace GodEye
{
    partial class StaffMonitoringForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StaffMonitoringForm));
            this.networkGames = new System.Windows.Forms.CheckBox();
            this.entertainmentSite = new System.Windows.Forms.CheckBox();
            this.startCurrentMonitoring = new System.Windows.Forms.Button();
            this.stopCurrentMonitoring = new System.Windows.Forms.Button();
            this.monitoringResultsGroupBox = new System.Windows.Forms.GroupBox();
            this.monitoringResultslistView = new System.Windows.Forms.DataGridView();
            this.rowTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rowSourceIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rowDestinationIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rowProtocol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rowReason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startTimeLabel = new System.Windows.Forms.Label();
            this.startDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.stopTimeLabel = new System.Windows.Forms.Label();
            this.stopDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.recordGroupBox = new System.Windows.Forms.GroupBox();
            this.recordDownButton = new System.Windows.Forms.Button();
            this.recordUpButton = new System.Windows.Forms.Button();
            this.recordButton = new System.Windows.Forms.Button();
            this.designatedestinationIPLabel = new System.Windows.Forms.Label();
            this.destinationTextBox = new System.Windows.Forms.TextBox();
            this.designatesourceIPLabel = new System.Windows.Forms.Label();
            this.sourceTextBox = new System.Windows.Forms.TextBox();
            this.currentMonitoringGroupBox = new System.Windows.Forms.GroupBox();
            this.currentDownButton = new System.Windows.Forms.Button();
            this.currentUpButton = new System.Windows.Forms.Button();
            this.monitoringResultsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.monitoringResultslistView)).BeginInit();
            this.recordGroupBox.SuspendLayout();
            this.currentMonitoringGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // networkGames
            // 
            this.networkGames.AutoSize = true;
            this.networkGames.Font = new System.Drawing.Font("华文楷体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.networkGames.Location = new System.Drawing.Point(42, 277);
            this.networkGames.Name = "networkGames";
            this.networkGames.Size = new System.Drawing.Size(155, 27);
            this.networkGames.TabIndex = 1;
            this.networkGames.Text = "网络游戏监测";
            this.networkGames.UseVisualStyleBackColor = true;
            this.networkGames.CheckedChanged += new System.EventHandler(this.networkGames_CheckedChanged);
            // 
            // entertainmentSite
            // 
            this.entertainmentSite.AutoSize = true;
            this.entertainmentSite.Font = new System.Drawing.Font("华文楷体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.entertainmentSite.Location = new System.Drawing.Point(42, 314);
            this.entertainmentSite.Name = "entertainmentSite";
            this.entertainmentSite.Size = new System.Drawing.Size(155, 27);
            this.entertainmentSite.TabIndex = 2;
            this.entertainmentSite.Text = "娱乐网站监测";
            this.entertainmentSite.UseVisualStyleBackColor = true;
            this.entertainmentSite.CheckedChanged += new System.EventHandler(this.entertainmentSite_CheckedChanged);
            // 
            // startCurrentMonitoring
            // 
            this.startCurrentMonitoring.Font = new System.Drawing.Font("华文楷体", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.startCurrentMonitoring.Location = new System.Drawing.Point(42, 33);
            this.startCurrentMonitoring.Name = "startCurrentMonitoring";
            this.startCurrentMonitoring.Size = new System.Drawing.Size(200, 32);
            this.startCurrentMonitoring.TabIndex = 4;
            this.startCurrentMonitoring.Text = "开始监测";
            this.startCurrentMonitoring.UseVisualStyleBackColor = true;
            this.startCurrentMonitoring.Click += new System.EventHandler(this.startMonitoring_Click);
            // 
            // stopCurrentMonitoring
            // 
            this.stopCurrentMonitoring.Font = new System.Drawing.Font("华文楷体", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.stopCurrentMonitoring.Location = new System.Drawing.Point(41, 141);
            this.stopCurrentMonitoring.Name = "stopCurrentMonitoring";
            this.stopCurrentMonitoring.Size = new System.Drawing.Size(200, 32);
            this.stopCurrentMonitoring.TabIndex = 5;
            this.stopCurrentMonitoring.Text = "结束监测";
            this.stopCurrentMonitoring.UseVisualStyleBackColor = true;
            this.stopCurrentMonitoring.Click += new System.EventHandler(this.stopMonitoring_Click);
            // 
            // monitoringResultsGroupBox
            // 
            this.monitoringResultsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.monitoringResultsGroupBox.Controls.Add(this.monitoringResultslistView);
            this.monitoringResultsGroupBox.Font = new System.Drawing.Font("华文楷体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.monitoringResultsGroupBox.Location = new System.Drawing.Point(319, 32);
            this.monitoringResultsGroupBox.Name = "monitoringResultsGroupBox";
            this.monitoringResultsGroupBox.Size = new System.Drawing.Size(853, 646);
            this.monitoringResultsGroupBox.TabIndex = 6;
            this.monitoringResultsGroupBox.TabStop = false;
            this.monitoringResultsGroupBox.Text = "检测结果";
            // 
            // monitoringResultslistView
            // 
            this.monitoringResultslistView.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("华文楷体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.monitoringResultslistView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.monitoringResultslistView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.monitoringResultslistView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rowTime,
            this.rowSourceIP,
            this.rowDestinationIP,
            this.rowProtocol,
            this.rowReason});
            this.monitoringResultslistView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.monitoringResultslistView.Location = new System.Drawing.Point(3, 31);
            this.monitoringResultslistView.Name = "monitoringResultslistView";
            this.monitoringResultslistView.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("华文楷体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.monitoringResultslistView.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.monitoringResultslistView.RowHeadersVisible = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.monitoringResultslistView.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.monitoringResultslistView.RowTemplate.Height = 23;
            this.monitoringResultslistView.ShowEditingIcon = false;
            this.monitoringResultslistView.Size = new System.Drawing.Size(847, 612);
            this.monitoringResultslistView.TabIndex = 0;
            this.monitoringResultslistView.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.monitoringResultslistView_CellMouseDown);
            this.monitoringResultslistView.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.monitoringResultslistView_ColumnWidthChanged);
            // 
            // rowTime
            // 
            this.rowTime.HeaderText = "时间";
            this.rowTime.Name = "rowTime";
            this.rowTime.ReadOnly = true;
            // 
            // rowSourceIP
            // 
            this.rowSourceIP.HeaderText = "源端IP";
            this.rowSourceIP.Name = "rowSourceIP";
            this.rowSourceIP.ReadOnly = true;
            // 
            // rowDestinationIP
            // 
            this.rowDestinationIP.HeaderText = "目标端IP";
            this.rowDestinationIP.Name = "rowDestinationIP";
            this.rowDestinationIP.ReadOnly = true;
            // 
            // rowProtocol
            // 
            this.rowProtocol.HeaderText = "协议";
            this.rowProtocol.Name = "rowProtocol";
            this.rowProtocol.ReadOnly = true;
            // 
            // rowReason
            // 
            this.rowReason.HeaderText = "原因";
            this.rowReason.Name = "rowReason";
            this.rowReason.ReadOnly = true;
            // 
            // startTimeLabel
            // 
            this.startTimeLabel.AutoSize = true;
            this.startTimeLabel.Font = new System.Drawing.Font("华文楷体", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.startTimeLabel.Location = new System.Drawing.Point(38, 30);
            this.startTimeLabel.Name = "startTimeLabel";
            this.startTimeLabel.Size = new System.Drawing.Size(77, 19);
            this.startTimeLabel.TabIndex = 7;
            this.startTimeLabel.Text = "开始日期";
            // 
            // startDateTimePicker
            // 
            this.startDateTimePicker.Font = new System.Drawing.Font("华文楷体", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.startDateTimePicker.Location = new System.Drawing.Point(41, 52);
            this.startDateTimePicker.Name = "startDateTimePicker";
            this.startDateTimePicker.Size = new System.Drawing.Size(200, 24);
            this.startDateTimePicker.TabIndex = 8;
            this.startDateTimePicker.ValueChanged += new System.EventHandler(this.startDateTimePicker_ValueChanged);
            // 
            // stopTimeLabel
            // 
            this.stopTimeLabel.AutoSize = true;
            this.stopTimeLabel.Font = new System.Drawing.Font("华文楷体", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.stopTimeLabel.Location = new System.Drawing.Point(38, 85);
            this.stopTimeLabel.Name = "stopTimeLabel";
            this.stopTimeLabel.Size = new System.Drawing.Size(77, 19);
            this.stopTimeLabel.TabIndex = 9;
            this.stopTimeLabel.Text = "结束日期";
            // 
            // stopDateTimePicker
            // 
            this.stopDateTimePicker.Font = new System.Drawing.Font("华文楷体", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.stopDateTimePicker.Location = new System.Drawing.Point(41, 107);
            this.stopDateTimePicker.Name = "stopDateTimePicker";
            this.stopDateTimePicker.Size = new System.Drawing.Size(200, 24);
            this.stopDateTimePicker.TabIndex = 10;
            // 
            // recordGroupBox
            // 
            this.recordGroupBox.Controls.Add(this.recordDownButton);
            this.recordGroupBox.Controls.Add(this.recordUpButton);
            this.recordGroupBox.Controls.Add(this.recordButton);
            this.recordGroupBox.Controls.Add(this.designatedestinationIPLabel);
            this.recordGroupBox.Controls.Add(this.destinationTextBox);
            this.recordGroupBox.Controls.Add(this.designatesourceIPLabel);
            this.recordGroupBox.Controls.Add(this.sourceTextBox);
            this.recordGroupBox.Controls.Add(this.stopDateTimePicker);
            this.recordGroupBox.Controls.Add(this.startTimeLabel);
            this.recordGroupBox.Controls.Add(this.stopTimeLabel);
            this.recordGroupBox.Controls.Add(this.entertainmentSite);
            this.recordGroupBox.Controls.Add(this.startDateTimePicker);
            this.recordGroupBox.Controls.Add(this.networkGames);
            this.recordGroupBox.Font = new System.Drawing.Font("华文楷体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.recordGroupBox.Location = new System.Drawing.Point(12, 32);
            this.recordGroupBox.Name = "recordGroupBox";
            this.recordGroupBox.Size = new System.Drawing.Size(300, 461);
            this.recordGroupBox.TabIndex = 11;
            this.recordGroupBox.TabStop = false;
            this.recordGroupBox.Text = "记录查询";
            // 
            // recordDownButton
            // 
            this.recordDownButton.Font = new System.Drawing.Font("华文楷体", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.recordDownButton.Location = new System.Drawing.Point(152, 402);
            this.recordDownButton.Name = "recordDownButton";
            this.recordDownButton.Size = new System.Drawing.Size(90, 32);
            this.recordDownButton.TabIndex = 17;
            this.recordDownButton.Text = "下页";
            this.recordDownButton.UseVisualStyleBackColor = true;
            // 
            // recordUpButton
            // 
            this.recordUpButton.Font = new System.Drawing.Font("华文楷体", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.recordUpButton.Location = new System.Drawing.Point(42, 402);
            this.recordUpButton.Name = "recordUpButton";
            this.recordUpButton.Size = new System.Drawing.Size(90, 32);
            this.recordUpButton.TabIndex = 16;
            this.recordUpButton.Text = "上页";
            this.recordUpButton.UseVisualStyleBackColor = true;
            // 
            // recordButton
            // 
            this.recordButton.Font = new System.Drawing.Font("华文楷体", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.recordButton.Location = new System.Drawing.Point(42, 364);
            this.recordButton.Name = "recordButton";
            this.recordButton.Size = new System.Drawing.Size(200, 32);
            this.recordButton.TabIndex = 15;
            this.recordButton.Text = "查询记录";
            this.recordButton.UseVisualStyleBackColor = true;
            this.recordButton.Click += new System.EventHandler(this.recordButton_Click);
            // 
            // designatedestinationIPLabel
            // 
            this.designatedestinationIPLabel.AutoSize = true;
            this.designatedestinationIPLabel.Font = new System.Drawing.Font("华文楷体", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.designatedestinationIPLabel.Location = new System.Drawing.Point(38, 202);
            this.designatedestinationIPLabel.Name = "designatedestinationIPLabel";
            this.designatedestinationIPLabel.Size = new System.Drawing.Size(93, 19);
            this.designatedestinationIPLabel.TabIndex = 14;
            this.designatedestinationIPLabel.Text = "指定目标IP";
            // 
            // destinationTextBox
            // 
            this.destinationTextBox.Location = new System.Drawing.Point(41, 224);
            this.destinationTextBox.Multiline = true;
            this.destinationTextBox.Name = "destinationTextBox";
            this.destinationTextBox.Size = new System.Drawing.Size(200, 24);
            this.destinationTextBox.TabIndex = 13;
            // 
            // designatesourceIPLabel
            // 
            this.designatesourceIPLabel.AutoSize = true;
            this.designatesourceIPLabel.Font = new System.Drawing.Font("华文楷体", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.designatesourceIPLabel.Location = new System.Drawing.Point(37, 142);
            this.designatesourceIPLabel.Name = "designatesourceIPLabel";
            this.designatesourceIPLabel.Size = new System.Drawing.Size(93, 19);
            this.designatesourceIPLabel.TabIndex = 12;
            this.designatesourceIPLabel.Text = "指定源端IP";
            // 
            // sourceTextBox
            // 
            this.sourceTextBox.Location = new System.Drawing.Point(41, 164);
            this.sourceTextBox.Multiline = true;
            this.sourceTextBox.Name = "sourceTextBox";
            this.sourceTextBox.Size = new System.Drawing.Size(200, 24);
            this.sourceTextBox.TabIndex = 11;
            // 
            // currentMonitoringGroupBox
            // 
            this.currentMonitoringGroupBox.Controls.Add(this.currentDownButton);
            this.currentMonitoringGroupBox.Controls.Add(this.currentUpButton);
            this.currentMonitoringGroupBox.Controls.Add(this.startCurrentMonitoring);
            this.currentMonitoringGroupBox.Controls.Add(this.stopCurrentMonitoring);
            this.currentMonitoringGroupBox.Font = new System.Drawing.Font("华文楷体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.currentMonitoringGroupBox.Location = new System.Drawing.Point(12, 499);
            this.currentMonitoringGroupBox.Name = "currentMonitoringGroupBox";
            this.currentMonitoringGroupBox.Size = new System.Drawing.Size(300, 179);
            this.currentMonitoringGroupBox.TabIndex = 1;
            this.currentMonitoringGroupBox.TabStop = false;
            this.currentMonitoringGroupBox.Text = "实时监测";
            // 
            // currentDownButton
            // 
            this.currentDownButton.Font = new System.Drawing.Font("华文楷体", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.currentDownButton.Location = new System.Drawing.Point(151, 87);
            this.currentDownButton.Name = "currentDownButton";
            this.currentDownButton.Size = new System.Drawing.Size(90, 32);
            this.currentDownButton.TabIndex = 19;
            this.currentDownButton.Text = "下页";
            this.currentDownButton.UseVisualStyleBackColor = true;
            // 
            // currentUpButton
            // 
            this.currentUpButton.Font = new System.Drawing.Font("华文楷体", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.currentUpButton.Location = new System.Drawing.Point(41, 87);
            this.currentUpButton.Name = "currentUpButton";
            this.currentUpButton.Size = new System.Drawing.Size(90, 32);
            this.currentUpButton.TabIndex = 18;
            this.currentUpButton.Text = "上页";
            this.currentUpButton.UseVisualStyleBackColor = true;
            // 
            // StaffMonitoringForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 711);
            this.Controls.Add(this.currentMonitoringGroupBox);
            this.Controls.Add(this.recordGroupBox);
            this.Controls.Add(this.monitoringResultsGroupBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StaffMonitoringForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GodEye-员工监测";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StaffMonitoringForm_FormClosing);
            this.Load += new System.EventHandler(this.StaffMonitoringForm_Load);
            this.Resize += new System.EventHandler(this.StaffMonitoringForm_Resize);
            this.monitoringResultsGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.monitoringResultslistView)).EndInit();
            this.recordGroupBox.ResumeLayout(false);
            this.recordGroupBox.PerformLayout();
            this.currentMonitoringGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        //网络游戏监测
        private System.Windows.Forms.CheckBox networkGames;
        //娱乐网站监测
        private System.Windows.Forms.CheckBox entertainmentSite;
        //开始监测
        private System.Windows.Forms.Button startCurrentMonitoring;
        //停止监测
        private System.Windows.Forms.Button stopCurrentMonitoring;
        //监测结果GroupBox
        private System.Windows.Forms.GroupBox monitoringResultsGroupBox;
        //开始时间label
        private Label startTimeLabel;
        //开始时间timePicker
        private DateTimePicker startDateTimePicker;
        //DateTimeString
        public string startDateTime;
        //结束时间label
        private Label stopTimeLabel;
        //结束时间timePicker
        private DateTimePicker stopDateTimePicker;
        private DataGridView monitoringResultslistView;
        private GroupBox recordGroupBox;
        private TextBox sourceTextBox;
        private Label designatesourceIPLabel;
        private Label designatedestinationIPLabel;
        private TextBox destinationTextBox;
        private Button recordUpButton;
        private Button recordButton;
        private Button recordDownButton;
        private GroupBox currentMonitoringGroupBox;
        private Button currentDownButton;
        private Button currentUpButton;

        //查询记录string
        private string recordButtonString = "recordButton";
        private string startCurrentMonitoringString = "startCurrentMonitoring";
        private string stopCurrentMonitoringString = "stopCurrentMonitoring";
        private DataGridViewTextBoxColumn rowTime;
        private DataGridViewTextBoxColumn rowSourceIP;
        private DataGridViewTextBoxColumn rowDestinationIP;
        private DataGridViewTextBoxColumn rowProtocol;
        private DataGridViewTextBoxColumn rowReason;
    }
}

