﻿namespace GodEye
{
    partial class EmailForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.emailContent = new System.Windows.Forms.GroupBox();
            this.emailRichTextBox = new System.Windows.Forms.RichTextBox();
            this.recordGroupBox = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.keywordTextBox = new System.Windows.Forms.TextBox();
            this.recordDownButton = new System.Windows.Forms.Button();
            this.recordUpButton = new System.Windows.Forms.Button();
            this.recordButton = new System.Windows.Forms.Button();
            this.designatedestinationIPLabel = new System.Windows.Forms.Label();
            this.destinationTextBox = new System.Windows.Forms.TextBox();
            this.designatesourceIPLabel = new System.Windows.Forms.Label();
            this.sourceTextBox = new System.Windows.Forms.TextBox();
            this.stopDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.startTimeLabel = new System.Windows.Forms.Label();
            this.stopTimeLabel = new System.Windows.Forms.Label();
            this.startDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.currentMonitoringGroupBox = new System.Windows.Forms.GroupBox();
            this.currentDownButton = new System.Windows.Forms.Button();
            this.currentUpButton = new System.Windows.Forms.Button();
            this.startCurrentMonitoring = new System.Windows.Forms.Button();
            this.stopCurrentMonitoring = new System.Windows.Forms.Button();
            this.emailDataGridView = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.emailSendColum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailReceiveColum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailTimeColum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailContent.SuspendLayout();
            this.recordGroupBox.SuspendLayout();
            this.currentMonitoringGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.emailDataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // emailContent
            // 
            this.emailContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.emailContent.Controls.Add(this.emailRichTextBox);
            this.emailContent.Font = new System.Drawing.Font("华文楷体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.emailContent.Location = new System.Drawing.Point(768, 12);
            this.emailContent.Name = "emailContent";
            this.emailContent.Size = new System.Drawing.Size(410, 687);
            this.emailContent.TabIndex = 0;
            this.emailContent.TabStop = false;
            this.emailContent.Text = "邮件内容";
            // 
            // emailRichTextBox
            // 
            this.emailRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.emailRichTextBox.Font = new System.Drawing.Font("华文楷体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailRichTextBox.Location = new System.Drawing.Point(3, 30);
            this.emailRichTextBox.Name = "emailRichTextBox";
            this.emailRichTextBox.Size = new System.Drawing.Size(404, 654);
            this.emailRichTextBox.TabIndex = 13;
            this.emailRichTextBox.Text = "";
            // 
            // recordGroupBox
            // 
            this.recordGroupBox.Controls.Add(this.label1);
            this.recordGroupBox.Controls.Add(this.keywordTextBox);
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
            this.recordGroupBox.Controls.Add(this.startDateTimePicker);
            this.recordGroupBox.Font = new System.Drawing.Font("华文楷体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.recordGroupBox.Location = new System.Drawing.Point(12, 12);
            this.recordGroupBox.Name = "recordGroupBox";
            this.recordGroupBox.Size = new System.Drawing.Size(300, 461);
            this.recordGroupBox.TabIndex = 12;
            this.recordGroupBox.TabStop = false;
            this.recordGroupBox.Text = "记录查询";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("华文楷体", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(39, 280);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 19);
            this.label1.TabIndex = 19;
            this.label1.Text = "指定关键词";
            // 
            // keywordTextBox
            // 
            this.keywordTextBox.Location = new System.Drawing.Point(41, 302);
            this.keywordTextBox.Multiline = true;
            this.keywordTextBox.Name = "keywordTextBox";
            this.keywordTextBox.Size = new System.Drawing.Size(200, 24);
            this.keywordTextBox.TabIndex = 18;
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
            this.designatedestinationIPLabel.Location = new System.Drawing.Point(38, 213);
            this.designatedestinationIPLabel.Name = "designatedestinationIPLabel";
            this.designatedestinationIPLabel.Size = new System.Drawing.Size(128, 19);
            this.designatedestinationIPLabel.TabIndex = 14;
            this.designatedestinationIPLabel.Text = "指定收件方地址";
            // 
            // destinationTextBox
            // 
            this.destinationTextBox.Location = new System.Drawing.Point(41, 235);
            this.destinationTextBox.Multiline = true;
            this.destinationTextBox.Name = "destinationTextBox";
            this.destinationTextBox.Size = new System.Drawing.Size(200, 24);
            this.destinationTextBox.TabIndex = 13;
            // 
            // designatesourceIPLabel
            // 
            this.designatesourceIPLabel.AutoSize = true;
            this.designatesourceIPLabel.Font = new System.Drawing.Font("华文楷体", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.designatesourceIPLabel.Location = new System.Drawing.Point(37, 153);
            this.designatesourceIPLabel.Name = "designatesourceIPLabel";
            this.designatesourceIPLabel.Size = new System.Drawing.Size(128, 19);
            this.designatesourceIPLabel.TabIndex = 12;
            this.designatesourceIPLabel.Text = "指定发件方地址";
            // 
            // sourceTextBox
            // 
            this.sourceTextBox.Location = new System.Drawing.Point(41, 175);
            this.sourceTextBox.Multiline = true;
            this.sourceTextBox.Name = "sourceTextBox";
            this.sourceTextBox.Size = new System.Drawing.Size(200, 24);
            this.sourceTextBox.TabIndex = 11;
            // 
            // stopDateTimePicker
            // 
            this.stopDateTimePicker.Font = new System.Drawing.Font("华文楷体", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.stopDateTimePicker.Location = new System.Drawing.Point(41, 114);
            this.stopDateTimePicker.Name = "stopDateTimePicker";
            this.stopDateTimePicker.Size = new System.Drawing.Size(200, 24);
            this.stopDateTimePicker.TabIndex = 10;
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
            // stopTimeLabel
            // 
            this.stopTimeLabel.AutoSize = true;
            this.stopTimeLabel.Font = new System.Drawing.Font("华文楷体", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.stopTimeLabel.Location = new System.Drawing.Point(38, 92);
            this.stopTimeLabel.Name = "stopTimeLabel";
            this.stopTimeLabel.Size = new System.Drawing.Size(77, 19);
            this.stopTimeLabel.TabIndex = 9;
            this.stopTimeLabel.Text = "结束日期";
            // 
            // startDateTimePicker
            // 
            this.startDateTimePicker.Font = new System.Drawing.Font("华文楷体", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.startDateTimePicker.Location = new System.Drawing.Point(41, 52);
            this.startDateTimePicker.Name = "startDateTimePicker";
            this.startDateTimePicker.Size = new System.Drawing.Size(200, 24);
            this.startDateTimePicker.TabIndex = 8;
            // 
            // currentMonitoringGroupBox
            // 
            this.currentMonitoringGroupBox.Controls.Add(this.currentDownButton);
            this.currentMonitoringGroupBox.Controls.Add(this.currentUpButton);
            this.currentMonitoringGroupBox.Controls.Add(this.startCurrentMonitoring);
            this.currentMonitoringGroupBox.Controls.Add(this.stopCurrentMonitoring);
            this.currentMonitoringGroupBox.Font = new System.Drawing.Font("华文楷体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.currentMonitoringGroupBox.Location = new System.Drawing.Point(12, 517);
            this.currentMonitoringGroupBox.Name = "currentMonitoringGroupBox";
            this.currentMonitoringGroupBox.Size = new System.Drawing.Size(300, 179);
            this.currentMonitoringGroupBox.TabIndex = 13;
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
            // emailDataGridView
            // 
            this.emailDataGridView.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.emailDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("华文楷体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.emailDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.emailDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.emailDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.emailSendColum,
            this.emailReceiveColum,
            this.emailTimeColum});
            this.emailDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.emailDataGridView.Location = new System.Drawing.Point(3, 30);
            this.emailDataGridView.Name = "emailDataGridView";
            this.emailDataGridView.ReadOnly = true;
            this.emailDataGridView.RowTemplate.Height = 23;
            this.emailDataGridView.ShowEditingIcon = false;
            this.emailDataGridView.Size = new System.Drawing.Size(441, 651);
            this.emailDataGridView.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.emailDataGridView);
            this.groupBox1.Font = new System.Drawing.Font("华文楷体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(318, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(447, 684);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "邮件列表";
            // 
            // emailSendColum
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.emailSendColum.DefaultCellStyle = dataGridViewCellStyle3;
            this.emailSendColum.HeaderText = "发件方";
            this.emailSendColum.Name = "emailSendColum";
            this.emailSendColum.ReadOnly = true;
            // 
            // emailReceiveColum
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.emailReceiveColum.DefaultCellStyle = dataGridViewCellStyle4;
            this.emailReceiveColum.HeaderText = "收件方";
            this.emailReceiveColum.Name = "emailReceiveColum";
            this.emailReceiveColum.ReadOnly = true;
            // 
            // emailTimeColum
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.emailTimeColum.DefaultCellStyle = dataGridViewCellStyle5;
            this.emailTimeColum.HeaderText = "时间";
            this.emailTimeColum.Name = "emailTimeColum";
            this.emailTimeColum.ReadOnly = true;
            // 
            // EmailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 711);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.currentMonitoringGroupBox);
            this.Controls.Add(this.recordGroupBox);
            this.Controls.Add(this.emailContent);
            this.Name = "EmailForm";
            this.Text = "GodEye-邮件监测";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EmailForm_FormClosing);
            this.Load += new System.EventHandler(this.EmailForm_Load);
            this.Resize += new System.EventHandler(this.EmailForm_Resize);
            this.emailContent.ResumeLayout(false);
            this.recordGroupBox.ResumeLayout(false);
            this.recordGroupBox.PerformLayout();
            this.currentMonitoringGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.emailDataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox emailContent;
        private System.Windows.Forms.RichTextBox emailRichTextBox;
        private System.Windows.Forms.GroupBox recordGroupBox;
        private System.Windows.Forms.Button recordDownButton;
        private System.Windows.Forms.Button recordUpButton;
        private System.Windows.Forms.Button recordButton;
        private System.Windows.Forms.Label designatedestinationIPLabel;
        private System.Windows.Forms.TextBox destinationTextBox;
        private System.Windows.Forms.Label designatesourceIPLabel;
        private System.Windows.Forms.TextBox sourceTextBox;
        private System.Windows.Forms.DateTimePicker stopDateTimePicker;
        private System.Windows.Forms.Label startTimeLabel;
        private System.Windows.Forms.Label stopTimeLabel;
        private System.Windows.Forms.DateTimePicker startDateTimePicker;
        private System.Windows.Forms.GroupBox currentMonitoringGroupBox;
        private System.Windows.Forms.Button currentDownButton;
        private System.Windows.Forms.Button currentUpButton;
        private System.Windows.Forms.Button startCurrentMonitoring;
        private System.Windows.Forms.Button stopCurrentMonitoring;
        private System.Windows.Forms.DataGridView emailDataGridView;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox keywordTextBox;

        //查询记录string
        private string recordButtonString = "recordButton";
        private string startCurrentMonitoringString = "startCurrentMonitoring";
        private string stopCurrentMonitoringString = "stopCurrentMonitoring";
        private System.Windows.Forms.DataGridViewTextBoxColumn emailSendColum;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailReceiveColum;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailTimeColum;
    }
}