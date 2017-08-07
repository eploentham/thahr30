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
    public partial class StaffAdd : Form
    {
        Connection lsGdb = new Connection();
        public Boolean lbFlagNew = false;
        public string lsStaffID = "", lsPassword="";
        Initial lsIniT = new Initial();
        private string lsProvCode="", lsDistrictCode="", lsSubDistrictCode="", flagstaff = "";
        FlagStaff flagStaff;
        public enum FlagStaff
        {
            Staff, Committee, PR, Guess
        }
        public FlagStaff FlagStafF
        {
            get
            {
                if (flagstaff == "1")
                {
                    flagStaff = FlagStaff.Staff;
                }
                else if (flagstaff == "2")
                {
                    flagStaff = FlagStaff.Committee;
                }
                else if (flagstaff == "3")
                {
                    flagStaff = FlagStaff.PR;
                }
                else if (flagstaff == "4")
                {
                    flagStaff = FlagStaff.Guess;
                }
                else
                {
                    flagStaff = FlagStaff.Staff;
                }
                return flagStaff;
            }
            set
            {
                flagStaff = value;
                if (flagStaff == FlagStaff.Staff)
                {
                    flagstaff = "1";
                }
                else if (flagStaff == FlagStaff.Committee)
                {
                    flagstaff = "2";
                }
                else if (flagStaff == FlagStaff.PR)
                {
                    flagstaff = "3";
                }
                else if (flagStaff == FlagStaff.Guess)
                {
                    flagstaff = "4";
                }
                else
                {
                    flagstaff = "3";
                }
            }
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
        public Boolean FlagNew
        {
            get
            {
                return lbFlagNew;
            }
            set
            {
                lbFlagNew = value;
            }
        }
        public StaffAdd()
        {
            InitializeComponent();
        }
        private void CloseForm()
        {
            this.Close();
        }
        private Boolean SaveStaff()
        {
            Staff lstblStaff = new Staff();
            lstblStaff.StaffID = TxtStaffID.Text;
            lstblStaff.StaffName = TxtStaffName.Text;
            lstblStaff.Line1 = TxtLine1.Text;
            lstblStaff.Remark = TxtRemark.Text;
            lstblStaff.Telephone = TxtTele.Text;
            lstblStaff.ContactName = TxtContact.Text;
            lstblStaff.EMail = TxtEMail.Text;
            lstblStaff.ID = TxtID.Text;
            lstblStaff.StaffSurName = TxtStaffSurName.Text;
            if (flagStaff == FlagStaff.Staff)
            {
                if (TxtUserName.Text == "")
                {
                    MessageBox.Show("User Name ไม่มีค่า \nกรุณาป้อน User Name", "username");
                    return false;
                }
                else
                {
                    lstblStaff.UserName = TxtUserName.Text;
                }
                if (lbFlagNew == true)
                {
                    lstblStaff.Password = TxtUserName.Text;
                }
                else
                {
                    lstblStaff.Password = lsPassword;
                }
            }

            lstblStaff.FlagStafF = (Staff.FlagStaff)flagStaff;
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
            
            if (lstblStaff.CreateStaff(lsGdb.Gdb))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void SelectStaff(string aStaffId)
        {
            string lsSQL = "";
            Int32 i = 0;
            lsSQL = "Select * From staff Where staffcode = '" + aStaffId + "'";
            MySqlCommand Comm = new MySqlCommand(lsSQL, lsGdb.Gdb);
            MySqlDataReader lsRead;
            lsRead = Comm.ExecuteReader();
            i = 0;
            while (lsRead.Read())
            {
                i++;
                TxtStaffID.Text = lsRead["staffcode"].ToString();
                TxtStaffName.Text = lsRead["staffname"].ToString();
                TxtRemark.Text = lsRead["remark"].ToString();
                TxtContact.Text = lsRead["contactname"].ToString();
                TxtID.Text = lsRead["id"].ToString();
                TxtTele.Text = lsRead["tele"].ToString();
                TxtEMail.Text = lsRead["email"].ToString();
                TxtLine1.Text = lsRead["line1"].ToString();
                TxtUserName.Text = lsRead["username"].ToString();
                lsPassword = lsRead["password"].ToString();
                TxtStaffSurName.Text = lsRead["staffsurname"].ToString();
            }
            lsRead.Close();
        }
        private void VisibleControl()
        {
            if (flagStaff == FlagStaff.Staff)
            {
                label3.Visible = true;
                label5.Visible = true;
                TxtID.Visible = true;
                TxtUserName.Visible = true;
                moreaction.Visible = true;
                label35.Text = "รหัสพนักงาน :";
                label12.Text = "ชื่อพนักงาน :";
                label6.Text = "นามสกุลพนักงาน :";
                label15.Text = "ประเภทพนักงาน :";
            }
            else if (flagStaff == FlagStaff.Committee)
            {
                label3.Visible = false;
                label5.Visible = false;
                TxtID.Visible = false;
                TxtUserName.Visible = false;
                SetPassword.Visible = false;
                setPrivileges.Visible = false;
                testLogin.Visible = false;
                moreaction.Visible = false;
                label35.Text = "รหัสคณะกรรมการ :";
                label12.Text = "ชื่อคณะกรรมการ :";
                label6.Text = "นามสกุลคณะกรรมการ :";
                label15.Text = "ประเภทคณะกรรมการ :";
            }
            else if (flagStaff == FlagStaff.PR)
            {
                label3.Visible = false;
                label5.Visible = false;
                TxtID.Visible = false;
                TxtUserName.Visible = false;
                moreaction.Visible = false;
                label35.Text = "รหัสผู้สื่อข่าว :";
                label12.Text = "ชื่อผู้สื่อข่าว :";
                label6.Text = "นามสกุลผู้สื่อข่าว :";
                label15.Text = "ประเภทผู้สื่อข่าว :";
            }
            else if (flagStaff == FlagStaff.Guess)
            {
                label3.Visible = false;
                label5.Visible = false;
                TxtID.Visible = false;
                TxtUserName.Visible = false;
                moreaction.Visible = false;
                label35.Text = "รหัสแขกVIP :";
                label12.Text = "ชื่อแขกVIP :";
                label6.Text = "นามสกุลแขกVIP :";
                label15.Text = "ประเภทแขกVIP :";
            }
        }
        private void StaffAdd_Load(object sender, EventArgs e)
        {
            if (lsGdb.Gdb.State == ConnectionState.Closed)
            {
                if (lsGdb.ConnectDatabase() == false)
                {
                    CloseForm();
                }
            }
            VisibleControl();
            SelectStaff(lsStaffID);
        }
        private void exit_Click(object sender, EventArgs e)
        {
            CloseForm();
        }
        private void save_Click(object sender, EventArgs e)
        {
            if (SaveStaff())
            {
                MessageBox.Show("Save OK", "Add Satff", MessageBoxButtons.OK);
                CloseForm();
            }
        }
        private void SetPassword_Click(object sender, EventArgs e)
        {
            StaffPassword frm = new StaffPassword();
            frm.Connnection = lsGdb.Gdb;
            frm.StaffID = TxtStaffID.Text;
            frm.StaffName = TxtStaffName.Text;
            frm.ShowDialog(this);
        }
        private void testLogin_Click(object sender, EventArgs e)
        {
            StaffLogin frm = new StaffLogin();
            frm.Connnection = lsGdb.Gdb;
            frm.ShowDialog(this);
        }
        private void setPrivileges_Click(object sender, EventArgs e)
        {
            StaffPrivileges frm = new StaffPrivileges();
            frm.Connnection = lsGdb.Gdb;
            frm.StaffID = TxtStaffID.Text;
            frm.ShowDialog(this);
        }

        private void TxtStaffName_Enter(object sender, EventArgs e)
        {
            TxtStaffName.BackColor = Color.SkyBlue;
        }

        private void TxtStaffName_Leave(object sender, EventArgs e)
        {
            TxtStaffName.BackColor = Color.White;
        }

        private void CboTStaff_Enter(object sender, EventArgs e)
        {
            CboTStaff.BackColor = Color.SkyBlue;
        }

        private void CboTStaff_Leave(object sender, EventArgs e)
        {
            CboTStaff.BackColor = Color.White;
        }

        private void TxtLine1_Enter(object sender, EventArgs e)
        {
            TxtLine1.BackColor = Color.SkyBlue;
        }

        private void TxtLine1_Leave(object sender, EventArgs e)
        {
            TxtLine1.BackColor = Color.White;
        }
        private void CboNation_Enter(object sender, EventArgs e)
        {
            CboNation.BackColor = Color.SkyBlue;
        }

        private void CboNation_Leave(object sender, EventArgs e)
        {
            CboNation.BackColor = Color.White;
        }

        private void TxtRemark_Enter(object sender, EventArgs e)
        {
            TxtRemark.BackColor = Color.SkyBlue;
        }

        private void TxtRemark_Leave(object sender, EventArgs e)
        {
            TxtRemark.BackColor = Color.White;
        }

        private void TxtTele_Enter(object sender, EventArgs e)
        {
            TxtTele.BackColor = Color.SkyBlue;
        }

        private void TxtTele_Leave(object sender, EventArgs e)
        {
            TxtTele.BackColor = Color.White;
        }

        private void TxtEMail_Enter(object sender, EventArgs e)
        {
            TxtEMail.BackColor = Color.SkyBlue;
        }

        private void TxtEMail_Leave(object sender, EventArgs e)
        {
            TxtEMail.BackColor = Color.White;
        }

        private void TxtContact_Enter(object sender, EventArgs e)
        {
            TxtContact.BackColor = Color.SkyBlue;
        }
        private void TxtContact_Leave(object sender, EventArgs e)
        {
            TxtContact.BackColor = Color.White;
        }
        private void TxtID_Enter(object sender, EventArgs e)
        {
            TxtID.BackColor = Color.SkyBlue;
        }
        private void TxtID_Leave(object sender, EventArgs e)
        {
            TxtID.BackColor = Color.White;
        }
        private void TxtUserName_Enter(object sender, EventArgs e)
        {
            TxtUserName.BackColor = Color.SkyBlue;
        }
        private void TxtUserName_Leave(object sender, EventArgs e)
        {
            TxtUserName.BackColor = Color.White;
        }
        private void savenew_Click(object sender, EventArgs e)
        {

        }
        private void TxtStaffSurName_Enter(object sender, EventArgs e)
        {
            TxtStaffSurName.BackColor = Color.SkyBlue;
        }
        private void TxtStaffSurName_Leave(object sender, EventArgs e)
        {
            TxtStaffSurName.BackColor = Color.White;
        }
        private void BtnSubDistrict_Click(object sender, EventArgs e)
        {
            SearchAddress frm = new SearchAddress();
            frm.Connnection = lsGdb.Gdb;
            frm.ShowDialog(this);
            TxtSubDistrict.Text = frm.SubDistrictNameT;
            TxtDistrict.Text = frm.DistrictNameT;
            TxtProvName.Text = frm.ProvNameT;
            TxtPostCode.Text = frm.PostCode;
            lsProvCode = frm.ProvCode;
            lsDistrictCode = frm.DistrictCode;
            lsSubDistrictCode = frm.SubDistrictCode;
            TxtPostCode.SelectAll();
            TxtPostCode.Focus();
        }
        private void TxtStaffName_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    {
                        TxtStaffSurName.SelectAll();
                        TxtStaffSurName.Focus();
                        break;
                    }
            }
        }
        private void TxtStaffSurName_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    {
                        TxtLine1.SelectAll();
                        TxtLine1.Focus();
                        break;
                    }
            }
        }
        private void CboTStaff_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    {
                        TxtLine1.SelectAll();
                        TxtLine1.Focus();
                        break;
                    }
            }
        }
        private void TxtLine1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    {
                        BtnSubDistrict.Focus();
                        break;
                    }
            }
        }
        private void TxtPostCode_Enter(object sender, EventArgs e)
        {
            TxtPostCode.BackColor = Color.SkyBlue;
        }

        private void TxtPostCode_Leave(object sender, EventArgs e)
        {
            TxtPostCode.BackColor = Color.White;
        }
        private void TxtPostCode_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    {
                        CboNation.Focus();
                        break;
                    }
            }
        }
        private void CboNation_DropDownClosed(object sender, EventArgs e)
        {
            TxtRemark.SelectAll();
            TxtRemark.Focus();
        }
        private void TxtRemark_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    {
                        TxtTele.SelectAll();
                        TxtTele.Focus();
                        break;
                    }
            }
        }
        private void TxtEMail_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    {
                        TxtContact.SelectAll();
                        TxtContact.Focus();
                        break;
                    }
            }
        }
        private void TxtTele_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    {
                        TxtEMail.SelectAll();
                        TxtEMail.Focus();
                        break;
                    }
            }
        }
        private void TxtContact_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    {
                        TxtID.SelectAll();
                        TxtID.Focus();
                        break;
                    }
            }
        }
        private void TxtID_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    {
                        TxtUserName.SelectAll();
                        TxtUserName.Focus();
                        break;
                    }
            }
        }
        private void TxtUserName_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    {
                        TxtStaffName.SelectAll();
                        TxtStaffName.Focus();
                        break;
                    }
            }
        }
        private void CboNation_KeyUp(object sender, KeyEventArgs e)
        {
            TxtRemark.SelectAll();
            TxtRemark.Focus();
        }

        private void savenew_Click_1(object sender, EventArgs e)
        {
            if (SaveStaff())
            {
                MessageBox.Show("Save OK", "Add Satff", MessageBoxButtons.OK);
                CleanForm();
                
            }
        }
        private void  CleanForm()
        {
            TxtStaffName.Text = "";
            TxtStaffSurName.Text = "";
            CboTStaff.SelectedIndex = -1;
            TxtLine1.Text = "";
            TxtSubDistrict.Text = "";
            TxtDistrict.Text = "";
            TxtProvName.Text = "";
            TxtPostCode.Text = "";
            CboNation.SelectedIndex = -1;
            TxtRemark.Text = "";
            TxtTele.Text = "";
            TxtEMail.Text = "";
            TxtContact.Text = "";
            TxtID.Text = "";
        }

    }
}