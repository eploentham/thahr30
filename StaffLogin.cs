using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace ThaHr30
{
    public partial class StaffLogin : Form
    {
        Connection lsGdb = new Connection();
        private string lsStaffName = "", lsStaffID="";
        private Int32 liCount = 0, liMax=3;
        private enum FlagConnection
        {
            Connecting, ConnectFalse, ConnectTrue
        }
        private void CloseForm()
        {
            this.Close();
        }
        public MySqlConnection Connnection
        {
            get
            {
                return lsGdb.Gdb;
            }
            set
            {
                lsGdb.Gdb = value;
            }
        }
        public string StaffName
        {
            get
            {
                return lsStaffName;
            }
            set
            {
                lsStaffName = value;
            }
        }
        public string StaffID
        {
            get
            {
                return lsStaffID;
            }
            set
            {
                lsStaffID = value;
            }
        }
        public StaffLogin()
        {
            InitializeComponent();
        }
        private void TxtUserName_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    {
                        TxtPassword.SelectAll();
                        TxtPassword.Focus();
                        break;
                    }
            }
        }
        private void TxtPassword_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    {
                        SetPicCheck(FlagConnection.ConnectTrue);
                        BtnOK.Focus();
                        break;
                    }
            }
        }
        private void TxtUserName_Enter(object sender, EventArgs e)
        {
            TxtUserName.BackColor = Color.SkyBlue;
            TxtUserName.SelectAll();
            SetPicPosition(true);
        }

        private void TxtUserName_Leave(object sender, EventArgs e)
        {
            TxtUserName.BackColor = Color.White;
        }

        private void TxtPassword_Enter(object sender, EventArgs e)
        {
            TxtPassword.BackColor = Color.SkyBlue;
            TxtPassword.SelectAll();
            SetPicPosition(false );
        }

        private void TxtPassword_Leave(object sender, EventArgs e)
        {
            TxtPassword.BackColor = Color.White;
        }
        private void SetPicCheck(FlagConnection aFlag)
        {
            switch (aFlag )
            {
                case FlagConnection .ConnectTrue :
                    {
                        PicTrue.Visible = true;
                        PicTrue.Left = PicFalse.Left;
                        PicFalse.Visible = false;
                        PicConnecting.Visible = false;
                        break;
                    }
                case FlagConnection.ConnectFalse:
                    {
                        PicTrue.Visible = false;
                        PicFalse.Visible = true;
                        PicConnecting.Visible = false;
                        break;
                    }
                case FlagConnection.Connecting:
                    {
                        PicConnecting.Visible = true;
                        PicConnecting.Left = PicFalse.Left;
                        PicFalse.Visible = false;
                        PicTrue.Visible = false;
                        break;
                    }
            }
        }
        private void SetPicPosition(Boolean aFlag)
        {
            if (aFlag)
            {
                PicPosition.Left = 282;
                PicPosition.Top = 56;
            }
            else
            {
                PicPosition.Left = 282;
                PicPosition.Top = 82;
            }
        }
        private void BtnOK_Click(object sender, EventArgs e)
        {
            Boolean lbConnect = false;
            
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Cursor.Show();
            SetPicCheck(FlagConnection.Connecting);
            Application.DoEvents();
            lsStaffName = "";
            lbConnect= lsGdb.ConnectDatabase();
            if (lsGdb.Gdb.State == ConnectionState.Closed)
            {
                SetPicCheck(FlagConnection.ConnectTrue);
                if (lbConnect == false)
                {
                    CloseForm();
                }
                else
                {
                    CloseForm();
                }
            }
            else
            {
                lsStaffName = lsGdb.Login(TxtUserName.Text, TxtPassword.Text, lsGdb.Gdb);
                if (lsStaffName != "")
                {
                    lsStaffID = lsGdb.StaffID;
                    CloseForm();
                }
                else
                {
                    SetPicCheck(FlagConnection.ConnectFalse);
                    MessageBox.Show("User Name or Password incorrect", "Login Fail", MessageBoxButtons.OK);
                    liCount++;
                    this.Text = "Login (" + liCount.ToString() + ")";
                    TxtUserName.SelectAll();
                    TxtUserName.Focus();
                }
                if (liCount > liMax)
                {
                    lsStaffName = "loginfail";
                    CloseForm();
                }
            }
            Cursor.Current = System.Windows.Forms.Cursors.Default;
            Cursor.Show();
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            lsStaffName = "loginfail";
            CloseForm();
        }

        private void StaffLogin_Load(object sender, EventArgs e)
        {
            PicFalse.Visible = false;
            PicTrue.Visible = false;
            PicConnecting.Visible = false;
            try
            {
                //this.Text = lsGdb.Gdb.ConnectionString;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Source, ex.Message);
            }
        }
    }
}