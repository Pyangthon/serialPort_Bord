using System;
using System.Text;
using System.IO.Ports;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Management;

namespace serialPort_Bord
{
    class SerialPortHelper
    {
        public enum SendData_Typedef        // 发送数据返回状态
        {
            SendError,      // 发送错误
            SendComp,       // 发送完成
            SendNull,       // 发送值为空
            PortError       // 串口错误
        }

        /// <summary>
        /// 枚举win32 api
        /// </summary>
        private enum HardwareEnum
        {
            // 硬件
            Win32_Processor, // CPU 处理器
            Win32_PhysicalMemory, // 物理内存条
            Win32_Keyboard, // 键盘
            Win32_PointingDevice, // 点输入设备，包括鼠标。
            Win32_FloppyDrive, // 软盘驱动器
            Win32_DiskDrive, // 硬盘驱动器
            Win32_CDROMDrive, // 光盘驱动器
            Win32_BaseBoard, // 主板
            Win32_BIOS, // BIOS 芯片
            Win32_ParallelPort, // 并口
            Win32_SerialPort, // 串口
            Win32_SerialPortConfiguration, // 串口配置
            Win32_SoundDevice, // 多媒体设置，一般指声卡。
            Win32_SystemSlot, // 主板插槽 (ISA & PCI & AGP)
            Win32_USBController, // USB 控制器
            Win32_NetworkAdapter, // 网络适配器
            Win32_NetworkAdapterConfiguration, // 网络适配器设置
            Win32_Printer, // 打印机
            Win32_PrinterConfiguration, // 打印机设置
            Win32_PrintJob, // 打印机任务
            Win32_TCPIPPrinterPort, // 打印机端口
            Win32_POTSModem, // MODEM
            Win32_POTSModemToSerialPort, // MODEM 端口
            Win32_DesktopMonitor, // 显示器
            Win32_DisplayConfiguration, // 显卡
            Win32_DisplayControllerConfiguration, // 显卡设置
            Win32_VideoController, // 显卡细节。
            Win32_VideoSettings, // 显卡支持的显示模式。

            // 操作系统
            Win32_TimeZone, // 时区
            Win32_SystemDriver, // 驱动程序
            Win32_DiskPartition, // 磁盘分区
            Win32_LogicalDisk, // 逻辑磁盘
            Win32_LogicalDiskToPartition, // 逻辑磁盘所在分区及始末位置。
            Win32_LogicalMemoryConfiguration, // 逻辑内存配置
            Win32_PageFile, // 系统页文件信息
            Win32_PageFileSetting, // 页文件设置
            Win32_BootConfiguration, // 系统启动配置
            Win32_ComputerSystem, // 计算机信息简要
            Win32_OperatingSystem, // 操作系统信息
            Win32_StartupCommand, // 系统自动启动程序
            Win32_Service, // 系统安装的服务
            Win32_Group, // 系统管理组
            Win32_GroupUser, // 系统组帐号
            Win32_UserAccount, // 用户帐号
            Win32_Process, // 系统进程
            Win32_Thread, // 系统线程
            Win32_Share, // 共享
            Win32_NetworkClient, // 已安装的网络客户端
            Win32_NetworkProtocol, // 已安装的网络协议
            Win32_PnPEntity,//all device
        }

        /// <summary>
        /// 发送16进制数据，不带长度
        /// </summary>
        /// <param name="serialPort"></param>
        /// <param name="hexArr"></param>
        /// <returns></returns>
        public SendData_Typedef SendHex(SerialPort serialPort, byte[] hexArr)
        {
            if (serialPort.IsOpen)
            {
                try
                {
                    byte[] data = new byte[1];      // 存放需要写入串口的数据
                    for (int i = 0; i < hexArr.Length; i++)
                    {
                        data[0] = hexArr[i];    // 将数据数组转换为二进制数据
                        serialPort.Write(data, 0, 1);               // 发送数据
                    }
                    return SendData_Typedef.SendComp;
                }
                catch (Exception)
                {
                    return SendData_Typedef.SendError;
                }
            }
            else
            {
                MessageBox.Show("串口未打开", "ERROR");
                return SendData_Typedef.PortError;
            }
        }

        /// <summary>
        /// 发送16进制数据，并需要带长度
        /// </summary>
        /// <param name="serialPort"></param>
        /// <param name="hexArr"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public SendData_Typedef SendHex(SerialPort serialPort, byte[] hexArr, int len)
        {
            if (serialPort.IsOpen)
            {
                try
                {
                    byte[] data = new byte[1];      // 存放需要写入串口的数据
                    for (int i = 0; i < len; i++)
                    {
                        data[0] = hexArr[i];    // 将数据数组转换为二进制数据
                        serialPort.Write(data, 0, 1);               // 发送数据
                    }
                    return SendData_Typedef.SendComp;
                }
                catch (Exception)
                {
                    return SendData_Typedef.SendError;
                }
            }
            else
            {
                MessageBox.Show("串口未打开", "ERROR");
                return SendData_Typedef.PortError;
            }
        }

        /// <summary>
        /// 获取串口号
        /// </summary>
        /// <param name="comboBox">串口号填写的下拉框控件</param>
        public void GetSerialName(ComboBox comboBox)
        {
            string[] portNames = SerialPort.GetPortNames();     // 获取串口名
            foreach (string name in portNames)  // 将获取到的串口名称加到串口名称下拉框中
            {
                comboBox.Items.Add(name);
            }
            if ((comboBox.Items.Count != 0) && (comboBox.Text == ""))    // 如果串口下拉框中存在串口名称则将第一个串口名设置为串口下拉框的默认text属性
            {
                comboBox.Text = (string)comboBox.Items[0];
            }
            else  // 没有则为空
            {
                comboBox.Text = "";
            }
        }

        /// <summary>
        /// 发送字符串
        /// </summary>
        /// <param name="serialPort">需要发送的串口名称</param>
        /// <param name="str">需要发送的字符串</param>
        /// <returns></returns>
        public SendData_Typedef SendStr(SerialPort serialPort, string str)
        {
            try
            {
                Encoding encoding = System.Text.Encoding.GetEncoding("GB2312");
                byte[] bytes = encoding.GetBytes(str);
                serialPort.Write(bytes, 0, bytes.Length);
                return SendData_Typedef.SendComp;
            }
            catch (Exception)
            {
                return SendData_Typedef.SendError;
            }
        }

        /// <summary>
        /// 将字符串模式的byte数组转换为实际意义的byte数组
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static byte[] HexStringToByteArray(string str)
        {
            str = str.Replace(" ", "");                 //先替换其中的空格等
            byte[] buffer = new byte[str.Length / 2];   //新建一个byte数组用来保存，长度是字符串长度的一半
            for (int i = 0; i < str.Length; i += 2)     //循环遍历字符串来赋值给byte数组
            {
                buffer[i / 2] = (byte)Convert.ToByte(str.Substring(i, 2), 16);  //按2位来截取转换为byte数据
            }
            return buffer;//返回转换之后的byte数组
        }

        /// <summary>
        /// 将数字转换成BCD码
        /// </summary>
        /// <param name="num"></param>
        /// <param name="arr"></param>
        public uint[] ConverBCD(uint num)
        {
            uint bit = num;
            uint t = 100;
            byte Len = NumLength(bit);
            if (Len % 2 == 0)
            {
                uint[] Arr = new uint[Len / 2];
                string[] tempArr = new string[Len / 2];
                uint[] arr = new uint[Len / 2];
                for (int i = 0; i < Len / 2; i++)
                {
                    Arr[i] = bit % t;
                    tempArr[i] = Convert.ToString(Arr[i]);                   
                    arr[i] = Convert.ToUInt16(tempArr[i], 16);
                    bit /= t;
                }
                return arr;
            }
            else
            {
                uint[] Arr = new uint[Len / 2 + 1];
                string[] tempArr = new string[Len / 2 + 1];
                uint[] arr = new uint[Len / 2 + 1];
                for (int i = 0; i < Len / 2 + 1; i++)
                {
                    Arr[i] = bit % t;
                    tempArr[i] = Convert.ToString(Arr[i]);                    
                    arr[i] = Convert.ToUInt16(tempArr[i], 16);
                    bit /= t;
                }
                return arr;
            }
        }

        /// <summary>
        /// 获取uint型数字的位数
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public byte NumLength(uint num)
        {
            byte bit = 0;
            while (num > 0)
            {
                num /= 10;
                bit++;
            }
            return bit;
        }

        /// <summary>
        /// 在文本框中打印byte字符(纯数字)(IP地址)
        /// </summary>
        /// <param name="Arr"></param>  需要输出的数组
        /// <param name="textBox"></param>  输出的位置
        public void PrintIP(byte[] Arr, TextBox textBox)
        {
            for (int i = 0; i < Arr.Length; i++)
            {
                textBox.AppendText(Convert.ToString(Arr[i]));   // 将数据转换成字符串并输出到文本框中 
                if (i < 3)
                {
                    textBox.AppendText(".");    // IP中的点
                }
            }
            textBox.AppendText("\r\n");     // 输出换行
        }

        /// <summary>
        /// 将字符串转为BCD码
        /// </summary>
        /// <param name="asc"></param>
        /// <returns></returns>
        public byte[] Str2Bcd(string asc)
        {
            int len = asc.Length;
            int mod = len % 2;

            if (mod != 0)
            {
                asc = "0" + asc;
                len = asc.Length;
            }

            byte[] abt = new byte[len];
            if (len >= 2)
            {
                len /= 2;
            }

            byte[] bbt = new byte[len];
            abt = Encoding.ASCII.GetBytes(asc);
            int j, k;

            for (int p = 0; p < asc.Length / 2; p++)
            {
                if ((abt[2 * p] >= '0') && (abt[2 * p] <= '9'))
                {
                    j = abt[2 * p] - '0';
                }
                else if ((abt[2 * p] >= 'a') && (abt[2 * p] <= 'z'))
                {
                    j = abt[2 * p] - 'a' + 0x0a;
                }
                else
                {
                    j = abt[2 * p] - 'A' + 0x0a;
                }

                if ((abt[2 * p + 1] >= '0') && (abt[2 * p + 1] <= '9'))
                {
                    k = abt[2 * p + 1] - '0';
                }
                else if ((abt[2 * p + 1] >= 'a') && (abt[2 * p + 1] <= 'z'))
                {
                    k = abt[2 * p + 1] - 'a' + 0x0a;
                }
                else
                {
                    k = abt[2 * p + 1] - 'A' + 0x0a;
                }

                int a = (j << 4) + k;
                byte b = (byte)a;
                bbt[p] = b;
            }
            return bbt;
        }

        /// <summary>
        /// BCD码转成字符串
        /// </summary>
        /// <param name="bcdNum">BCD码数组</param>
        /// <returns></returns>
        public string BCDToString(byte[] bcdNum)
        {
            StringBuilder temp = new StringBuilder(bcdNum.Length * 2);

            for (int i = 0; i < bcdNum.Length; i++)
            {
                temp.Append(string.Format("{0:X2}", bcdNum[i]));
            }
            
            return temp.ToString();
        }

        /// <summary>
        /// 16进制字符串转数组
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        public string GetChsFromHex(string hex)
        {
            if (hex == null)
            {
                return "";
            }

            if (hex.Length % 2 != 0)
            {
                hex += "20";//空格
                            //throw new ArgumentException("hex is not a valid number!", "hex");
            }

            // 需要将 hex 转换成 byte 数组。
            byte[] bytes = new byte[hex.Length / 2];

            for (int i = 0; i < bytes.Length; i++)
            {
                try
                {
                    // 每两个字符是一个 byte。
                    bytes[i] = byte.Parse(hex.Substring(i * 2, 2),
                    System.Globalization.NumberStyles.HexNumber);
                }
                catch
                {
                    // Rethrow an exception with custom message.
                    throw new ArgumentException("hex is not a valid hex number!", "hex");
                }
            }

            // 获得 GB2312，Chinese Simplified。
            Encoding chs = System.Text.Encoding.GetEncoding("GB2312");
            return chs.GetString(bytes);
        }
        
        /// <summary>
        /// WMI取硬件信息
        /// </summary>
        /// <param name="hardType"></param>
        /// <param name="propKey"></param>
        /// <returns></returns>
        private string[] MulGetHardwareInfo(HardwareEnum hardType, string propKey)
        {
            List<string> strs = new List<string>();
            try
            {
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from " + hardType))
                {
                    var hardInfos = searcher.Get();
                    foreach (var hardInfo in hardInfos)
                    {
                        if (hardInfo.Properties[propKey].Value != null && hardInfo.Properties[propKey].Value.ToString().Contains("COM"))
                        {
                            strs.Add(hardInfo.Properties[propKey].Value.ToString());
                        }

                    }
                    searcher.Dispose();
                }

                return strs.ToArray();
            }
            catch
            {
                return strs.ToArray();
            }
        }

        /// <summary>
        /// 串口信息
        /// </summary>
        /// <returns></returns>
        public string[] GetSerialPort()
        {
            return MulGetHardwareInfo(HardwareEnum.Win32_PnPEntity, "Name");
        }

        /// <summary>
        /// 获取时间戳
        /// </summary>
        /// <returns></returns>
        public string GetTimeStamp()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}
