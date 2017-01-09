using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GodEye
{
    public partial class QQForm : Form
    {
        Thread RealTimeDataThread;
        ProcessingQQLoginLogoutList<ProcessingQQLoginLogout> qqllList = ProcessingQQLoginLogoutList<ProcessingQQLoginLogout>.GetInstance();
        delegate void DataGridRowsShowHandler1(ProcessingQQLoginLogout pqll);
        bool isLoadRealTimeData = false;
        object threadLock = new object();
        object bufferLock = new object();
        string[] rowsLine = new string[4];
        /// <summary>
        /// 
        /// </summary>
        ArrayList qqllListBuffer = new ArrayList();

        //查询记录string
        private string recordButtonString = "recordButton";
        private string startCurrentMonitoringString = "startCurrentMonitoring";
        private string stopCurrentMonitoringString = "stopCurrentMonitoring";

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
            LoadRealData();
        }

        private void LoadRealData()
        {
            isLoadRealTimeData = true;
            RealTimeDataThread = new Thread(new ThreadStart(LoadRealTimeDateThread));
            RealTimeDataThread.IsBackground = true;
            RealTimeDataThread.Start();
        }

        private void LoadRealTimeDateThread()
        {
            while (isLoadRealTimeData)
            {
                bool isShouldSleep = true;
                lock (threadLock)
                {
                    if (qqllList.Count != 0)
                    {
                        isShouldSleep = false;
                    }
                }
                if (isShouldSleep)//
                {
                    Thread.Sleep(101);
                }
                else
                {
                    lock (qqllList.SyncRoot)
                    {
                        lock (bufferLock)
                        {
                            qqllListBuffer.AddRange(qqllList);
                        }
                        foreach (ProcessingQQLoginLogout qqll in qqllList)
                        {
                            this.BeginInvoke(new DataGridRowsShowHandler1(ShowDataRows), qqll);
                        }
                        //清除传递的数据
                        qqllList.Clear();
                    }
                }
            }
        }

        private void ShowDataRows(ProcessingQQLoginLogout qqll)
        {
            try
            {
                rowsLine[0] = qqll.Time;
                rowsLine[1] = qqll.QqIP;
                rowsLine[2] = qqll.QqID;
                if(qqll.QqLogin==1)
                {
                    rowsLine[3] = "上线";
                }
                else
                {
                    rowsLine[3] = "下线";
                }

                monitoringResultslistView.Rows.Add(rowsLine);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void stopCurrentMonitoring_Click(object sender, EventArgs e)
        {
            UIConfig(stopCurrentMonitoringString);
            ExitThread();
        }

        private void ExitThread()
        {
            try
            {
                isLoadRealTimeData = false;
                if (RealTimeDataThread != null && RealTimeDataThread.IsAlive)
                {
                    RealTimeDataThread.Abort();
                }
            }
            catch
            {
                //Debug.WriteLine();
                MessageBox.Show("退出出现异常");
            }
        }

        private void monitoringResultslistView_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            this.rowLogin.Width = monitoringResultslistView.Width-rowIP.Width-rowTime.Width-rowIP.Width;
        }
    }
}
