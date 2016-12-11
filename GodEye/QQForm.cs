using System;
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
    public partial class QQForm : Form
    {
        public QQForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;//设置窗体居屏幕中央
            this.Opacity = 0.92;
        }

        private void QQForm_Load(object sender, EventArgs e)
        {
            UIConfig(recordButtonString);
            DataGridViewConfig();
        }

        private void QQForm_Resize(object sender, EventArgs e)
        {
            DataGridViewConfig();
        }

        private void DataGridViewConfig()
        {
            int width = this.monitoringResultslistView.Width;
            this.rowIP.Width = width / monitoringResultslistView.ColumnCount;
            this.rowQQnumber.Width = width / monitoringResultslistView.ColumnCount;
            this.rowTime.Width = width / monitoringResultslistView.ColumnCount;
            this.rowLogin.Width = width / monitoringResultslistView.ColumnCount;
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
                networkGames.Enabled = false;
                entertainmentSite.Enabled = false;
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
                networkGames.Enabled = true;
                entertainmentSite.Enabled = true;
                stopCurrentMonitoring.Enabled = false;
                recordButton.Enabled = true;
                startCurrentMonitoring.Enabled = true;
            }

        }
        private void recordButton_Click(object sender, EventArgs e)
        {
            UIConfig(recordButtonString);
        }

        private void startCurrentMonitoring_Click(object sender, EventArgs e)
        {
            UIConfig(startCurrentMonitoringString);
        }

        private void stopCurrentMonitoring_Click(object sender, EventArgs e)
        {
            UIConfig(stopCurrentMonitoringString);
        }
    }
}
