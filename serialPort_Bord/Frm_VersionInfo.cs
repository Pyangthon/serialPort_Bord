using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using serialPort_Bord.serialPort_Bord;
namespace serialPort_Bord
{
    public partial class Frm_VersionInfo : Form
    {
        public Frm_VersionInfo()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗口加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_VersionInfo_Load(object sender, EventArgs e)
        {
            VersionNum_Lable.Text = Frm_Main.VersionNum;       // 当前版本号

            foreach (var item in Frm_Main.Project_Name)        // 加载当前的项目列表
            {
                listBox_ProjectName.Items.Add(item);
            }

            currentProject_Lable.Text = Frm_Main.Project_Name[Frm_Main.Project_Selection];        // 当前服务项目选择
        }

        /// <summary>
        /// 窗口关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_VersionInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            Frm_Main.form = null;
        }
    }
}
