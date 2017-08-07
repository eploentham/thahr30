using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
namespace ThaHr30
{
    class Address
    {
        private string lsAddressName = "", lsLine1 = "", lsSubDistrictCode = "", lsDistrictCode = "", lsProvCode = "", lsAddressCode="";
        private string lsWebsite = "", lsEmail = "", lsTelephone = "", lsFax = "", lsPostCode = "", lsRemark="", lsRefID="", lsFlagLang="";
        private string lsDistrictNameT = "", lsDistrictNameE = "", lsSubDistrictNameE = "", lsSubDistrictNameT = "", lsProvNameE = "", lsProvNameT = "";
        private Int32 liAddressId = 0;
        private Flaglanguage1 lfFlagLang;
        public enum Flaglanguage1
        {
            Thai, English
        }
        public string AddressName
        {
            get
            {
                return lsAddressName;
            }
            set
            {
                lsAddressName = value.Trim();
            }
        }
        public string AddressCode
        {
            get
            {
                return lsAddressCode;
            }
            set
            {
                lsAddressCode = value.Trim();
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
        public string Website
        {
            get
            {
                return lsWebsite;
            }
            set
            {
                lsWebsite = value.Trim();
            }
        }
        public string Email
        {
            get
            {
                return lsEmail;
            }
            set
            {
                lsEmail = value.Trim();
            }
        }
        public string Telephone
        {
            get
            {
                return lsTelephone;
            }
            set
            {
                lsTelephone = value.Trim();
            }
        }
        public string Fax
        {
            get
            {
                return lsFax;
            }
            set
            {
                lsFax = value.Trim();
            }
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
        public Int32 AddressId
        {
            get
            {
                return liAddressId;
            }
            set
            {
                liAddressId = value;
            }
        }
        public string PostCode // lsRemark
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
        public string Remark // lsRemark
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
        public Int32 NewAddressID(MySqlConnection Conn)
        {
            Int32 liAddressID = 0;
            string lsSQL = "select max(addressid) as cnt From address ";
            MySqlCommand lsComm1 = new MySqlCommand(lsSQL, Conn);
            MySqlDataReader lsRead = lsComm1.ExecuteReader();
            while (lsRead.Read())
            {
                liAddressID = Convert.ToInt32(lsRead["cnt"]);
            }
            lsRead.Close();
            liAddressID++;
            return liAddressID;
        }
        public string NewDistrictCode(string aProvCode, MySqlConnection Conn)
        {
            Int32 liMax = 0;
            string lsDistrictCode = "";
            string lsSQL = "select max(substring(districtcode, 3,2)) as cnt From district Where provcode = '" + aProvCode + "' ";
            MySqlCommand lsComm1 = new MySqlCommand(lsSQL, Conn);
            MySqlDataReader lsRead = lsComm1.ExecuteReader();
            while (lsRead.Read())
            {
                liMax = Convert.ToInt32(lsRead["cnt"]);
            }
            lsRead.Close();
            liMax++;
            lsDistrictCode = aProvCode.Substring(0, 2) + liMax.ToString("00") + "00";
            return lsDistrictCode;
        }
        public string NewSubDistrictCode(string aDistrictCode, MySqlConnection Conn)
        {
            Int32 liMax = 0;
            string lsSubDistrictCode = "";
            string lsSQL = "select max(substring(subdistrictcode, 5,2)) as cnt From subdistrict Where districtcode = '" + aDistrictCode + "' ";
            MySqlCommand lsComm1 = new MySqlCommand(lsSQL, Conn);
            MySqlDataReader lsRead = lsComm1.ExecuteReader();
            while (lsRead.Read())
            {
                liMax = Convert.ToInt32(lsRead["cnt"]);
            }
            lsRead.Close();
            liMax++;
            lsSubDistrictCode = aDistrictCode.Substring(0, 4) + liMax.ToString("00");
            return lsSubDistrictCode;
        }
        public Boolean UpdateSubDistrict(string aCouCode, string aProvCode, string aDistrictCode, string aSubDistrictCode, string aSubDistrictNameT, string aSubDistrictNameE, string aPostCode, MySqlConnection Conn)
        {
            string lsSQL = "";
            //lsSQL = "Update subdistrict Set subdistrictnamee = '" +aSubDistrictNameE + "', subdistrictnamet ='"
            //    + aSubDistrictNameT + "', postcode = '" + aPostCode + "' " 
            //        + "Where subdistrictcode = '"+ aSubDistrictCode + "'";
            lsSQL = "Delete From subdistrict Where subdistrictcode = '" + aSubDistrictCode + "'";
            MySqlCommand lsComm = new MySqlCommand(lsSQL, Conn);
            lsComm.ExecuteNonQuery();
            lsSQL = "Insert Into subdistrict(coucode, provcode, districtcode, subdistrictcode, " 
                + "subdistrictnamet, subdistrictnamee, postcode) "
                + "Values('" + aCouCode + "','" + aProvCode + "','" + aDistrictCode + "','" + aSubDistrictCode + "','" 
                + aSubDistrictNameT + "','" + aSubDistrictNameE + "','" + aPostCode + "')";
            lsComm.CommandText = lsSQL;
            lsComm.ExecuteNonQuery();
            return true;
        }
        public Boolean UpdateDistrict(string aCouCode, string aProvCode, string aDistrictCode, string aDistrictNameT, string aDistrictNameE, MySqlConnection Conn)
        {
            string lsSQL = "";
            //lsSQL = "Update district Set districtnamee = '" + aDistrictNameE + "', districtnamet ='" + aDistrictNameT + "' "
            //        + "Where districtcode = '" + aDistrictCode + "'";
            lsSQL = "Delete From district Where districtcode = '" + aDistrictCode + "'";
            MySqlCommand lsComm = new MySqlCommand(lsSQL, Conn);
            lsComm.ExecuteNonQuery();
            lsSQL = "Insert Into district(districtcode, districtnamet, districtnamee, provcode, coucode, sysdate, user) "
                + "Values('" + aDistrictCode + "','" + aDistrictNameT + "','" + aDistrictNameE + "','" + aProvCode + "','" + aCouCode + "',sysdate(), user())";
            lsComm.CommandText = lsSQL;
            lsComm.ExecuteNonQuery();
            return true;
        }
        public Boolean CreateAddress(MySqlConnection Conn)
        {
            string lsSQL = "";
            string lsFlagLang = "";
            if (lfFlagLang == Flaglanguage1.Thai)
            {
                lsFlagLang = "1";
            }
            else
            {
                lsFlagLang = "2";
            }
            //Connection lsConn = new Connection();
            //lsConn.ConnectDatabase();
            if (liAddressId == 0)
            {
                liAddressId = NewAddressID(Conn);
            }
            lsSQL = "Delete From address Where addressid = " +liAddressId ;
            MySqlCommand lsComm = new MySqlCommand(lsSQL, Conn);
            lsComm.ExecuteNonQuery();
            //lsSQL = "Delete From address Where addresscode = '" + lsAddressCode + "'";
            //lsComm.CommandText = lsSQL;
            //lsComm.ExecuteNonQuery();
            lsSQL = "Insert Into address(addressid, refid, addressname, line1, subdistrictcode, districtcode, "
                + "provcode, postcode, telephone, fax, "
                + "email, website, remark, addresscode, flaglang) "
                + "Values(" + liAddressId + ",'" + lsRefID + "','" + lsAddressName + "','" + lsLine1 + "','" + lsSubDistrictCode + "','" + lsDistrictCode + "','"
                + lsProvCode + "','" + lsPostCode + "','" + lsTelephone + "','" + lsFax + "','"
                + lsEmail + "','" + lsWebsite + "','" + lsRemark + "','" + lsAddressCode + "','"+lsFlagLang+"');";
            //MySqlCommand lsComm1 = new MySqlCommand(lsSQL, Conn);
            lsComm.CommandText = lsSQL;
            lsComm.ExecuteNonQuery();
            //lsConn.Gdb.Close();
            return true;
        }
    }
}
