using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Collections;
namespace ThaHr30
{
    class Initial
    {
        private string lsColumnCode = "", lsColumnNameE = "", lsDataCode = "", lsDataNameE = "", lsTableName="", lsDataFlag="";

        public enum WhereSelect
        {
            aCodetoName, aNametoCode
        }
        public Hashtable TblMember = new Hashtable();
        public Hashtable TblNationality = new Hashtable();
        public Hashtable TblCounter = new Hashtable();
        public Hashtable TblShift = new Hashtable();
        public Hashtable TblTypeMem = new Hashtable();
        public Hashtable TblRegion = new Hashtable();
        public Hashtable TblTypeRoom = new Hashtable();
        public Hashtable TblStaff = new Hashtable();
        public Hashtable TblStatus = new Hashtable();
        public Hashtable TblStar = new Hashtable();
        public Hashtable TblGreenLeft = new Hashtable();
        public Hashtable TblPrefix = new Hashtable();
        public Hashtable TblLocation = new Hashtable();
        public Hashtable TblMemberEmailAccount = new Hashtable();
        public Hashtable TblTypePayment = new Hashtable();
        public void CreateTblInitial(MySqlConnection aConn)
        {
            CreateTblStaff(aConn);
            CreateTblRegion(aConn);
            CreateTblTypeRoom(aConn);
            CreateTblTypeMem(aConn);
            CreateTblMember(aConn);
            CreateTblNationality(aConn);
            CreateTblCounter(aConn);
            CreateTblShift(aConn);
            CreateTblStatus(aConn);
            CreateTblStar(aConn);
            CreateTblGreenLeft(aConn);
            CreateTblPrefix(aConn);
            CreateTblLocation(aConn);
            CreateTblMemberEMailAccount(aConn);
            CreateTblTypePayment(aConn);
        }
        public void CreateTblStaff(MySqlConnection aConn)
        {
            string lsSQL = "Select staffcode, staffname From staff";
            MySqlCommand lsComm = new MySqlCommand(lsSQL, aConn);
            MySqlDataReader lsRead;
            lsRead = lsComm.ExecuteReader();
            if (lsRead.HasRows)
            {
                while (lsRead.Read())
                {
                   
                    TblStaff.Add(lsRead["staffcode"].ToString(), lsRead["staffname"].ToString().Trim());
                }
            }
            lsRead.Close();
        }
        public void CreateTblRegion(MySqlConnection aConn)
        {
            string lsSQL = "Select regioncode, regionname From region";
            MySqlCommand lsComm = new MySqlCommand(lsSQL, aConn);
            MySqlDataReader lsRead;
            lsRead = lsComm.ExecuteReader();
            if (lsRead.HasRows)
            {
                while (lsRead.Read())
                {
                    TblRegion.Add(lsRead["regioncode"].ToString(), lsRead["regionname"].ToString().Trim());
                }
            }
            lsRead.Close();
        }
        public void CreateTblTypeRoom(MySqlConnection aConn)
        {
            string lsSQL = "Select plcode, plnamee From typeroom";
            MySqlCommand lsComm = new MySqlCommand(lsSQL, aConn);
            MySqlDataReader lsRead;
            lsRead = lsComm.ExecuteReader();
            if (lsRead.HasRows)
            {
                while (lsRead.Read())
                {
                    TblTypeRoom.Add(lsRead["plcode"].ToString(), lsRead["plnamee"].ToString().Trim());
                }
            }
            lsRead.Close();
        }
        public void CreateTblTypeMem(MySqlConnection aConn)
        {
            string lsSQL = "Select tmemcode, tmemname From typemem";
            MySqlCommand lsComm = new MySqlCommand(lsSQL, aConn);
            MySqlDataReader lsRead;
            lsRead = lsComm.ExecuteReader();
            if (lsRead.HasRows)
            {
                while (lsRead.Read())
                {
                    TblTypeMem.Add(lsRead["tmemcode"].ToString(), lsRead["tmemname"].ToString().Trim());
                }
            }
            lsRead.Close();
        }
        public void CreateTblMember(MySqlConnection aConn)
        {            
            string lsSQL = "Select memid, memnamee1 From member Order By memid";
            MySqlCommand lsComm = new MySqlCommand(lsSQL, aConn);
            MySqlDataReader lsRead;
            lsRead = lsComm.ExecuteReader();
            if (lsRead.HasRows)
            {
                while (lsRead.Read())
                {
                    TblMember.Add(lsRead["memid"].ToString(), lsRead["memnamee1"].ToString().Trim());
                }
            }
            lsRead.Close();
        }
        public void CreateTblTypePayment(MySqlConnection aConn)
        {
            string lsSQL = "Select tpaycode, tpaynamee From typepayment Order By tpaycode";
            MySqlCommand lsComm = new MySqlCommand(lsSQL, aConn);
            MySqlDataReader lsRead;
            lsRead = lsComm.ExecuteReader();
            if (lsRead.HasRows)
            {
                while (lsRead.Read())
                {
                    TblTypePayment.Add(lsRead["tpaycode"].ToString(), lsRead["tpaynamee"].ToString().Trim());
                }
            }
            lsRead.Close();
        }
        public void CreateTblMemberEMailAccount(MySqlConnection aConn)
        {
            string lsSQL = "Select memid, emailaccount From member Order By memid";
            MySqlCommand lsComm = new MySqlCommand(lsSQL, aConn);
            MySqlDataReader lsRead;
            lsRead = lsComm.ExecuteReader();
            if (lsRead.HasRows)
            {
                while (lsRead.Read())
                {
                    TblMemberEmailAccount.Add(lsRead["memid"].ToString(), lsRead["emailaccount"].ToString().Trim());
                }
            }
            lsRead.Close();
        }
        public void CreateTblNationality(MySqlConnection aConn)
        {
            string lsSQL = "Select nationcode, nationname From nationality Order By nationname";
            MySqlCommand lsComm = new MySqlCommand(lsSQL, aConn);
            MySqlDataReader lsRead;
            lsRead = lsComm.ExecuteReader();
            if (lsRead.HasRows)
            {
                while (lsRead.Read())
                {
                    TblNationality.Add(lsRead["nationcode"].ToString(), lsRead["nationname"].ToString().Trim());
                }
            }
            lsRead.Close();
        }
        public void CreateTblCounter(MySqlConnection aConn)
        {
            string lsSQL = "Select counterid, countername From counter Order By counterid";
            MySqlCommand lsComm = new MySqlCommand(lsSQL, aConn);
            MySqlDataReader lsRead;
            lsRead = lsComm.ExecuteReader();
            if (lsRead.HasRows)
            {
                while (lsRead.Read())
                {
                    TblCounter.Add(lsRead["counterid"].ToString().Trim(), lsRead["countername"].ToString().Trim());
                }
            }
            lsRead.Close();
        }
        public void CreateTblShift(MySqlConnection aConn)
        {
            string lsSQL = "Select shiftcode, shiftname From shift Order By shiftcode";
            MySqlCommand lsComm = new MySqlCommand(lsSQL, aConn);
            MySqlDataReader lsRead;
            lsRead = lsComm.ExecuteReader();
            if (lsRead.HasRows)
            {
                while (lsRead.Read())
                {
                    TblShift.Add(lsRead["shiftcode"].ToString(), lsRead["shiftname"].ToString().Trim());
                }
            }
            lsRead.Close();
        }
        public void CreateTblStatus(MySqlConnection aConn)
        {
            string lsSQL = "Select statuscode, statusname From status Order By statuscode";
            MySqlCommand lsComm = new MySqlCommand(lsSQL, aConn);
            MySqlDataReader lsRead;
            lsRead = lsComm.ExecuteReader();
            if (lsRead.HasRows)
            {
                while (lsRead.Read())
                {
                    TblStatus.Add(lsRead["statuscode"].ToString(), lsRead["statusname"].ToString().Trim());
                }
            }
            lsRead.Close();
        }
        public void CreateTblStar(MySqlConnection aConn)
        {
            string lsSQL = "Select starcode, starname From star Order By starcode";
            MySqlCommand lsComm = new MySqlCommand(lsSQL, aConn);
            MySqlDataReader lsRead;
            lsRead = lsComm.ExecuteReader();
            if (lsRead.HasRows)
            {
                while (lsRead.Read())
                {
                    TblStar.Add(lsRead["starcode"].ToString(), lsRead["starname"].ToString().Trim());
                }
            }
            lsRead.Close();
        }
        public void CreateTblGreenLeft(MySqlConnection aConn)
        {
            string lsSQL = "Select greencode, greenname From greenleft Order By greencode";
            MySqlCommand lsComm = new MySqlCommand(lsSQL, aConn);
            MySqlDataReader lsRead;
            lsRead = lsComm.ExecuteReader();
            if (lsRead.HasRows)
            {
                while (lsRead.Read())
                {
                    TblGreenLeft.Add(lsRead["greencode"].ToString(), lsRead["greenname"].ToString().Trim());
                }
            }
            lsRead.Close();
        }
        public void CreateTblPrefix(MySqlConnection aConn)
        {
            string lsSQL = "Select id, name From cboselect Where cboname = 'cboprefix' Order By name";
            MySqlCommand lsComm = new MySqlCommand(lsSQL, aConn);
            MySqlDataReader lsRead;
            lsRead = lsComm.ExecuteReader();
            if (lsRead.HasRows)
            {
                while (lsRead.Read())
                {
                    TblPrefix.Add(lsRead["id"].ToString(), lsRead["name"].ToString().Trim());
                }
            }
            lsRead.Close();
        }
        public void CreateTblLocation(MySqlConnection aConn)
        {
            string lsSQL = "Select locationcode, locationnamet From location Order By locationnamet";
            MySqlCommand lsComm = new MySqlCommand(lsSQL, aConn);
            MySqlDataReader lsRead;
            lsRead = lsComm.ExecuteReader();
            if (lsRead.HasRows)
            {
                while (lsRead.Read())
                {
                    TblLocation.Add(lsRead["locationcode"].ToString(), lsRead["locationnamet"].ToString().Trim());
                }
            }
            lsRead.Close();
        }
        public string SelectInitial(Hashtable aHashTable, string aValue, WhereSelect aFlag)
        {
            string lsCode = "", lsReturn = "";
            IDictionaryEnumerator lsNat = aHashTable.GetEnumerator();
            switch (aFlag)
            {
                case WhereSelect.aNametoCode:
                    {
                        if (aHashTable.ContainsValue(aValue))
                        {
                            while (lsNat.MoveNext())
                            {
                                lsCode = Convert.ToString(lsNat.Value).ToLower();
                                if (lsCode == aValue.ToLower())
                                {
                                    lsReturn = Convert.ToString(lsNat.Key);
                                    break;
                                }
                            }
                        }
                        break;
                    }
                case WhereSelect.aCodetoName:
                    {
                        if (aHashTable.ContainsKey(aValue))
                        {
                            while (lsNat.MoveNext())
                            {
                                lsCode = Convert.ToString(lsNat.Key);
                                if (lsCode == aValue)
                                {
                                    lsReturn = Convert.ToString(lsNat.Value);
                                    break;
                                }
                            }
                        }
                        break;
                    }
            }
            return lsReturn;
        }

        public string ColumnCode
        {
            get
            {
                return lsColumnCode;
            }
            set
            {
                lsColumnCode = value.Trim();
            }
        }
        public string ColumnNameE
        {
            get
            {
                return lsColumnNameE;
            }
            set
            {
                lsColumnNameE = value.Trim();
            }
        }
        public string DataCode
        {
            get
            {
                return lsDataCode;
            }
            set
            {
                lsDataCode = value.Trim();
            }
        }
        public string DataNameE
        {
            get
            {
                return lsDataNameE;
            }
            set
            {
                lsDataNameE = value.Trim();
            }
        }
        public string DataFlag
        {
            get
            {
                return lsDataFlag;
            }
            set
            {
                lsDataFlag = value.Trim();
            }
        }
        public string TableName
        {
            get
            {
                return lsTableName;
            }
            set
            {
                lsTableName = value.Trim();
            }
        }
        public string SelectMax(string aTableName,MySqlConnection aConn)
        {
            string lsMax = "", lsSQL="";
            lsSQL = "Select count(*) as cnt From " + aTableName;
            MySqlCommand lsComm = new MySqlCommand(lsSQL, aConn);
            MySqlDataReader lsRead = lsComm.ExecuteReader();
            if (lsRead.HasRows)
            {
                while (lsRead.Read())
                {
                    lsMax = lsRead["cnt"].ToString();
                }
                lsMax = Convert .ToString(Convert.ToInt32(lsMax) + 1);
            }
            else
            {
                lsMax = "01";
            }
            lsRead.Close();
            return lsMax;
        }
        public Boolean CreateInitial(MySqlConnection Conn)
        {
            //Connection lsConn = new Connection();
            //lsConn.ConnectDatabase();
            string lsSQL = "";
            lsSQL = "Lock Tables " + lsTableName + " WRITE; Delete From " + lsTableName + " Where " 
                + lsColumnCode + " = '" + lsDataCode + "'";
            MySqlCommand lsComm = new MySqlCommand(lsSQL, Conn);
            lsComm.ExecuteNonQuery();
            lsSQL = "Insert Into " + lsTableName + "(" + lsColumnCode + ", " + lsColumnNameE + ", flag) "
                + "Values('" + lsDataCode + "','" + lsDataNameE + "','" +lsDataFlag + "'); Unlock Tables;";
            MySqlCommand lsComm2 = new MySqlCommand(lsSQL, Conn);
            lsComm2.ExecuteNonQuery();
            return true;
        }
    }
}
