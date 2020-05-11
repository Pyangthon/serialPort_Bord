using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace serialPort_Bord
{
    class UpdateHelper
    {
        /// <summary>
        /// 启动升级固件
        /// </summary>
        /// <param name="socket"></param>
        /// <param name="ep"></param>
        public static byte[] getFirmwareUpdate()
        {
            try
            {
                //创建包头
                StructHeader header = new StructHeader
                {
                    // 包头
                    HEAD = GSMCMDEnum.frameHead,
                    //启动固件升级
                    CMD = GSMCMDEnum.firmwareUpdate,
                    //帧长度
                    LEN = 17
                };
                //转换大小端
                header.LEN = BytesArrayHelper.SwapUInt16(header.LEN);
                //通信地址
                byte[] comAddr = { 0xAA, 0xAA, 0xAA, 0xAA, 0xAA };
                header.COMADDR = comAddr;
                //源类型
                header.SRC = 0xE1;
                //目标类型
                header.DEST = 0xA1;
                //数据域
                byte[] dataBytes = { 0xff };
                //转换包头
                byte[] headerBytes = StructToBytes(header);
                //创建总包bytes
                byte[] sendBytes = new byte[17];
                //拷贝Header
                Array.Copy(headerBytes, 0, sendBytes, 0, headerBytes.Length);
                //拷贝xxTea
                Array.Copy(dataBytes, 0, sendBytes, headerBytes.Length, dataBytes.Length);
                //crc
                ushort crc = Crc16.GetCRC16(sendBytes, sendBytes.Length - 5);
                // 创建2字节byte数组用于存放校验位
                byte[] Check_Arr = new byte[2];
                // 获取校验位高8位         
                Check_Arr[1] = Convert.ToByte(crc >> 8);
                // 获取校验位低8位   
                Check_Arr[0] = Convert.ToByte(crc & 0xFF);   
                //拷贝crc
                Array.Copy(Check_Arr, 0, sendBytes, sendBytes.Length - 5, 2);
                //包尾
                // sendBytes[sendBytes.Length - 1] = 0x16;
                sendBytes[sendBytes.Length - 3] = 0x2d;
                sendBytes[sendBytes.Length - 2] = 0x2d;
                sendBytes[sendBytes.Length - 1] = 0x45;
                //返回数据
                return sendBytes;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// 获取固件包
        /// </summary>
        /// <param name="reportBuffer">串口上报的数据，用于解析请求的index</param>
        /// <returns></returns>
        public static byte[] getFirmwarePag(byte[] reportBuffer)
        {
            try
            {
                //转读固件包结构
                ReadUpdateP readPag = (ReadUpdateP)BytesToStruct(reportBuffer, typeof(ReadUpdateP));
                //获取Index
                int index = readPag.index;
                //Index 赋值
                Frm_Main.packetIndex = index + 1;
                //取升级固件包
                Dstruct dataSt = Frm_Main.DataPacks[index];
                byte[] data = StructToBytes(dataSt);
                //升级包数据域
                Updatestruct upStruct = new Updatestruct();
                //创建包头
                StructHeader header = new StructHeader();
                // 添加包头
                header.HEAD = GSMCMDEnum.frameHead;
                //通信地址
                byte[] comAddr = { 0xAA, 0xAA, 0xAA, 0xAA, 0xAA };
                header.COMADDR = comAddr;
                //源类型
                header.SRC = 0xE1;
                //目标类型
                header.DEST = 0xA1;
                //命令码
                header.CMD = GSMCMDEnum.ackFirmware;
                //帧长度
                header.LEN = 14 + 256 + 2 + 3;
                //转换大小端
                header.LEN = BytesArrayHelper.SwapUInt16(header.LEN);
                //升级包编号
                upStruct.index = (byte)index;
                //固件总长度
                UInt16 fileLength = (UInt16)Frm_Main.fileLenth;
                //转换大端
                fileLength = BytesArrayHelper.SwapUInt16(fileLength);
                //设置总长度
                upStruct.fileLength = fileLength;
                //升级包
                upStruct.dPack = data;
                //数据域
                byte[] dataBytes = new byte[259];
                //赋值固件包数据
                dataBytes = StructToBytes(upStruct);
                //转换包头
                byte[] headerBytes = StructToBytes(header);
                //创建总包bytes
                byte[] sendBytes = new byte[headerBytes.Length + dataBytes.Length + 2 + 3];
                //拷贝Header
                Array.Copy(headerBytes, 0, sendBytes, 0, headerBytes.Length);
                //拷贝xxTea
                Array.Copy(dataBytes, 0, sendBytes, headerBytes.Length, dataBytes.Length);
                //crc
                UInt16 crc = Crc16.GetCRC16(sendBytes, sendBytes.Length - 5);
                // 创建2字节byte数组用于存放校验位
                byte[] Check_Arr = new byte[2];
                // 获取校验位高8位         
                Check_Arr[1] = Convert.ToByte(crc >> 8);
                // 获取校验位低8位   
                Check_Arr[0] = Convert.ToByte(crc & 0xFF);
                //拷贝crc
                Array.Copy(Check_Arr, 0, sendBytes, sendBytes.Length - 5, 2);
                //包尾
                sendBytes[sendBytes.Length - 3] = 0x2d;
                sendBytes[sendBytes.Length - 2] = 0x2d;
                sendBytes[sendBytes.Length - 1] = 0x45;

                //返回数据
                return sendBytes;
            
            }
            catch (Exception)
            {
                //若发送报错则关闭套接字
                return null;
            }
        }

      /// <summary>
      /// 判断是否升级成功
      /// </summary>
      /// <param name="reportBuffer"></param>
      /// <returns></returns>
        public static bool isSuccess(byte[] reportBuffer)
        {
            try
            {
                //转读固件包结构
                UpdateDoneP readPag = (UpdateDoneP)BytesToStruct(reportBuffer, typeof(UpdateDoneP));
                //获取success
                int success = readPag.success;
                //判断是否成功
                if (success > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {
                //若发送报错则关闭套接字
                return false;
            }
        }



        /// <summary>
        /// byte[]转换为struct  
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="strcutType"></param>
        /// <returns></returns>
        public static object BytesToStruct(byte[] bytes, Type strcutType)
        {
            int size = Marshal.SizeOf(strcutType);
            IntPtr buffer = Marshal.AllocHGlobal(size);
            try
            {
                Marshal.Copy(bytes, 0, buffer, size);
                return Marshal.PtrToStructure(buffer, strcutType);
            }
            finally
            {
                Marshal.FreeHGlobal(buffer);
            }
        }

        /// <summary>
        /// byte[]转换为struct  
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="index"></param>
        /// <param name="strcutType"></param>
        /// <returns></returns>
        public static object BytesToStruct(byte[] bytes, int index, Type strcutType)
        {
            int size = Marshal.SizeOf(strcutType);
            IntPtr buffer = Marshal.AllocHGlobal(size);
            try
            {
                Marshal.Copy(bytes, index, buffer, size);
                return Marshal.PtrToStructure(buffer, strcutType);
            }
            finally
            {
                Marshal.FreeHGlobal(buffer);
            }
        }

        //struct转换为  byte[]
        public static byte[] StructToBytes(object structObj)
        {
            int size = Marshal.SizeOf(structObj);
            IntPtr buffer = Marshal.AllocHGlobal(size);
            try
            {
                Marshal.StructureToPtr(structObj, buffer, false);
                byte[] bytes = new byte[size];
                Marshal.Copy(buffer, bytes, 0, size);
                return bytes;
            }
            finally
            {
                Marshal.FreeHGlobal(buffer);
            }
        }

        public static byte[] InfraredUpgrade()
        {
            try
            {
                byte[] sendBytes = new byte[14];
                Frm_Main.ConDefValve(sendBytes);
                sendBytes[1] = 14;
                sendBytes[GSMCMDEnum.detPos] = GSMCMDEnum.infUpdataDet;
                sendBytes[GSMCMDEnum.dataStartPos] = GSMCMDEnum.returnSuccess;
                Crc16.GetCrc16(sendBytes);
                sendBytes[sendBytes[1] - 1] = GSMCMDEnum.frameTail;
                //返回数据
                return sendBytes;
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}
