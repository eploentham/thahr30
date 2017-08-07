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
    public partial class StaffPassword : Form
    {
        string lsStaffName = "", lsStaffID="";
        Connection lsGdb = new Connection();
        Staff lsStaff = new Staff();
        public StaffPassword()
        {
            InitializeComponent();
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
        private void CloseForm()
        {
            this.Close();
        }
        private void exit_Click(object sender, EventArgs e)
        {
            CloseForm();
        }
        private void StaffPassword_Load(object sender, EventArgs e)
        {
            if (lsGdb.Gdb.State == ConnectionState.Closed)
            {
                lsGdb.ConnectDatabase();
            }
            else
            {
                lsGdb.Gdb.Close();
                lsGdb.Gdb.Open();
                //lsGdb.ConnectDatabase();
            }
            TxtStaffName.Text = lsStaffName;
        }

        private void save_Click(object sender, EventArgs e)
        {
            if (lsGdb.Gdb.State == ConnectionState.Closed)
            {
                lsGdb.ConnectDatabase();
            }
            else
            {
                lsGdb.Gdb.Close();
                lsGdb.Gdb.Open();
                //lsGdb.ConnectDatabase();
            }
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Cursor.Show();
            lsStaff.UpdatePassword(lsStaffID, TxtPasswordNew.Text, TxtPasswordConfirm.Text, lsGdb.Gdb);
            Cursor.Current = System.Windows.Forms.Cursors.Default;
            Cursor.Show();
            CloseForm();
        }

        private void exit_Click_1(object sender, EventArgs e)
        {
            CloseForm();
        }

        private void TxtPasswordNew_Enter(object sender, EventArgs e)
        {
            TxtPasswordNew.BackColor = Color.SkyBlue;
        }

        private void TxtPasswordNew_Leave(object sender, EventArgs e)
        {
            TxtPasswordNew.BackColor = Color.White;
        }

        private void TxtPasswordConfirm_Leave(object sender, EventArgs e)
        {
            TxtPasswordConfirm.BackColor = Color.White;
        }

        private void TxtPasswordConfirm_Enter(object sender, EventArgs e)
        {
            TxtPasswordConfirm.BackColor = Color.SkyBlue;
        }

        private void TxtPasswordNew_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    {
                        TxtPasswordConfirm.SelectAll();
                        TxtPasswordConfirm.Focus();
                        break;
                    }
            }
        }

        private void TxtPasswordConfirm_KeyUp(object sender, KeyEventArgs e)
        {
            
        }
    }
}