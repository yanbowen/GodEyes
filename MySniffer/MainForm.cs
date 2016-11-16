using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using SharpPcap;
using SharpPcap.LibPcap;//引用SharpPcap
namespace MySniffer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            pktInfo = new PacketInfo(this.treeView1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadDevice();//加载窗体时加载网卡
        }



        ICaptureDevice device;// 定义设备
        List<RawCapture> packetList = new List<RawCapture>();//捕获的数据列表
        List<RawCapture> bufferList;//缓存列表
        Thread AnalyzerThread;//分析数据的线程
        object threadLock = new object();//线程锁定
        bool isStartAnalyzer;//用于表示是否启动分析线程的标志
        DeviceMode devMode = DeviceMode.Promiscuous;//数据采集模式
        int readTimeOut = 1000;
        delegate void DataGridRowsShowHandler(RawCapture packet);
        DataBuilder rowsBulider = new DataBuilder();
        PacketInfo pktInfo;
        uint packetIndex = 0;


        private void loadDevice()// 获取网卡方法
        {
            try
            {
                foreach (var i in CaptureDeviceList.Instance)
                {
                    comDeviceList.Items.Add(i.Description);  //在combox中添加
                }
                if (comDeviceList.Items.Count > 0)
                {
                    comDeviceList.SelectedIndex = 0;//自动选中第一个
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
        //选择网卡
        private void comDeviceList_SelectedIndexChanged(object sender, EventArgs e)
        {
            device = CaptureDeviceList.Instance[comDeviceList.SelectedIndex];
        }
        private void UIConfig(bool isStart)
        {
            comDeviceList.Enabled = !isStart;
            comFilter.Enabled = !isStart;
            btnStart.Enabled = !isStart;
            btnStop.Enabled = isStart;
            btnOpen.Enabled = !isStart;
            btnSave.Enabled = !isStart;
            checkBox1.Enabled = !isStart;

        }

        public void Clear()
        {
            if (packetList != null)
            {
                packetList.Clear();
            }
            if (bufferList != null)
            {
                bufferList.Clear();
            }
            dataGridPacket.Rows.Clear();
            treeView1.Nodes.Clear();
            richTextBox1.Text = "";
            packetIndex = 0;

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            devMode = (checkBox1.Checked) ? DeviceMode.Promiscuous : DeviceMode.Normal;
        }


        /// <summary>
        /// 启动网卡
        /// </summary>
        private void Start()
        {
            if (device == null || device.Started)
                return;

            bufferList = new List<RawCapture>();
            Clear();//清理原有的数据
            isStartAnalyzer = true;


            StartAnalyzer();//启动分析线程


            try
            {
                device.OnPacketArrival += new PacketArrivalEventHandler(device_OnPacketArrival);
                //默认使用混杂模式，超时 1000
                device.Open(devMode, readTimeOut);
                device.Filter = comFilter.Text;
                device.StartCapture();

                UIConfig(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                UIConfig(false);
            }

        }
        /// <summary>
        /// 启动分析
        /// </summary>
        private void StartAnalyzer()
        {
            AnalyzerThread = new Thread(new ThreadStart(analysrThreadMethod));
            AnalyzerThread.IsBackground = true;
            AnalyzerThread.Start();

        }
        /// <summary>
        /// 停止
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
                if (AnalyzerThread !=null && AnalyzerThread.IsAlive)
                {
                    AnalyzerThread.Abort();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            UIConfig(false);
        }

        void device_OnPacketArrival(object sender, CaptureEventArgs e)
        {
            lock (threadLock)
            {
                bufferList.Add(e.Packet);
            }
        }

        //数据分析线程
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
                    Thread.Sleep(200);
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
                        this.Invoke(new DataGridRowsShowHandler(ShowDataRows), i);

                    }
                }
            }
        }

        private void ShowDataRows(RawCapture packet)
        {
            try
            {
                dataGridPacket.Rows.Add(rowsBulider.Row(packet, ++packetIndex));//加载DataGridRows;
            }
            catch (Exception ex)
            {

            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            Stop();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Stop();
        }

        private void dataGridPacket_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            if (e.Button == MouseButtons.Right)//右击也可选中
            {
                dataGridPacket.Rows[e.RowIndex].Selected = true;
            }
            selectDataGridRow(e.RowIndex);
        }
        /// <summary>
        /// 选中一行
        /// </summary>
        /// <param name="index">选定的数据行索引值</param>
        private void selectDataGridRow(int index)
        {
            if (index < 0 || index > dataGridPacket.Rows.Count)
                return;
            //获取数据包位置
            int i = Convert.ToInt32(dataGridPacket.Rows[index].Cells[0].Value.ToString());
            if (i > packetList.Count)
                return;
            RawCapture rawPacket = packetList[i - 1];

            treeView1.Nodes.Clear();
            pktInfo.GetProtcolTree(rawPacket);
            richTextBox1.Text = HexConvert.ConvertToHexText(rawPacket .Data);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sd = new SaveFileDialog();
            sd.Filter = "Pcap文件|*.pcap";
            if (sd.ShowDialog() == DialogResult.OK)
            {
                var offDev = new SharpPcap.LibPcap.CaptureFileWriterDevice(sd.FileName);
                foreach (var i in packetList)
                {
                    offDev.Write(i);
                }
                MessageBox.Show("文件保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //打开文件
        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog od = new OpenFileDialog();
            od.Filter = "pcap文件|*.pcap";

            if (od.ShowDialog() == DialogResult.OK)
            {
                Clear();

                ICaptureDevice offDev = new SharpPcap.LibPcap.CaptureFileReaderDevice(od.FileName);
                RawCapture tempPacket;
                offDev.Open();
                while ((tempPacket = offDev.GetNextPacket()) != null)
                {
                    packetList.Add(tempPacket);
                    ShowDataRows(tempPacket);
                }
                offDev.Close();

            }
        }
    }
}
