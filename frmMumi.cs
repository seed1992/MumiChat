//  Version      	Date      		    By                  Description
//  ----------      ------------------  -----------------   --------------------------------------------------------------------------------------------------------------------
//  1.2.0.0         ----/--/--          --                  ----    
//  1.3.0.0         2020/02/05          Anthar Lin          修改群組功能，但群組名稱直接寫在程式裡
//  1.4.0.0         2020/08/29          Anthar Lin          修改密碼檔定義，改放到server上
//  ----------      ------------------  -----------------   --------------------------------------------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using System.Security.Principal;
using System.Data;

namespace MuMiChat
{
    
    public partial class frmMain : Form
    {
        DateTime UpdateTime;
        string Chat_Path = string.Empty;
        string Dir_Path;
        string Login_Path;
        string Username;
        string Password;
        string ChatGroup;
        bool reSend = false;
        string msgTemp = string.Empty;
        public frmMain()
        {
            InitializeComponent();
        }

        private void textBox_Chat_KeyDown(object sender, KeyEventArgs e)
        {
            e = null;
        }

        private void textBox_KeyIn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && textBox_KeyIn.Text.Trim() != "") //按下ENTER時
            {
                Send();
                textBox_KeyIn.Text = string.Empty;
                e.KeyChar = (char)0;
            }
        }

        private void LoadChat()
        {
            try
            {
                if (UpdateTime != File.GetLastWriteTime(Chat_Path) && Chat_Path != string.Empty) //時間戳記不同才重新LOADING
                {
                    string TxtTemp;
                    TxtTemp = File.ReadAllText(Chat_Path);


                    textBox_Chat.Clear();
                    textBox_Chat.Text = TxtTemp;
                    textBox_Chat.SelectionStart = textBox_Chat.Text.Length;
                    textBox_Chat.ScrollToCaret();
                    //textBox_Chat.Refresh();
                    UpdateTime = File.GetLastWriteTime(Chat_Path);
                    //File.WriteAllText(Application.StartupPath + @"\" + ChatGroup + System.DateTime.Now.ToString("yyyyMMdd"), TxtTemp);

                    FlashWindow.FlashWindowEx(this.Handle, FlashWindow.flashType.FLASHW_TIMERNOFG);   //閃爍視窗
                }
            }
            catch
            {
                System.Threading.Thread.Sleep(100);
            }
        }

        private void Send()
        {
            try
            {
                if (reSend != true) { msgTemp = System.DateTime.Now.ToString("[HH:mm:ss] ") + Username + " : " + textBox_KeyIn.Text.Trim() + " \r\n"; }

                File.AppendAllText(Chat_Path, msgTemp);
                reSend = false;
            }
            catch
            {
                System.Threading.Thread.Sleep(100);
                reSend = true;
                Send();
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Dir_Path = @""; // your chat file path
            if (Directory.Exists(Dir_Path) == false) { Directory.CreateDirectory(Dir_Path); }

            this.Width = 680;
            this.Text += " ver." + FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion;    //file version
        }

        private void textBox_KeyIn_KeyUp(object sender, KeyEventArgs e)
        {
        }

        private void timer_GetMessage_Tick(object sender, EventArgs e)
        {
            LoadChat();
        }

        private void button_SendMsg_Click(object sender, EventArgs e)
        {
            Send();
            LoadChat();
            textBox_KeyIn.Text = string.Empty;
            textBox_KeyIn.Focus();
            return;
        }

        private void bar_Login_Click(object sender, EventArgs e)
        {
            bool bLogin = false;
            if (InputBox("名稱", "請輸入名稱:", ref Username) == DialogResult.OK)
            {
                if (InputBox("密碼", "請輸入密碼:", ref Password, IsPW: true) == DialogResult.OK)
                {
                    if (InputBox("房間名稱", "請房間名稱:", ref ChatGroup) == DialogResult.OK)
                    {
                        if (SecurityCheck(Username, Password, ChatGroup))
                        {
                            bLogin = true;
                        }
                        else
                        {
                            MessageBox.Show("登入失敗，請確認登入資訊");
                        }
                    }
                }
            }

            if (bLogin)
            {
                bar_Login.Enabled = false;
                bar_RegistUser.Enabled = false;
                if (Username == "Administrator") bar_RegistUser.Enabled = true;
                button_SendMsg.Enabled = true;
                Chat_Path = Dir_Path + @"\" + ChatGroup;
                File.AppendAllText(Chat_Path, "");
                this.Text = ChatGroup + "-" + this.Text;
                LoadChat();
            }
        }


        private bool SecurityCheck(string bUser, string bPassword, string bGroup)
        {
            Login_Path = @"\\emapplus-dev-01\D\Handover";

            string sUserCheck = string.Empty;
            string sPwCheck = string.Empty;
            string sRoomCheck = string.Empty;
            string RegisterFile = string.Empty;
            try
            {
                if (File.Exists("LoginACPW")) File.Delete("LoginACPW");
                using (WindowsImpersonationContext wic = ImpersonateHelper.GetImpersonationContext("", "", ""))//use the file server, which account has right to R/W it
                {
                    File.Copy(Login_Path, "LoginACPW");
                    RegisterFile = File.ReadAllText("LoginACPW");
                }
            }
            finally
            {
                RegisterFile = File.ReadAllText("LoginACPW");
            }

            if (bGroup != "Mumi")
            {
                MessageBox.Show("目前不支援Mumi以外的聊天室");
                return false;
            }

            sUserCheck = EncryptionHelper.Encrypt(bUser);
            sPwCheck = EncryptionHelper.Encrypt(bPassword);
            sRoomCheck = EncryptionHelper.Encrypt(bGroup);
            if (RegisterFile.IndexOf(sUserCheck + "," + sPwCheck + "," + sRoomCheck + ";", 0) != -1) return true;

            return false;
        }
        private void UserRegist(string sUser, string sPassword, string sGroup)
        {
            string RegisterFile = File.ReadAllText(Login_Path);

            if (sGroup != "Mumi")
            {
                MessageBox.Show("目前不支援Mumi以外的聊天室");
            }
            else
            {
                sUser = EncryptionHelper.Encrypt(sUser);
                sPassword = EncryptionHelper.Encrypt(sPassword);
                sGroup = EncryptionHelper.Encrypt(sGroup);
                if (RegisterFile.IndexOf(sUser + ",", 0) == -1)
                {
                    try
                    {
                        if (File.Exists("LoginACPW")) File.Delete("LoginACPW");
                        using (WindowsImpersonationContext wic = ImpersonateHelper.GetImpersonationContext("", "", ""))//use the file server, which account has right to R/W it
                        {
                            File.AppendAllText(Login_Path, sUser + "," + sPassword + "," + sGroup + ";");
                            File.Copy(Login_Path, "LoginACPW");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Connot connect Server, please oncall Mumi owner for checking.");
                    }
                }
                else
                {
                    MessageBox.Show("該帳號已被註冊過，請更換使用者名稱。");
                }
            }
        }


        public static DialogResult InputBox(string title, string promptText, ref string value, bool IsPW = false)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            if (IsPW) textBox.PasswordChar = '*';   //密碼遮罩
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }

        private void bar_RegistUser_Click(object sender, EventArgs e)
        {
            if (InputBox("名稱", "請輸入名稱:", ref Username) == DialogResult.OK)
            {
                if (InputBox("密碼", "請輸入密碼:", ref Password) == DialogResult.OK)
                {
                    if (InputBox("房間名稱", "請房間名稱:", ref ChatGroup) == DialogResult.OK)
                    {
                        UserRegist(Username, Password, ChatGroup);
                    }
                }
            }
        }

        private void textBox_KeyIn_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_Chat_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void textBox_Chat_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }
    }
}
