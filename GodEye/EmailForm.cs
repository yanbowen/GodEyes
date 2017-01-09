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
    public partial class EmailForm : Form
    {
        Thread RealTimeDataThread;
        ProcessingEmailList<ProcessingEmail> peList = ProcessingEmailList<ProcessingEmail>.GetInstance();
        delegate void DataGridRowsShowHandler1(ProcessingEmail pe);
        bool isLoadRealTimeData = false;
        object threadLock = new object();
        object bufferLock = new object();
        string[] rowsLine = new string[5];
        /// <summary>
        /// 
        /// </summary>
        ArrayList peListBuffer = new ArrayList();

        private string recordButtonString = "recordButton";
        private string startCurrentMonitoringString = "startCurrentMonitoring";
        private string stopCurrentMonitoringString = "stopCurrentMonitoring";

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
            this.emailSubjectColum.Width = width / emailDataGridView.ColumnCount;
            //Debug.WriteLine(width);
        }

        private void emailDataGridView_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            this.emailSubjectColum.Width = emailDataGridView.Width - emailSendColum.Width - emailReceiveColum.Width - emailTimeColum.Width;
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
                    if (peList.Count != 0)
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
                    lock (peList.SyncRoot)
                    {
                        lock (bufferLock)
                        {
                            peListBuffer.AddRange(peList);
                        }
                        foreach (ProcessingEmail pe in peList)
                        {
                            this.BeginInvoke(new DataGridRowsShowHandler1(ShowDataRows), pe);
                        }
                        //清除传递的数据
                        peList.Clear();
                    }
                }
            }
        }

        private void ShowDataRows(ProcessingEmail pe)
        {
            try
            {
                rowsLine[0] = pe.Time;
                rowsLine[1] = pe.Sender;
                rowsLine[2] = pe.Receiver;
                rowsLine[3] = pe.Subject;
                emailDataGridView.Rows.Add(rowsLine);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void UIConfig(string buttonName)
        {
            if (buttonName.Equals(recordButtonString))
            {
                recordUpButton.Enabled = true;
                recordDownButton.Enabled = true;
                currentUpButton.Enabled = false;
                currentDownButton.Enabled = false;
                stopCurrentMonitoring.Enabled = false;
            }
            else
            if (buttonName.Equals(startCurrentMonitoringString))
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

        private void EmailForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            UIConfig(stopCurrentMonitoringString);
            ExitThread();
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

            }
        }

        private void emailDataGridView_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            if (e.Button == MouseButtons.Right)//右击也可选中
            {
                emailDataGridView.Rows[e.RowIndex].Selected = true;
            }
            selectDataGridRow(e.RowIndex);
        }

        private void selectDataGridRow(int index)
        {
            if (index < 0 || index > emailDataGridView.Rows.Count)
                return;
            //获取数据包位置
            //int i = Convert.ToInt32(monitoringResultslistView.Rows[index].Cells[0].Value.ToString());
            //if (i > pbListBuffer.Count)
            //    return;
            //Debug.WriteLine(index);
            //Debug.WriteLine(peListBuffer.Count);
            foreach (ProcessingEmail m in peListBuffer)
            {
                Debug.WriteLine(m.Caption);
                Debug.WriteLine(m.Time);
            }

            emailBrowser.DocumentText = ((ProcessingEmail)peListBuffer[index]).Caption;
            emailHeadInfo.Text = ((ProcessingEmail)peListBuffer[index]).Sender + "\r\n" + ((ProcessingEmail)peListBuffer[index]).Receiver + "\r\n" + ((ProcessingEmail)peListBuffer[index]).Subject;
        }

        private void emailDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        
    }
}
