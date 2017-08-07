using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
namespace ThaHr30
{
    class Contact
    {
        private string lsContactNameT = "", lsContactNameE = "", lsContactSurnametT = "", lsContactSurnameE = "", lsSubDistrictCode = "";
        private string lsDistrictCode = "", lsProvCode = "", lsPostCode = "", lsPositionT = "", lsRemark = "", lsPositionE = "", lsEMail = "", lsTele = "";
        private Int32 liContactID = 0;
        private Flaglanguage1 lfFlagLang;
        private FlagShowSkk91 lfFlagShowSkk9;
        private FlagContactMeeting1 lfFlagContactMeeting1;
        private string lsMobile = "", lsRefID="", lsLine1="", lsFlagSkk9="", lsFlagLang="", lsFlagContactMeeting="", lsFlagPrintLabel="";
        public enum Flaglanguage1
        {
            Thai, English
        }
        public enum FlagShowSkk91
        {
            ShowSkk9, NoShowSkk9
        }
        public enum FlagContactMeeting1
        {
            YesContactMeeting, NoContactMeeting
        }
        public Flaglanguage1 FlagLanguage
        {
            get
            {
                return lfFlagLang;
            }
            set
            {
                lfFlagLang = value;
            }
        }
        public FlagContactMeeting1 FlagContactMeeting
        {
            get
            {
                return lfFlagContactMeeting1;
            }
            set
            {
                lfFlagContactMeeting1 = value;
            }
        }
        public string ContactNameT
        {
            get
            {
                return lsContactNameT;
            }
            set
            {
                lsContactNameT = value.Trim();
                if (lsContactNameT.Contains("'"))
                {
                    lsContactNameT = lsContactNameT.Replace("'", "''");
                }
            }
        }
        public string ContactNameE
        {
            get
            {
                return lsContactNameE;
            }
            set
            {
                lsContactNameE = value.Trim();
                if (lsContactNameE.Contains("'"))
                {
                    lsContactNameE = lsContactNameE.Replace("'", "''");
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
        public string ContactSurnametT
        {
            get
            {
                return lsContactSurnametT;
            }
            set
            {
                lsContactSurnametT = value.Trim();
                if (lsContactSurnametT.Contains("'"))
                {
                    lsContactSurnametT = lsContactSurnametT.Replace("'", "''");
                }
            }
        }
        public string ContactSurnameE
        {
            get
            {
                return lsContactSurnameE;
            }
            set
            {
                lsContactSurnameE = value.Trim();
                if (lsContactSurnameE.Contains("'"))
                {
                    lsContactSurnameE = lsContactSurnameE.Replace("'", "''");
                }
            }
        }
        public string SubDistrictCode
        {
            get
            {
                return lsSubDistrictCode;
            }
            set
            {
                lsSubDistrictCode = value.Trim();
            }
        }
        public string DistrictCode
        {
            get
            {
                return lsDistrictCode;
            }
            set
            {
                lsDistrictCode = value.Trim();
            }
        }
        public string ProvCode
        {
            get
            {
                return lsProvCode;
            }
            set
            {
                lsProvCode = value.Trim();
            }
        }
        public string PostCode
        {
            get
            {
                return lsPostCode;
            }
            set
            {
                lsPostCode = value.Trim();
            }
        }
        public FlagShowSkk91 FlagSkk9
        {
            get
            {
                return lfFlagShowSkk9;
            }
            set
            {
                lfFlagShowSkk9 = value;
            }
        }
        public string FlagPrintLabel
        {
            get
            {
                return lsFlagPrintLabel;
            }
            set
            {
                lsFlagPrintLabel = value;
            }
        }
        public string PositionT
        {
            get
            {
                return lsPositionT;
            }
            set
            {
                lsPositionT = value.Trim();
                if (lsPositionT.Contains("'"))
                {
                    lsPositionT = lsPositionT.Replace("'", "''");
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
        public string PositionE
        {
            get
            {
                return lsPositionE;
            }
            set
            {
                lsPositionE = value.Trim();
                if (lsPositionE.Contains("'"))
                {
                    lsPositionE = lsPositionE.Replace("'", "''");
                }
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
        public string Tele
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
        public string Mobile
        {
            get
            {
                return lsMobile;
            }
            set
            {
                lsMobile = value.Trim();
            }
        }
        public Int32 ContactID
        {
            get
            {
                return liContactID;
            }
            set
            {
                liContactID = value;
            }
        }
        public string RefID
        {
            get
            {
                return lsRefID;
            }
            set
            {
                lsRefID = value.Trim();
            }
        }
        public Int32 SelectNewContactID(MySqlConnection Conn)
        {
            Int32 liContactID = 0;
            string lsSQL = "select max(contactid) as cnt From contact ";
            MySqlCommand lsComm1 = new MySqlCommand(lsSQL, Conn);
            MySqlDataReader lsRead = lsComm1.ExecuteReader();
            while (lsRead.Read())
            {
                liContactID = Convert.ToInt32(lsRead["cnt"]);
            }
            lsRead.Close();
            liContactID++;
            return liContactID;
        }
        public Boolean DeleteContactID(Int32 aContactID, MySqlConnection Conn)
        {
            string lsSQL = "Delete From contact Where contactid = " + aContactID;
            MySqlCommand lsComm = new MySqlCommand(lsSQL, Conn);
            lsComm.CommandText = lsSQL;
            lsComm.ExecuteNonQuery();
            return true;
        }
        public Boolean CreateContact(MySqlConnection Conn)
        {
            if (lfFlagLang == Flaglanguage1.Thai)
            {
                lsFlagLang = "1";
            }
            else
            {
                lsFlagLang = "2";
            }
            if (lfFlagShowSkk9 == FlagShowSkk91.ShowSkk9)
            {
                lsFlagSkk9 = "1";
            }
            else
            {
                lsFlagSkk9 = "0";
            }//lsFlagContactMeeting
            if (lfFlagContactMeeting1 == FlagContactMeeting1.YesContactMeeting)
            {
                lsFlagContactMeeting = "1";
            }
            else
            {
                lsFlagContactMeeting = "2";
            }
            string lsSQL = "";
            if (liContactID == 0)
            {
                liContactID = SelectNewContactID(Conn);
            }
            if (lsFlagPrintLabel == "")
            {
                lsFlagPrintLabel = "0";
            }
            lsSQL = "Delete From contact Where contactid = " + liContactID;
            MySqlCommand lsComm = new MySqlCommand(lsSQL, Conn);
            lsComm.ExecuteNonQuery();
            lsSQL = "Insert Into contact(contactid, refid, contactnamet, contactnamee, "
                + "line1, contactsurnamet, contactsurnamee, subdistrictcode, "
                + "districtcode, provcode, postcode, telephone, "
                + "positiont, positione, email, mobile, "
                + "remark, flaglang, flagskk9, flagold, flagmeeting, flagprintlabel) "
                + "Values(" + liContactID + ",'" + lsRefID + "','" + lsContactNameT + "','" + lsContactNameE + "','" 
                + lsLine1 + "','" + lsContactSurnametT +"','" + lsContactSurnameE + "','" + lsSubDistrictCode + "','" 
                + lsDistrictCode + "','" + lsProvCode + "','" + lsPostCode + "','" + lsTele + "','" 
                + lsPositionT + "','" + lsPositionE + "','"+ lsEMail + "','" + lsMobile + "','"
                + lsRemark + "','" + lsFlagLang + "','" + lsFlagSkk9 + "','1','" + lsFlagContactMeeting + "','" + lsFlagPrintLabel+ "');";
            MySqlCommand lsComm1 = new MySqlCommand(lsSQL, Conn);
            lsComm1.ExecuteNonQuery();
            return true;
        }
    }
}
