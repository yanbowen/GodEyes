using SharpPcap;
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
using System.Windows.Forms.DataVisualization.Charting;

namespace GodEye
{

    public partial class MainForm : Form
    {

        /// <summary>
        /// 成员变量
        /// dalong
        /// 2016-11-9 22:22:41
        /// </summary>
        #region
        private Hashtable ht;
        private System.Timers.Timer timer2 = new System.Timers.Timer();
        private StaffMonitoringForm staffForm;
        private EmailForm emailForm;
        private QQForm qqForm;
        ICaptureDevice device;// 定义设备
        List<RawCapture> packetList = new List<RawCapture>();//捕获的数据列表
        List<RawCapture> bufferList;//缓存列表

        /// <summary>
        /// 不能用ArrayList泛型
        /// </summary>
        List<ProcessingBehave> behaveList = new List<ProcessingBehave>();

        Thread AnalyzerThread;//分析数据的线程
        object threadLock = new object();//线程锁定
        bool isStartAnalyzer;//用于表示是否启动分析线程的标志
        DeviceMode devMode = DeviceMode.Promiscuous;//数据采集模式
        int readTimeOut = 1000;
        delegate void DataGridRowsShowHandler(RawCapture packet);
        DataBuilder rowsBulider = new DataBuilder();//规范化数据
        uint packetIndex = 0;//包计数索引
        LinkMySQL lmysql = new LinkMySQL();
        
        /// <summary>
        /// 用户行为引用
        /// </summary>
        ProcessingBehave pb;
        /// <summary>
        /// 邮件引用
        /// </summary>
        ProcessingEmail pe = new ProcessingEmail();
        EmailAnalysis ea = new EmailAnalysis();
        /// <summary>
        /// QQ上下线引用
        /// </summary>
        ProcessingQQLoginLogout pqll;
        /// <summary>
        /// 用户行为单例列表
        /// </summary>
        ProcessingBehaveList<ProcessingBehave> pbList = ProcessingBehaveList<ProcessingBehave>.GetInstance();
        /// <summary>
        /// 邮件单例列表
        /// </summary>
        ProcessingEmailList<ProcessingEmail> peList = ProcessingEmailList<ProcessingEmail>.GetInstance();
        /// <summary>
        /// QQ上下线单例列表
        /// </summary>
        ProcessingQQLoginLogoutList<ProcessingQQLoginLogout> pqllList = ProcessingQQLoginLogoutList<ProcessingQQLoginLogout>.GetInstance();

        ProcessingAllData rowData;

        ProcessingAllDataList<ProcessingAllData> padList = ProcessingAllDataList<ProcessingAllData>.GetInstance();

        System.Windows.Forms.Timer chartTimer = new System.Windows.Forms.Timer();

        private int countQQ=0;
        private int countEmail=0;
        private int countBehave=0;

        #endregion

        public MainForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;//设置窗体居屏幕中央
            this.Opacity = 0.92;
            
            Init();
            timer2.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
            timer2.Interval = 120000;
            timer2.Start();
            //lmysql.test();
        }

        private void Init()
        {
            ht = new Hashtable();
            ht.Add("taobao", "访问淘宝网站");
            ht.Add("jd.com", "访问京东商城");
            ht.Add("blizzard", "访问游戏：魔兽世界");
            ht.Add("douyu", "访问斗鱼直播平台");

        }

        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (!ht.ContainsKey("taobao"))
            {
                ht.Add("taobao", "访问淘宝网站");
            }
            else if (!ht.ContainsKey("jd.com"))
            {
                ht.Add("jd.com", "访问京东商城");
            }
            else if (!ht.ContainsKey("blizzard"))
            {
                ht.Add("blizzard", "访问游戏：魔兽世界");
            }
            else if (!ht.ContainsKey("douyu"))
            {
                ht.Add("douyu", "访问斗鱼直播平台");
            }

        }
        

        /// <summary>
        /// 
        /// </summary>
        private void InitChart()
        {
            DateTime time = DateTime.Now;
            chartTimer.Interval = 1000;
            chartTimer.Tick += chartTimer_Tick;
            chartflow.DoubleClick += chartflow_DoubleClick;

            Series series = chartflow.Series[0];
            series.ChartType = SeriesChartType.Spline;
            series.IsVisibleInLegend = false;
            //Series series1 = chartflow.Series[1];
            //series1.ChartType = SeriesChartType.Spline;
            //series1.IsVisibleInLegend = false;

            chartflow.ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm:ss";
            chartflow.ChartAreas[0].AxisX.ScaleView.Size = 5;
            chartflow.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;
            chartflow.ChartAreas[0].AxisX.ScrollBar.Enabled = true;

            chartTimer.Start();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chartflow_DoubleClick(object sender, EventArgs e)
        {
            chartflow.ChartAreas[0].AxisX.ScaleView.Size = 5;
            chartflow.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;
            chartflow.ChartAreas[0].AxisX.ScrollBar.Enabled = true;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chartTimer_Tick(object sender, EventArgs e)
        {
            int length = 0;
            if (packetList != null)
            {

                foreach (RawCapture rawCapture in packetList)
                {
                    length += rawCapture.Data.Length;
                }


                try
                {

                    //Random ra = new Random();
                    Series series = chartflow.Series[0];
                    //series.Points.AddXY(DateTime.Now, ra.Next(1, 10));
                    series.Points.AddXY(DateTime.Now, length / 1024 );
                    chartflow.ChartAreas[0].AxisX.ScaleView.Position = series.Points.Count - 5;
                }
                catch
                {

                }
            }

        }

        private void staffMonitoringOpenLabel_Click(object sender, EventArgs e)
        {
            if (staffForm == null)
            {
                staffForm = new StaffMonitoringForm();
                staffForm.Show();
            }
            else
            {
                if (staffForm.IsDisposed)
                {
                    staffForm = new StaffMonitoringForm();
                    staffForm.Show();
                }
                else
                {
                    staffForm.WindowState = FormWindowState.Normal;
                    staffForm.TopMost = true;
                }
            }
        }

        /// <summary>
        /// 窗体加载时，加载网卡，配置UI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            loadDevice();//加载窗体时获取网卡
            UIConfig(false);
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
        }

        /// <summary>
        /// UI配置，按钮、列表等的可用和不可用
        /// </summary>
        /// <param name="isStart"></param>
        private void UIConfig(bool isStart)
        {
            deviceComboList.Enabled = !isStart;
            startMonitoring.Enabled = !isStart;
            stopMonitoring.Enabled = isStart;
        }

        /// <summary>
        /// 加载网卡方法
        /// </summary>
        private void loadDevice()
        {
            try
            {
                foreach (var i in CaptureDeviceList.Instance)
                {
                    deviceComboList.Items.Add(i.Description);  //在combox中添加
                }
                if (deviceComboList.Items.Count > 0)
                {
                    deviceComboList.SelectedIndex = 0;//自动选中第一个
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        /// <summary>
        /// 网卡选择改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deviceCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            device = CaptureDeviceList.Instance[deviceComboList.SelectedIndex];
        }

        /// <summary>
        /// 显示数据清理
        /// </summary>
        private void Clear()
        {
            if (packetList != null)
            {
                packetList.Clear();
            }
            if (bufferList != null)
            {
                bufferList.Clear();
            }
            ///
            //monitoringResultslistView.Rows.Clear();
            //treeView1.Nodes.Clear();
            //richTextBox1.Text = "";//内容显示框
            packetIndex = 0;
        }
        
        /// <summary>
        /// 开始抓包的起点,调用UIConfig
        /// </summary>
        private void Start()
        {
            if (device == null || device.Started)
            {
                return;
            }
            bufferList = new List<RawCapture>();
            Clear();
            isStartAnalyzer = true;

            StartAnalyzer();

            try
            {
                device.OnPacketArrival += new PacketArrivalEventHandler(device_OnPacketArrival);
                device.Open(devMode, readTimeOut);
                //device.Filter = "混杂模式";
                device.StartCapture();

                UIConfig(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                UIConfig(false);
            }
            InitChart();
        }

        /// <summary>
        /// 停止，调用UIConfig
        /// </summary>
        private void Stop()
        {
            try
            {
                if (device != null && device.Started)
                {
                    device.StopCapture();
                    device.Close();
                }

                isStartAnalyzer = false;
                if (AnalyzerThread != null && AnalyzerThread.IsAlive)
                {
                    AnalyzerThread.Abort();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            UIConfig(false);

            chartTimer.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            staffNoticeLabel.Left -= 3;
            qqNoticeLabel.Left -= 4;
            emailNoticeLabel.Left -= 2;
            if (staffNoticeLabel.Right<= 0)
            {
                staffNoticeLabel.Left = staffMonitoringPanel.Width;
            }
            if (qqNoticeLabel.Right <= 0)
            {
                qqNoticeLabel.Left = staffMonitoringPanel.Width;
            }
            if (emailNoticeLabel.Right <= 0)
            {
                emailNoticeLabel.Left = staffMonitoringPanel.Width;
            }
        }

        /// <summary>
        /// 包来临时添加到缓冲链表中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void device_OnPacketArrival(object sender, CaptureEventArgs e)
        {
            lock (threadLock)
            {
                bufferList.Add(e.Packet);
            }
        }

        /// <summary>
        /// 启用数据分析线程
        /// </summary>
        private void StartAnalyzer()
        {
            AnalyzerThread = new Thread(new ThreadStart(analysrThreadMethod));
            AnalyzerThread.IsBackground = true;
            AnalyzerThread.Start();
        }

        /// <summary>
        /// 数据分析线程，并添加到缓冲列表中
        /// </summary>
        private void analysrThreadMethod()
        {
            while (isStartAnalyzer)
            {
                bool isShoudSleep = true;
                lock (threadLock)
                {
                    if (bufferList.Count != 0)
                        isShoudSleep = false;
                }
                if (isShoudSleep)//
                {
                    Thread.Sleep(100);
                }
                else
                {
                    List<RawCapture> tmpPacketList;
                    lock (threadLock) //获取数据
                    {
                        tmpPacketList = bufferList;
                        bufferList = new List<RawCapture>();//构建新列表
                        packetList.AddRange(tmpPacketList);
                    }
                    foreach (var i in tmpPacketList)
                    {   
                        ///委托AddDatToList到UI线程上刷新数据；等待后续代码再执行
                        this.Invoke(new DataGridRowsShowHandler(AddDataToList), i); 
                    }
                }
            }
        }

        /// <summary>
        /// 将分析好的数据添加到列表
        /// </summary>
        /// <param name="packet"></param>
        private void AddDataToList(RawCapture packet)
        {
            try
            {
                string[] rowsLinebuffer = new string[7];
                rowsLinebuffer = rowsBulider.Row(packet, ++packetIndex);
                if (rowsLinebuffer[1] == "TCP" || rowsLinebuffer[1] == "SMTP"|| rowsLinebuffer[1] == "POP3"|| rowsLinebuffer[1] == "HTTP"|| rowsLinebuffer[1] == "OICQ")
                {
                    rowData = new ProcessingAllData();
                    rowData.Id = rowsLinebuffer[0];
                    rowData.Protocol = rowsLinebuffer[1];
                    rowData.Length = rowsLinebuffer[2];
                    rowData.SourceAddress = rowsLinebuffer[3];
                    rowData.DestinationAddress = rowsLinebuffer[4];
                    rowData.HardwareType = rowsLinebuffer[5];
                    rowData.Time = rowsLinebuffer[6];
                    rowData.BinaryData = packet.Data; //?
                    rowData.Data = HexConvert.ConvertToAscii(packet.Data);

                    //添加总的数据
                    lock (padList.SyncRoot)
                    {
                        padList.Add(rowData);
                    } 

                    //邮件分析
                    if (rowsLinebuffer[1] == "SMTP" || rowsLinebuffer[1] == "POP3")
                    {
                        //一条记录包含在多个包里，需要多次分析才得到一条数据
                        //pe = new ProcessingEmail();
                        countEmail += ea.Analysis(rowData);
                    }

                    //员工行为
                    if (rowsLinebuffer[1] == "TCP" || rowsLinebuffer[1] == "HTTP")
                    {
                        pb = new ProcessingBehave();
                        String key = pb.Analysis(rowData, ht, pbList);

                        if (!key.Equals("key"))
                        {
                            ht.Remove(key);
                            countBehave++;
                        }
                    }

                    if (rowsLinebuffer[1] == "OICQ")
                    {
                        pqll = new ProcessingQQLoginLogout();
                        countQQ += pqll.Analysis(rowData);
                        if (pqll.QqLogin == 1 || pqll.QqLogin == 2)
                        {
                            lock (pqllList.SyncRoot)
                            {
                                pqllList.Add(pqll);
                            }
                        }
                    }

                    //pb = new ProcessingBehave();
                    //pb.Time = rowData.Time;
                    //pb.UserIPA =rowData.SourceAddress;
                    //pb.UserIPB = rowData.DestinationAddress;
                    //pb.Protocol = rowData.Protocol;
                    ////pb.Reason = rowData.HardwareType;///修改
                    //pb.Reason = HexConvert.ConvertToAscii(packet.Data); 

                    //pb.Caption = HexConvert.ConvertToHexText(packet.Data);
                    //lock (pbList.SyncRoot)
                    //{
                    //    pbList.Add(pb);
                    //}
                    //behaveList.Add(pb);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.staffNoticeLabel.Text = "今日新增记录" + countBehave + "条";
            this.qqNoticeLabel.Text = "今日新增记录" + countQQ + "条";
            this.emailNoticeLabel.Text = "今日新增记录" + countEmail + "条";
        }

        /// <summary>
        /// 开始监测按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startMonitoring_Click(object sender, EventArgs e)
        {
            Start();
        }

        /// <summary>
        /// 停止监测按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void stopMonitoring_Click(object sender, EventArgs e)
        {
            Stop();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Stop();
        }

        private void emailMonitoringOpenLabel_Click(object sender, EventArgs e)
        {
            if (emailForm == null)
            {
                emailForm = new EmailForm();
                emailForm.Show();
            }
            else
            {
                if (emailForm.IsDisposed)
                {
                    emailForm = new EmailForm();
                    emailForm.Show();
                }
                else
                {
                    emailForm.WindowState = FormWindowState.Normal;
                    emailForm.TopMost = true;
                }
            }
        }

        private void emailMonitoringPanel_Click(object sender, EventArgs e)
        {
            if (emailForm == null)
            {
                if (!isStartAnalyzer)
                {
                    MessageBox.Show("请在主界面选择合适的网卡，然后启动监测！ ：）");
                }
                emailForm = new EmailForm();
                emailForm.Show();
            }
            else
            {
                if (emailForm.IsDisposed)
                {
                    emailForm = new EmailForm();
                    emailForm.Show();
                }
                else
                {
                    emailForm.WindowState = FormWindowState.Normal;
                    emailForm.TopMost = true;
                }
            }
        }

        private void qqLoginPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void qqLoginPanel_Click(object sender, EventArgs e)
        {
            if (qqForm == null)
            {
                qqForm = new QQForm();
                qqForm.Show();
            }
            else
            {
                if (qqForm.IsDisposed)
                {
                    qqForm = new QQForm();
                    qqForm.Show();
                }
                else
                {
                    qqForm.WindowState = FormWindowState.Normal;
                    qqForm.TopMost = true;
                }
            }
        }
    }

}
