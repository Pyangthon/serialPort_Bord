using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static serialPort_Bord.Frm_Main;

namespace serialPort_Bord
{
    class FileBytes
    {

        //读filename到byte[]

        public static byte[] ReadFile(string fileName)
        {

            FileStream pFileStream = null;

            byte[] pReadByte = new byte[0];

            try

            {

                pFileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);

                BinaryReader r = new BinaryReader(pFileStream);

                r.BaseStream.Seek(0, SeekOrigin.Begin);    //将文件指针设置到文件开

                pReadByte = r.ReadBytes((int)r.BaseStream.Length);

                return pReadByte;

            }

            catch

            {

                return pReadByte;

            }

            finally

            {

                if (pFileStream != null)

                    pFileStream.Close();

            }

        }

        //写byte[]到fileName

        public static bool writeFile(byte[] pReadByte, string fileName)

        {

            FileStream pFileStream = null;



            try

            {

                pFileStream = new FileStream(fileName, FileMode.OpenOrCreate);

                pFileStream.Write(pReadByte, 0, pReadByte.Length);



            }

            catch

            {

                return false;

            }

            finally

            {

                if (pFileStream != null)

                    pFileStream.Close();

            }

            return true;

        }

        /// <summary>
        /// 准备升级固件包
        /// </summary>
        /// <returns></returns>
        public static void ReadyPacket(int FileSize,string romPath)
        {
            int FileLenth = 0;     //文件长度
            byte PacketNum = 0;   //包数

            if (!File.Exists(romPath))
            {
              //  MessageBox.Show("无Bin文件！", "错误");
                return;
            }
            FileInfo file = new FileInfo(romPath);     //文件路径
            FileLenth = (int)file.Length; //先把long型转化成字符型，再把字符型转化成int型

            if (file.Length % FileSize == 0)
                PacketNum = byte.Parse((file.Length / FileSize + 1).ToString());
            else
                PacketNum = byte.Parse((file.Length / FileSize + 1).ToString());

            Frm_Main.fileLenth = FileLenth;  //升级总字节数
            Frm_Main.packetNum = PacketNum;  //升级包个数
            
            //获取固件包List
            GetDataPack(FileSize,romPath);
        }

        /// <summary>
        /// 从文件中获取数据包，并将其保存在list中
        /// </summary>
        /// 4G集中器一包512个字节，2G集中器一包1024个字节
        public static void GetDataPack(int FileSize,string romPath)
        {
           
            //清空缓存数据包列表
           Frm_Main.DataPacks.Clear();
            //新建缓存buffer    
            byte[] buffer = new byte[FileSize];
            //打开文件
            System.IO.FileStream file = new System.IO.FileStream(romPath, FileMode.Open, FileAccess.Read);  //句柄
            //循环读取文件
            while (true)
            {
                //加锁
                lock (buffer)
                {
                    //情况缓存buffer
                    Array.Clear(buffer, 0, FileSize);
                    //异步读取文件
                    Task<int> r = file.ReadAsync(buffer, 0, FileSize);
                    //返回结果为零则表示读取完了
                    if (r.Result == 0)
                    {
                        file.Close();
                        return;
                    }
                    //将读取到的buffer封包
                    Dstruct bufStruct = (Dstruct)UpdateHelper.BytesToStruct(buffer, typeof(Dstruct));
                    //添加到缓存列表中
                    DataPacks.Add(bufStruct);
                }
            }
        }
    }
}
