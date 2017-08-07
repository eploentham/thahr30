using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
namespace ThaHr30
{
    class Meeting
    {
        Int32 liMeetingID = 0, contactid =0;
        string lsMeetingNameT = "", lsDescription = "", lsPlase = "", lsMeetingStartDate = "", lsMeetingEndDate = "", lsMeetingStartTime = "", lsMeetingEndTime = "";
        string lsRemark = "", lsYear = "", lsMeetingNameE="";

        public enum FlagContact
        {
            Contact = 1, Committee=2 ,Reporter=3
        }
        Connection lsGdb = new Connection();
        IniFile lsIni = new IniFile("thahr30.ini");
        public Int32 ContactID
        {
            get
            {
                return contactid;
            }
            set
            {
                contactid = value;
            }
        }
        public Int32 MeetingID
        {
            get
            {
                return liMeetingID;
            }
            set
            {
                liMeetingID = value;
            }
        }
        public string MeetingNameT
        {
            get
            {
                return lsMeetingNameT;
            }
            set
            {
                lsMeetingNameT = value.Trim();
                if (lsMeetingNameT.Contains("'"))
                {
                    lsMeetingNameT = lsMeetingNameT.Replace("'", "''");
                }
            }
        }
        public string MeetingNameE
        {
            get
            {
                return lsMeetingNameE;
            }
            set
            {
                lsMeetingNameE = value.Trim();
                if (lsMeetingNameE.Contains("'"))
                {
                    lsMeetingNameE = lsMeetingNameE.Replace("'", "''");
                }
            }
        }
        public string Description
        {
            get
            {
                return lsDescription;
            }
            set
            {
                lsDescription = value.Trim();
                if (lsDescription.Contains("'"))
                {
                    lsDescription = lsDescription.Replace("'", "''");
                }
            }
        }
        public string Plase
        {
            get
            {
                return lsPlase;
            }
            set
            {
                lsPlase = value.Trim();
                if (lsPlase.Contains("'"))
                {
                    lsPlase = lsPlase.Replace("'", "''");
                }
            }
        }
        public DateTime MeetingStartDate
        {
            get
            {
                DateTime ld;
                ld = Convert.ToDateTime(lsMeetingStartDate);
                return ld;
            }
            set
            {
                string ls = "";
                DateTime ld;
                ld = value;
                ls = lsGdb.SelectDateMySQL(ld);
                lsMeetingStartDate = ls;
            }
        }
        public DateTime MeetingEndDate
        {
            get
            {
                DateTime ld;
                ld = Convert.ToDateTime(lsMeetingEndDate);
                return ld;
            }
            set
            {
                string ls = "";
                DateTime ld;
                ld = value;
                ls = lsGdb.SelectDateMySQL(ld);
                lsMeetingEndDate = ls;
            }
        }

        public string MeetingStartTime
        {
            get
            {
                return lsMeetingStartTime;
            }
            set
            {
                lsMeetingStartTime = value.Trim();
            }
        }
        public string MeetingEndTime
        {
            get
            {
                return lsMeetingEndTime;
            }
            set
            {
                lsMeetingEndTime = value.Trim();
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
            }
        }
        public string Year
        {
            get
            {
                return lsYear;
            }
            set
            {
                lsYear = value.Trim();
            }
        }
        public Boolean DeleteMeetingContactALL(Int32 aMeeting, MySqlConnection Conn)
        {
            string lsSQL = "Delete From meetingcontact Where meetingid = " + aMeeting;
            MySqlCommand lsComm = new MySqlCommand(lsSQL, Conn);
            lsComm.CommandText = lsSQL;
            lsComm.ExecuteNonQuery();
            return true;
        }
        public Boolean DeleteMeetingContact(Int32 aMeeting, Int32 aMeetingContactID, MySqlConnection Conn)
        {
            string lsSQL = "Delete From meetingcontact Where meetingid = " + aMeeting + " and meetingcontactid = '" + aMeetingContactID;
            MySqlCommand lsComm = new MySqlCommand(lsSQL, Conn);
            lsComm.CommandText = lsSQL;
            lsComm.ExecuteNonQuery();
            return true;
        }
        public Boolean UpdateMeetingContact(Int32 aMeeting, Int32 aMeetingContactID, string aContactName, string aCompanyName, string aPositionName, string aTypeMeeting, string aRemark, MySqlConnection Conn)
        {
            Boolean lbReturn = false;
            string lsSQL = "", lsContactName, lsCompanyName = "", lsTypeMeeting = "", lsPositionName = "", lsRemark = "";
            Int32 liMax = 0, liMeetingContactID = 0;
            MySqlCommand lsComm = new MySqlCommand(lsSQL, Conn);
            MySqlDataReader lsRead;
            lsContactName = aContactName.Replace("'", "''");
            lsCompanyName = aCompanyName.Replace("'", "''");
            lsTypeMeeting = aTypeMeeting.Replace("'", "''");
            lsPositionName = aPositionName.Replace("'", "''");
            lsRemark = aRemark.Replace("'", "''");
            try
            {
                lsSQL = "Update meetingcontact Set contactname = '" + lsContactName + "', companyname = '" + lsCompanyName + "', "
                    + "typemeeting = '" + lsTypeMeeting + "', positionname = '" + lsPositionName + "', remark = '" + lsRemark + "' "
                    + "Where meetingid = " + aMeeting + " and meetingcontactid = " + aMeetingContactID;                    
                lsComm.CommandText = lsSQL;
                lsComm.ExecuteNonQuery();
                lbReturn = true;
            }
            catch (MySqlException e)
            {
                string ls = "ไม่สามารถบันทึกข้อมูล Meeting ได้ " + lsSQL;
                lsGdb.WriteLogError(ls, e, lsSQL, "UpdateMeetingContact Meeting ");
                MessageBox.Show(ls + " " + e.Message.ToString(), e.Source.ToString(), MessageBoxButtons.OK);
            }
            return lbReturn;
        }
        public Boolean CreateMeetingContact(Int32 aMeeting, Int32 aMeetingContactID, string aContactName, string aCompanyName, 
            string aPositionName, string aTypeMeeting, string aRemark, string aFlagVisit, string aMemID, FlagContact aFlagContact,
            string aTmemNameT, string aMemNameT, string aContactID, MySqlConnection Conn)
        {
            Boolean lbReturn = false;
            string lsSQL = "", lsContactName, lsCompanyName = "", lsTypeMeeting = "", lsPositionName="", lsRemark="";
            Int32 liMax = 0, liMeetingContactID=0;
            MySqlCommand lsComm = new MySqlCommand(lsSQL, Conn);
            MySqlDataReader lsRead;
            if (aMeetingContactID == 0)
            {
                lsSQL = "select max(meetingcontactid) as cnt From meetingcontact ";
                lsComm.CommandText = lsSQL;
                lsRead = lsComm.ExecuteReader();
                while (lsRead.Read())
                {
                    if (lsRead["cnt"].ToString() == "")
                    {
                        liMax = 0;
                    }
                    else
                    {
                        liMax = Convert.ToInt32(lsRead["cnt"].ToString());
                    }
                }
                lsRead.Close();
                liMax++;
                liMeetingContactID = liMax;
            }
            else
            {
                liMeetingContactID = aMeetingContactID;
            }
            lsContactName = aContactName.Replace("'", "''");
            lsCompanyName = aCompanyName.Replace("'", "''");
            lsTypeMeeting = aTypeMeeting.Replace("'", "''");
            lsPositionName = aPositionName.Replace("'", "''");
            lsRemark = aRemark.Replace("'", "''");
            aTmemNameT = aTmemNameT.Replace("'", "''");
            aMemNameT = aMemNameT.Replace("'", "''");
            try
            {
                lsSQL = "Delete From meetingcontact Where meetingcontactid = " + liMeetingContactID;
                lsComm.CommandText = lsSQL;
                lsComm.ExecuteNonQuery();
                lsSQL = "Insert Into meetingcontact(meetingid, meetingcontactid, contactname, companyname, "
                    + "typemeeting, positionname, remark, flagvisit, "
                    + "memid, tmemnamet, memnamet, contactid) "
                    + "Values('" + aMeeting + "','" + liMeetingContactID + "','" + lsContactName + "','" + lsCompanyName + "','"
                    + lsTypeMeeting + "','" + lsPositionName + "','" + lsRemark + "','" + aFlagVisit + "', '"
                    + aMemID + "','" + aTmemNameT + "','" + aMemNameT + "'," + aContactID + ")";
                lsComm.CommandText = lsSQL;
                lsComm.ExecuteNonQuery();
                lbReturn = true;
            }
            catch (MySqlException e)
            {
                string ls = "ไม่สามารถบันทึกข้อมูล Meeting ได้ " + lsSQL;
                lsGdb.WriteLogError(ls, e, lsSQL, "Create Meeting ");
                MessageBox.Show(ls + " " + e.Message.ToString(), e.Source.ToString(), MessageBoxButtons.OK);
            }
            return lbReturn;
        }
        public Boolean UpdateMeetingContactWithoutSelect(Int32 aMeeting,  ToolStripProgressBar aPb1, MySqlConnection Conn)
        {
            Boolean lbReturn = false;
            string lsSQL = "", lsContactName, lsCompanyName = "", lsTypeMeeting = "", lsPositionName = "", lsRemark = "";
            Int32 liMax = 0, liMeetingContactID = 0, liCnt=0, li=0, liLine=5;
            MySqlDataReader lsRead, lsRead1;

            aPb1.Visible = true;
            string lsCharSet = lsIni.GetString("thahr30", "charset", "tis620");
            string lsServer = lsIni.GetString("thahr30", "serverdatabasename", "localhost");
            string lsDatabase = lsIni.GetString("thahr30", "databasename", "thahr3");
            string lsUserName = lsIni.GetString("thahr30", "username", "janepop");
            string lsPassword = lsIni.GetString("thahr30", "password", "Ekartc2c5");
            MySqlConnection conn1 = new MySqlConnection("Data Source=" + lsServer + ";Database=" + lsDatabase + ";User ID=" + lsUserName + ";Password=" + lsPassword + ";CHARSET=" + lsCharSet + "");
            conn1.Open();

            lsSQL = "Delete From meetingcontact Where remark = 'default'";
            MySqlCommand lsComm = new MySqlCommand(lsSQL, Conn);
            MySqlCommand lsComm1 = new MySqlCommand(lsSQL, conn1);
            lsComm.ExecuteNonQuery();
            lsSQL = "select max(meetingcontactid) as cnt From meetingcontact ";
            lsComm.CommandText = lsSQL;
            lsRead = lsComm.ExecuteReader();
            while (lsRead.Read())
            {
                if (lsRead["cnt"].ToString() == "")
                {
                    liMax = 0;
                }
                else
                {
                    liMax = Convert.ToInt32(lsRead["cnt"].ToString());
                }
            }
            lsRead.Close();
            liMax++;
            liMeetingContactID = liMax;
            lsSQL = "Select count(*) cnt From member Where flag <> '3' ";
            lsComm.CommandText = lsSQL;
            lsRead = lsComm.ExecuteReader();
            if (lsRead.HasRows)
            {
                while (lsRead.Read())
                {
                    aPb1.Maximum = Convert.ToInt32(lsRead["cnt"]);
                }
            }
            lsRead.Close();

            lsSQL = "select memnamee1 from member Where flag <> '3' Order By memnamee1";
            lsComm.CommandText = lsSQL;
            lsRead = lsComm.ExecuteReader();
            if (lsRead.HasRows)
            {
                while (lsRead.Read())
                {
                    lsCompanyName = lsRead["memnamee1"].ToString();
                    lsCompanyName = lsCompanyName.Replace("'", "''");
                    lsSQL = "Select count(*) as cnt from meetingcontact Where meetingid = '" + aMeeting + "' and companyname = '" + lsCompanyName + "'";
                    lsComm1.CommandText = lsSQL;
                    lsRead1 = lsComm1.ExecuteReader();
                    liCnt = 0;
                    if (lsRead1.HasRows)
                    {
                        while (lsRead1.Read())
                        {
                            liCnt = Convert.ToInt32(lsRead1["cnt"].ToString());
                        }
                    }
                    lsRead1.Close();

                    for (Int32 i = 0; i <= (liLine - liCnt); i++)
                    {
                        lsSQL = "Insert Into meetingcontact(meetingid, meetingcontactid, contactname, companyname, "
                        + "typemeeting, positionname, remark) "
                        + "Values('" + aMeeting + "', '" + liMeetingContactID + "', '', '" + lsCompanyName + "','','','default')";
                        lsComm1.CommandText = lsSQL;
                        lsComm1.ExecuteNonQuery();
                        liMeetingContactID++;
                    }
                    li++;
                    aPb1.Value = li;
                }
            }
            lsRead.Close();
            aPb1.Visible = false;
            return lbReturn;
        }
        public Int32 CreateMeeting(MySqlConnection Conn)
        {
            Boolean lbReturn = false;
            string lsSQL = "";
            Int32 liMax = 0;
            MySqlCommand lsComm = new MySqlCommand(lsSQL, Conn);
            MySqlDataReader lsRead;
            if (liMeetingID == 0)
            {
                lsSQL = "select max(meetingid) as cnt From meeting ";
                lsComm.CommandText = lsSQL;
                lsRead = lsComm.ExecuteReader();
                while (lsRead.Read())
                {
                    if (lsRead["cnt"].ToString() == "")
                    {
                        liMax = 0;
                    }
                    else
                    {
                        liMax = Convert.ToInt32(lsRead["cnt"].ToString());
                    }
                }
                lsRead.Close();
                liMax++;
                liMeetingID = liMax;
            }
            try
            {
                lsSQL = "Delete From meeting Where meetingid = " + liMeetingID;
                lsComm.CommandText = lsSQL;
                lsComm.ExecuteNonQuery();
                lsSQL = "Insert Into meeting(meetingid, meetingnamet, meetingnamee, description, "
                    + "place, meetingstartdate, meetingenddate, meetingstarttime, "
                    + "meetingendtime, remark, year, sysdate, user) "
                    + "Values('" + liMeetingID + "','" + lsMeetingNameT + "','" + lsMeetingNameE + "','" + lsDescription + "','"
                    + lsPlase + "','" + lsMeetingStartDate + "','" + lsMeetingEndDate + "','" + lsMeetingStartTime + "','"
                    + lsMeetingEndTime + "','" + lsRemark + "','" + lsYear + "', sysdate(), user())";
                lsComm.CommandText = lsSQL;
                lsComm.ExecuteNonQuery();
                lbReturn = true;
            }
            catch (MySqlException e)
            {
                string ls = "ไม่สามารถบันทึกข้อมูล Meeting ได้ " + lsSQL;
                lsGdb.WriteLogError(ls, e, lsSQL, "Create Meeting ");
                MessageBox.Show(ls + " " + e.Message.ToString(), e.Source.ToString(), MessageBoxButtons.OK);
            }
            return liMeetingID;
        }
    }
}
