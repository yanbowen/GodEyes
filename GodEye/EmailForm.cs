﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GodEye
{
    public partial class EmailForm : Form
    {
        public EmailForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;//设置窗体居屏幕中央
            this.Opacity = 0.92;
        }


        private void DataGridViewConfig()
        {
            int width = this.emailDataGridView.Width;
            this.emailSendColum.Width = width / emailDataGridView.ColumnCount;
            this.emailReceiveColum.Width = width / emailDataGridView.ColumnCount;
            this.emailTimeColum.Width = width / emailDataGridView.ColumnCount;
        }

        private void EmailForm_Resize(object sender, EventArgs e)
        {
            DataGridViewConfig();
        }

        private void EmailForm_Load(object sender, EventArgs e)
        {
            UIConfig(recordButtonString);
            DataGridViewConfig();
        }

        private void UIConfig(string buttionName)
        {
            if (buttionName.Equals(recordButtonString))
            {
                recordUpButton.Enabled = true;
                recordDownButton.Enabled = true;
                currentUpButton.Enabled = false;
                currentDownButton.Enabled = false;
                stopCurrentMonitoring.Enabled = false;
            }
            else
            if (buttionName.Equals(startCurrentMonitoringString))
            {
                startDateTimePicker.Enabled = false;
                stopDateTimePicker.Enabled = false;
                sourceTextBox.Enabled = false;
                destinationTextBox.Enabled = false;
                keywordTextBox.Enabled = false;
                startCurrentMonitoring.Enabled = false;
                recordButton.Enabled = false;
                recordUpButton.Enabled = false;
                recordDownButton.Enabled = false;
                currentUpButton.Enabled = true;
                currentDownButton.Enabled = true;
                stopCurrentMonitoring.Enabled = true;
            }
            else
            {
                startDateTimePicker.Enabled = true;
                stopDateTimePicker.Enabled = true;
                sourceTextBox.Enabled = true;
                destinationTextBox.Enabled = true;
                keywordTextBox.Enabled = true;
                stopCurrentMonitoring.Enabled = false;
                recordButton.Enabled = true;
                startCurrentMonitoring.Enabled = true;
            }

        }

        private void startCurrentMonitoring_Click(object sender, EventArgs e)
        {
            UIConfig(startCurrentMonitoringString);
        }

        private void stopCurrentMonitoring_Click(object sender, EventArgs e)
        {
            UIConfig(stopCurrentMonitoringString);
        }

        private void recordButton_Click(object sender, EventArgs e)
        {
            UIConfig(recordButtonString);
        }

        private void EmailForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            UIConfig(stopCurrentMonitoringString);
        }
    }
}