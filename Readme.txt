开发日志
	日期：20200428
	开发详情
	添加单板测试工装测试助手"关于"按键部分逻辑内容
	添加窗口 Frm_VersionInfo 部分，用于显示软件名称，版本号，公司详情，服务项目等相关内容。
	主要添加窗口加载方法 Frm_VersionInfo_Load(object sender, EventArgs e)，用于加载窗口消息
			窗口关闭方法 Frm_VersionInfo_FormClosing(object sender, FormClosingEventArgs e) 释放显示窗口的变量
	
	自测状态：
		目前测试正常，可正常切换服务项目
