namespace GodEye
{
    partial class QQForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.currentUpButton = new System.Windows.Forms.Button();
            this.entertainmentSite = new System.Windows.Forms.CheckBox();
            this.currentMonitoringGroupBox = new System.Windows.Forms.GroupBox();
            this.currentDownButton = new System.Windows.Forms.Button();
            this.startCurrentMonitoring = new System.Windows.Forms.Button();
            this.stopCurrentMonitoring = new System.Windows.Forms.Button();
            this.recordDownButton = new System.Windows.Forms.Button();
            this.recordUpButton = new System.Windows.Forms.Button();
            this.recordButton = new System.Windows.Forms.Button();
            this.designatesourceIPLabel = new System.Windows.Forms.Label();
            this.sourceTextBox = new System.Windows.Forms.TextBox();
            this.recordGroupBox = new System.Windows.Forms.GroupBox();
            this.stopDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.startTimeLabel = new System.Windows.Forms.Label();
            this.stopTimeLabel = new System.Windows.Forms.Label();
            this.startDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.networkGames = new System.Windows.Forms.CheckBox();
            this.monitoringResultslistView = new System.Windows.Forms.DataGridView();
            this.rowTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rowIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rowQQnumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rowLogin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monitoringResultsGroupBox = new System.Windows.Forms.GroupBox();
            this.currentMonitoringGroupBox.SuspendLayout();
            this.recordGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.monitoringResultslistView)).BeginInit();
            this.monitoringResultsGroupBox.SuspendLayout();
            this.SuspendLayout();
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
            // entertainmentSite
            // 
            this.entertainmentSite.AutoSize = true;
            this.entertainmentSite.Font = new System.Drawing.Font("华文楷体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.entertainmentSite.Location = new System.Drawing.Point(42, 270);
            this.entertainmentSite.Name = "entertainmentSite";
            this.entertainmentSite.Size = new System.Drawing.Size(103, 27);
            this.entertainmentSite.TabIndex = 2;
            this.entertainmentSite.Text = "QQ下线";
            this.entertainmentSite.UseVisualStyleBackColor = true;
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
            this.currentMonitoringGroupBox.TabIndex = 12;
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
            // startCurrentMonitoring
            // 
            this.startCurrentMonitoring.Font = new System.Drawing.Font("华文楷体", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.startCurrentMonitoring.Location = new System.Drawing.Point(42, 33);
            this.startCurrentMonitoring.Name = "startCurrentMonitoring";
            this.startCurrentMonitoring.Size = new System.Drawing.Size(200, 32);
            this.startCurrentMonitoring.TabIndex = 4;
            this.startCurrentMonitoring.Text = "开始监测";
            this.startCurrentMonitoring.UseVisualStyleBackColor = true;
            this.startCurrentMonitoring.Click += new System.EventHandler(this.startCurrentMonitoring_Click);
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
            this.stopCurrentMonitoring.Click += new System.EventHandler(this.stopCurrentMonitoring_Click);
            // 
            // recordDownButton
            // 
            this.recordDownButton.Font = new System.Drawing.Font("华文楷体", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.recordDownButton.Location = new System.Drawing.Point(152, 366);
            this.recordDownButton.Name = "recordDownButton";
            this.recordDownButton.Size = new System.Drawing.Size(90, 32);
            this.recordDownButton.TabIndex = 17;
            this.recordDownButton.Text = "下页";
            this.recordDownButton.UseVisualStyleBackColor = true;
            // 
            // recordUpButton
            // 
            this.recordUpButton.Font = new System.Drawing.Font("华文楷体", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.recordUpButton.Location = new System.Drawing.Point(42, 366);
            this.recordUpButton.Name = "recordUpButton";
            this.recordUpButton.Size = new System.Drawing.Size(90, 32);
            this.recordUpButton.TabIndex = 16;
            this.recordUpButton.Text = "上页";
            this.recordUpButton.UseVisualStyleBackColor = true;
            // 
            // recordButton
            // 
            this.recordButton.Font = new System.Drawing.Font("华文楷体", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.recordButton.Location = new System.Drawing.Point(42, 328);
            this.recordButton.Name = "recordButton";
            this.recordButton.Size = new System.Drawing.Size(200, 32);
            this.recordButton.TabIndex = 15;
            this.recordButton.Text = "查询记录";
            this.recordButton.UseVisualStyleBackColor = true;
            this.recordButton.Click += new System.EventHandler(this.recordButton_Click);
            // 
            // designatesourceIPLabel
            // 
            this.designatesourceIPLabel.AutoSize = true;
            this.designatesourceIPLabel.Font = new System.Drawing.Font("华文楷体", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.designatesourceIPLabel.Location = new System.Drawing.Point(37, 160);
            this.designatesourceIPLabel.Name = "designatesourceIPLabel";
            this.designatesourceIPLabel.Size = new System.Drawing.Size(103, 19);
            this.designatesourceIPLabel.TabIndex = 12;
            this.designatesourceIPLabel.Text = "指定QQ号码";
            // 
            // sourceTextBox
            // 
            this.sourceTextBox.Location = new System.Drawing.Point(41, 182);
            this.sourceTextBox.Multiline = true;
            this.sourceTextBox.Name = "sourceTextBox";
            this.sourceTextBox.Size = new System.Drawing.Size(200, 24);
            this.sourceTextBox.TabIndex = 11;
            // 
            // recordGroupBox
            // 
            this.recordGroupBox.Controls.Add(this.recordDownButton);
            this.recordGroupBox.Controls.Add(this.recordUpButton);
            this.recordGroupBox.Controls.Add(this.recordButton);
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
            this.recordGroupBox.TabIndex = 14;
            this.recordGroupBox.TabStop = false;
            this.recordGroupBox.Text = "记录查询";
            // 
            // stopDateTimePicker
            // 
            this.stopDateTimePicker.Font = new System.Drawing.Font("华文楷体", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.stopDateTimePicker.Location = new System.Drawing.Point(41, 125);
            this.stopDateTimePicker.Name = "stopDateTimePicker";
            this.stopDateTimePicker.Size = new System.Drawing.Size(200, 24);
            this.stopDateTimePicker.TabIndex = 10;
            // 
            // startTimeLabel
            // 
            this.startTimeLabel.AutoSize = true;
            this.startTimeLabel.Font = new System.Drawing.Font("华文楷体", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.startTimeLabel.Location = new System.Drawing.Point(38, 48);
            this.startTimeLabel.Name = "startTimeLabel";
            this.startTimeLabel.Size = new System.Drawing.Size(77, 19);
            this.startTimeLabel.TabIndex = 7;
            this.startTimeLabel.Text = "开始日期";
            // 
            // stopTimeLabel
            // 
            this.stopTimeLabel.AutoSize = true;
            this.stopTimeLabel.Font = new System.Drawing.Font("华文楷体", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.stopTimeLabel.Location = new System.Drawing.Point(38, 103);
            this.stopTimeLabel.Name = "stopTimeLabel";
            this.stopTimeLabel.Size = new System.Drawing.Size(77, 19);
            this.stopTimeLabel.TabIndex = 9;
            this.stopTimeLabel.Text = "结束日期";
            // 
            // startDateTimePicker
            // 
            this.startDateTimePicker.Font = new System.Drawing.Font("华文楷体", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.startDateTimePicker.Location = new System.Drawing.Point(41, 70);
            this.startDateTimePicker.Name = "startDateTimePicker";
            this.startDateTimePicker.Size = new System.Drawing.Size(200, 24);
            this.startDateTimePicker.TabIndex = 8;
            // 
            // networkGames
            // 
            this.networkGames.AutoSize = true;
            this.networkGames.Font = new System.Drawing.Font("华文楷体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.networkGames.Location = new System.Drawing.Point(42, 233);
            this.networkGames.Name = "networkGames";
            this.networkGames.Size = new System.Drawing.Size(103, 27);
            this.networkGames.TabIndex = 1;
            this.networkGames.Text = "QQ上线";
            this.networkGames.UseVisualStyleBackColor = true;
            // 
            // monitoringResultslistView
            // 
            this.monitoringResultslistView.AllowUserToOrderColumns = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("华文楷体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.monitoringResultslistView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.monitoringResultslistView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.monitoringResultslistView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rowTime,
            this.rowIP,
            this.rowQQnumber,
            this.rowLogin});
            this.monitoringResultslistView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.monitoringResultslistView.Location = new System.Drawing.Point(3, 31);
            this.monitoringResultslistView.Name = "monitoringResultslistView";
            this.monitoringResultslistView.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("华文楷体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.monitoringResultslistView.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.monitoringResultslistView.RowHeadersVisible = false;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.monitoringResultslistView.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.monitoringResultslistView.RowTemplate.Height = 23;
            this.monitoringResultslistView.ShowEditingIcon = false;
            this.monitoringResultslistView.Size = new System.Drawing.Size(847, 612);
            this.monitoringResultslistView.TabIndex = 0;
            // 
            // rowTime
            // 
            this.rowTime.HeaderText = "时间";
            this.rowTime.Name = "rowTime";
            this.rowTime.ReadOnly = true;
            // 
            // rowIP
            // 
            this.rowIP.HeaderText = "IP地址";
            this.rowIP.Name = "rowIP";
            this.rowIP.ReadOnly = true;
            // 
            // rowQQnumber
            // 
            this.rowQQnumber.HeaderText = "QQ号码";
            this.rowQQnumber.Name = "rowQQnumber";
            this.rowQQnumber.ReadOnly = true;
            // 
            // rowLogin
            // 
            this.rowLogin.HeaderText = "上/下 线";
            this.rowLogin.Name = "rowLogin";
            this.rowLogin.ReadOnly = true;
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
            this.monitoringResultsGroupBox.TabIndex = 13;
            this.monitoringResultsGroupBox.TabStop = false;
            this.monitoringResultsGroupBox.Text = "检测结果";
            // 
            // QQForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 711);
            this.Controls.Add(this.currentMonitoringGroupBox);
            this.Controls.Add(this.recordGroupBox);
            this.Controls.Add(this.monitoringResultsGroupBox);
            this.Name = "QQForm";
            this.Text = "GodEye-QQ监测";
            this.Load += new System.EventHandler(this.QQForm_Load);
            this.Resize += new System.EventHandler(this.QQForm_Resize);
            this.currentMonitoringGroupBox.ResumeLayout(false);
            this.recordGroupBox.ResumeLayout(false);
            this.recordGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.monitoringResultslistView)).EndInit();
            this.monitoringResultsGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button currentUpButton;
        private System.Windows.Forms.CheckBox entertainmentSite;
        private System.Windows.Forms.GroupBox currentMonitoringGroupBox;
        private System.Windows.Forms.Button currentDownButton;
        private System.Windows.Forms.Button startCurrentMonitoring;
        private System.Windows.Forms.Button stopCurrentMonitoring;
        private System.Windows.Forms.Button recordDownButton;
        private System.Windows.Forms.Button recordUpButton;
        private System.Windows.Forms.Button recordButton;
        private System.Windows.Forms.Label designatesourceIPLabel;
        private System.Windows.Forms.TextBox sourceTextBox;
        private System.Windows.Forms.GroupBox recordGroupBox;
        private System.Windows.Forms.DateTimePicker stopDateTimePicker;
        private System.Windows.Forms.Label startTimeLabel;
        private System.Windows.Forms.Label stopTimeLabel;
        private System.Windows.Forms.DateTimePicker startDateTimePicker;
        private System.Windows.Forms.CheckBox networkGames;
        private System.Windows.Forms.DataGridView monitoringResultslistView;
        private System.Windows.Forms.GroupBox monitoringResultsGroupBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn rowTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn rowIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn rowQQnumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn rowLogin;

        //查询记录string
        private string recordButtonString = "recordButton";
        private string startCurrentMonitoringString = "startCurrentMonitoring";
        private string stopCurrentMonitoringString = "stopCurrentMonitoring";
    }
}