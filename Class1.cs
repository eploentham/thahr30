using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
using System.Collections;
using MySql.Data.MySqlClient;
using FarPoint.Win.Spread;
using System.IO;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Data.OleDb;
namespace ThaHr30
{           
    public class CboState
    {
        private string myShortName;
        private string myLongName;

        public CboState(string strShortName, string strLongName)
        {
            this.myShortName = strShortName.Trim();
            this.myLongName = strLongName.Trim();
        }
        public string ShortName
        {
            get
            {
                return myShortName;
            }
        }
        public string LongName
        {
            get
            {
                return myLongName;
            }
        }
        public override string ToString()
        {
            return this.ShortName + " - " + this.LongName;
        }
    }
    class Connection
    {
        private string lsStaffID = "", lsProvNameE="", lsDistrictNameE="", lsSubDistrictNameE="";
        private TableIniT TableName;
        //public ArrayList sendemail = new ArrayList();
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
        public string SubDistrictNameE
        {
            get
            {
                return lsSubDistrictNameE;
            }
            set
            {
                lsSubDistrictNameE = value;
            }
        }
        public string DistrictNameE
        {
            get
            {
                return lsDistrictNameE;
            }
            set
            {
                lsDistrictNameE = value;
            }
        }
        public string ProvNameE
        {
            get
            {
                return lsProvNameE;
            }
            set
            {
                lsProvNameE = value;
            }
        }
        public enum TableIniT
        {
            Counter, Shift, Region, TypeRoom, Member, Staff, Nationality, Province, Status, HotelChain, TypeMem, TypeBis, CboTSend, CboShopView, CboMemViewFilter, CboPrefix, CboVoucherView, Star, GreenLeft, MemberFromRegCode, MonthName, YearName, CboLinkPicture, Location, CboTypePayment, CboAddress, SubDistrict, District, CboDistrictFromSubDistrict, MemberOwner, CboDistrictFromProvCode, CboSubDistrictFromDistrict, Salutation, MemberPriceList, Contact, Address, MemberNote, MemberStatus
        }
        public enum FlagDate
        {
            DateBuddhism, DateEra, DateMySQL, DateShow
        }
        public ArrayList MemberSendEmailSelect(string flagtype, string flagsubtype)
        {
            ArrayList sendemail = new ArrayList();
            string cnt = "";
            IniFile ini = new IniFile("thahr30.ini");
            string accessemail = ini.GetString("thahr30", "accessdatabaseemail", "D:\\thahr30\\email.mdb");
            string sql = "", where = "";
            OleDbConnection acc = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + accessemail + ";");
            acc.Open();
            OleDbCommand accCom = new OleDbCommand(sql, acc);
            int i = flagsubtype.IndexOf("(");
            string subtype = "";
            if (i > 1)
            {
                subtype = flagsubtype.Substring(0, i);
            }
            else
            {
                subtype = flagsubtype;
            }
            sql = "Select email From members ";
            
            if (flagtype.Equals("province"))
            {
                if (!flagsubtype.Equals(""))
                {
                    where = " Where locaprovname = '" + subtype + "'";
                }
                else
                {
                    where = " ";
                }
            }
            else if (flagtype.Equals("region"))
            {
                if (!flagsubtype.Equals(""))
                {
                    where = " Where regname = '" + subtype + "'";
                }
                else
                {
                    where = " ";
                }
            }
            else
            {
                if (!flagsubtype.Equals(""))
                {
                    where = " Where typecode = '" + subtype + "'";
                }
                else
                {
                    where = " ";
                }
            }
            accCom.CommandText = sql + where;
            OleDbDataReader rsacc;
            rsacc = accCom.ExecuteReader();
            if (rsacc.HasRows)
            {
                while (rsacc.Read())
                {
                    sendemail.Add(rsacc["email"].ToString());
                }
            }
            rsacc.Close();
            acc.Close();
            return sendemail;
        }

        public DateTime LastDayofMonth(DateTime aDate)
        {
            DateTime ld = new DateTime();
            Int32 liday = 0;
            ld = aDate .AddMonths(1);
            liday = ld.Day ;
            ld = ld.AddDays(-liday);
            return ld ;
        }
        public void WriteTextFile()
        {
            // Create an instance of StreamWriter to write text to a file.
            // The using statement also closes the StreamWriter.
            StreamWriter sw = new StreamWriter("TestFile.txt");
                // Add some text to the file.
            sw.Write("This is the ");
            sw.WriteLine("header for the file.");
            sw.WriteLine("-------------------");
            // Arbitrary objects can also be written to the file.
            sw.Write("The date is: ");
            sw.WriteLine(DateTime.Now);
            sw.Close();
        }
        public void CopyFile(string aSourceFileName, string aDescFolder, string aDescFileName)
        {
            if (Directory.Exists(aDescFolder) == false)
            {
                Directory.CreateDirectory(aDescFolder);
            }
            if (File.Exists(aDescFolder + "\\" + aDescFileName))
            {
                File.Delete(aDescFolder + "\\" + aDescFileName);
            }
            File.Copy(aSourceFileName, aDescFolder + "\\" + aDescFileName);
        }
        public void WriteLogError(string aLog, Exception e, string aSQL, string aMethod)
        {
            StreamWriter sw = new StreamWriter("LogError.txt");
            sw.WriteLine(DateTime.Now + "|" + aMethod + " |" + aLog + "| Error Source -> " + e.Source.ToString() + "| Message -> " + e.Message.ToString() + "| SQL -> " + aSQL);
            sw.Close();
        }
        private string lsHostName="", lsDatabaseName="", lsUserName="", lsPassword="";
        
        public enum HostConnect
        {
            Localhost, Remote
        }
        enum Sorting
        {
            Code, NameT, Name, NameE, Sort1
        }
        public string HostName
        {
            get
            {
                return lsHostName;
            }
            set
            {
                lsHostName = value;
            }
        }
        public string DatabaseName
        {
            get
            {
                return lsDatabaseName;
            }
            set
            {
                lsDatabaseName = value;
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
                lsUserName = value;
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
                lsPassword = value;
            }
        }
        public MySqlConnection Gdb = new MySqlConnection();
        public string Login(string aUserName, string Password, MySqlConnection Conn)
        {
            string lsSQL = "", lsReturn = "";
            lsSQL = "Select staffname, password, staffid From staff Where username = '" 
                + aUserName + "' and password = password('" +Password+ "')";
            MySqlCommand lsComm = new MySqlCommand(lsSQL, Conn);
            MySqlDataReader lsRead;
            lsRead = lsComm.ExecuteReader();
            if (lsRead.HasRows)
            {
                while (lsRead.Read())
                {
                    lsReturn = lsRead["staffname"].ToString();
                    lsStaffID = lsRead["staffid"].ToString();
                }
            }
            else
            {
                lsReturn = "";
            }
            lsRead.Close();
            return lsReturn;
        }
        public Boolean ConnectDatabase()
        {
            IniFile lsIni = new IniFile("thahr30.ini");
            Boolean lbReturn = true;
            string lsServer = lsIni.GetString("thahr30", "serverdatabasename", "localhost");
            string lsDatabase = lsIni.GetString("thahr30", "databasename", "thahr3");
            string lsUserName = lsIni.GetString("thahr30", "username", "janepop");
            string lsPassword = lsIni.GetString("thahr30", "password", "Ekartc2c5");
            string lsCharSet = lsIni.GetString("thahr30", "charset", "tis620");
            string timeout = lsIni.GetString("thahr30", "timeout", "3000");
            //timeout = "36000";
            if (HostName == "local")
            {
                lsHostName = lsServer;
                lsDatabaseName = lsDatabase;
                lsUserName = "root";
                lsPassword = "Ekartc2c5";
            }
            else
            {
                lsHostName = lsServer;
                lsDatabaseName = lsDatabase;
            }
            if (Gdb != null)
                Gdb.Close();
            try
            {
                Gdb = new MySqlConnection("Data Source=" + lsHostName + ";Database=" + lsDatabaseName + ";User ID=" + lsUserName + ";Password=" + lsPassword + ";CHARSET=" + lsCharSet + ";Port=3306;Connect Timeout=" + timeout + ";");                
                Gdb.Open();
            }
            catch (MySqlException ex)
            {
                lbReturn = false;
                MessageBox.Show("Error connecting to the server: " + ex.Message + "\n" + Gdb.ConnectionString);
            }
            return lbReturn;
        }
        public Boolean getConnectThaiHotels()
        {
            IniFile lsIni = new IniFile("thahr30.ini");
            Boolean lbReturn = true;
            string lsServer = lsIni.GetString("thahr30", "serverdatabasename", "localhost");
            string lsDatabase = lsIni.GetString("thahr30", "databasename", "thahr3");
            string lsUserName = lsIni.GetString("thahr30", "username", "janepop");
            string lsPassword = lsIni.GetString("thahr30", "password", "Ekartc2c5");
            string lsCharSet = lsIni.GetString("thahr30", "charset", "tis620");
            if (HostName == "local")
            {
                lsHostName = lsServer;
                lsDatabaseName = lsDatabase;
                lsUserName = "root";
                lsPassword = "Ekartc2c5";
            }
            else
            {
                lsHostName = lsServer;
                lsDatabaseName = lsDatabase;
            }
            if (Gdb != null)
                Gdb.Close();
            try
            {
                Gdb = new MySqlConnection("Data Source=" + lsHostName + ";Database=" + lsDatabaseName + ";User ID=" + lsUserName + ";Password=" + lsPassword + ";CHARSET=" + lsCharSet + ";Port=3306;Connect Timeout=3000;");
                Gdb.Open();
            }
            catch (MySqlException ex)
            {
                lbReturn = false;
                MessageBox.Show("Error connecting to the server: " + ex.Message + "\n" + Gdb.ConnectionString);
            }
            return lbReturn;
        }
        public ComboBox RemoveCbo(ComboBox Cbo)
        {
            Int32 liRow = 0;
            liRow = Cbo.Items.Count;
            //Cbo.Dispose();
            for (Int32 i = 0; i < liRow; i++)
            {
                Cbo.Items.RemoveAt(i);
            }
            return Cbo;
        }
        public string SelectDateMySQL(DateTime aDate)
        {
            string lsYear = Convert.ToString(aDate.Year);
            string lsReturn = "";
            lsReturn = lsYear + "-" + aDate.Month.ToString("00") + "-" + aDate.Day.ToString("00");
            return lsReturn;
        }
        public string SelectDateBudda(DateTime aDate)
        {
            string lsReturn = "";
            lsReturn = aDate.Day.ToString("00") + "/" + aDate.Month.ToString("00") + "/" + Convert.ToString(aDate.Year + 543);
            return lsReturn;
        }
        public string SelectDateEra(DateTime aDate)
        {
            string lsReturn = "";
            lsReturn = aDate.Day.ToString("00") + "/" + aDate.Month.ToString("00") + "/" + Convert.ToString(aDate.Year);
            return lsReturn;
        }
        public string SelectDate(DateTime aDate, FlagDate aFlag, IniFile aIniFile)
        {
            string lsReturn = "";
            string lsFlag = "";
            switch (aFlag)
            {
                case FlagDate.DateMySQL :
                    {
                        lsReturn = SelectDateMySQL(aDate);
                        break;
                    }
                case FlagDate.DateShow :
                    {
                        lsFlag = aIniFile.GetString("thahr30", "flagdate", "0");
                        switch (lsFlag)
                        {
                            case "0":
                                {
                                    lsReturn = SelectDateBudda(aDate);
                                    break;
                                }
                            case "1":
                                {
                                    lsReturn = SelectDateEra(aDate);
                                    break;
                                }
                        }
                        break;
                    }
                case FlagDate.DateBuddhism:
                    {
                        lsReturn = aDate.Day.ToString("00") + "/" + aDate.Month.ToString("00") + "/"+ (Convert.ToInt32(aDate.Year.ToString("0000")) +543);
                        break;
                    }
            }
            return lsReturn;
        }
        public String SelectCounter(string aFlag, string aWhere, string aCode, MySqlConnection Conn)
        {
            string lsSQL="Select * From counter Where " + aWhere + " = '" + aCode + "'", lsReturn="";
            MySqlCommand lsComm = new MySqlCommand(lsSQL, Conn);
            MySqlDataReader lsRead;
            lsRead = lsComm.ExecuteReader();
            if (lsRead.HasRows)
            {
                switch (aFlag)
                {
                    case "counteridfromcountername":
                        {
                            while (lsRead.Read())
                            {
                                lsReturn = lsRead["counterid"].ToString();
                            }
                            break;
                        }
                    case "ipfromcountername":
                        {
                            while (lsRead.Read())
                            {
                                lsReturn = lsRead["ip"].ToString();
                            }
                            break;
                        }
                    case "counternamefromcounterid":
                        {
                            while (lsRead.Read())
                            {
                                lsReturn = lsRead["countername"].ToString();
                            }
                            break;
                        }
                    case "ipfromcounterid":
                        {
                            while (lsRead.Read())
                            {
                                lsReturn = lsRead["ip"].ToString();
                            }
                            break;
                        }
                }
            }
            lsRead.Close();
            return lsReturn;
        }
        public string SelectTxtProvDistrSubDistrictPostCode(TextBox TxtProv, TextBox TxtDistrict, TextBox TxtSubDistrict, TextBox TxtPostCode, string lsWhereCode)
        {
            string lsSQL = "", lsReturn = "";
            lsSQL = "Select d.districtcode, d.districtnamet, p.provcode, p.provnamet, pc.postcode, s.subdistrictcode, s.subdistrictnamet From district d, province p, subdistrict s , postcode pc Where  d.districtcode = (Select districtcode From subdistrict Where subdistrictcode = '" + lsWhereCode + "') and d.provcode = p.provcode and pc.subdistrictcode = s.subdistrictcode and s.districtcode = d.districtcode and s.subdistrictcode = '" + lsWhereCode + "'";
            MySqlCommand lsComm = new MySqlCommand(lsSQL, Gdb);
            MySqlDataReader lsReader;
            lsReader = lsComm.ExecuteReader();
            if (lsReader.HasRows)
            {
                while (lsReader.Read())
                {
                    TxtDistrict.Text = lsReader["districtnamet"].ToString();
                    TxtSubDistrict.Text = lsReader["subdistrictnamet"].ToString();
                    TxtProv.Text = lsReader["provnamet"].ToString();
                    TxtPostCode.Text = lsReader["postcode"].ToString();
                }
            }
            lsReader.Close();
            return lsReturn;
        }
        public void UpdateSendVoucher(string aCounter, string aDate, string aFlagSendEmailSu)
        {
            string lsSQL = "Insert Into countersend (counter1, senddate, flag, flagsendemailsu) Values('"+aCounter +"','" + aDate +"','1','" + aFlagSendEmailSu + "')";
            MySqlCommand lsComm = new MySqlCommand(lsSQL, Gdb);
            lsComm.ExecuteNonQuery();
        }
        public string SelectCboProvDistrSubDistr(ComboBox CboProv, ComboBox CboDistr, ComboBox CboSubDistr, TextBox TxtPostCode, string lsWhereCode, TableIniT aFlag)
        {
            Boolean lbFlagSubDistr = false;
            string lsSQL = "", ls = "", lsReturn="", lsProv="", lsSubDistr="";
            switch (aFlag)
            {
                case TableIniT.SubDistrict:
                    lsSQL = "Select s.subdistrictcode, concat(s.subdistrictnamet, ' / ', d.districtnamet, ' / ' , p.provnamet) From subdistrict s, district d, province p Where s.subdistrictnamet like '" + lsWhereCode + "%' and s.districtcode = d.districtcode and s.provcode = p.provcode order by p.provnamet, d.districtnamet";
                    break;
                case TableIniT.CboDistrictFromSubDistrict:
                    lsSQL = "Select d.districtcode, d.districtnamet, p.provcode, p.provnamet, pc.postcode, s.subdistrictcode, s.subdistrictnamet, p.provnamee, d.districtnamee, s.subdistrictnamee From district d, province p, subdistrict s , postcode pc Where  d.districtcode = (Select districtcode From subdistrict Where subdistrictcode = '" + lsWhereCode + "') and d.provcode = p.provcode and pc.subdistrictcode = s.subdistrictcode and s.districtcode = d.districtcode and s.subdistrictcode = '" + lsWhereCode + "'";
                    break;
            }
            MySqlCommand lsComm = new MySqlCommand(lsSQL, Gdb);
            MySqlDataReader lsReader;
            lsReader = lsComm.ExecuteReader();
            if (lsReader.HasRows)
            {
                ArrayList lsListSubDistr = new ArrayList();
                ArrayList lsListDistr = new ArrayList();
                ArrayList lsListProv = new ArrayList();
                if (aFlag == TableIniT.TypeRoom)
                {
                    lsListDistr.Add(new CboState("-", "-"));
                }
                else if (aFlag == TableIniT.CboDistrictFromSubDistrict)
                {
                    lsListSubDistr.Add(new CboState("-", "-"));
                    lsListDistr.Add(new CboState("-", "-"));
                    lsListProv.Add(new CboState("-", "-"));
                }
                while (lsReader.Read())
                {
                    ls = lsReader.GetValue(0).ToString().Trim();
                    lsProv = lsReader.GetValue(2).ToString().Trim();
                    lsSubDistr = lsReader.GetValue(4).ToString().Trim();
                    lsListSubDistr.Add(new CboState(lsReader.GetValue(5).ToString().Trim(), lsReader.GetValue(6).ToString().Trim()));
                    lsListDistr.Add(new CboState(lsReader.GetValue(0).ToString().Trim(), lsReader.GetValue(1).ToString().Trim()));
                    lsListProv.Add(new CboState(lsReader.GetValue(2).ToString().Trim(), lsReader.GetValue(3).ToString().Trim()));
                    TxtPostCode.Text = lsReader.GetValue(4).ToString().Trim();
                    lsSubDistrictNameE = lsReader["subdistrictnamee"].ToString();
                    lsDistrictNameE = lsReader["districtnamee"].ToString();
                    lsProvNameE = lsReader["provnamee"].ToString();
                }
                if (CboSubDistr.DataSource == null)
                {
                    CboSubDistr.DataSource = lsListSubDistr;
                    CboSubDistr.DisplayMember = "LongName";
                    CboSubDistr.ValueMember = "ShortName";
                    CboSubDistr.Text = "";
                    lbFlagSubDistr = true;
                }
                CboDistr.DataSource = lsListDistr;
                CboDistr.DisplayMember = "LongName";
                CboDistr.ValueMember = "ShortName";
                CboDistr.Text = "";
                CboProv.DataSource = lsListProv;
                CboProv.DisplayMember = "LongName";
                CboProv.ValueMember = "ShortName";
                CboProv.Text = "";
            }
            lsReader.Close();
            switch (aFlag)
            {
                case TableIniT.CboDistrictFromSubDistrict:
                    {
                        CboDistr.SelectedValue = ls;
                        CboProv.SelectedValue = lsProv;
                        if (lbFlagSubDistr == true )
                        {
                            CboSubDistr.SelectedValue = lsSubDistr;
                        }
                        break;
                    }
            }
            return lsReturn;
        }
        public string SelectStaffPrivileges(string aStaffID)
        {
            string lsReturn = "";
            string lsSQL = "Select * From staffprivileges Where staffid = '"+ aStaffID + "'";
            MySqlCommand lsComm = new MySqlCommand(lsSQL, Gdb);
            MySqlDataReader lsRead;
            lsRead = lsComm.ExecuteReader();
            if (lsRead.HasRows)
            {
                while (lsRead.Read())
                {
                    lsReturn = lsRead["privilegesview"].ToString() + lsRead["privilegesadd"].ToString() + lsRead["privilegesedit"].ToString() + lsRead["privilegesdele"].ToString();
                }
            }
            lsRead.Close();
            return lsReturn;
        }
        public void SeparateTable(TableIniT aTable, string aPrimaryKey, string aWhereSelect, ToolStripProgressBar aPB1, MySqlConnection aConnHost, MySqlConnection aConnDesc)
        {
            string lsColumnName = "", lsData = "", lsDataType = "", lsInsertInto = "", lsDataInto = "", lsSQL = "", lsPrimaryKeyData = "", lsExeCData = "", lsPrimaryKeyData2 = "";
            Int32 liCount=0;
            if (aWhereSelect == "")
            {
                lsSQL = "Select count(*) as cnt From " + aTable.ToString().ToLower();
            }
            else
            {
                lsSQL = "Select count(*) as cnt From " + aTable.ToString().ToLower() + " Where " + aWhereSelect;
            }
            MySqlCommand lsCommData = new MySqlCommand(lsSQL, aConnHost);
            MySqlDataReader lsReadData;
            lsReadData = lsCommData.ExecuteReader();
            if (lsReadData.HasRows)
            {
                while (lsReadData .Read ())
                {
                    liCount = Convert.ToInt32(lsReadData["cnt"]);
                }
            }
            lsReadData .Close ();
            aPB1.Minimum = 0;
            aPB1.Maximum = liCount;
            aPB1.Visible = true;
            if (aWhereSelect == "")
            {
                lsSQL = "Select * From " + aTable.ToString().ToLower();
            }
            else
            {
                lsSQL = "Select * From " + aTable.ToString().ToLower() + " Where " + aWhereSelect;
            }
            MySqlCommand lsCommExeC = new MySqlCommand();
            lsCommExeC.Connection = aConnDesc;
            lsCommData.CommandText = lsSQL;
            lsReadData = lsCommData.ExecuteReader();
            if (lsReadData.HasRows)
            {
                Int32 i = 0, j = 0;
                while (lsReadData.Read())
                {
                    try
                    {
                        lsInsertInto = "Insert Into " + aTable.ToString().ToLower() + "(";
                        lsDataInto = " Values (";
                        for (Int32 k = 0; k <= lsReadData.FieldCount - 1; k++)
                        {
                            lsColumnName = lsReadData.GetName(k).ToString().ToLower();
                            lsInsertInto = lsInsertInto + " " + lsColumnName + ",";
                            lsDataType = lsReadData.GetFieldType(k).ToString().ToLower();
                            lsData = lsReadData[lsColumnName].ToString();
                            if (lsColumnName == aPrimaryKey)
                            {
                                lsPrimaryKeyData = lsData;
                            }
                            switch (lsDataType)
                            {
                                case "system.string":
                                    {
                                        lsData = lsData.Replace("'", "''");
                                        lsDataInto = lsDataInto + " '" + lsData + "',";
                                        break;
                                    }
                                case "system.datetime":
                                    {
                                        if (lsData == "")
                                        {
                                            lsData = "null";
                                            lsDataInto = lsDataInto + " " + lsData + ",";
                                        }
                                        else
                                        {
                                            lsDataInto = lsDataInto + " '" + lsData + "',";
                                        }
                                        break;
                                    }
                                case "system.double":
                                    {
                                        if (lsData == "")
                                        {
                                            lsData = "0";
                                            lsDataInto = lsDataInto + " " + lsData + ",";
                                        }
                                        else
                                        {
                                            lsDataInto = lsDataInto + " " + lsData + ",";
                                        }
                                        break ;
                                    }
                                case "system.decimal":
                                    {
                                        if (lsData == "")
                                        {
                                            lsData = "0";
                                            lsDataInto = lsDataInto + " " + lsData + ",";
                                        }
                                        else
                                        {
                                            lsDataInto = lsDataInto + " " + lsData + ",";
                                        }
                                        break;
                                    }
                                case "system.int16":
                                    {
                                        if (lsData == "")
                                        {
                                            lsData = "0";
                                            lsDataInto = lsDataInto + " " + lsData + ",";
                                        }
                                        else
                                        {
                                            lsDataInto = lsDataInto + " " + lsData + ",";
                                        }
                                        break;
                                    }
                                case "system.int32":
                                    {
                                        if (lsData == "")
                                        {
                                            lsData = "0";
                                            lsDataInto = lsDataInto + " " + lsData + ",";
                                        }
                                        else
                                        {
                                            lsDataInto = lsDataInto + " " + lsData + ",";
                                        }
                                        break;
                                    }
                                case "system.uint32":
                                    {
                                        if (lsData == "")
                                        {
                                            lsData = "0";
                                            lsDataInto = lsDataInto + " " + lsData + ",";
                                        }
                                        else
                                        {
                                            lsDataInto = lsDataInto + " " + lsData + ",";
                                        }
                                        break;
                                    }
                                default :
                                    {
                                        lsDataInto = lsDataInto + " " + lsData + ",";
                                        break ;
                                    }
                            }
                        }
                        lsInsertInto = lsInsertInto.Substring(0, lsInsertInto.Length - 1) + ") ";
                        lsDataInto = lsDataInto.Substring(0, lsDataInto.Length - 1) + ") ";
                        lsExeCData = lsInsertInto + lsDataInto;
                        lsSQL = "Delete From " + aTable.ToString().ToLower() + " Where " + aPrimaryKey + "='" + lsPrimaryKeyData + "'";
                        lsCommExeC.CommandText = lsSQL;
                        lsCommExeC.ExecuteNonQuery();
                        lsCommExeC.CommandText = lsExeCData;
                        lsCommExeC.ExecuteNonQuery();
                        i++;
                        aPB1.Value = i;
                    }
                    catch (Exception e)
                    {
                        string ls = "ไม่สามารถ SeparateTable ได้ ";
                        WriteLogError(ls, e, "", "SeparateTable");
                        MessageBox.Show(ls + " " + e.Message.ToString(), e.Source.ToString());
                    }
                }
            }
            aPB1.Visible = false;
            lsReadData.Close();
        }
        public ComboBox SelectCbo(ComboBox Cbo, string lsWhereCode, TableIniT aFlag)
        {
            string lsSQL = "", ls="";
            if (aFlag == TableIniT.YearName)
            {
                Int32 i = 2546;
                ArrayList lsList = new ArrayList();
                for (i = 2546; i <= System.DateTime.Now.Year+543; i++)
                {
                    lsList.Add(new CboState(i.ToString(),i.ToString()));
                }
                Cbo.DataSource = lsList;
                Cbo.DisplayMember = "LongName";
                Cbo.ValueMember = "ShortName";
                Cbo.Text = "";
            }
            else if (Cbo.Name.ToString() == TableIniT.CboLinkPicture.ToString())
            {
                ArrayList lsList1 = new ArrayList();
                lsSQL = "Select id, name From cboselect Where cboname = '" + Cbo.Name + "' Order by name";
                MySqlCommand lsComm1 = new MySqlCommand(lsSQL, Gdb);
                MySqlDataReader lsReader1;
                lsReader1 = lsComm1.ExecuteReader();
                if (lsReader1.HasRows)
                {
                    while (lsReader1.Read())
                    {
                        //Cbo.Items.Add(lsReader.GetValue(1).ToString());
                        lsList1.Add(new CboState(lsReader1.GetValue(0).ToString().Trim(), lsReader1.GetValue(1).ToString().Trim()));
                        //lsSQL = lsReader.GetValue(1).ToString();
                    }
                }
                lsReader1.Close();
                lsSQL = "Select m.plcode, t.plnamee From typeroom t, memberpricelist m "
                                + "Where m.memid = '" + lsWhereCode + "'  and m.plcode = t.plcode Order by plnamee";
                MySqlCommand lsComm2 = new MySqlCommand(lsSQL, Gdb);
                MySqlDataReader lsReader2;
                lsReader2 = lsComm2.ExecuteReader();
                if (lsReader2.HasRows)
                {
                    while (lsReader2.Read())
                    {
                        //Cbo.Items.Add(lsReader.GetValue(1).ToString());
                        lsList1.Add(new CboState(lsReader2.GetValue(0).ToString().Trim(), lsReader2.GetValue(1).ToString().Trim()));
                        //lsSQL = lsReader.GetValue(1).ToString();
                    }
                }
                if (aFlag == TableIniT.TypeRoom)
                {
                    lsList1.Add(new CboState("-", "-"));
                }
                Cbo.DataSource = lsList1;
                Cbo.DisplayMember = "LongName";
                Cbo.ValueMember = "ShortName";
                Cbo.Text = "";
                lsReader2.Close();
            }
            else
            {
                string lsWhere = "";
                switch (aFlag)
                {
                    case TableIniT.Nationality:
                        lsSQL = "Select nationcode, nationname From nationality Order By nationname";
                        break;
                    case TableIniT.SubDistrict :
                        lsSQL = "Select s.subdistrictcode, concat(s.subdistrictnamet, ' / ', d.districtnamet, ' / ' , p.provnamet) From subdistrict s, district d, province1 p Where s.subdistrictnamet like '" + lsWhereCode + "%' and s.districtcode = d.districtcode and s.provcode = p.provcode order by p.provnamet, d.districtnamet";
                        break;
                    case TableIniT .CboDistrictFromProvCode :
                        lsSQL = "Select districtcode, districtnamet From district Where provcode = '" + lsWhereCode + "'";
                        break;
                    case TableIniT .CboDistrictFromSubDistrict :
                        lsSQL = "Select d.districtcode, d.districtnamet From district d Where  districtcode = (Select districtcode From subdistrict Where subdistrictcode = '" + lsWhereCode + "') ";
                        break;
                    case TableIniT.District:
                        {
                            lsSQL = "Select districtcode, districtnamet From district Where provcode = '" + lsWhereCode + "' Order by districtnamet";
                            break;
                        }
                    case TableIniT.CboSubDistrictFromDistrict:
                        {
                            lsSQL = "Select subdistrictcode, subdistrictnamet From subdistrict Where districtcode = '" + lsWhereCode + "' Order by subdistrictnamet";
                            break;
                        }
                    case TableIniT.Province:
                        {
                            lsSQL = "Select provcode, provname From province Order by provname";
                            break;
                        }
                    case TableIniT.Member:
                        if (lsWhereCode == "")
                        {
                            lsWhere = "1 = 1";
                        }
                        else
                        {
                            lsWhere = " provcode = '" + lsWhereCode + "'";
                        }
                        lsSQL = "Select memid, memnamee1 From member Where " + lsWhere + " and flag = '1' and flagsale = '1' Order by memnamee1";
                        break;
                    case TableIniT.MemberFromRegCode:
                        lsSQL = "Select regisid, nameeng From regis Where regcode = '" + lsWhereCode + "' Order by nameeng";
                        break;
                    case TableIniT.Shift:
                        lsSQL = "Select shiftcode, shiftname From shift Order by shiftcode";
                        break;
                    case TableIniT.TypeRoom:
                        if (lsWhereCode == "")
                        {
                            //lsSQL = "Select plcode, plnamee From typeroom Order by plnamee";
                            lsSQL = "Select m.plcode, t.plnamee From typeroom t, memberpricelist m "
                                + "Where m.memid = '" + lsWhereCode + "'  and m.plcode = t.plcode Order by plnamee";
                        }
                        else
                        {
                            lsSQL = "Select m.plcode, t.plnamee From typeroom t, memberpricelist m "
                                + "Where m.memid = '" + lsWhereCode + "'  and m.plcode = t.plcode Order by plnamee";
                        }
                        break;
                    case TableIniT.Region:
                        lsSQL = "Select regioncode, regionname From region Order by sort1";
                        break;
                    case TableIniT.Staff:
                        lsSQL = "Select staffcode, staffname From staff Order by staffname";
                        break;
                    case TableIniT.Status:
                        lsSQL = "Select statuscode, statusname From status Where flag = '1' Order by statusname";
                        break;
                    case TableIniT.HotelChain:
                        lsSQL = "Select hotelchaincode, hotelchainname From hotelchain Order by hotelchainname";
                        break;
                    case TableIniT.TypeMem:
                        lsSQL = "Select tmemcode, tmemname From typemem Order by tmemname";
                        break;
                    case TableIniT.TypeBis:
                        lsSQL = "Select tbiscode, tbisname From typebis Order by tbisname";
                        break;
                    case TableIniT.GreenLeft:
                        lsSQL = "Select greencode, greenname From greenleft Order by greenname";
                        break;
                    case TableIniT.Location:
                        lsSQL = "Select locationcode, locationnamet From location Order by locationnamet";
                        break;
                    case TableIniT.MemberOwner:
                        lsSQL = "Select distinct ownerid, ownernamet From memberowner Order by ownernamet";
                        break;
                    case TableIniT.Star:
                        lsSQL = "Select starcode, starname From star Order by starname";
                        break;
                    case TableIniT.CboVoucherView:
                        lsSQL = "Select id, name From cboselect Where cboname = '" + lsWhereCode + "' Order by name";
                        break;
                    case TableIniT.CboPrefix:
                        lsSQL = "Select id, name From cboselect Where cboname = '" + lsWhereCode + "' Order by name";
                        break;
                    case TableIniT.CboMemViewFilter:
                        lsSQL = "Select id, name From cboselect Where cboname = '" + lsWhereCode + "' Order by name";
                        break;
                    case TableIniT.CboShopView:
                        lsSQL = "Select id, name From cboselect Where cboname = '" + lsWhereCode + "' Order by name";
                        break;
                    case TableIniT.CboTSend:
                        lsSQL = "Select id, name From cboselect Where cboname = '" + lsWhereCode + "' Order by name";
                        break;
                    case TableIniT.CboLinkPicture:
                        lsSQL = "Select id, name From cboselect Where cboname = '" + lsWhereCode + "' Order by name";
                        break;
                    case TableIniT.CboTypePayment:
                        lsSQL = "Select tpaycode, tpaynamee From typepayment Order by tpaynamee";
                        break;
                    case TableIniT.CboAddress:
                        lsSQL = "Select id, name From cboselect Where cboname = 'cboaddress' Order by name";
                        break;
                    case TableIniT.MonthName:
                        lsSQL = "Select monthid, monthnamee From monthname ";
                        break;
                    case TableIniT .MemberStatus :
                        lsSQL = "Select id, name From cboselect Where cboname = 'cbomemberstatus' Order by id";
                        break;
                    case TableIniT.Counter:
                        if (lsWhereCode == "ip")
                        {
                            lsSQL = "Select ip, countername From counter Where flag = '1' Order By counterid";
                        }
                        else if (lsWhereCode == "report")
                        {
                            lsSQL = "Select ip, countername From counter Order By counterid";
                        }
                        else
                        {
                            lsSQL = "Select counterid, countername From counter Where flag = '1' Order By counterid";
                        }
                        break;
                }
                //lsSQL = "Select nationcode, nationname From nationality ";
                
                MySqlCommand lsComm = new MySqlCommand(lsSQL, Gdb);
                MySqlDataReader lsReader;
                lsReader = lsComm.ExecuteReader();
                if (lsReader.HasRows)
                {
                    ArrayList lsList = new ArrayList();
                    if (aFlag == TableIniT.TypeRoom)
                    {
                        lsList.Add(new CboState("-", "-"));
                    }
                    else if (aFlag == TableIniT.CboDistrictFromSubDistrict)
                    {
                        lsList.Add(new CboState("-", "-"));
                    }
                    while (lsReader.Read())
                    {
                        //Cbo.Items.Add(lsReader.GetValue(1).ToString());
                        ls = lsReader.GetValue(1).ToString().Trim();
                        lsList.Add(new CboState(lsReader.GetValue(0).ToString().Trim(), lsReader.GetValue(1).ToString().Trim()));
                        //lsSQL = lsReader.GetValue(1).ToString();
                    }
                    Cbo.DataSource = lsList;
                    Cbo.DisplayMember = "LongName";
                    Cbo.ValueMember = "ShortName";
                    Cbo.Text = "";
                }
                lsReader.Close();
                switch (aFlag)
                {
                    case TableIniT.CboDistrictFromSubDistrict:
                        {
                            //lsSQL = Cbo.SelectedValue.ToString();
                            //ls = Cbo.SelectedItem.ToString();
                            Cbo.SelectedValue = ls;
                            //Cbo.SelectedItem = ls;
                            //lsSQL = Cbo.SelectedText;
                            break;
                        }
                }
            }
            return Cbo;
        }
    }
}
