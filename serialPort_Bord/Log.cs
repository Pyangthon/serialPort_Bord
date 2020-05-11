using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace serialPort_Bord
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    namespace serialPort_Bord
    {
        class Log
        {
            private static object forLock = new object();
            public Log()
            {
                //
                // TODO: 在此处添加构造函数逻辑
                //
            }
            public static void WriteLog(string info)
            {
                try
                {
                    string AppPath = Environment.CurrentDirectory + @"/log"; // 结尾不带"/" 
                    if (Directory.Exists(AppPath) == false)
                        Directory.CreateDirectory(AppPath);

                    WriteLog(info, AppPath);
                }
                catch (Exception)
                { }
            }

            public static void WriteLog(string info, string dir)
            {

                lock (forLock)
                {

                    if (!Directory.Exists(dir))
                        Directory.CreateDirectory(dir);


                    string logfile = dir + @"\log" + DateTime.Now.ToString("yyMMdd") + ".txt";
                    FileStream fs;
                    if (!File.Exists(logfile))
                        fs = File.Create(logfile);
                    else
                        fs = File.Open(logfile, FileMode.Append);

                    StreamWriter streamWriter = new StreamWriter(fs);
                    streamWriter.BaseStream.Seek(0, SeekOrigin.End);
                    streamWriter.WriteLine(DateTime.Now.ToString("dd HH:mm:ss") + " " + info);
                    streamWriter.Flush();
                    fs.Close();
                    fs = null;
                }
            }
        }
    }

}
