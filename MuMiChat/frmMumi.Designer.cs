namespace MuMiChat
{
    partial class frmMain
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.textBox_KeyIn = new System.Windows.Forms.TextBox();
            this.timer_GetMessage = new System.Windows.Forms.Timer(this.components);
            this.button_SendMsg = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.bar_Login = new System.Windows.Forms.ToolStripMenuItem();
            this.bar_RegistUser = new System.Windows.Forms.ToolStripMenuItem();
            this.群組ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aSECLMESToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aSECLFA3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox_Chat = new System.Windows.Forms.RichTextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_KeyIn
            // 
            this.textBox_KeyIn.Location = new System.Drawing.Point(12, 436);
            this.textBox_KeyIn.Multiline = true;
            this.textBox_KeyIn.Name = "textBox_KeyIn";
            this.textBox_KeyIn.Size = new System.Drawing.Size(535, 55);
            this.textBox_KeyIn.TabIndex = 0;
            this.textBox_KeyIn.TextChanged += new System.EventHandler(this.textBox_KeyIn_TextChanged);
            this.textBox_KeyIn.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyIn_KeyPress);
            this.textBox_KeyIn.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyIn_KeyUp);
            // 
            // timer_GetMessage
            // 
            this.timer_GetMessage.Enabled = true;
            this.timer_GetMessage.Interval = 500;
            this.timer_GetMessage.Tick += new System.EventHandler(this.timer_GetMessage_Tick);
            // 
            // button_SendMsg
            // 
            this.button_SendMsg.Enabled = false;
            this.button_SendMsg.Location = new System.Drawing.Point(553, 436);
            this.button_SendMsg.Name = "button_SendMsg";
            this.button_SendMsg.Size = new System.Drawing.Size(73, 55);
            this.button_SendMsg.TabIndex = 3;
            this.button_SendMsg.Text = "送出";
            this.button_SendMsg.UseVisualStyleBackColor = true;
            this.button_SendMsg.Click += new System.EventHandler(this.button_SendMsg_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bar_Login,
            this.bar_RegistUser,
            this.群組ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(642, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // bar_Login
            // 
            this.bar_Login.Name = "bar_Login";
            this.bar_Login.Size = new System.Drawing.Size(44, 20);
            this.bar_Login.Text = "登入";
            this.bar_Login.Click += new System.EventHandler(this.bar_Login_Click);
            // 
            // bar_RegistUser
            // 
            this.bar_RegistUser.Enabled = false;
            this.bar_RegistUser.Name = "bar_RegistUser";
            this.bar_RegistUser.Size = new System.Drawing.Size(44, 20);
            this.bar_RegistUser.Text = "註冊";
            this.bar_RegistUser.Click += new System.EventHandler(this.bar_RegistUser_Click);
            // 
            // 群組ToolStripMenuItem
            // 
            this.群組ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aSECLMESToolStripMenuItem,
            this.aSECLFA3ToolStripMenuItem});
            this.群組ToolStripMenuItem.Name = "群組ToolStripMenuItem";
            this.群組ToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.群組ToolStripMenuItem.Text = "群組";
            // 
            // aSECLMESToolStripMenuItem
            // 
            this.aSECLMESToolStripMenuItem.Name = "aSECLMESToolStripMenuItem";
            this.aSECLMESToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aSECLMESToolStripMenuItem.Text = "ASECL-MES";
            // 
            // aSECLFA3ToolStripMenuItem
            // 
            this.aSECLFA3ToolStripMenuItem.Name = "aSECLFA3ToolStripMenuItem";
            this.aSECLFA3ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aSECLFA3ToolStripMenuItem.Text = "ASECL-FA3";
            // 
            // textBox_Chat
            // 
            this.textBox_Chat.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Chat.Location = new System.Drawing.Point(12, 27);
            this.textBox_Chat.Name = "textBox_Chat";
            this.textBox_Chat.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.textBox_Chat.Size = new System.Drawing.Size(614, 403);
            this.textBox_Chat.TabIndex = 8;
            this.textBox_Chat.Text = "";
            this.textBox_Chat.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.textBox_Chat_LinkClicked);
            this.textBox_Chat.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBox_Chat_MouseClick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(642, 512);
            this.Controls.Add(this.textBox_Chat);
            this.Controls.Add(this.button_SendMsg);
            this.Controls.Add(this.textBox_KeyIn);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "內壢姆咪聊天室";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_KeyIn;
        private System.Windows.Forms.Timer timer_GetMessage;
        private System.Windows.Forms.Button button_SendMsg;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem bar_Login;
        private System.Windows.Forms.ToolStripMenuItem bar_RegistUser;
        private System.Windows.Forms.RichTextBox textBox_Chat;
        private System.Windows.Forms.ToolStripMenuItem 群組ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aSECLMESToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aSECLFA3ToolStripMenuItem;
    }
}

