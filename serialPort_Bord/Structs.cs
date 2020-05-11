using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace serialPort_Bord
{
    /// <summary>
    /// 链路数据帧包头
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct StructHeader
    {
        public byte HEAD;                                       //数据帧头1
        public ushort LEN;                                       //数据域长度
        public byte SRC;                                        //源类型
        public byte DEST;                                       //目标类型
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]    //5字节0xaa
        public byte[] COMADDR;                                  //通信地址
        public byte CMD;                                        //指令码
    }

    /// <summary>
    /// 唐山上报应答数据
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct StructTsAckData
    {
        public uint time;            //表号
        public byte activeSeconds;     //保持连接数
    }

    //升级固件包结构
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct Dstruct      //分包
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]  //开辟256个字节长度符型数组 
        public byte[] dPack;   //数组名
    }

    //升级固件包数据域结构
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct Updatestruct      //分包
    {
        //升级包编号
        public byte index;
        //固件总长度
        public ushort fileLength;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]  //开辟256个字节长度符型数组 
        public byte[] dPack;   //数组名
    }

    //升级固件包数据域结构
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct ReadUpdateP      //读固件包
    {
        //包头
        StructHeader header;
        //升级包编号
        public byte index;
    }

    //升级固件完成数据结构
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct UpdateDoneP      //升级完成包
    {
        //包头
        StructHeader header;
        //升级完成标志
        public byte success;
    }
}

