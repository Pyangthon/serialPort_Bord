using serialPort_Bord.Properties;

namespace serialPort_Bord
{
    partial class Frm_Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Main));
            this.SerialNum_ComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SerialOption_Button = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.BuadRate_ComboBox = new System.Windows.Forms.ComboBox();
            this.SendData_Button = new System.Windows.Forms.Button();
            this.SendHex_CheckBox = new System.Windows.Forms.CheckBox();
            this.Current_Button = new System.Windows.Forms.Button();
            this.ZeroBia_CheckBox = new System.Windows.Forms.CheckBox();
            this.Reset_Button = new System.Windows.Forms.Button();
            this.Key_Button = new System.Windows.Forms.Button();
            this.HeadWare_Button = new System.Windows.Forms.Button();
            this.OpenValve_Button = new System.Windows.Forms.Button();
            this.SerialPort_Entity = new System.IO.Ports.SerialPort(this.components);
            this.ClearReceDis_Button = new System.Windows.Forms.Button();
            this.ClearSendData_Button = new System.Windows.Forms.Button();
            this.Chan0MaxValve_TextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Chan0MinValve_TextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Chan1MinValve_TextBox = new System.Windows.Forms.TextBox();
            this.Chan1MaxValve_TextBox = new System.Windows.Forms.TextBox();
            this.Chan0Cancel_Button = new System.Windows.Forms.Button();
            this.Chan0Confirm_Button = new System.Windows.Forms.Button();
            this.SendData_TextBox = new System.Windows.Forms.TextBox();
            this.Chan1Confirm_Button = new System.Windows.Forms.Button();
            this.Chan1Cancel_Button = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.Project_combox = new System.Windows.Forms.ComboBox();
            this.TableNumStartPos_TextBox = new System.Windows.Forms.TextBox();
            this.TableNumConfig_TextBox = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.SystemTag_Lable = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.TableNumConfig_Confirm_Button = new System.Windows.Forms.Button();
            this.TableNum_Cancel_Button = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.updateProgress_Lable = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label21 = new System.Windows.Forms.Label();
            this.FactoryPattern_ChekedBox = new System.Windows.Forms.CheckBox();
            this.label20 = new System.Windows.Forms.Label();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.txtRomPath = new System.Windows.Forms.TextBox();
            this.OPenValve_PictureBox = new System.Windows.Forms.PictureBox();
            this.HeadWare_PictureBox = new System.Windows.Forms.PictureBox();
            this.Key_PictureBox = new System.Windows.Forms.PictureBox();
            this.SerialPortState_PictureBox = new System.Windows.Forms.PictureBox();
            this.Current_PictureBox = new System.Windows.Forms.PictureBox();
            this.Timer_StateUpdata = new System.Windows.Forms.Timer(this.components);
            this.SerialPort_Update = new System.Windows.Forms.Timer(this.components);
            this.label14 = new System.Windows.Forms.Label();
            this.TableNumber_TextBox = new System.Windows.Forms.TextBox();
            this.TableNnumber_Confirm_Button = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.IP_PORT_Confirm_Button = new System.Windows.Forms.Button();
            this.Port_Num_TextBox = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.TableNum_PictureBox = new System.Windows.Forms.PictureBox();
            this.IP_Port_PictureBox = new System.Windows.Forms.PictureBox();
            this.MainIPAddress_MaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.meter_CheckBox = new System.Windows.Forms.CheckBox();
            this.IPandPortConfig_checkBox = new System.Windows.Forms.CheckBox();
            this.tableNumAutoAdd_checkbox = new System.Windows.Forms.CheckBox();
            this.SubIPAddress_MaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.GetIP_PictureBox = new System.Windows.Forms.PictureBox();
            this.GetIP_Button = new System.Windows.Forms.Button();
            this.GetVersion_PictureBox = new System.Windows.Forms.PictureBox();
            this.GetVersion_Button = new System.Windows.Forms.Button();
            this.Rece_HexCheckBox = new System.Windows.Forms.CheckBox();
            this.Dis_Rece_TextBox = new System.Windows.Forms.TextBox();
            this.updateWorker = new System.ComponentModel.BackgroundWorker();
            this.openRom = new System.Windows.Forms.OpenFileDialog();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.CheckResult_PictureBox = new System.Windows.Forms.PictureBox();
            this.Muen_toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripSplitButton_Regard = new System.Windows.Forms.ToolStripSplitButton();
            this.ToolStripMenuItem_ViewVersion = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_VersionNum = new System.Windows.Forms.ToolStripTextBox();
            this.ToolStripMenuItem_TestProject = new System.Windows.Forms.ToolStripMenuItem();
            this.TestProject_TextBox = new System.Windows.Forms.ToolStripTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ProNum_Textbox = new System.Windows.Forms.TextBox();
            this.btnGetProNum = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OPenValve_PictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeadWare_PictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Key_PictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SerialPortState_PictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Current_PictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableNum_PictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IP_Port_PictureBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GetIP_PictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GetVersion_PictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckResult_PictureBox)).BeginInit();
            this.Muen_toolStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SerialNum_ComboBox
            // 
            this.SerialNum_ComboBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.SerialNum_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SerialNum_ComboBox.FormattingEnabled = true;
            resources.ApplyResources(this.SerialNum_ComboBox, "SerialNum_ComboBox");
            this.SerialNum_ComboBox.Name = "SerialNum_ComboBox";
            this.SerialNum_ComboBox.Sorted = true;
            this.SerialNum_ComboBox.Click += new System.EventHandler(this.SerialNum_ComboBox_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.label1.Name = "label1";
            // 
            // SerialOption_Button
            // 
            this.SerialOption_Button.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.SerialOption_Button, "SerialOption_Button");
            this.SerialOption_Button.Name = "SerialOption_Button";
            this.SerialOption_Button.UseVisualStyleBackColor = true;
            this.SerialOption_Button.Click += new System.EventHandler(this.SerialOption_Button_Click);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Cursor = System.Windows.Forms.Cursors.Default;
            this.label2.Name = "label2";
            // 
            // BuadRate_ComboBox
            // 
            this.BuadRate_ComboBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.BuadRate_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BuadRate_ComboBox.FormattingEnabled = true;
            resources.ApplyResources(this.BuadRate_ComboBox, "BuadRate_ComboBox");
            this.BuadRate_ComboBox.Name = "BuadRate_ComboBox";
            // 
            // SendData_Button
            // 
            resources.ApplyResources(this.SendData_Button, "SendData_Button");
            this.SendData_Button.Name = "SendData_Button";
            this.SendData_Button.UseVisualStyleBackColor = true;
            this.SendData_Button.Click += new System.EventHandler(this.SendData_Button_Click);
            // 
            // SendHex_CheckBox
            // 
            resources.ApplyResources(this.SendHex_CheckBox, "SendHex_CheckBox");
            this.SendHex_CheckBox.Name = "SendHex_CheckBox";
            this.SendHex_CheckBox.UseVisualStyleBackColor = true;
            // 
            // Current_Button
            // 
            this.Current_Button.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.Current_Button, "Current_Button");
            this.Current_Button.Name = "Current_Button";
            this.Current_Button.Tag = "0";
            this.Current_Button.UseVisualStyleBackColor = true;
            this.Current_Button.Click += new System.EventHandler(this.Button_Click);
            // 
            // ZeroBia_CheckBox
            // 
            resources.ApplyResources(this.ZeroBia_CheckBox, "ZeroBia_CheckBox");
            this.ZeroBia_CheckBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.ZeroBia_CheckBox.Name = "ZeroBia_CheckBox";
            this.ZeroBia_CheckBox.UseVisualStyleBackColor = true;
            // 
            // Reset_Button
            // 
            this.Reset_Button.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.Reset_Button, "Reset_Button");
            this.Reset_Button.Name = "Reset_Button";
            this.Reset_Button.Tag = "5";
            this.Reset_Button.UseVisualStyleBackColor = true;
            this.Reset_Button.Click += new System.EventHandler(this.Button_Click);
            // 
            // Key_Button
            // 
            this.Key_Button.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.Key_Button, "Key_Button");
            this.Key_Button.Name = "Key_Button";
            this.Key_Button.Tag = "1";
            this.Key_Button.UseVisualStyleBackColor = true;
            this.Key_Button.Click += new System.EventHandler(this.Button_Click);
            // 
            // HeadWare_Button
            // 
            this.HeadWare_Button.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.HeadWare_Button, "HeadWare_Button");
            this.HeadWare_Button.Name = "HeadWare_Button";
            this.HeadWare_Button.Tag = "";
            this.HeadWare_Button.UseVisualStyleBackColor = true;
            this.HeadWare_Button.Click += new System.EventHandler(this.HeadWare_Button_Click);
            // 
            // OpenValve_Button
            // 
            this.OpenValve_Button.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.OpenValve_Button, "OpenValve_Button");
            this.OpenValve_Button.Name = "OpenValve_Button";
            this.OpenValve_Button.Tag = "3";
            this.OpenValve_Button.UseVisualStyleBackColor = true;
            this.OpenValve_Button.Click += new System.EventHandler(this.Button_Click);
            // 
            // ClearReceDis_Button
            // 
            this.ClearReceDis_Button.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.ClearReceDis_Button, "ClearReceDis_Button");
            this.ClearReceDis_Button.Name = "ClearReceDis_Button";
            this.ClearReceDis_Button.UseVisualStyleBackColor = true;
            this.ClearReceDis_Button.Click += new System.EventHandler(this.ClearReceDis_Button_Click);
            // 
            // ClearSendData_Button
            // 
            resources.ApplyResources(this.ClearSendData_Button, "ClearSendData_Button");
            this.ClearSendData_Button.Name = "ClearSendData_Button";
            this.ClearSendData_Button.UseVisualStyleBackColor = true;
            this.ClearSendData_Button.Click += new System.EventHandler(this.ClearSendData_Button_Click);
            // 
            // Chan0MaxValve_TextBox
            // 
            resources.ApplyResources(this.Chan0MaxValve_TextBox, "Chan0MaxValve_TextBox");
            this.Chan0MaxValve_TextBox.Name = "Chan0MaxValve_TextBox";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // Chan0MinValve_TextBox
            // 
            resources.ApplyResources(this.Chan0MinValve_TextBox, "Chan0MinValve_TextBox");
            this.Chan0MinValve_TextBox.Name = "Chan0MinValve_TextBox";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // Chan1MinValve_TextBox
            // 
            resources.ApplyResources(this.Chan1MinValve_TextBox, "Chan1MinValve_TextBox");
            this.Chan1MinValve_TextBox.Name = "Chan1MinValve_TextBox";
            // 
            // Chan1MaxValve_TextBox
            // 
            resources.ApplyResources(this.Chan1MaxValve_TextBox, "Chan1MaxValve_TextBox");
            this.Chan1MaxValve_TextBox.Name = "Chan1MaxValve_TextBox";
            // 
            // Chan0Cancel_Button
            // 
            resources.ApplyResources(this.Chan0Cancel_Button, "Chan0Cancel_Button");
            this.Chan0Cancel_Button.Name = "Chan0Cancel_Button";
            this.Chan0Cancel_Button.Tag = "1";
            this.Chan0Cancel_Button.UseVisualStyleBackColor = true;
            this.Chan0Cancel_Button.Click += new System.EventHandler(this.ConfigButton_Click);
            // 
            // Chan0Confirm_Button
            // 
            resources.ApplyResources(this.Chan0Confirm_Button, "Chan0Confirm_Button");
            this.Chan0Confirm_Button.Name = "Chan0Confirm_Button";
            this.Chan0Confirm_Button.Tag = "0";
            this.Chan0Confirm_Button.UseVisualStyleBackColor = true;
            this.Chan0Confirm_Button.Click += new System.EventHandler(this.ConfigButton_Click);
            // 
            // SendData_TextBox
            // 
            resources.ApplyResources(this.SendData_TextBox, "SendData_TextBox");
            this.SendData_TextBox.Name = "SendData_TextBox";
            // 
            // Chan1Confirm_Button
            // 
            resources.ApplyResources(this.Chan1Confirm_Button, "Chan1Confirm_Button");
            this.Chan1Confirm_Button.Name = "Chan1Confirm_Button";
            this.Chan1Confirm_Button.Tag = "2";
            this.Chan1Confirm_Button.UseVisualStyleBackColor = true;
            this.Chan1Confirm_Button.Click += new System.EventHandler(this.ConfigButton_Click);
            // 
            // Chan1Cancel_Button
            // 
            resources.ApplyResources(this.Chan1Cancel_Button, "Chan1Cancel_Button");
            this.Chan1Cancel_Button.Name = "Chan1Cancel_Button";
            this.Chan1Cancel_Button.Tag = "3";
            this.Chan1Cancel_Button.UseVisualStyleBackColor = true;
            this.Chan1Cancel_Button.Click += new System.EventHandler(this.ConfigButton_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.SendData_TextBox);
            this.tabPage1.Controls.Add(this.SendData_Button);
            this.tabPage1.Controls.Add(this.SendHex_CheckBox);
            this.tabPage1.Controls.Add(this.ClearSendData_Button);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ProNum_Textbox);
            this.tabPage2.Controls.Add(this.Project_combox);
            this.tabPage2.Controls.Add(this.TableNumStartPos_TextBox);
            this.tabPage2.Controls.Add(this.TableNumConfig_TextBox);
            this.tabPage2.Controls.Add(this.label25);
            this.tabPage2.Controls.Add(this.label24);
            this.tabPage2.Controls.Add(this.label26);
            this.tabPage2.Controls.Add(this.label19);
            this.tabPage2.Controls.Add(this.SystemTag_Lable);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.TableNumConfig_Confirm_Button);
            this.tabPage2.Controls.Add(this.Chan1Confirm_Button);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.TableNum_Cancel_Button);
            this.tabPage2.Controls.Add(this.Chan1Cancel_Button);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.Chan1MaxValve_TextBox);
            this.tabPage2.Controls.Add(this.Chan0MinValve_TextBox);
            this.tabPage2.Controls.Add(this.btnGetProNum);
            this.tabPage2.Controls.Add(this.Chan0Confirm_Button);
            this.tabPage2.Controls.Add(this.Chan1MinValve_TextBox);
            this.tabPage2.Controls.Add(this.Chan0MaxValve_TextBox);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.Chan0Cancel_Button);
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Project_combox
            // 
            this.Project_combox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Project_combox.FormattingEnabled = true;
            resources.ApplyResources(this.Project_combox, "Project_combox");
            this.Project_combox.Name = "Project_combox";
            this.Project_combox.SelectedIndexChanged += new System.EventHandler(this.Project_combox_SelectedIndexChanged);
            // 
            // TableNumStartPos_TextBox
            // 
            resources.ApplyResources(this.TableNumStartPos_TextBox, "TableNumStartPos_TextBox");
            this.TableNumStartPos_TextBox.Name = "TableNumStartPos_TextBox";
            // 
            // TableNumConfig_TextBox
            // 
            resources.ApplyResources(this.TableNumConfig_TextBox, "TableNumConfig_TextBox");
            this.TableNumConfig_TextBox.Name = "TableNumConfig_TextBox";
            // 
            // label25
            // 
            resources.ApplyResources(this.label25, "label25");
            this.label25.Name = "label25";
            // 
            // label24
            // 
            resources.ApplyResources(this.label24, "label24");
            this.label24.Name = "label24";
            // 
            // label26
            // 
            resources.ApplyResources(this.label26, "label26");
            this.label26.Name = "label26";
            // 
            // label19
            // 
            resources.ApplyResources(this.label19, "label19");
            this.label19.Name = "label19";
            // 
            // SystemTag_Lable
            // 
            resources.ApplyResources(this.SystemTag_Lable, "SystemTag_Lable");
            this.SystemTag_Lable.Name = "SystemTag_Lable";
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // TableNumConfig_Confirm_Button
            // 
            resources.ApplyResources(this.TableNumConfig_Confirm_Button, "TableNumConfig_Confirm_Button");
            this.TableNumConfig_Confirm_Button.Name = "TableNumConfig_Confirm_Button";
            this.TableNumConfig_Confirm_Button.Tag = "4";
            this.TableNumConfig_Confirm_Button.UseVisualStyleBackColor = true;
            this.TableNumConfig_Confirm_Button.Click += new System.EventHandler(this.ConfigButton_Click);
            // 
            // TableNum_Cancel_Button
            // 
            resources.ApplyResources(this.TableNum_Cancel_Button, "TableNum_Cancel_Button");
            this.TableNum_Cancel_Button.Name = "TableNum_Cancel_Button";
            this.TableNum_Cancel_Button.Tag = "5";
            this.TableNum_Cancel_Button.UseVisualStyleBackColor = true;
            this.TableNum_Cancel_Button.Click += new System.EventHandler(this.ConfigButton_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage3.Controls.Add(this.updateProgress_Lable);
            this.tabPage3.Controls.Add(this.pictureBox1);
            this.tabPage3.Controls.Add(this.btnUpdate);
            this.tabPage3.Controls.Add(this.progressBar1);
            this.tabPage3.Controls.Add(this.label21);
            this.tabPage3.Controls.Add(this.FactoryPattern_ChekedBox);
            this.tabPage3.Controls.Add(this.label20);
            this.tabPage3.Controls.Add(this.btnOpenFile);
            this.tabPage3.Controls.Add(this.txtRomPath);
            this.tabPage3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            resources.ApplyResources(this.tabPage3, "tabPage3");
            this.tabPage3.Name = "tabPage3";
            // 
            // updateProgress_Lable
            // 
            resources.ApplyResources(this.updateProgress_Lable, "updateProgress_Lable");
            this.updateProgress_Lable.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.updateProgress_Lable.Name = "updateProgress_Lable";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::serialPort_Bord.Properties.Resources.Wait;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // btnUpdate
            // 
            this.btnUpdate.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            resources.ApplyResources(this.btnUpdate, "btnUpdate");
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // progressBar1
            // 
            resources.ApplyResources(this.progressBar1, "progressBar1");
            this.progressBar1.Name = "progressBar1";
            // 
            // label21
            // 
            resources.ApplyResources(this.label21, "label21");
            this.label21.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label21.Name = "label21";
            // 
            // FactoryPattern_ChekedBox
            // 
            resources.ApplyResources(this.FactoryPattern_ChekedBox, "FactoryPattern_ChekedBox");
            this.FactoryPattern_ChekedBox.Name = "FactoryPattern_ChekedBox";
            this.FactoryPattern_ChekedBox.UseVisualStyleBackColor = true;
            // 
            // label20
            // 
            resources.ApplyResources(this.label20, "label20");
            this.label20.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label20.Name = "label20";
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            resources.ApplyResources(this.btnOpenFile, "btnOpenFile");
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // txtRomPath
            // 
            resources.ApplyResources(this.txtRomPath, "txtRomPath");
            this.txtRomPath.Name = "txtRomPath";
            // 
            // OPenValve_PictureBox
            // 
            this.OPenValve_PictureBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.OPenValve_PictureBox.Image = global::serialPort_Bord.Properties.Resources.Wait;
            resources.ApplyResources(this.OPenValve_PictureBox, "OPenValve_PictureBox");
            this.OPenValve_PictureBox.Name = "OPenValve_PictureBox";
            this.OPenValve_PictureBox.TabStop = false;
            // 
            // HeadWare_PictureBox
            // 
            this.HeadWare_PictureBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.HeadWare_PictureBox.Image = global::serialPort_Bord.Properties.Resources.Wait;
            resources.ApplyResources(this.HeadWare_PictureBox, "HeadWare_PictureBox");
            this.HeadWare_PictureBox.Name = "HeadWare_PictureBox";
            this.HeadWare_PictureBox.TabStop = false;
            // 
            // Key_PictureBox
            // 
            this.Key_PictureBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.Key_PictureBox.Image = global::serialPort_Bord.Properties.Resources.Wait;
            resources.ApplyResources(this.Key_PictureBox, "Key_PictureBox");
            this.Key_PictureBox.Name = "Key_PictureBox";
            this.Key_PictureBox.TabStop = false;
            // 
            // SerialPortState_PictureBox
            // 
            this.SerialPortState_PictureBox.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.SerialPortState_PictureBox, "SerialPortState_PictureBox");
            this.SerialPortState_PictureBox.Name = "SerialPortState_PictureBox";
            this.SerialPortState_PictureBox.TabStop = false;
            // 
            // Current_PictureBox
            // 
            this.Current_PictureBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.Current_PictureBox.Image = global::serialPort_Bord.Properties.Resources.Wait;
            resources.ApplyResources(this.Current_PictureBox, "Current_PictureBox");
            this.Current_PictureBox.Name = "Current_PictureBox";
            this.Current_PictureBox.TabStop = false;
            // 
            // Timer_StateUpdata
            // 
            this.Timer_StateUpdata.Enabled = true;
            this.Timer_StateUpdata.Interval = 1000;
            this.Timer_StateUpdata.Tick += new System.EventHandler(this.Timer_StateUpdata_Tick);
            // 
            // SerialPort_Update
            // 
            this.SerialPort_Update.Interval = 500;
            this.SerialPort_Update.Tick += new System.EventHandler(this.SerialPort_Update_Tick);
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.Cursor = System.Windows.Forms.Cursors.Default;
            this.label14.Name = "label14";
            // 
            // TableNumber_TextBox
            // 
            this.TableNumber_TextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.TableNumber_TextBox, "TableNumber_TextBox");
            this.TableNumber_TextBox.Name = "TableNumber_TextBox";
            this.TableNumber_TextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TableNumber_TextBox_KeyPress);
            // 
            // TableNnumber_Confirm_Button
            // 
            this.TableNnumber_Confirm_Button.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.TableNnumber_Confirm_Button, "TableNnumber_Confirm_Button");
            this.TableNnumber_Confirm_Button.Name = "TableNnumber_Confirm_Button";
            this.TableNnumber_Confirm_Button.Tag = "0";
            this.TableNnumber_Confirm_Button.UseVisualStyleBackColor = true;
            this.TableNnumber_Confirm_Button.Click += new System.EventHandler(this.TableNnumber_Confirm_Button_Click);
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.Cursor = System.Windows.Forms.Cursors.Default;
            this.label15.Name = "label15";
            // 
            // IP_PORT_Confirm_Button
            // 
            this.IP_PORT_Confirm_Button.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.IP_PORT_Confirm_Button, "IP_PORT_Confirm_Button");
            this.IP_PORT_Confirm_Button.Name = "IP_PORT_Confirm_Button";
            this.IP_PORT_Confirm_Button.Tag = "0";
            this.IP_PORT_Confirm_Button.UseVisualStyleBackColor = true;
            this.IP_PORT_Confirm_Button.Click += new System.EventHandler(this.IP_PORT_Confirm_Button_Click);
            // 
            // Port_Num_TextBox
            // 
            this.Port_Num_TextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.Port_Num_TextBox, "Port_Num_TextBox");
            this.Port_Num_TextBox.Name = "Port_Num_TextBox";
            // 
            // label16
            // 
            resources.ApplyResources(this.label16, "label16");
            this.label16.Cursor = System.Windows.Forms.Cursors.Default;
            this.label16.Name = "label16";
            // 
            // TableNum_PictureBox
            // 
            this.TableNum_PictureBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.TableNum_PictureBox.Image = global::serialPort_Bord.Properties.Resources.Wait;
            resources.ApplyResources(this.TableNum_PictureBox, "TableNum_PictureBox");
            this.TableNum_PictureBox.Name = "TableNum_PictureBox";
            this.TableNum_PictureBox.TabStop = false;
            // 
            // IP_Port_PictureBox
            // 
            this.IP_Port_PictureBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.IP_Port_PictureBox.Image = global::serialPort_Bord.Properties.Resources.Wait;
            resources.ApplyResources(this.IP_Port_PictureBox, "IP_Port_PictureBox");
            this.IP_Port_PictureBox.Name = "IP_Port_PictureBox";
            this.IP_Port_PictureBox.TabStop = false;
            // 
            // MainIPAddress_MaskedTextBox
            // 
            this.MainIPAddress_MaskedTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.MainIPAddress_MaskedTextBox, "MainIPAddress_MaskedTextBox");
            this.MainIPAddress_MaskedTextBox.Name = "MainIPAddress_MaskedTextBox";
            this.MainIPAddress_MaskedTextBox.Tag = "10";
            this.MainIPAddress_MaskedTextBox.Click += new System.EventHandler(this.IPAddress_MaskedTextBox_Click);
            this.MainIPAddress_MaskedTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IPAddress_MaskedTextBox_KeyPress);
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.meter_CheckBox);
            this.groupBox1.Controls.Add(this.IPandPortConfig_checkBox);
            this.groupBox1.Controls.Add(this.tableNumAutoAdd_checkbox);
            this.groupBox1.Controls.Add(this.TableNumber_TextBox);
            this.groupBox1.Controls.Add(this.SubIPAddress_MaskedTextBox);
            this.groupBox1.Controls.Add(this.MainIPAddress_MaskedTextBox);
            this.groupBox1.Controls.Add(this.TableNum_PictureBox);
            this.groupBox1.Controls.Add(this.IP_PORT_Confirm_Button);
            this.groupBox1.Controls.Add(this.IP_Port_PictureBox);
            this.groupBox1.Controls.Add(this.TableNnumber_Confirm_Button);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.Port_Num_TextBox);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // meter_CheckBox
            // 
            resources.ApplyResources(this.meter_CheckBox, "meter_CheckBox");
            this.meter_CheckBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.meter_CheckBox.Name = "meter_CheckBox";
            this.meter_CheckBox.UseVisualStyleBackColor = true;
            // 
            // IPandPortConfig_checkBox
            // 
            resources.ApplyResources(this.IPandPortConfig_checkBox, "IPandPortConfig_checkBox");
            this.IPandPortConfig_checkBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.IPandPortConfig_checkBox.Name = "IPandPortConfig_checkBox";
            this.IPandPortConfig_checkBox.UseVisualStyleBackColor = true;
            // 
            // tableNumAutoAdd_checkbox
            // 
            resources.ApplyResources(this.tableNumAutoAdd_checkbox, "tableNumAutoAdd_checkbox");
            this.tableNumAutoAdd_checkbox.Cursor = System.Windows.Forms.Cursors.Default;
            this.tableNumAutoAdd_checkbox.Name = "tableNumAutoAdd_checkbox";
            this.tableNumAutoAdd_checkbox.UseVisualStyleBackColor = true;
            // 
            // SubIPAddress_MaskedTextBox
            // 
            this.SubIPAddress_MaskedTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.SubIPAddress_MaskedTextBox, "SubIPAddress_MaskedTextBox");
            this.SubIPAddress_MaskedTextBox.Name = "SubIPAddress_MaskedTextBox";
            this.SubIPAddress_MaskedTextBox.Tag = "11";
            this.SubIPAddress_MaskedTextBox.Click += new System.EventHandler(this.IPAddress_MaskedTextBox_Click);
            this.SubIPAddress_MaskedTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IPAddress_MaskedTextBox_KeyPress);
            // 
            // label18
            // 
            resources.ApplyResources(this.label18, "label18");
            this.label18.Cursor = System.Windows.Forms.Cursors.Default;
            this.label18.Name = "label18";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.GetIP_PictureBox);
            this.groupBox2.Controls.Add(this.GetIP_Button);
            this.groupBox2.Controls.Add(this.Current_Button);
            this.groupBox2.Controls.Add(this.Key_Button);
            this.groupBox2.Controls.Add(this.GetVersion_PictureBox);
            this.groupBox2.Controls.Add(this.OPenValve_PictureBox);
            this.groupBox2.Controls.Add(this.HeadWare_Button);
            this.groupBox2.Controls.Add(this.HeadWare_PictureBox);
            this.groupBox2.Controls.Add(this.GetVersion_Button);
            this.groupBox2.Controls.Add(this.OpenValve_Button);
            this.groupBox2.Controls.Add(this.Key_PictureBox);
            this.groupBox2.Controls.Add(this.Reset_Button);
            this.groupBox2.Controls.Add(this.ZeroBia_CheckBox);
            this.groupBox2.Controls.Add(this.Current_PictureBox);
            this.groupBox2.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // GetIP_PictureBox
            // 
            this.GetIP_PictureBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.GetIP_PictureBox.Image = global::serialPort_Bord.Properties.Resources.Wait;
            resources.ApplyResources(this.GetIP_PictureBox, "GetIP_PictureBox");
            this.GetIP_PictureBox.Name = "GetIP_PictureBox";
            this.GetIP_PictureBox.TabStop = false;
            // 
            // GetIP_Button
            // 
            this.GetIP_Button.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.GetIP_Button, "GetIP_Button");
            this.GetIP_Button.Name = "GetIP_Button";
            this.GetIP_Button.Tag = "6";
            this.GetIP_Button.UseVisualStyleBackColor = true;
            this.GetIP_Button.Click += new System.EventHandler(this.GetIP_Button_Click);
            // 
            // GetVersion_PictureBox
            // 
            this.GetVersion_PictureBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.GetVersion_PictureBox.Image = global::serialPort_Bord.Properties.Resources.Wait;
            resources.ApplyResources(this.GetVersion_PictureBox, "GetVersion_PictureBox");
            this.GetVersion_PictureBox.Name = "GetVersion_PictureBox";
            this.GetVersion_PictureBox.TabStop = false;
            // 
            // GetVersion_Button
            // 
            this.GetVersion_Button.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.GetVersion_Button, "GetVersion_Button");
            this.GetVersion_Button.Name = "GetVersion_Button";
            this.GetVersion_Button.Tag = "4";
            this.GetVersion_Button.UseVisualStyleBackColor = true;
            this.GetVersion_Button.Click += new System.EventHandler(this.Button_Click);
            // 
            // Rece_HexCheckBox
            // 
            resources.ApplyResources(this.Rece_HexCheckBox, "Rece_HexCheckBox");
            this.Rece_HexCheckBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.Rece_HexCheckBox.Name = "Rece_HexCheckBox";
            this.Rece_HexCheckBox.UseVisualStyleBackColor = true;
            // 
            // Dis_Rece_TextBox
            // 
            this.Dis_Rece_TextBox.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Dis_Rece_TextBox, "Dis_Rece_TextBox");
            this.Dis_Rece_TextBox.Name = "Dis_Rece_TextBox";
            // 
            // updateWorker
            // 
            this.updateWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.updateWorker_DoWork);
            this.updateWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.updateWorker_ProgressChanged);
            // 
            // openRom
            // 
            this.openRom.FileName = "openFileDialog1";
            // 
            // label22
            // 
            resources.ApplyResources(this.label22, "label22");
            this.label22.Cursor = System.Windows.Forms.Cursors.Default;
            this.label22.Name = "label22";
            // 
            // label23
            // 
            resources.ApplyResources(this.label23, "label23");
            this.label23.Cursor = System.Windows.Forms.Cursors.Default;
            this.label23.Name = "label23";
            // 
            // CheckResult_PictureBox
            // 
            this.CheckResult_PictureBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.CheckResult_PictureBox.Image = global::serialPort_Bord.Properties.Resources.checkWait;
            resources.ApplyResources(this.CheckResult_PictureBox, "CheckResult_PictureBox");
            this.CheckResult_PictureBox.Name = "CheckResult_PictureBox";
            this.CheckResult_PictureBox.TabStop = false;
            // 
            // Muen_toolStrip
            // 
            this.Muen_toolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.Muen_toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSplitButton_Regard});
            resources.ApplyResources(this.Muen_toolStrip, "Muen_toolStrip");
            this.Muen_toolStrip.Name = "Muen_toolStrip";
            // 
            // toolStripSplitButton_Regard
            // 
            this.toolStripSplitButton_Regard.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripSplitButton_Regard.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_ViewVersion,
            this.ToolStripMenuItem_TestProject});
            resources.ApplyResources(this.toolStripSplitButton_Regard, "toolStripSplitButton_Regard");
            this.toolStripSplitButton_Regard.Name = "toolStripSplitButton_Regard";
            this.toolStripSplitButton_Regard.Click += new System.EventHandler(this.toolStripSplitButton_Regard_Clicked);
            // 
            // ToolStripMenuItem_ViewVersion
            // 
            this.ToolStripMenuItem_ViewVersion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_VersionNum});
            this.ToolStripMenuItem_ViewVersion.Name = "ToolStripMenuItem_ViewVersion";
            resources.ApplyResources(this.ToolStripMenuItem_ViewVersion, "ToolStripMenuItem_ViewVersion");
            // 
            // ToolStripMenuItem_VersionNum
            // 
            resources.ApplyResources(this.ToolStripMenuItem_VersionNum, "ToolStripMenuItem_VersionNum");
            this.ToolStripMenuItem_VersionNum.Name = "ToolStripMenuItem_VersionNum";
            this.ToolStripMenuItem_VersionNum.ReadOnly = true;
            // 
            // ToolStripMenuItem_TestProject
            // 
            this.ToolStripMenuItem_TestProject.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TestProject_TextBox});
            this.ToolStripMenuItem_TestProject.Name = "ToolStripMenuItem_TestProject";
            resources.ApplyResources(this.ToolStripMenuItem_TestProject, "ToolStripMenuItem_TestProject");
            // 
            // TestProject_TextBox
            // 
            resources.ApplyResources(this.TestProject_TextBox, "TestProject_TextBox");
            this.TestProject_TextBox.Name = "TestProject_TextBox";
            this.TestProject_TextBox.ReadOnly = true;
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.SerialOption_Button);
            this.panel1.Controls.Add(this.SerialNum_ComboBox);
            this.panel1.Controls.Add(this.BuadRate_ComboBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.SerialPortState_PictureBox);
            this.panel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel1.Name = "panel1";
            // 
            // ProNum_Textbox
            // 
            resources.ApplyResources(this.ProNum_Textbox, "ProNum_Textbox");
            this.ProNum_Textbox.Name = "ProNum_Textbox";
            // 
            // btnGetProNum
            // 
            resources.ApplyResources(this.btnGetProNum, "btnGetProNum");
            this.btnGetProNum.Name = "btnGetProNum";
            this.btnGetProNum.Tag = "6";
            this.btnGetProNum.UseVisualStyleBackColor = true;
            this.btnGetProNum.Click += new System.EventHandler(this.ConfigButton_Click);
            // 
            // Frm_Main
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.CausesValidation = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Muen_toolStrip);
            this.Controls.Add(this.CheckResult_PictureBox);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.Rece_HexCheckBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.ClearReceDis_Button);
            this.Controls.Add(this.Dis_Rece_TextBox);
            this.KeyPreview = true;
            this.Name = "Frm_Main";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OPenValve_PictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeadWare_PictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Key_PictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SerialPortState_PictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Current_PictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableNum_PictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IP_Port_PictureBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GetIP_PictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GetVersion_PictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckResult_PictureBox)).EndInit();
            this.Muen_toolStrip.ResumeLayout(false);
            this.Muen_toolStrip.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.ComboBox SerialNum_ComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SerialOption_Button;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox BuadRate_ComboBox;
        private System.Windows.Forms.Button SendData_Button;
        private System.Windows.Forms.CheckBox SendHex_CheckBox;
        private System.Windows.Forms.Button Current_Button;
        private System.Windows.Forms.CheckBox ZeroBia_CheckBox;
        private System.Windows.Forms.Button Reset_Button;
        private System.Windows.Forms.Button Key_Button;
        private System.Windows.Forms.Button HeadWare_Button;
        private System.Windows.Forms.Button OpenValve_Button;
        private System.IO.Ports.SerialPort SerialPort_Entity;
        private System.Windows.Forms.Button ClearReceDis_Button;
        private System.Windows.Forms.Button ClearSendData_Button;
        private System.Windows.Forms.TextBox Chan0MaxValve_TextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Chan0MinValve_TextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox Chan1MinValve_TextBox;
        private System.Windows.Forms.TextBox Chan1MaxValve_TextBox;
        private System.Windows.Forms.Button Chan0Cancel_Button;
        private System.Windows.Forms.Button Chan0Confirm_Button;
        private System.Windows.Forms.TextBox SendData_TextBox;
        private System.Windows.Forms.Button Chan1Confirm_Button;
        private System.Windows.Forms.Button Chan1Cancel_Button;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.PictureBox Current_PictureBox;
        private System.Windows.Forms.PictureBox Key_PictureBox;
        private System.Windows.Forms.PictureBox HeadWare_PictureBox;
        private System.Windows.Forms.PictureBox OPenValve_PictureBox;
        private System.Windows.Forms.PictureBox SerialPortState_PictureBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label SystemTag_Lable;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Timer Timer_StateUpdata;
        private System.Windows.Forms.Timer SerialPort_Update;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox TableNumber_TextBox;
        private System.Windows.Forms.Button TableNnumber_Confirm_Button;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button IP_PORT_Confirm_Button;
        private System.Windows.Forms.TextBox Port_Num_TextBox;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.PictureBox TableNum_PictureBox;
        private System.Windows.Forms.PictureBox IP_Port_PictureBox;
        private System.Windows.Forms.MaskedTextBox MainIPAddress_MaskedTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox Rece_HexCheckBox;
        private System.Windows.Forms.PictureBox GetIP_PictureBox;
        private System.Windows.Forms.Button GetIP_Button;
        private System.Windows.Forms.MaskedTextBox SubIPAddress_MaskedTextBox;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox TableNumConfig_TextBox;
        private System.Windows.Forms.Button TableNumConfig_Confirm_Button;
        private System.Windows.Forms.Button TableNum_Cancel_Button;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox Dis_Rece_TextBox;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.TextBox txtRomPath;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker updateWorker;
        private System.Windows.Forms.OpenFileDialog openRom;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox tableNumAutoAdd_checkbox;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label updateProgress_Lable;
        private System.Windows.Forms.PictureBox GetVersion_PictureBox;
        private System.Windows.Forms.Button GetVersion_Button;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.PictureBox CheckResult_PictureBox;
        private System.Windows.Forms.CheckBox IPandPortConfig_checkBox;
        private System.Windows.Forms.CheckBox FactoryPattern_ChekedBox;
        private System.Windows.Forms.TextBox TableNumStartPos_TextBox;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.ComboBox Project_combox;
        private System.Windows.Forms.ToolStrip Muen_toolStrip;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton_Regard;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_ViewVersion;
        private System.Windows.Forms.ToolStripTextBox ToolStripMenuItem_VersionNum;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_TestProject;
        private System.Windows.Forms.ToolStripTextBox TestProject_TextBox;
        private System.Windows.Forms.CheckBox meter_CheckBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox ProNum_Textbox;
        private System.Windows.Forms.Button btnGetProNum;
    }
}

