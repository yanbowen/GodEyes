using SharpPcap;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GodEye
{
    public partial class StaffMonitoringForm : Form
    {

        private Hashtable ht;
        //使用多线程计时器
        private System.Timers.Timer timer = new System.Timers.Timer();

        public StaffMonitoringForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;//设置窗体居屏幕中央
            this.Opacity = 0.92;
            timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
            timer.Enabled = true;
            Init();

        }

        private void Init()
        {
            ht = new Hashtable();
            ht.Add("121.194.7.215", "访问淘宝网站");
            ht.Add("182.140.245.49", "访问淘宝网站");
            ht.Add("182.140.246.253", "访问淘宝网站");
            ht.Add("121.9.212.177", "访问淘宝网站");
            ht.Add("121.9.212.176", "访问淘宝网站");
            ht.Add("118.123.203.254", "访问淘宝网站");
            ht.Add("183.56.147.1", "访问京东商城");
            ht.Add("59.111.0.50", "访问游戏：魔兽世界");
            ht.Add("183.6.245.191", "访问游戏：阴阳师");


        }

        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Init();
            System.Threading.Thread.Sleep(20000);
        }

        Thread RealTimeDataThread;
        bool isLoadRealTimeData = false;
        object threadLock = new object();
        object bufferLock = new object();
        string[] rowsLine = new string[5];
        delegate void DataGridRowsShowHandler1(ProcessingBehave pb);
        ProcessingBehaveList<ProcessingBehave> pbList = ProcessingBehaveList<ProcessingBehave>.GetInstance();

        ///注意装箱和拆箱
        ArrayList pbListBuffer = new ArrayList();

        /// <summary>
        /// 控件可用与不可用逻辑
        /// </summary>
        /// <param name="buttionName"></param>
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
                destinationTextBox.Enabled = true;
                networkGames.Enabled = true;
                entertainmentSite.Enabled = true;
                stopCurrentMonitoring.Enabled = false;
                recordButton.Enabled = true;
                startCurrentMonitoring.Enabled = true;
            }

        }

        private void StaffMonitoringForm_Load(object sender, EventArgs e)
        {
            UIConfig(recordButtonString);
            DataGridViewConfig();
        }

        private void networkGames_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void entertainmentSite_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkAll_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void monitoringResultslistView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void startMonitoring_Click(object sender, EventArgs e)
        {
            UIConfig(startCurrentMonitoringString);
            isLoadRealTimeData = true;
            LoadRealTimeData();
            //this.monitoringResultslistView.Update();  //结束数据处理，UI界面一次性绘制。 
        }

        private void LoadRealTimeData()
        {
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
                    if (pbList.Count != 0)
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
                    lock (pbList.SyncRoot)
                    {
                        lock (bufferLock)
                        {
                            pbListBuffer.AddRange(pbList);
                        }
                        foreach (ProcessingBehave pb in pbList)
                        {
                            this.BeginInvoke(new DataGridRowsShowHandler1(ShowDataRows), pb);
                        }
                        pbList.Clear();
                    }
                }
            }
        }

        private void ShowDataRows(ProcessingBehave pb)
        {

            foreach (String key in ht.Keys)
            {

                if (pb.UserIPA.Contains(key) || pb.UserIPB.Contains(key))
                {

                    record(pb, (String)ht[key], key);
                }
            }
            
        }

        private void record(ProcessingBehave pb, string method, String key)
        {
            rowsLine[1] = pb.UserIPA;
            rowsLine[2] = pb.UserIPB;
            rowsLine[3] = pb.Reason;
            rowsLine[0] = pb.Time;
            rowsLine[4] = method;
            try
            {
                monitoringResultslistView.Rows.Add(rowsLine);
                //ht.Remove(key);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        /// <summary>
        /// 需要关闭线程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void stopMonitoring_Click(object sender, EventArgs e)
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

        private void DataGridViewConfig()
        {
            int width = this.monitoringResultslistView.Width;
            this.rowSourceIP.Width = width / monitoringResultslistView.ColumnCount;
            this.rowDestinationIP.Width = width / monitoringResultslistView.ColumnCount;
            this.rowTime.Width = width / monitoringResultslistView.ColumnCount;
            this.rowReason.Width = width / monitoringResultslistView.ColumnCount;
            this.rowProtocol.Width = width / monitoringResultslistView.ColumnCount;
        }

        private void StaffMonitoringForm_Resize(object sender, EventArgs e)
        {
            DataGridViewConfig();
        }

        private void startDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            startDateTimePicker.Value.ToString("hh:mm:ss  MM/dd/yyyy");
        }

        private void monitoringResultslistView_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            rowReason.Width = monitoringResultslistView.Width - rowSourceIP.Width - rowDestinationIP.Width - rowProtocol.Width - rowTime.Width;
        }

        private void recordButton_Click(object sender, EventArgs e)
        {
            UIConfig(recordButtonString);
        }

        private void StaffMonitoringForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            UIConfig(stopCurrentMonitoringString);
            ExitThread();
        }

        private void monitoringResultslistView_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            if (e.Button == MouseButtons.Right)//右击也可选中
            {
                monitoringResultslistView.Rows[e.RowIndex].Selected = true;
            }
            selectDataGridRow(e.RowIndex);
        }

        /// <summary>
        /// 选中一行
        /// </summary>
        /// <param name="index">选定的数据行索引值</param>
        private void selectDataGridRow(int index)
        {
            if (index < 0 || index > monitoringResultslistView.Rows.Count)
                return;
            //获取数据包位置
            //int i = Convert.ToInt32(monitoringResultslistView.Rows[index].Cells[0].Value.ToString());
            //if (i > pbListBuffer.Count)
            //    return;
            richTextBox1.Text = ((ProcessingBehave)pbListBuffer[index]).Caption;
        }
    }
}
