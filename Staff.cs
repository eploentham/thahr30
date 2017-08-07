using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
namespace ThaHr30
{
    class Staff
    {
        Connection lsGdb = new Connection();
        private string lsStaffID = "", lsStaffName = "", lsTele = "", lsID = "", lsEMail = "";
        private string lsRemark="", lsLine1="", lsContactName="", lsUserName="", lsPassword="";
        private string lsConfirmPassword="", lsScreenName="", lsStaffSurName="", flagstaff="";
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
        public string StaffID
        {
            get
            {
                return lsStaffID;
            }
            set
            {
                lsStaffID = value.Trim();
            }
        }
        public string ID
        {
            get
            {
                return lsID;
            }
            set
            {
                lsID = value.Trim();
            }
        }
        public string ScreenName
        {
            get
            {
                return lsScreenName;
            }
            set
            {
                lsScreenName = value.Trim();
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
                lsStaffName = value.Trim();
                if (lsStaffName.Contains("'"))
                {
                    lsStaffName = lsStaffName.Replace("'", "''");
                }
            }
        }
        public string StaffSurName
        {
            get
            {
                return lsStaffSurName;
            }
            set
            {
                lsStaffSurName = value.Trim();
                if (lsStaffSurName.Contains("'"))
                {
                    lsStaffSurName = lsStaffSurName.Replace("'", "''");
                }
            }
        }
        public string Line1
        {
            get
            {
                return lsLine1;
            }
            set
            {
                lsLine1 = value.Trim();
                if (lsLine1.Contains("'"))
                {
                    lsLine1 = lsLine1.Replace("'", "''");
                }
            }
        }
        public string ContactName
        {
            get
            {
                return lsContactName;
            }
            set
            {
                lsContactName = value.Trim();
                if (lsContactName.Contains("'"))
                {
                    lsContactName = lsContactName.Replace("'", "''");
                }
            }
        }
        public string Remark
        {
            get
            {
                return lsRemark;
            }
            set
            {
                lsRemark = value.Trim();
                if (lsRemark.Contains("'"))
                {
                    lsRemark = lsRemark.Replace("'", "''");
                }
            }
        }
        public string Telephone
        {
            get
            {
                return lsTele;
            }
            set
            {
                lsTele = value.Trim();
            }
        }
        public string UserName
        {
            get
            {
                return lsUserName;
            }
            set
            {
                lsUserName = value.Trim().ToLower();
            }
        }
        public string Password
        {
            get
            {
                return lsPassword;
            }
            set
            {
                lsPassword = value.Trim();
            }
        }
        public string ConfirmPassword
        {
            get
            {
                return lsConfirmPassword;
            }
            set
            {
                lsConfirmPassword = value.Trim();
            }
        }
        public string EMail
        {
            get
            {
                return lsEMail;
            }
            set
            {
                lsEMail = value.Trim();
            }
        }
        public Boolean UpdatePassword(string aStaffID, string aPassword, string aConfirmPassword, MySqlConnection aConn)
        {
            if (aPassword == aConfirmPassword)
            {
                string lsSQL = "Update staff Set password = password('" + aPassword + "') Where staffid = '" + aStaffID + "'";
                MySqlCommand lsComm = new MySqlCommand(lsSQL, aConn);
                lsComm.ExecuteNonQuery();
                return true;
            }
            else
            {
                MessageBox.Show("New Password กับ Confirm Password ไม่ตรงกัน" , "Password", MessageBoxButtons.OK);
                return false ;
            }
        }
        public Boolean DeleteStaffPrivilegesAll(string aStaffID, MySqlConnection aConn)
        {
            string lsSQL = "Delete From staffprivileges Where staffid = '" + aStaffID + "'";
            MySqlCommand lsComm = new MySqlCommand(lsSQL, aConn);
            lsComm.ExecuteNonQuery();
            return true;
        }
        public Boolean CreateStaffPrivileges(string aStaffID, string aScreenName, string aView, string aAdd, string aEdit, string aDele, string aNodeParentID, MySqlConnection aConn)
        {
            string lsSQL = "Delete From staffprivileges Where staffid = '" + aStaffID + "' and screenname = '" +aScreenName+ "'";
            MySqlCommand lsComm = new MySqlCommand(lsSQL, aConn);
            lsComm.ExecuteNonQuery();
            lsSQL = "Insert Into staffprivileges(staffid, screenname, privilegesview, "
                + "privilegesadd, privilegesedit, privilegesdele, nodeparentid, flag) Values('" + aStaffID + "','" + aScreenName + "'," + aView + ","
                +aAdd+","+aEdit+","+aDele+",'"+aNodeParentID+"','1')";
            lsComm.CommandText = lsSQL;
            lsComm.ExecuteNonQuery();
            return true;
        }
        public Boolean CreateGroup(string aGroup, string aRemark, MySqlConnection aConn)
        {
            string lsRemark = aRemark.Replace("'", "''");
            string lsSQL = "Delete From staffgroup Where groupname = '" +aGroup + "'";
            MySqlCommand lsComm = new MySqlCommand(lsSQL, aConn);
            lsComm.ExecuteNonQuery();
            lsSQL = "Insert Into staffgroup(groupname, remark, flag) Values('" + aGroup + "','" + lsRemark + "','1')";
            lsComm.CommandText = lsSQL;
            lsComm.ExecuteNonQuery();
            return true;
        }
        public Boolean CreateStaff(MySqlConnection Conn)
        {
            Boolean lbReturn = false;
            string lsSQL = "", lsUserNameOld="", lsStaffNameOld="";
            Int32 liMax = 0;
            lsSQL = "select username, staffname From staff Where username = '"+lsUserName+"'";
            MySqlCommand lsComm = new MySqlCommand(lsSQL, Conn);
            MySqlDataReader lsRead = lsComm.ExecuteReader();
            while (lsRead.Read())
            {
                lsUserNameOld =lsRead["username"].ToString();
                lsStaffNameOld = lsRead["staffname"].ToString();
            }
            lsRead.Close();
            if ((lsUserNameOld != "") && (lsStaffNameOld != lsStaffName))
            {
                MessageBox.Show("User Name ซ้ำ " + lsUserNameOld + "\n" + lsStaffNameOld, "", MessageBoxButtons.OK);
                return false;
            }
            if (lsStaffID == "")
            {
                lsSQL = "select count(staffcode) as cnt From staff ";
                lsComm.CommandText = lsSQL;
                lsRead = lsComm.ExecuteReader();
                while (lsRead.Read())
                {
                    liMax = Convert.ToInt32(lsRead["cnt"].ToString());
                }
                lsRead.Close();
                liMax++;
                lsStaffID = liMax.ToString("00000");
            }
            try
            {
                lsStaffName = lsStaffName.Replace("'", "''");
                lsStaffSurName = lsStaffSurName.Replace("'", "''");
                lsRemark = lsRemark.Replace("'", "''");
                lsSQL = "Select staffcode From staff Where staffcode = '" + lsStaffID + "'";
                lsComm.CommandText = lsSQL;                
                MySqlDataReader rs;
                rs = lsComm.ExecuteReader();
                if (rs.HasRows)
                {
                    lsSQL = "Update staff Set staffname = '" + lsStaffName + "', tele = '" + lsTele + "', "
                    + "id = '" + lsID + "', email = '" + lsEMail + "', remark = '" + lsRemark + "', line1 = '" 
                    + lsLine1 + "', " + "contactname = '" + lsContactName + "', username = '" 
                    + lsUserName + "', password = password('" + lsPassword + "'), staffid = '" 
                    + lsStaffID + "', staffsurname = '" + lsStaffSurName + "', flagstaff = '" 
                    + flagstaff + "' "
                    + "Where staffcode = '" + lsStaffID + "'";
                }
                else
                {
                    lsSQL = "Insert Into staff(staffcode, staffname, flag, tele, "
                    + "id, email, remark, line1, "
                    + "contactname, username, password, staffid, staffsurname, flagstaff) "
                    + "Values('" + lsStaffID + "','" + lsStaffName + "','1','" + lsTele
                    + "','" + lsID + "','" + lsEMail + "','" + lsRemark + "','" + lsLine1 + "','"
                    + lsContactName + "','" + lsUserName + "',password('" + lsPassword + "'),'" + lsStaffID + "','" + lsStaffSurName + "','" + flagstaff + "')";
                }
                rs.Close();
                
                lsComm.CommandText = lsSQL;
                lsComm.ExecuteNonQuery();
                lbReturn = true;
            }
            catch (MySqlException e)
            {
                string ls = "ไม่สามารถบันทึกข้อมูล Staff ได้ " + lsSQL;
                lsGdb.WriteLogError(ls, e, lsSQL, "Create Staff ");
                MessageBox.Show(ls + " " + e.Message.ToString(), e.Source.ToString(), MessageBoxButtons.OK);
            }
            return lbReturn;
        }
    }
}
