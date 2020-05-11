using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace serialPort_Bord
{
    //以下是命令域CMD中需要用到的命令，服务器下行的命令
    class GSMCMDEnum
    {
        public const byte frameHead         = 0x68;         // 帧头
        public const byte firmwareUpdate    = 0xF4;         // 启动固件更新
        public const byte readFirmware      = 0xF5;         // 表头读固件
        public const byte ackFirmware       = 0xF6;         // 返回固件包
        public const byte updateDone        = 0xF7;         // 升级完成
        public const byte metercl           = 0XF9;         // 清除用气量
        public const byte configTableNum    = 0XFB;         // 配置表号
        public const byte configIPAndPort   = 0XFA;         // 配置IP和端口
        public const byte getIPAndPortDet   = 0XFC;         // 获取IP和端口
        public const byte returnSuccess     = 0XFF;         // 返回成功
        public const byte frameTail         = 0X16;         // 帧尾
        public const byte headWareDet       = 0XFD;         // 测试硬件(按键和阀门)
        public const byte detPos            = 0X09;         // 指令位置
        public const byte fBackPos          = 0X0A;         // 返回指令状态位置
        public const byte fixedLength       = 0X0D;         // 固定数据长度位数
        public const byte dataStartPos      = 0X0A;         // 数据开始位
        public const ushort maxPortNum      = 0XFFFF;       // 端口号最大值
        public const byte currentDet        = 0XBC;         // 电流测试指令
        public const byte testErrDet        = 0XE0;         // 电流检测失败
        public const byte chA               = 0XA0;         // 通道A
        public const byte chB               = 0XB0;         // 通道B      
        public const byte zeroVolt          = 0X0E;         // 零偏电压
        public const byte infUpdataDet      = 0XFD;         // APP模式升级
        public const byte buttonConfTabDet  = 0XF0;         // 按键设置表号指令
        public const byte tableNumMaxValve  = 0X99;         // 单位表号最大值
        public const byte setProNumDet      = 0X1F;         // 项目更换指令
        public const byte getProNumDet      = 0X2F;         // 获取项目编号指令
        public const byte getVersionNum     = 0XCD;         // 获取版本号
    }
}
