using System;
using System.Windows.Forms;
using System.IO.Ports;
using serialPort_Bord.Properties;
using System.Configuration;
using System.Net;
using System.Collections.Generic;
using System.IO;
using serialPort_Bord.serialPort_Bord;
using System.Threading;
using System.Text;

namespace serialPort_Bord
{
    public partial class Frm_Main : Form
    {
        public struct CurrentTestRangeTypeDef   // 电流测试范围值结构体
        {
            public double Chan0MaxValve;        // 通道0最大值(显示为通道a)
            public double Chan0MinValve;        // 通道0最小值
            public double Chan1MaxValve;        // 通道1最大值(显示为通道b)
            public double Chan1MinValve;        // 通道1最小值
            public bool CurrentTestDet;         // 电流测试指令(判断当前接收的内容是否为电流值)
        }

        public struct IPandPortTypeDef
        {
            public string DefMainIpAddress;
            public ushort DefPortNum;
        }


        public const byte PRINTFRECER = 1;   // 是否需要输出数据 
        public static string VersionNum = "V1.0.2.20042801_RC";
        public static Form form;
        public static string[] Project_Name = { "唐山滦南超声波燃气表", "新奥超声波燃气表" };
        public static byte Project_Selection = 0;       // 项目选择 0表示唐山项目， 1表示新奥项目，此项是根据Project_Name的下标确定的
        private readonly byte View_content_Flag = 0;         // 关于按钮展示的内容 0表示窗口， 其他表示展示默认属性
        

        CurrentTestRangeTypeDef CurrentTestStruct;  // 实例化电流测试结构体
        IPandPortTypeDef IPandPortStruct;           // 实例化IP和端口初始化值
        AutoSizeFormClass asc = new AutoSizeFormClass();
        readonly Crc16 Crc16 = new Crc16();         // 实例化Cre16校验类
        readonly SerialPortHelper SerialPortHelper = new SerialPortHelper();
        public byte TableNumBitLength = 0;          // 表号长度
        public byte TableNumStartPos = 0;           // 表号开始位
        public static string romPath = "";          //升级文件路径
        public static int  fileLenth ;              //升级总字节数
        public static int packetNum;                //升级包数量  
        public static int packetIndex;              //请求固件包Index  
        public static List<Dstruct> DataPacks = new List<Dstruct>();//升级固件包List
        private byte[] ReceBuffer = new byte[100];           // 创建串口缓存集合
        private int BuffPtr = 0;                             // 数据长度

        // 该字段用于判断是否需要显示测试过程
        private bool is_TableNumClick = false;      // 表号设置消息反馈
        private bool is_HardwareClick = false;      // 硬件检测消息反馈
        private bool is_CurrentClick = false;       // 电流检测消息反馈
        private bool SetTabNumFlag = false;         // 是否是表号设置按钮按下
        

        /// <summary>
        /// 初始化UI
        /// </summary>
        public Frm_Main()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        /// <summary>
        /// 页面初始配置
        /// </summary>
        private void FormInit()
        {
            // 常用串口波特率
            string[] BuadRate = { "2400", "9600", };
            // 项目选项选择
            
            foreach (var item in BuadRate)      // 将波特率添加到波特率下拉框中
            {
                BuadRate_ComboBox.Items.Add(item);
            }
            foreach (var item in Project_Name)
            {
                Project_combox.Items.Add(item);
            }
            BuadRate_ComboBox.SelectedIndex = 0;    // 选择默认串口波特
            SerialPort_Entity.DataReceived += new SerialDataReceivedEventHandler(Port_ReceData);    // 创建串口接收事件
            LoadApp_CurrentConfig();                // 配置基本数据

            CurrentTestStruct.CurrentTestDet = false;   // 将电流检测标志位设置为false

            // 现在只有功耗测试功能，暂时先关闭其他按键
            Key_Button.Enabled = false;
            OpenValve_Button.Enabled = false;
            Rece_HexCheckBox.Checked = true;
            // 版本号
            ToolStripMenuItem_VersionNum.Text = VersionNum;

            //初始化进度条
            initProgress();
            asc.Initialize(this);
        }

        /// <summary>
        /// 串口接收事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Port_ReceData(object sender, EventArgs e)
        {

            try
            {
                SerialPort_Entity.Encoding = System.Text.Encoding.GetEncoding("GB2312");        // 将串口数据编码格式修改为GB2312
                if (!Rece_HexCheckBox.Checked)       // 判断当前接收是否为接收16进制
                {
                    string str = SerialPort_Entity.ReadExisting();      // 读取串口数据并存储到str字符串中
                    Dis_Rece_TextBox.AppendText(str);                   // 添加展示到接收框中

                }
                else
                {
                    Port_Rece_HexData(SerialPort_Entity);       // 接收16进制数据
                }
            }
            catch (Exception)
            {

               
            }
           
        }

        /// <summary>
        /// 串口接收16进制数据
        /// </summary>
        /// <param name="serialPort"></param>串口名
        public void Port_Rece_HexData(SerialPort serialPort)
        {
            int len = serialPort.BytesToRead;       //获取可以读取的字节数
            byte[] buff = new byte[len];            //创建缓存数据数组
            serialPort.Read(buff, 0, len);          //把数据读取到buff数组
            try
            {
                lock (ReceBuffer)
                {
                    Array.Copy(buff, 0, ReceBuffer, BuffPtr, len);  // 将当前串口收内容存到缓存区
                    BuffPtr += len;

                }
                if(buff.Length != 0)
                { 
                    if ((buff[buff.Length - 1] == GSMCMDEnum.frameTail) || (buff[buff.Length -1] == 0X45 && buff[buff.Length - 2] == 0X45 && buff[buff.Length - 3] == 0X2D) && (BuffPtr > 13))     // 判断最后一个字节是否为0x16
                    {
                        
                        Event_Manage();       // 校验数据
                       
                    } 
                }
            }
            catch (Exception)
            {
                
                Array.Clear(ReceBuffer, 0, ReceBuffer.Length);
                BuffPtr = 0;
            }        
            if(ReceBuffer[0] != 0X68 )
            {
                BuffPtr = 0;
            }

        }

        /// <summary>
        /// 数据处理
        /// </summary>
        public void Event_Manage()
        {
            byte[] buffer = new byte[100];
            if (ReceBuffer[2] == 0x00 && ReceBuffer[3] == 0x00)
            {
                Array.Copy(ReceBuffer, 22, buffer, 0, ReceBuffer[23]);
            }       // 接收错误处理
            else
            {
                Array.Copy(ReceBuffer, buffer, ReceBuffer[1]);
            }

            lock (buffer)        // 锁住该数组，保证数组在使用时不会被再次使用
            {
                //for (int i = 0; i < BuffPtr; i++)   // 输出接收到的数据
                //{
                //    Dis_Rece_TextBox.AppendText(string.Format("{0:X2} ", ReceBuffer[i]));
                //}
                //Dis_Rece_TextBox.AppendText("\r\n");    // 输出换行

                int detPos = GSMCMDEnum.detPos;    // 默认唐山项目
                byte[] tempArr = new byte[5];
                Array.Copy(buffer, 4, tempArr, 0, 5);
                byte[] _temp = { 0xaa, 0xaa, 0xaa, 0xaa, 0xaa };
                if (!Crc16.Arr_Equals(tempArr, _temp))
                {
                    if (Project_Selection == 1)// 如果是新奥项目
                    {
                        detPos += 3;
                    }
                } 
                // 帧位数1位
                switch (buffer[detPos])
                {
                    case GSMCMDEnum.configTableNum:
                        if (SetTabNumFlag != true)
                        {
                            return;
                        }

                        if (buffer[detPos+1] == GSMCMDEnum.returnSuccess )
                        {
                            byte TableLen = 0;
                            if (TableNumBitLength % 2 == 0)
                            {
                                TableLen = (byte)(TableNumBitLength / 2);   // 表号位数为偶数
                            }
                            else
                            {
                                TableLen = (byte)(TableNumBitLength / 2 + 1);   // 表号位数为奇数
                            }

                            byte[] temp = new byte[TableLen];       // 创建一个表号位数一半的byte类型数组

                            Array.Copy(ReceBuffer, 4, temp, 0, TableLen);    // 将接收的数据中的表号数据拷贝到临时数组中

                            string TableNumStr = SerialPortHelper.BCDToString(temp);    // 将表号转成BCD码字符串

                            Dis_Rece_TextBox.AppendText("表号修改成功,表号为: " + TableNumStr + "\r\n");     // 显示表号

                            Log.WriteLog("表号修改成功,表号为: " + TableNumStr);

                            if(tableNumAutoAdd_checkbox.Checked)
                            {
                                TableNumber_TextBox.Text = TableNumAutoAdd(TableNumStr, Project_Selection);     // 表号自增(勾选表号自增选项才会执行)
                            }
                            

                            TableNum_PictureBox.Image = Resources.Acces;            // 修改提示图标为成功

                            if (is_TableNumClick && is_HardwareClick && is_CurrentClick)
                            {
                                CheckResult_PictureBox.Image = Resources.OK;
                            }
                            if (IPandPortConfig_checkBox.Checked )
                            {
                                Thread.Sleep(500);
                                IP_PORT_Confirm_Button_Click(null, null);
                            }
                            is_TableNumClick = false;
                        }
                        else
                        {
                            Dis_Rece_TextBox.AppendText("表号修改失败\r\n");     // 显示表号
                            Log.WriteLog("表号修改失败");
                        }
                        SetTabNumFlag = false;
                        
                        break;
                    case GSMCMDEnum.configIPAndPort:

                        if (buffer[detPos + 1] == GSMCMDEnum.returnSuccess) // 解析指令结果
                        {
                            Dis_Rece_TextBox.AppendText("IP和端口号修改成功\r\n");
                            IP_Port_PictureBox.Image = Resources.Acces;
                            Log.WriteLog("IP和端口号修改成功");
                            if(meter_CheckBox.Checked)
                            {
                                set_meter_ql();
                            }
                        }
                        else
                        {
                            Dis_Rece_TextBox.AppendText("IP和端口号修改失败\r\n");
                            IP_Port_PictureBox.Image = Resources.Error;
                            Log.WriteLog("IP和端口号修改失败");
                        }
                        break;
                    case GSMCMDEnum.metercl:
                        Dis_Rece_TextBox.AppendText("累积量清零成功\r\n");
                        CheckResult_PictureBox.Image = Resources.OK;
                        break;

                    case GSMCMDEnum.getIPAndPortDet:
                        GetIPAndPort(buffer);
                        GetIP_PictureBox.Image = Resources.Acces;
                        break;

                    case GSMCMDEnum.headWareDet:
 
                        if (buffer[detPos + 1] == GSMCMDEnum.returnSuccess)
                        {
                            Dis_Rece_TextBox.AppendText("硬件状态检测正常\r\n");

                            HeadWare_PictureBox.Image = Resources.Acces;

                            Log.WriteLog("硬件状态检测正常");

                            is_HardwareClick = true;
                            if(is_TableNumClick)
                            {
                                CheckResult_PictureBox.Image = Resources.Checking;
                            }
                        }
                        else
                        {
                            Dis_Rece_TextBox.AppendText("硬件状态检测失败\r\n");

                            HeadWare_PictureBox.Image = Resources.Error;
                            
                            Log.WriteLog("硬件状态检测失败");

                            is_HardwareClick = false;

                            if(is_TableNumClick)
                            {
                                CheckResult_PictureBox.Image = Resources.NO;
                                TableNum_PictureBox.Image = Resources.Error;
                                CheckResult_PictureBox.Image = Resources.Checking;
                            }
                        }
                        break;

                    case GSMCMDEnum.currentDet:

                        if (buffer[detPos + 1] == GSMCMDEnum.testErrDet)
                        {
                            Dis_Rece_TextBox.AppendText("零偏电压存在误差，请去除被测板后重新获取零偏电压!!!!\r\n");
                            byte[] data = { 0X0A };
                            UsartFormatData(0XFD, data, data.Length);
                            Current_PictureBox.Image = Resources.Error;
                            is_CurrentClick = false;
                        }
                        else if (buffer[detPos + 1] == GSMCMDEnum.chA)
                        {
                            byte[] CurrTemp = new byte[4];
                            Array.Copy(ReceBuffer, GSMCMDEnum.dataStartPos + 1, CurrTemp, 0, 4);
                            CurrentCalculation(CurrTemp, Dis_Rece_TextBox, GSMCMDEnum.chA);
                        }
                        else if (buffer[detPos + 1] == GSMCMDEnum.chB)
                        {
                            byte[] CurrTemp = new byte[4];
                            Array.Copy(ReceBuffer, GSMCMDEnum.dataStartPos + 1, CurrTemp, 0, 4);
                            CurrentCalculation(CurrTemp, Dis_Rece_TextBox, GSMCMDEnum.chB);
                        }

                        break;

                    case GSMCMDEnum.zeroVolt:

                        if(buffer[detPos + 1] == GSMCMDEnum.returnSuccess)
                        { 
                            byte[] ZeroVoltATempArr = new byte[4];
                            byte[] ZeroVoltBTempArr = new byte[4];

                            Array.Copy(buffer, GSMCMDEnum.dataStartPos + 1, ZeroVoltATempArr, 0, 4);
                            Array.Copy(buffer, GSMCMDEnum.dataStartPos + 5, ZeroVoltBTempArr, 0, 4);

                            float ZeroVoltA = ByteToFloat(ZeroVoltATempArr);
                            float ZeroVoltB = ByteToFloat(ZeroVoltBTempArr);

                            Dis_Rece_TextBox.AppendText("通道 A 零偏电压为: " + ZeroVoltA + "mV\r\n");
                            Dis_Rece_TextBox.AppendText("通道 B 零偏电压为: " + ZeroVoltB + "mV\r\n");
                        }
                        else
                        {
                            Dis_Rece_TextBox.AppendText("零偏电压不正常,请去除被测板后重新检测零偏电压!!!\r\n");
                            byte[] data = { 0X0A };
                            UsartFormatData(0XFD, data, data.Length);
                            Current_PictureBox.Image = Resources.Error;
                        }
                        break;
                    case GSMCMDEnum.buttonConfTabDet:
                        TableNnumber_Confirm_Button_Click(null, null);
                        break;
                    case GSMCMDEnum.getProNumDet:
                        ProNum_Textbox.Text = Project_Name[buffer[detPos + 1]];
                        break;
                    case GSMCMDEnum.getVersionNum:

                        byte[] VerionArr = new byte[8];

                        Array.Copy(buffer, detPos+1, VerionArr, 0, 8);

                        Dis_Rece_TextBox.AppendText("当前测试底板版本号为" + GetBordVerison(VerionArr) + "\r\n");

                        GetVersion_PictureBox.Image = Resources.Acces;

                        break;

                    default:
                        break;
                }

                // 帧位数(升级)2位
                switch (ReceBuffer[GSMCMDEnum.dataStartPos])
                {
                    case GSMCMDEnum.readFirmware:
                        if (Crc16.CheckData(ReceBuffer, BuffPtr, 2) == false)      // 判断校验数据是否成功
                        {
                            Dis_Rece_TextBox.AppendText("校验数据错误，请重试\r\n");
                            Array.Clear(ReceBuffer, 0, ReceBuffer.Length);
                            throw (new Exception("DataCheck Error"));
                        }
                        //获取固件包
                        byte[] sendBytes = UpdateHelper.getFirmwarePag(ReceBuffer);
                        //判断数据是否为空
                        if (sendBytes == null)
                        {
                            return;
                        }
                        //发送数据
                        SerialPortHelper.SendHex(SerialPort_Entity, sendBytes);
                        //声明配置进度
                        updateWorker.WorkerReportsProgress = true;
                        //更新进度条
                        updateWorker_DoWork(null, null);
                        break;
                    case GSMCMDEnum.updateDone:
                        if (Crc16.CheckData(ReceBuffer, BuffPtr, 2) == false)      // 判断校验数据是否成功
                        {
                            Dis_Rece_TextBox.AppendText("校验数据错误，请重试\r\n");
                            throw (new Exception("DataCheck Error"));
                        }
                        if (UpdateHelper.isSuccess(ReceBuffer))
                        {
                            Dis_Rece_TextBox.AppendText(SerialPortHelper.GetTimeStamp() + "  升级成功！\r\n");
                            pictureBox1.Image = Resources.Acces;
                        }
                        else
                        {
                            Dis_Rece_TextBox.AppendText("升级失败！\r\n");
                            pictureBox1.Image = Resources.Error;
                        }
                        break;
                    default:
                        //    for (int i = 0; i < BuffPtr; i++)   // 输出接收到的数据
                        //    {
                        //        Dis_Rece_TextBox.AppendText(string.Format("{0:X2} ", ReceBuffer[i]));
                        //    }
                        //    Dis_Rece_TextBox.AppendText("\r\n");    // 输出换行
                        break;
                }
            }
            Array.Clear(ReceBuffer, 0, ReceBuffer.Length);
            BuffPtr = 0;
        }

        /// <summary>
        /// byte转浮点数
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public float ByteToFloat(byte[] arr)
        {
            float Vlave;

            ushort intpart = Convert.ToUInt16(arr[0].ToString("X2") + arr[1].ToString("X2"), 16);

            ushort fractpart = Convert.ToUInt16(arr[2].ToString("X2") + arr[3].ToString("X2"), 16);

            Vlave = intpart + (float)(fractpart / 10000.0);

            return Vlave;
        }

        /// <summary>
        /// 获取版本号拼接字符串
        /// </summary>
        /// <param name="arr"> 带版本号的数组</param>
        /// <returns>字符串版本号</returns>
        public string GetBordVerison(byte[] arr)
        {
            StringBuilder VersionNum = new StringBuilder();
            string[] VersionDev = { "Alpha", "Beta", "RC", "Release" };
            VersionNum.Append("V");
            VersionNum.Append(arr[0].ToString("X"));
            VersionNum.Append(".");
            VersionNum.Append(arr[1].ToString("X"));
            VersionNum.Append(".");
            VersionNum.Append(arr[2].ToString("X"));
            VersionNum.Append(".");
            for(int i = 0; i < 3;i++)
            {
                VersionNum.Append(arr[i + 3].ToString("X2"));
            }
            VersionNum.Append("_");
            VersionNum.Append(arr[6].ToString("X2"));
            VersionNum.Append("_");
            VersionNum.Append(VersionDev[arr[7]]);

            return VersionNum.ToString();
        }

        /// <summary>
        /// 电流判断
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="textBox"></param>
        /// <param name="ch"></param>
        public void CurrentCalculation(byte[] arr, TextBox textBox, byte ch)
        {
            float CurrentValve = ByteToFloat(arr);

            if (ch == GSMCMDEnum.chA)
            {
                if (CurrentValve >= CurrentTestStruct.Chan0MaxValve)
                {
                    textBox.AppendText("通道 A 当前电流值 " + CurrentValve + " mA,功耗测试未通过,电流过大!!!\r\n");

                    byte[] data = { 0X0A };
                    UsartFormatData(0XFD, data, data.Length);

                    Current_PictureBox.Image = Resources.Error;

                    Log.WriteLog("通道 A 当前电流值 " + CurrentValve + " mA, 功耗测试未通过, 电流过大!!!");

                    is_CurrentClick = false;

                    if (is_TableNumClick)
                    {
                        CheckResult_PictureBox.Image = Resources.NO;
                        TableNum_PictureBox.Image = Resources.Error;
                    }
                }
                else if (CurrentValve < CurrentTestStruct.Chan0MinValve)
                {
                    textBox.AppendText("通道 A 当前电流值 " + CurrentValve + " mA,功耗测试未通过,电流过小!!!\r\n");

                    byte[] data = { 0X0A };
                    UsartFormatData(0XFD, data, data.Length);

                    Current_PictureBox.Image = Resources.Error;

                    Log.WriteLog("通道 A 当前电流值 " + CurrentValve + " mA,功耗测试未通过,电流过小!!!");

                    is_CurrentClick = false;

                    if (is_TableNumClick)
                    {
                        CheckResult_PictureBox.Image = Resources.NO;
                        TableNum_PictureBox.Image = Resources.Error;
                    }
                }
                else
                {
                    textBox.AppendText("通道 A 当前电流值 " + CurrentValve + " mA,功耗测试通过,电流正常!!!\r\n");

                    byte[] data = { 0XFF };
                    UsartFormatData(0XFD, data, data.Length);

                    Current_PictureBox.Image = Resources.Acces;

                    Log.WriteLog("通道 A 当前电流值 " + CurrentValve + " mA,功耗测试通过,电流正常!!!");

                    is_CurrentClick = true;
                }
            }
            else if (ch == GSMCMDEnum.chB)
            {
                if (CurrentValve >= CurrentTestStruct.Chan1MaxValve)
                {
                    Dis_Rece_TextBox.AppendText("通道 B 当前电流值 " + CurrentValve +  " uA,功耗测试未通过,电流过大!!!\r\n");

                    byte[] data = { 0X0B };
                    UsartFormatData(0XFD, data, data.Length);

                    Current_PictureBox.Image = Resources.Error;

                    Log.WriteLog("通道 B 当前电流值 " + CurrentValve + " uA, 功耗测试未通过, 电流过大!!!");

                    is_CurrentClick = false;

                    if(is_TableNumClick)
                    {
                        CheckResult_PictureBox.Image = Resources.NO;
                        TableNum_PictureBox.Image = Resources.Error;
                    }
                }
                else if (CurrentValve < CurrentTestStruct.Chan1MinValve)
                {
                    Dis_Rece_TextBox.AppendText("通道 B 当前电流值 " + CurrentValve + " uA,功耗测试未通过,电流过小!!!\r\n");

                    byte[] data = { 0X0B };
                    UsartFormatData(0XFD, data, data.Length);

                    Current_PictureBox.Image = Resources.Error;

                    Log.WriteLog("通道 B 当前电流值 " + CurrentValve + " uA,功耗测试未通过,电流过小!!!");

                    is_CurrentClick = false;
                    if (is_TableNumClick)
                    {
                        CheckResult_PictureBox.Image = Resources.NO;
                        TableNum_PictureBox.Image = Resources.Error;
                    }
                }
                else
                {
                    Dis_Rece_TextBox.AppendText("通道 B 当前电流值 " + CurrentValve + " uA,功耗测试通过,电流正常!!!\r\n");
                    byte[] data = { 0XFF };
                    UsartFormatData(0XFD, data, data.Length);
                    Current_PictureBox.Image = Resources.Acces;

                    Log.WriteLog("通道 B 当前电流值 " + CurrentValve + " uA,功耗测试通过,电流正常!!!");

                    is_CurrentClick = true;
                }
            }
            //Dis_Rece_TextBox.AppendText("----------------------------------------------\r\n");
        }

        /// <summary>
        /// 串口发送数据
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="data"></param>
        public void UsartFormatData(byte cmd, byte[] data, int len)
        {
            byte[] ValTempArr = new byte[13 + len];
            ConDefValve(ValTempArr);
            ValTempArr[1] =  Convert.ToByte(len + 13);
            ValTempArr[9] = cmd;
            Array.Copy(data, 0, ValTempArr, 10, len);
            Crc16.GetCrc16(ValTempArr);
            ValTempArr[ValTempArr.Length-1] = 0X16;
            SerialPortHelper.SendHex(SerialPort_Entity, ValTempArr);
        }
        /// <summary>
        /// 表号自增
        /// </summary>
        /// <param name="TabNum">表号</param>
        /// <param name="ProSele">项目编号</param>
        /// <returns></returns>
        public string TableNumAutoAdd(string TabNum, byte ProSele)
        {
            if(ProSele == 0)      // 唐山项目
            {
                uint tableNum = Convert.ToUInt32(TabNum);   // 将表号转为无符号整数
                return Convert.ToString(tableNum + 1);  // 表号自增后返回字符串

            }
            else if(ProSele == 1) // 新奥项目
            {
                int tableNum = Convert.ToInt32(TabNum.Substring(10)) + 1;   // 将实际的表号截取出来并自加
                byte t = SerialPortHelper.NumLength((uint)tableNum); // 获取表号长度
                string x = string.Empty;    
                for (int i = 0; i < 6 - t; i++) // 补0
                {
                    x += "0";
                }
                StringBuilder tempStr = new StringBuilder();
                tempStr.Append(TabNum.Substring(0, 10) + tableNum.ToString());
                tempStr.Insert(10, x);
                return tempStr.ToString();
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 在数组中获取IP地址和端口号并做输出
        /// </summary>
        /// <param name="Arr"></param> 被读取的IP地址数组
        public void GetIPAndPort(byte[] Arr)
        {
            
            byte[] MainIP = new byte[4];            // 主IP
            byte[] SubIP  = new byte[4];            // 备用IP
            byte[] PortNumArr = new byte[2];        // 端口号
            Array.Copy(Arr, GSMCMDEnum.dataStartPos, MainIP, 0, 4);      // 获取主IP
            Array.Copy(Arr, GSMCMDEnum.dataStartPos + 4, SubIP, 0, 4);       // 获取备用IP
            Array.Copy(Arr, GSMCMDEnum.dataStartPos + 8, PortNumArr, 0, 2);  // 获取端口号

            byte TableLen;
            if (TableNumBitLength % 2 == 0)
            {
                TableLen = (byte)(TableNumBitLength / 2);   // 表号位数为偶数
            }
            else
            {
                TableLen = (byte)(TableNumBitLength / 2 + 1);   // 表号位数为奇数
            }
            byte[] TableNum = new byte[TableLen];          // 表号

            Array.Copy(Arr, TableLen, TableNum, 0, TableLen);    // 将接收的数据中的表号数据拷贝到临时数组中

            string TableNumStr = SerialPortHelper.BCDToString(TableNum);    // 将表号转成BCD码字符串

            Dis_Rece_TextBox.AppendText("表号为         : " + TableNumStr + "\r\n");

            Dis_Rece_TextBox.AppendText("主IP地址为   : ");
            SerialPortHelper.PrintIP(MainIP, Dis_Rece_TextBox);      // 输出主IP地址

            Dis_Rece_TextBox.AppendText("备用IP地址为: ");
            SerialPortHelper.PrintIP(SubIP, Dis_Rece_TextBox);       // 输出备用IP地址

            ushort PortNum = Convert.ToUInt16(PortNumArr[0].ToString("X2") + PortNumArr[1].ToString("X2"), 16);          // 将端口号数组转换成十进制数据
            Dis_Rece_TextBox.AppendText("端口号为      : " + PortNum + "\r\n");     // 在文本框中输出端口号

            Log.WriteLog("获取IP地址");
            Log.WriteLog("表号为           " + TableNumStr);
            Log.WriteLog("主IP地址为     " + ByteToNumString(MainIP));
            Log.WriteLog("备用IP地址为   " + ByteToNumString(SubIP));
            Log.WriteLog("端口号为        " + PortNum);


        }

        /// <summary>
        /// 数组转IP字符串
        /// </summary>
        /// <param name="Arr"></param>
        /// <returns></returns>
        public string ByteToNumString(byte[] Arr)
        {
            string str;
            int num1,num2, num3, num4;
            num1 = Convert.ToInt32(Arr[0].ToString("X2"), 16);
            num2 = Convert.ToInt32(Arr[1].ToString("X2"), 16);
            num3 = Convert.ToInt32(Arr[2].ToString("X2"), 16);
            num4 = Convert.ToInt32(Arr[3].ToString("X2"), 16);

            str = Convert.ToString(num1 + "." + num2 + "." + num3 + "." + num4);

            return str;
        }   

        /// <summary>
        /// 串口配置写入
        /// </summary>
        /// <param name="serialPort"></param>
        private void SerialConfig(SerialPort serialPort)
        {
            serialPort.PortName = SerialNum_ComboBox.Text;                      // 配置串口名称
            serialPort.BaudRate = Convert.ToInt32(BuadRate_ComboBox.Text);      // 配置串口波特率
            serialPort.DataBits = 8;            // 8位数据位        // 配置串口数据位
            serialPort.StopBits = (StopBits)1;  // 1位停止位        // 配置串口停止位
            serialPort.Parity = 0;              // 无校验位         // 配置串口校验位
        }

        /// <summary>
        /// 窗口加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            FormInit();         // 串口初始化
            SerialPortHelper.GetSerialName(SerialNum_ComboBox);
        }

        /// <summary>
        /// 窗口分辨率自适应
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Resize(object sender, EventArgs e)
        {
            asc.ReSize(this);
        }

        /// <summary>
        /// 串口开关按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SerialOption_Button_Click(object sender, EventArgs e)
        {
            if (SerialNum_ComboBox.Text == "")      // 判断串口下拉框是否有串口名称存在
            {
                MessageBox.Show("串口名称未选择", "ERROR");
                return;
            }
            // 判断串口是否被打开
            if (!SerialPort_Entity.IsOpen)
            {
                try
                {
                    SerialPort_Entity.Close();              // 先关闭串口
                    SerialConfig(SerialPort_Entity);        // 配置默认数据到当前串口
                    SerialPort_Entity.Open();               // 打开串口
                    SerialOption_Button.Text = "关闭串口";  // 将按键文字修改为关闭串口
                    SerialPort_Update.Start();              // 开启串口号更新定时器，这里会一直去更新串口名称，如果当前串口掉线，会及时提醒
                    SerialPortState_PictureBox.Image = Resources.connect;    
                    SerialNum_ComboBox.Enabled = false;
                    BuadRate_ComboBox.Enabled = false;
                }
                catch (Exception)
                {
                    if (SerialPort_Entity.IsOpen)
                    {
                        SerialPort_Entity.Close();
                        SerialOption_Button.Text = "打开串口";
                        SerialNum_ComboBox.Enabled = true;
                        BuadRate_ComboBox.Enabled = true;
                        SerialPortState_PictureBox.Image = Resources.notConnect;
                    }
                    else
                    {
                        MessageBox.Show("串口打开失败，可能端口已被占用", "提示");
                        SerialOption_Button.Text = "打开串口";
                        SerialPortState_PictureBox.Image = Resources.notConnect;
                    }
                }
            }
            else if (SerialPort_Entity.IsOpen)
            {
                try
                {
                    SerialPort_Entity.Close();
                    SerialOption_Button.Text = "打开串口";
                    SerialNum_ComboBox.Enabled = true;
                    BuadRate_ComboBox.Enabled = true;
                    SerialPortState_PictureBox.Image = Resources.notConnect;

                }
                catch (Exception)
                {
                    MessageBox.Show("关闭串口失败,请重试", "提示");
                }

            }
        }

        /// <summary>
        /// 串口名称下拉框点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SerialNum_ComboBox_Click(object sender, EventArgs e)
        {
            SerialNum_ComboBox.Items.Clear();
            SerialPortHelper.GetSerialName(SerialNum_ComboBox);
        }

        /// <summary>
        /// 测试按钮事件，通过tag属性区分按键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, EventArgs e)
        {    

            Button MyButton = (Button)(sender);
            int Flag = Convert.ToInt32(MyButton.Tag);
            byte TestDet = 0x00;
            byte[] DataArr = { 0x00 };
            switch (Flag)
            {
                case 0:
                    Current_PictureBox.Image = Resources.Wait;
                    if (!is_TableNumClick)
                    {
                        CheckResult_PictureBox.Image = Resources.checkWait;
                    }
                    TestDet = GSMCMDEnum.currentDet;
                    CurrentTestStruct.CurrentTestDet = true;
                    Rece_HexCheckBox.Checked = true;
                    break;
                case 1:
                    TestDet = 0XDF;
                    break;
                case 3:
                    TestDet = 0XFC;
                    break;
                case 4:
                    TestDet = GSMCMDEnum.getVersionNum;
                    break;
                case 5:
                    TestDet = 0XCC;
                    if (ZeroBia_CheckBox.Checked)
                    {
                        DataArr[0] = 0X01;
                    }
                    ZeroBia_CheckBox.Checked = false;
                    Rece_HexCheckBox.Checked = true;
                    break;
            }
            UsartFormatData(TestDet, DataArr, DataArr.Length);
            
        }
        
        /// <summary>
        /// 清除接收区内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearReceDis_Button_Click(object sender, EventArgs e)
        {
            Dis_Rece_TextBox.Clear();            
            Current_PictureBox.Image    = Resources.Wait;                       
            Key_PictureBox.Image        = Resources.Wait;                       
            HeadWare_PictureBox.Image   = Resources.Wait;
            OPenValve_PictureBox.Image  = Resources.Wait;  
            TableNum_PictureBox.Image   = Resources.Wait;
            IP_Port_PictureBox.Image    = Resources.Wait;
            GetVersion_PictureBox.Image = Resources.Wait;
            GetIP_PictureBox.Image      = Resources.Wait;
            CheckResult_PictureBox.Image = Resources.checkWait;
          
        }

        /// <summary>
        /// 发送数据按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SendData_Button_Click(object sender, EventArgs e)
        {
            if (SerialPort_Entity.IsOpen)
            {
                try
                {
                    if (!SendHex_CheckBox.Checked)
                    {
                        SerialPortHelper.SendStr(SerialPort_Entity, SendData_TextBox.Text);
                    }
                    else
                    {
                        byte[] HexArr = SerialPortHelper.HexStringToByteArray(SendData_TextBox.Text);
                        SerialPortHelper.SendHex(SerialPort_Entity, HexArr);
                    }
                }
                catch (Exception)
                {

                    MessageBox.Show("请输入数据内容", "提示");
                }
            }
            else
            {
                MessageBox.Show("未打开串口", "提示");
            }
        }
        
        /// <summary>
        /// 清除发送数据文本框的内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearSendData_Button_Click(object sender, EventArgs e)
        {
            SendData_TextBox.Clear();
        }

        /// <summary>
        /// 状态更新计时器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_StateUpdata_Tick(object sender, EventArgs e)
        {
            Timer_StateUpdata.Stop();
            if (SystemTag_Lable.Text != "就绪")
            {
                SystemTag_Lable.Text = "就绪";
            }

        }

        /// <summary>
        /// 串口状态更新定时器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SerialPort_Update_Tick(object sender, EventArgs e)
        {
            if (SerialOption_Button.Text == "关闭串口")
            {
                string[] portNames = SerialPort.GetPortNames();     // 获取串口名
                if (Array.IndexOf(portNames, SerialNum_ComboBox.Text) == -1)        // 判断当前串口是否仍在数组中
                {
                    SerialPort_Entity.Close();      // 关闭串口

                    SerialOption_Button.Text = "打开串口";      // 将串口按键文本内容改为打开串口
                    
                    SerialPortState_PictureBox.Image = Resources.notConnect;    // 将提示图片改为未连接状态
                    
                    SerialNum_ComboBox_Click(sender, e);        // 重新刷新串口下拉框数据
                    
                    Dis_Rece_TextBox.AppendText("\r\n串口断开,请重新连接\r\n");  
                    
                    SerialPort_Update.Stop();
                    
                    SerialNum_ComboBox.Enabled = true;
                    
                    BuadRate_ComboBox.Enabled = true;
                }
            }
        }

        /// <summary>
        /// 写入默认数据
        /// </summary>
        /// <param name="Arr"></param>
        public static void ConDefValve(byte[] Arr)
        {
            byte[] tempArr = { 0X68, 0X00, 0XE1, 0XA1, 0XAA, 0XAA, 0XAA, 0XAA, 0XAA };
            Array.Copy(tempArr, 0, Arr, 0, tempArr.Length);
        }

        /// <summary>
        /// 表号设置按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TableNnumber_Confirm_Button_Click(object sender, EventArgs e)
        {
            Array.Clear(ReceBuffer, 0, ReceBuffer.Length);
            BuffPtr = 0;
            try
            {
                if (IPandPortConfig_checkBox.Checked)
                {
                    if ((Crc16.Str_IsEmpty(MainIPAddress_MaskedTextBox.Text) == true) && (Crc16.Str_IsEmpty(SubIPAddress_MaskedTextBox.Text) == true))
                    {
                        Dis_Rece_TextBox.AppendText("不需要设置IP时请取消勾选一键配置\r\n需要配置请填写IP和端口号,本次表号设置取消\r\n");
                        return;
                    }
                }
                
                string TableNum = "";

                try
                {
                    TableNum = TableNumber_TextBox.Text.Substring(TableNumStartPos - 1, TableNumBitLength);
                }
                
                catch (Exception)
                {
                    //Dis_Rece_TextBox.AppendText(ex.GetType() + "\r\n");
                    if (TableNumBitLength < 1)
                    {
                        Dis_Rece_TextBox.AppendText("表号起始位必须大于 0, 请合理修改表号起始位");
                    }
                    else
                    {
                        byte GetTableNumLength = 0;
                        GetTableNumLength = Convert.ToByte( TableNumber_TextBox.Text.Length - (TableNumStartPos - 1));
                        if(GetTableNumLength < 0)    
                        {
                            GetTableNumLength = 0;
                        }
                        Dis_Rece_TextBox.AppendText("您输入的表号不够获取到" + TableNumBitLength + "位，当前可获取长度为" +
                        GetTableNumLength.ToString() + "位, " + "起始位为第"+TableNumStartPos+ "位。\r\n" + "请正确输入表号或检查表号起始位是否正确!!!!\r\n");
                        
                    }
                    Log.WriteLog("表号长度" + TableNumBitLength + "位,表号起始位" + TableNumStartPos + "位,当前输入表号位" + TableNumber_TextBox.Text);
                    TableNum_PictureBox.Image = Resources.Error;
                    return;
                }

                byte[] TableNumber = SerialPortHelper.Str2Bcd(TableNum);    // 将字符串转成BCD码

                if(Project_Selection == 0)
                {
                    for (int i = 0; i < TableNumber.Length; i++)
                    {
                        if (TableNumber[i] > GSMCMDEnum.tableNumMaxValve) // 当前单位最大值为0X99
                        {
                            throw (new Exception("Data Error"));
                        }
                    }
                }
                
                Rece_HexCheckBox.Checked = true;        // 将接收16进制勾选框选上。

                UsartFormatData(GSMCMDEnum.configTableNum, TableNumber, TableNumber.Length);

                

                is_TableNumClick = true;
                is_HardwareClick = false;
                is_CurrentClick = false;

                Current_PictureBox.Image = Resources.Wait;

                HeadWare_PictureBox.Image = Resources.Wait;
                                
                TableNum_PictureBox.Image = Resources.Wait;

                CheckResult_PictureBox.Image = Resources.checkWait;

                SetTabNumFlag = true;


                //Log.WriteLog("配置表号    " + TableNumber_TextBox.Text);
            }
            catch (Exception)
            {
                Dis_Rece_TextBox.AppendText("请输入正确的表号\r\n");
            }
        }

        /// <summary>
        /// 发送获取IP地址命令按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetIP_Button_Click(object sender, EventArgs e)
        {

            GetIP_PictureBox.Image = Resources.Wait;
            Array.Clear(ReceBuffer, 0, ReceBuffer.Length);
            BuffPtr = 0;
            byte[] GetIp_Arr = { 0xFF };    // 创建一个byte数组，存放获取IP地址的数据指令    

            Rece_HexCheckBox.Checked = true;                // 将接收16进制勾选框勾上

            UsartFormatData(GSMCMDEnum.getIPAndPortDet, GetIp_Arr, GetIp_Arr.Length);
        }

        /// <summary>
        /// 硬件检测按键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HeadWare_Button_Click(object sender, EventArgs e)
        {
            byte[] HeadCheck_Arr = { 0x00 };        // 创建数组用于存放硬件检测指令

            HeadWare_PictureBox.Image = Resources.Wait;

            Rece_HexCheckBox.Checked = true;                // 将接收16进制勾选框勾上

            UsartFormatData(GSMCMDEnum.headWareDet, HeadCheck_Arr, HeadCheck_Arr.Length);
        }

        /// <summary>
        /// 获取并判断字符串中的内容是否是IP地址
        /// </summary>
        /// <param name="IPAdd"></param>    IP地址字符串
        /// <param name="IP_Arr"></param>   需要存放的IP地址的数组
        /// <param name="index"></param>    索引值
        /// <returns></returns>
        public bool GetIPAddress(string IPAdd, byte[] IP_Arr, int index)
        {
            Array.Clear(ReceBuffer, 0, ReceBuffer.Length);
            BuffPtr = 0;
            try
            {
                IPAdd = IPAdd.Replace(" ", "");          // 去除IP地址字符串中的 " "
               
                IPAddress IPAddress_temp = IPAddress.Parse(IPAdd);      // 将IP地址获取出来，如果获取到的IP地址不在合理范围内容，会跳到catch中提示IP地址不在正确范围内

                byte[] temp = IPAddress_temp.GetAddressBytes();         // 将IP地址依次放到数组中
                
                Array.Copy(temp, 0, IP_Arr, index, temp.Length);        // 将主IP地址
                
                return true;
            }
            catch (Exception)
            {

                IP_Port_PictureBox.Image = Resources.Error;

                Dis_Rece_TextBox.AppendText("IP地址错误,不在正确IP地址范围内，请重新输入\r\n");
                
                return false;
            }
        }

        /// <summary>
        /// IP和端口确认按键确认Click方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IP_PORT_Confirm_Button_Click(object sender, EventArgs e)
        {

            Array.Clear(ReceBuffer, 0, ReceBuffer.Length);
            
            BuffPtr = 0;

            byte[] IP_Port_Arr = new byte[10]; 
            
            string MainIpAddress = MainIPAddress_MaskedTextBox.Text;            // 获取主IP地址
            
            string SubIpAddrss = SubIPAddress_MaskedTextBox.Text;               // 获取副IP地址

            if ((Crc16.Str_IsEmpty(MainIpAddress) == true) && (Crc16.Str_IsEmpty(SubIpAddrss) == true))  // 判断主副IP地址是否都为空，若为空则提示需要任意输入一个IP地址
            {
            
                Dis_Rece_TextBox.AppendText("修改IP请至少输入主IP或备用IP其中一个\r\n");
               
                return;
            }
            else
            {

                                                                // 判断该字符串内有没有类似于IP地址的内容，如果有则将其分为四个字节并放到输出数组中，
                if (Crc16.Str_IsEmpty(MainIpAddress) != true && GetIPAddress(MainIpAddress, IP_Port_Arr, 0) == false)     // 判断主IP地址是否为空，为空则跳过
                {                  
                    return;
                }
                if (Crc16.Str_IsEmpty(SubIpAddrss) != true && GetIPAddress(SubIpAddrss, IP_Port_Arr, 4) == false)
                {
                    return;
                }
            }
            try
            {
                ushort PortNum = Convert.ToUInt16(Port_Num_TextBox.Text);   // 获取端口号
                IP_Port_Arr[8] = Convert.ToByte(PortNum & 0xFF);
                IP_Port_Arr[9] = Convert.ToByte(PortNum >> 8);
            }
            catch (Exception)
            {
                IP_Port_PictureBox.Image = Resources.Error;
                Dis_Rece_TextBox.AppendText("端口号超出范围(0-" + GSMCMDEnum.maxPortNum + ")，请重新输入\r\n");     // 错误提示
                return;
            }

            Rece_HexCheckBox.Checked = true;
            UsartFormatData(GSMCMDEnum.configIPAndPort, IP_Port_Arr, IP_Port_Arr.Length);
        }

        /// <summary>
        /// ip地址输入框点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IPAddress_MaskedTextBox_Click(object sender, EventArgs e)
        {
            MaskedTextBox maskedTextBox = (MaskedTextBox)sender;
            
            if (Crc16.Str_IsEmpty(maskedTextBox.Text) == true)       // 如果字符串为空，则将当前光标移到开始处
            {
                maskedTextBox.SelectionStart = 0;
            }
        }

        /// <summary>
        /// 清空累计流量
        /// </summary>
        public void set_meter_ql()
        {
            byte[] Meter_Clear = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

            UsartFormatData(0xF9, Meter_Clear, Meter_Clear.Length);

            Rece_HexCheckBox.Checked = true;

        }

        /// <summary>
        /// IP地址输入框按键检测事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IPAddress_MaskedTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            MaskedTextBox maskedTextBox = (MaskedTextBox)sender;
            
            switch (e.KeyChar)
            {
                case (char)46:
                case (char)12290:
                    PosIndex(maskedTextBox);
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// 编辑光标位置变动
        /// </summary>
        /// <param name="maskedTextBox"></param>
        public void PosIndex(MaskedTextBox maskedTextBox)
        {
            int[] posIndexArr = { 4, 8, 12, 15};           // 编辑位置editor
            int pos = maskedTextBox.SelectionStart;
            int max = (maskedTextBox.MaskedTextProvider.Length - maskedTextBox.MaskedTextProvider.EditPositionCount);
            int nextField = 0;
            for (int i = 0; i < maskedTextBox.MaskedTextProvider.Length; i++)
            {
                if (!maskedTextBox.MaskedTextProvider.IsEditPosition(i) && (pos + max) >= i)
                    nextField = i;
            }
            nextField += 1;
            try
            {
                if (Array.IndexOf(posIndexArr, maskedTextBox.SelectionStart) == -1)
                {
                    maskedTextBox.SelectionStart = nextField;
                }
                else
                {
                    maskedTextBox.SelectionStart = pos;
                }
            }
            catch (Exception)
            {

                
            }
        }

        /// <summary>
        /// 配置按键修改，项目编号，电流测试阈值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConfigButton_Click(object sender, EventArgs e)
        {
            Button MyButton = (Button)sender;
            int flag = Convert.ToInt32(MyButton.Tag);
            try
            {
                switch (flag)
                {
                    case 0:
                        // 将通道0的最大，最小值写到全局变量中
                        CurrentTestStruct.Chan0MaxValve = Convert.ToDouble(Chan0MaxValve_TextBox.Text);
                        CurrentTestStruct.Chan0MinValve = Convert.ToDouble(Chan0MinValve_TextBox.Text);
                        if (CurrentTestStruct.Chan0MaxValve < CurrentTestStruct.Chan0MinValve)
                        {
                            SystemTag_Lable.Text = "修改失败";
                            Dis_Rece_TextBox.AppendText("最大值不能比最小值小\r\n");
                            CurrentTestStruct.Chan0MaxValve = Convert.ToDouble(ConfigurationManager.AppSettings["SystemSettingConfig_Chan0MaxValve"]);
                            CurrentTestStruct.Chan0MinValve = Convert.ToDouble(ConfigurationManager.AppSettings["SystemSettingConfig_Chan0MinValve"]);
                            Chan0MaxValve_TextBox.Text = Convert.ToString(CurrentTestStruct.Chan0MaxValve);
                            Chan0MinValve_TextBox.Text = Convert.ToString(CurrentTestStruct.Chan0MinValve);
                            return;
                        }
                        AddUpdateAppSetting("SystemSettingConfig_Chan0MaxValve", Chan0MaxValve_TextBox.Text);
                        AddUpdateAppSetting("SystemSettingConfig_Chan0MinValve", Chan0MinValve_TextBox.Text);
                        SystemTag_Lable.Text = "修改成功";
                        break;
                    case 1:
                        // 将当前通道0的值写入该文本框
                        Chan0MaxValve_TextBox.Text = ConfigurationManager.AppSettings["SystemSettingConfig_Chan0MaxValve"];
                        Chan0MinValve_TextBox.Text = ConfigurationManager.AppSettings["SystemSettingConfig_Chan0MinValve"];
                        break;
                    case 2:
                        // 将通道1的最大，最小值写到全局变量中
                        CurrentTestStruct.Chan1MaxValve = Convert.ToDouble(Chan1MaxValve_TextBox.Text);
                        CurrentTestStruct.Chan1MinValve = Convert.ToDouble(Chan1MinValve_TextBox.Text);
                        
                        if (CurrentTestStruct.Chan1MaxValve < CurrentTestStruct.Chan1MinValve)
                        {
                            SystemTag_Lable.Text = "修改失败";
                            Dis_Rece_TextBox.AppendText("最大值不能比最小值小\r\n");
                            CurrentTestStruct.Chan0MaxValve = Convert.ToDouble(ConfigurationManager.AppSettings["SystemSettingConfig_Chan1MaxValve"]);
                            CurrentTestStruct.Chan0MinValve = Convert.ToDouble(ConfigurationManager.AppSettings["SystemSettingConfig_Chan1MinValve"]);
                            Chan0MaxValve_TextBox.Text = Convert.ToString(CurrentTestStruct.Chan1MaxValve);
                            Chan0MinValve_TextBox.Text = Convert.ToString(CurrentTestStruct.Chan1MinValve);
                            return;
                        }
                        AddUpdateAppSetting("SystemSettingConfig_Chan1MaxValve", Chan1MaxValve_TextBox.Text);
                        AddUpdateAppSetting("SystemSettingConfig_Chan1MinValve", Chan1MinValve_TextBox.Text);
                        SystemTag_Lable.Text = "修改成功";
                        break;
                    case 3:
                        // 将当前通道0的值写入该文本框
                        Chan1MaxValve_TextBox.Text = ConfigurationManager.AppSettings["SystemSettingConfig_Chan1MaxValve"];
                        Chan1MinValve_TextBox.Text = ConfigurationManager.AppSettings["SystemSettingConfig_Chan1MinValve"];
                        break;

                    case 4: // 将表号配置位数写入存档
                        TableNumBitLength = Convert.ToByte(TableNumConfig_TextBox.Text);
                        TableNumStartPos = Convert.ToByte(TableNumStartPos_TextBox.Text);
                        if(TableNumBitLength <= 0)
                        {
                            SystemTag_Lable.Text = "修改失败";
                            Dis_Rece_TextBox.AppendText("表号位数必须大于0\r\n");
                            TableNumBitLength = Convert.ToByte(ConfigurationManager.AppSettings["TableNumDefault"]);
                            TableNumConfig_TextBox.Text = Convert.ToString(TableNumBitLength);
                            return;
                        }
                        else if(TableNumStartPos > TableNumBitLength)
                        {
                            SystemTag_Lable.Text = "修改失败";
                            Dis_Rece_TextBox.AppendText("表号起始位置不能大于表号位数");
                            TableNumStartPos = Convert.ToByte(ConfigurationManager.AppSettings["SystenSetingTableNumStartPos"]);
                            return;
                        }   
                        
                        AddUpdateAppSetting("TableNumDefault", TableNumConfig_TextBox.Text);                // 表号的长度
                        AddUpdateAppSetting("SystenSetingTableNumStartPos", TableNumStartPos_TextBox.Text); // 表号起始位置
                        AddUpdateAppSetting("System_ProjectName", Project_Selection.ToString());            // 项目选择
                        SystemTag_Lable.Text = "修改成功";

                        break;
                    case 5:

                        TableNumStartPos_TextBox.Text = ConfigurationManager.AppSettings["SystenSetingTableNumStartPos"];
                        TableNumConfig_TextBox.Text = ConfigurationManager.AppSettings["TableNumDefault"];
                        Project_combox.SelectedIndex = Convert.ToByte(ConfigurationManager.AppSettings["System_ProjectName"]);

                        break;
                    case 6:
                        byte[] temparr = { 0xff };
                        UsartFormatData(GSMCMDEnum.getProNumDet, temparr, 1);
                        break;
                }
            }
            catch (Exception)
            {
                SystemTag_Lable.Text = "修改失败";
                Dis_Rece_TextBox.AppendText("请输入整数或者小数，不能输入字母和汉字\r\n");
            }
            Timer_StateUpdata.Start();
        }

        /// <summary>
        /// 添加更新程序设置
        /// </summary>
        /// <param name="key"></param>
        /// 键
        /// <param name="valve"></param>
        /// 值
        private void AddUpdateAppSetting(string key, string valve)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings[key] == null)
                {
                    settings.Add(key, valve);
                }
                else
                {
                    settings[key].Value = valve;
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (Exception)
            {
                MessageBox.Show("保存失败, 请重试", "ERROR");
            }
        }

        /// <summary>
        /// 加载数据
        /// </summary>
        private void LoadApp_CurrentConfig()
        {
            try
            {
                Chan0MaxValve_TextBox.Text = ConfigurationManager.AppSettings["SystemSettingConfig_Chan0MaxValve"];
                Chan0MinValve_TextBox.Text = ConfigurationManager.AppSettings["SystemSettingConfig_Chan0MinValve"];
                Chan1MaxValve_TextBox.Text = ConfigurationManager.AppSettings["SystemSettingConfig_Chan1MaxValve"];
                Chan1MinValve_TextBox.Text = ConfigurationManager.AppSettings["SystemSettingConfig_Chan1MinValve"];
                TableNumConfig_TextBox.Text = ConfigurationManager.AppSettings["TableNumDefault"];
                TableNumStartPos_TextBox.Text = ConfigurationManager.AppSettings["SystenSetingTableNumStartPos"];
                MainIPAddress_MaskedTextBox.Text = ConfigurationManager.AppSettings["TangShan_MainIP"];
                Port_Num_TextBox.Text = ConfigurationManager.AppSettings["TangShan_Port"];
                Project_combox.SelectedIndex = Convert.ToByte(ConfigurationManager.AppSettings["System_ProjectName"]);
                


                CurrentTestStruct.Chan0MaxValve = Convert.ToDouble(Chan0MaxValve_TextBox.Text);
                CurrentTestStruct.Chan0MinValve = Convert.ToDouble(Chan0MinValve_TextBox.Text);
                CurrentTestStruct.Chan1MaxValve = Convert.ToDouble(Chan1MaxValve_TextBox.Text);
                CurrentTestStruct.Chan1MinValve = Convert.ToDouble(Chan1MinValve_TextBox.Text);
                TableNumBitLength = Convert.ToByte(TableNumConfig_TextBox.Text);
                TableNumStartPos  = Convert.ToByte(TableNumStartPos_TextBox.Text);
                Project_Selection = Convert.ToByte(Project_combox.SelectedIndex);
                TestProject_TextBox.Text = Project_combox.Text;
            }
            catch (Exception)       // 如果没有配置文件，则会在这里写入默认初始值
            {
                CurrentTestStruct.Chan0MaxValve = 30f;
                CurrentTestStruct.Chan0MinValve = 0;
                CurrentTestStruct.Chan1MaxValve = 60f;
                CurrentTestStruct.Chan1MinValve = 0;
                TableNumBitLength = 8;
                TableNumStartPos = 1;
                IPandPortStruct.DefMainIpAddress = "211.143.68 .224";
                IPandPortStruct.DefPortNum = 6117;
                Project_Selection = 0;


                WriteInitialValve();
            }
        }

        /// <summary>
        /// 写入初始值
        /// </summary>
        private void WriteInitialValve()
        {
            Chan0MaxValve_TextBox.Text = Convert.ToString(CurrentTestStruct.Chan0MaxValve);
            AddUpdateAppSetting("SystemSettingConfig_Chan0MaxValve", Chan0MaxValve_TextBox.Text);

            Chan0MinValve_TextBox.Text = Convert.ToString(CurrentTestStruct.Chan0MinValve);
            AddUpdateAppSetting("SystemSettingConfig_Chan0MinValve", Chan0MinValve_TextBox.Text);

            Chan1MaxValve_TextBox.Text = Convert.ToString(CurrentTestStruct.Chan1MaxValve);
            AddUpdateAppSetting("SystemSettingConfig_Chan1MaxValve", Chan1MaxValve_TextBox.Text);

            Chan1MinValve_TextBox.Text = Convert.ToString(CurrentTestStruct.Chan1MinValve);
            AddUpdateAppSetting("SystemSettingConfig_Chan1MinValve", Chan1MinValve_TextBox.Text);

            TableNumConfig_TextBox.Text = Convert.ToString(TableNumBitLength);
            AddUpdateAppSetting("TableNumDefault", TableNumConfig_TextBox.Text);

            TableNumStartPos_TextBox.Text = Convert.ToString(TableNumStartPos);
            AddUpdateAppSetting("SystenSetingTableNumStartPos", TableNumStartPos_TextBox.Text);

            MainIPAddress_MaskedTextBox.Text = IPandPortStruct.DefMainIpAddress;
            AddUpdateAppSetting("TangShan_MainIP", MainIPAddress_MaskedTextBox.Text);

            Port_Num_TextBox.Text = Convert.ToString(IPandPortStruct.DefPortNum);
            AddUpdateAppSetting("TangShan_Port", Port_Num_TextBox.Text);

            Project_combox.SelectedIndex = Project_Selection;
            AddUpdateAppSetting("System_ProjectName", Project_Selection.ToString());


        }

        /// <summary>
        /// 打开升级Bin文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            //限制文件后缀为.Bin
            this.openRom.FileName = "*.bin";
            if (this.openRom.ShowDialog() == DialogResult.OK)
            {
                //文件文本框赋值
                this.txtRomPath.Text = openRom.FileName;
            }
            //判断文件名是否为空
            if (txtRomPath.Text != null && txtRomPath.Text != "")
            {
                //保存文件路径
                romPath = this.txtRomPath.Text.ToString().Trim();
            }
            else
            {
               Dis_Rece_TextBox.AppendText("获取文件路径出错!\r\n");
            }
            //判断文件是否存在
            if (!File.Exists(Frm_Main.romPath))
            {
                Dis_Rece_TextBox.AppendText("在磁盘中没有找到Bin文件!\r\n");
                return;
            }
            //准备固件包
            FileBytes.ReadyPacket(256, romPath);
        }

        /// <summary>
        /// 启动升级
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtRomPath.Text == "")
            {
                Dis_Rece_TextBox.AppendText("请选择升级文件!!!\r\n");
                return;
            }
            //获取启动固件升级数据包
            byte[] SendBytes = new byte[20];
            if (FactoryPattern_ChekedBox.Checked)
            {
                SendBytes = UpdateHelper.getFirmwareUpdate();
            }
            else
            {
                SendBytes = UpdateHelper.InfraredUpgrade();
            }

            //判断数据是否为空
            if (SendBytes == null)
            {
                return;
            }
            Rece_HexCheckBox.Checked = true;

            //发送数据
            if (SerialPortHelper.SendHex(SerialPort_Entity, SendBytes) == SerialPortHelper.SendData_Typedef.SendComp)
            {
                Dis_Rece_TextBox.AppendText(SerialPortHelper.GetTimeStamp() + "   擦除存储器中，请稍等\r\n");
            }
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void updateWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            //请求包数转deouble
            double num = Double.Parse(packetNum.ToString());
            //更新进度
            if (packetIndex != (packetNum))
            {
                startProgress(Convert.ToInt32((packetIndex + 1) / num * 100));
            }
            else{
                startProgress(100);
            }
            //设置提示图标
            if (packetIndex % 2 == 0)
            {
                pictureBox1.Image = Resources.green;
            }
            else
            {
                pictureBox1.Image = Resources.yellow;
            }
            //写信息到文本框
            Dis_Rece_TextBox.AppendText("升级（"+packetNum+"包）：发送第"+packetIndex+"包固件\r\n");
        }

        /// <summary>
        /// 进度改变时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void updateWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;

        }

        /// <summary>
        /// 进度完成时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void updateWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            progressBar1.Value = progressBar1.Value;
        }

        /// <summary>
        /// 更新进度条
        /// </summary>
        private void startProgress(int value)
        {
         
            progressBar1.Value = value;// 设置进度条初始值
            //执行PerformStep()函数
            progressBar1.PerformStep();
            updateProgress_Lable.Text = Math.Round(100.0 * packetIndex / packetNum, 2).ToString("#0.00") + "%";  // 设置当前传输进度
        }

        /// <summary>
        /// 初始化进度条
        /// </summary>
        private void initProgress()
        {
            progressBar1.Minimum = 0;// 设置进度条最小值.
            progressBar1.Maximum = 100;// 设置进度条最大值.
            progressBar1.Step = 1;// 设置每次增加的步长
            progressBar1.Visible = true;// 显示进度条控件.
        }

        /// <summary>
        /// 表号文本框按键处理事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TableNumber_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch(e.KeyChar)
            {
                case (char)13:
                    TableNnumber_Confirm_Button_Click(null, null);
                    break;
            }
        }

        /// <summary>
        /// 项目选择标志位修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Project_combox_SelectedIndexChanged(object sender, EventArgs e)
        {
            byte[] temp = new byte[1];
            switch(Project_combox.SelectedIndex.ToString())
            {
                case "0":
                    Project_Selection = 0;
                    TableNumConfig_TextBox.Text = "8";
                    break;
                case "1":
                    Project_Selection = 1;
                    TableNumConfig_TextBox.Text = "16";
                    break;
                default:
                    Project_Selection = 0;
                    TableNumConfig_TextBox.Text = "8";
                    break;
            }
            DefIPandPortWrite(Project_Selection);       // 选择写入IP默认值
            ConfigButton_Click(TableNumConfig_Confirm_Button, null);    // 保存设置
            //TestProject_TextBox.Text = Project_combox.Text; // 
            if(SerialPort_Entity.IsOpen)
            {
                temp[0] = Project_Selection;
                UsartFormatData(GSMCMDEnum.setProNumDet, temp, 1); // 向底板发送当前项目选项
            }
            
        }

        /// <summary>
        /// 关于按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripSplitButton_Regard_Clicked(object sender, EventArgs e)
        {
            
            if(View_content_Flag == 0)
            {
                if(form == null)
                {
                    form = new Frm_VersionInfo();
                    form.Show();
                }
                else
                {
                    form.Activate();
                }
                
            }
            else
            {
                
            }
        }

        /// <summary>
        /// 写入IP地址默认值
        /// </summary>
        /// <param name="projectNum"></param>
        private void DefIPandPortWrite(int projectNum)
        {
            switch (projectNum)
            {
                case 0:
                    MainIPAddress_MaskedTextBox.Text = ConfigurationManager.AppSettings["TangShan_MainIP"];
                    Port_Num_TextBox.Text = ConfigurationManager.AppSettings["TangShan_Port"];
                    break;
                case 1:
                    MainIPAddress_MaskedTextBox.Text = "";
                    Port_Num_TextBox.Text = "";
                    break;
                default:
                    break;
            }
        }

    }
} 
