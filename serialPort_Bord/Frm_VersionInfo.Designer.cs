using serialPort_Bord.Properties;

namespace serialPort_Bord
{
    partial class Frm_VersionInfo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.picBox_Companyinfo = new System.Windows.Forms.PictureBox();
            this.companyInfo_leble = new System.Windows.Forms.Label();
            this.Version_info_Lable = new System.Windows.Forms.Label();
            this.VersionNum_Lable = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.listBox_ProjectName = new System.Windows.Forms.ListBox();
            this.currentProject_Lable = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_Companyinfo)).BeginInit();
            this.SuspendLayout();
            // 
            // picBox_Companyinfo
            // 
            this.picBox_Companyinfo.BackgroundImage = global::serialPort_Bord.Properties.Resources.Company;
            this.picBox_Companyinfo.Location = new System.Drawing.Point(12, 28);
            this.picBox_Companyinfo.Name = "picBox_Companyinfo";
            this.picBox_Companyinfo.Size = new System.Drawing.Size(260, 56);
            this.picBox_Companyinfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picBox_Companyinfo.TabIndex = 0;
            this.picBox_Companyinfo.TabStop = false;
            // 
            // companyInfo_leble
            // 
            this.companyInfo_leble.AutoSize = true;
            this.companyInfo_leble.Font = new System.Drawing.Font("华文行楷", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.companyInfo_leble.Location = new System.Drawing.Point(290, 39);
            this.companyInfo_leble.Name = "companyInfo_leble";
            this.companyInfo_leble.Size = new System.Drawing.Size(275, 19);
            this.companyInfo_leble.TabIndex = 1;
            this.companyInfo_leble.Text = "瑞臻信息技术（深圳）有限公司";
            // 
            // Version_info_Lable
            // 
            this.Version_info_Lable.AutoSize = true;
            this.Version_info_Lable.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Version_info_Lable.Location = new System.Drawing.Point(8, 131);
            this.Version_info_Lable.Name = "Version_info_Lable";
            this.Version_info_Lable.Size = new System.Drawing.Size(37, 20);
            this.Version_info_Lable.TabIndex = 2;
            this.Version_info_Lable.Text = "版本";
            // 
            // VersionNum_Lable
            // 
            this.VersionNum_Lable.AutoSize = true;
            this.VersionNum_Lable.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.VersionNum_Lable.Location = new System.Drawing.Point(43, 131);
            this.VersionNum_Lable.Name = "VersionNum_Lable";
            this.VersionNum_Lable.Size = new System.Drawing.Size(48, 20);
            this.VersionNum_Lable.TabIndex = 3;
            this.VersionNum_Lable.Text = "V1.0.1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(343, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Microsoft.Net Framweork";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(343, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "版本 V4.5.0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(8, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "可服务项目";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(8, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "单板测试工装夹具助手";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("华文行楷", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(308, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(248, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "努力奋斗成为一家伟大的科技公司";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(343, 156);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 20);
            this.label6.TabIndex = 1;
            this.label6.Text = "当前服务项目";
            // 
            // listBox_ProjectName
            // 
            this.listBox_ProjectName.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listBox_ProjectName.FormattingEnabled = true;
            this.listBox_ProjectName.ItemHeight = 20;
            this.listBox_ProjectName.Location = new System.Drawing.Point(12, 182);
            this.listBox_ProjectName.Name = "listBox_ProjectName";
            this.listBox_ProjectName.ScrollAlwaysVisible = true;
            this.listBox_ProjectName.Size = new System.Drawing.Size(312, 104);
            this.listBox_ProjectName.TabIndex = 6;
            // 
            // currentProject_Lable
            // 
            this.currentProject_Lable.AutoSize = true;
            this.currentProject_Lable.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.currentProject_Lable.ForeColor = System.Drawing.Color.SteelBlue;
            this.currentProject_Lable.Location = new System.Drawing.Point(343, 182);
            this.currentProject_Lable.Name = "currentProject_Lable";
            this.currentProject_Lable.Size = new System.Drawing.Size(65, 20);
            this.currentProject_Lable.TabIndex = 1;
            this.currentProject_Lable.Text = "当前项目";
            // 
            // Frm_VersionInfo
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(568, 316);
            this.Controls.Add(this.listBox_ProjectName);
            this.Controls.Add(this.VersionNum_Lable);
            this.Controls.Add(this.Version_info_Lable);
            this.Controls.Add(this.currentProject_Lable);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.companyInfo_leble);
            this.Controls.Add(this.picBox_Companyinfo);
            this.Icon = global::serialPort_Bord.Properties.Resources.about;
            this.MaximizeBox = false;
            this.Name = "Frm_VersionInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "版本信息";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_VersionInfo_FormClosing);
            this.Load += new System.EventHandler(this.Frm_VersionInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBox_Companyinfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picBox_Companyinfo;
        private System.Windows.Forms.Label companyInfo_leble;
        private System.Windows.Forms.Label Version_info_Lable;
        private System.Windows.Forms.Label VersionNum_Lable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox listBox_ProjectName;
        private System.Windows.Forms.Label currentProject_Lable;
    }
}