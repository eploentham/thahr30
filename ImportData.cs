using System;
using System.IO;
using System.Xml;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data.OleDb;
namespace ThaHr30
{
    public partial class ImportData : Form
    {
        public ImportData()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Connection lsGdb = new Connection();
            Int32 i=0, liNumRoom=0, liAddressID=0;
            string lsSubDistrict = "", lsDistrict = "", lsTele="", lsFax="", lsWeb="", lsEmail="", lsPostCode="", lsSoi="";
            string lsMemID = "", lsMemNameT = "", lsMemNameE1="", lsTmemCode="", lsRegCode="", lsStar="", lsMemNameE2="", lsFlagGreenLeft="";
            string lsFlagSale="", lsTbisCode="", lsRemark="", lsNationCode = "", lsHotelChainCode="", lsTypePricebaht="", lsLine1="", lsProvCode="", lsAddressCode="", lsStartDate="", lsEndDate="", lsRegisDate="", lsSKK9ID="";
            decimal ldoPriceStart = 0, ldoPriceEnd = 0;
            IniFile lsIni = new IniFile("thahr30.ini");
            string lsCharSet = lsIni.GetString("thahr30", "charset", "tis620");
            string lsServer = lsIni.GetString("thahr30", "serverdatabasename", "localhost");
            string lsDatabase = lsIni.GetString("thahr30", "databasename", "thahr3");
            string lsUserName = lsIni.GetString("thahr30", "username", "janepop");
            string lsPassword = lsIni.GetString("thahr30", "password", "Ekartc2c5");
            OleDbConnection acc = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=d:\\thahr30\\thahr20.mdb;");
            acc.Open();
            MySqlConnection conn = new MySqlConnection("Data Source=" + lsServer + ";Database=" + lsDatabase + ";User ID="+lsUserName+";Password="+lsPassword+";CHARSET=" + lsCharSet + "");
            conn.Open();
            string lsSQL = "Select count(*) as cnt From regis ";
            OleDbCommand accCom = new OleDbCommand(lsSQL, acc);
            OleDbDataReader lsAccRead1;
            lsAccRead1 = accCom.ExecuteReader();
            if (lsAccRead1.HasRows)
            {

                while (lsAccRead1.Read())
                {
                    Pb1.Minimum = 0;
                    lsSQL = lsAccRead1.GetValue(0).ToString();
                    Pb1.Maximum = Convert.ToInt32(lsAccRead1.GetValue(0).ToString());
                }
            }
            lsAccRead1.Close();
            Pb1.Visible = true;
            SL1.Visible = true;
            OleDbDataReader lsRead;
            MySqlCommand lsCom = new MySqlCommand("truncate table address", conn);
            lsCom.ExecuteNonQuery();
            lsSQL = "Select * From regis";
            accCom.CommandText = lsSQL;
            lsRead = accCom.ExecuteReader();
            while (lsRead.Read())
            {
                i++;
                lsMemID = lsRead.GetValue(0).ToString();
                lsMemNameT = lsRead.GetValue(3).ToString();
                //lsMemNameT = textBox1.Text;
                lsMemNameE1 = lsRead.GetValue(1).ToString();
                lsMemNameE2 = lsRead["nameeng2"].ToString();
                lsTmemCode = lsRead["typecode"].ToString();
                lsRegCode = lsRead["regcode"].ToString();
                lsStar = lsRead["class1"].ToString();
                lsStartDate = lsGdb.SelectDateMySQL(Convert .ToDateTime(lsRead["inoperdate"]));
                lsEndDate = lsGdb.SelectDateMySQL(Convert .ToDateTime(lsRead["expiredate"]));
                lsRegisDate = lsGdb.SelectDateMySQL(Convert .ToDateTime(lsRead["regisdate"]));
                lsFlagGreenLeft = lsRead["flaggreenleft"].ToString();
                liNumRoom = Convert .ToInt32 ( lsRead["size1"]);
                lsSQL = lsRead.GetValue(90).ToString();
                if (lsRead.GetValue(90).ToString() != "")
                {
                    ldoPriceStart = Convert.ToDecimal(lsRead["frroomprice"].ToString());
                }
                else
                {
                    ldoPriceStart = 0;
                }
                if (lsRead.GetValue(90).ToString() != "")
                {
                    ldoPriceEnd = Convert .ToDecimal(lsRead["toroomprice"].ToString());
                }
                else
                {
                    ldoPriceEnd = 0;
                }
                lsFlagSale = lsRead["sale"].ToString();
                lsTbisCode = lsRead["tbiscode"].ToString();
                lsRemark = lsRead["remark"].ToString();
                lsNationCode = lsRead["nationcode"].ToString();
                lsHotelChainCode = lsRead["chaincode"].ToString();
                lsSKK9ID = lsRead["membercode"].ToString();
                lsTypePricebaht = "1";
                if (ldoPriceStart > 0)
                {
                    lsTypePricebaht = "0";
                }
                lsSQL = "Update member Set memnamet = '" + lsMemNameT + "', memnamee1 = '"
                    + lsMemNameE1 + "', tmemcode = '" + lsTmemCode + "', numroom = "
                    + liNumRoom + ", regioncode = '" + lsRegCode + "', star = '"
                    + lsStar + "', memnamee2 = '" + lsMemNameE2 + "', flaggreenleft = '"
                    + lsFlagGreenLeft + "', flagsale = '" + lsFlagSale + "', tbiscode = '"
                    + lsTbisCode + "', remark = '" + lsRemark + "', nationcode = '"
                    + lsNationCode + "', hotelchaincode = '" + lsHotelChainCode + "', pricestart="
                    + ldoPriceStart + ", priceend = " + ldoPriceEnd + ", typepricebaht =" + lsTypePricebaht + ", startdate = '" + lsStartDate + "', enddate = '" + lsEndDate + "', regisdate = '" + lsRegisDate + "', skk9id = '" + lsSKK9ID + "' Where memid = '" + lsMemID + "'";
                MySqlCommand lsCom2 = new MySqlCommand(lsSQL, conn);
                lsCom2.ExecuteNonQuery();
                lsSQL = "select count(*) as cnt From address ";
                MySqlCommand lsComm5 = new MySqlCommand(lsSQL, conn);
                MySqlDataReader lsRead1 = lsComm5.ExecuteReader();
                while (lsRead1.Read())
                {
                     liAddressID = Convert.ToInt32(lsRead1["cnt"]);
                }
                lsRead1.Close();
                liAddressID++;
                lsSoi = lsRead["locasoi"].ToString();
                lsSQL = lsRead["locasubdistrict"].ToString();
                lsSubDistrict = lsRead["locasubdistrict"].ToString().Replace("ตำบล", "");
                lsDistrict = lsRead["locadistrict"].ToString();
                lsEmail = lsRead["locaemail"].ToString();
                lsWeb = lsRead["locaweb"].ToString();
                lsTele = lsRead["locatele"].ToString();
                lsFax = lsRead["locafax"].ToString();
                lsPostCode = lsRead["locapostcode"].ToString();
                lsLine1 = lsRead["locano"].ToString() + " " + lsSoi + " " + lsRead["locaroad"].ToString(); //+ " " + lsSubDistrict + " " + lsDistrict;
                lsProvCode = lsRead["locaprovcode"].ToString();
                lsSQL = "Delete From address Where refid = '" + lsMemID + "' and addressid = " + liAddressID;
                MySqlCommand lsComm3 = new MySqlCommand(lsSQL, conn);
                lsComm3.ExecuteNonQuery();
                lsSQL = "Insert Into address (refid, addressid, addressname, line1, " 
                    + "provcode, subdistrictcode, districtcode, " 
                    + "fax, email, telephone, website, postcode, addresscode) "
                    + "Values('" + lsMemID + "'," + liAddressID + ",'ที่อยู่ของโรงแรม','" + lsLine1 + "','" 
                    + lsProvCode + "','" + lsSubDistrict + "','" + lsDistrict + "','" 
                    + lsFax + "','" + lsEmail +"','" + lsTele + "','" + lsWeb + "','"+ lsPostCode + "','106')";
                MySqlCommand lsComm4 = new MySqlCommand(lsSQL, conn);
                lsComm4.ExecuteNonQuery();
                liAddressID++;
                lsSoi = lsRead["mailsoi"].ToString();
                lsSQL = lsRead["mailsubdistrict"].ToString();
                lsSubDistrict = lsRead["mailsubdistrict"].ToString();
                lsDistrict = lsRead["maildistrict"].ToString();
                lsEmail = lsRead["mailemail"].ToString();
                lsWeb = lsRead["mailweb"].ToString();
                lsTele = lsRead["mailtele"].ToString();
                lsFax = lsRead["mailfax"].ToString();
                lsPostCode = lsRead["mailpostcode"].ToString();
                lsLine1 = lsRead["mailno"].ToString() + " " + lsSoi + " " + lsRead["mailroad"].ToString(); //+ " " + lsSubDistrict + " " + lsDistrict;
                lsProvCode = lsRead["mailprovcode"].ToString();
                lsSQL = "Delete From address Where refid = '" + lsMemID + "' and addressid = " + liAddressID;
                MySqlCommand lsComm7 = new MySqlCommand(lsSQL, conn);
                lsComm7.ExecuteNonQuery();
                lsSQL = "Insert Into address (refid, addressid, addressname, line1, "
                    + "provcode, subdistrictcode, districtcode, "
                    + "fax, email, telephone, website, postcode, addresscode) "
                    + "Values('" + lsMemID + "'," + liAddressID + ",'ที่อยู่สำหรับส่งเอกสาร','" + lsLine1 + "','"
                    + lsProvCode + "','" + lsSubDistrict + "','" + lsDistrict + "','"
                    + lsFax + "','" + lsEmail + "','" + lsTele + "','" + lsWeb + "','" + lsPostCode + "','107')";
                MySqlCommand lsComm6 = new MySqlCommand(lsSQL, conn);
                lsComm6.ExecuteNonQuery();

                liAddressID++;
                lsSoi = lsRead["bkksoi"].ToString();
                lsSQL = lsRead["bkksubdistrict"].ToString();
                lsSubDistrict = lsRead["bkksubdistrict"].ToString();
                lsDistrict = lsRead["bkkdistrict"].ToString();
                lsEmail = lsRead["bkkemail"].ToString();
                lsWeb = lsRead["bkkweb"].ToString();
                lsTele = lsRead["bkktele"].ToString();
                lsFax = lsRead["bkkfax"].ToString();
                lsPostCode = lsRead["bkkpostcode"].ToString();
                lsLine1 = lsRead["bkkno"].ToString() + " " + lsSoi + " " + lsRead["mailroad"].ToString(); //+ " " + lsSubDistrict + " " + lsDistrict;
                lsProvCode = lsRead["bkkprovcode"].ToString();
                lsSQL = "Delete From address Where refid = '" + lsMemID + "' and addressid = " + liAddressID;
                MySqlCommand lsComm8 = new MySqlCommand(lsSQL, conn);
                lsComm8.ExecuteNonQuery();
                lsSQL = "Insert Into address (refid, addressid, addressname, line1, "
                    + "provcode, subdistrictcode, districtcode, "
                    + "fax, email, telephone, website, postcode, addresscode) "
                    + "Values('" + lsMemID + "'," + liAddressID + ",'ที่อยู่ของสำนักงาน','" + lsLine1 + "','"
                    + lsProvCode + "','" + lsSubDistrict + "','" + lsDistrict + "','"
                    + lsFax + "','" + lsEmail + "','" + lsTele + "','" + lsWeb + "','" + lsPostCode + "','108')";
                MySqlCommand lsComm9 = new MySqlCommand(lsSQL, conn);
                lsComm9.ExecuteNonQuery();
                liAddressID++;
                lsSoi = lsRead["locasoit"].ToString();
                lsSQL = lsRead["locasubdistrictt"].ToString();
                lsSubDistrict = lsRead["locasubdistrictt"].ToString().Replace("ตำบล", "");
                lsSubDistrict = lsSubDistrict.Replace("แขวง", "");
                lsDistrict = lsRead["locadistrictt"].ToString();
                lsEmail = lsRead["locaemail"].ToString();
                lsWeb = lsRead["locaweb"].ToString();
                lsTele = lsRead["locatele"].ToString();
                lsFax = lsRead["locafax"].ToString();
                lsPostCode = lsRead["locapostcode"].ToString();
                lsLine1 = lsRead["locano"].ToString() + " " + lsSoi + " " + lsRead["locaroadt"].ToString(); //+ " " + lsSubDistrict + " " + lsDistrict;
                lsProvCode = lsRead["locaprovcode"].ToString();
                lsSQL = "Delete From address Where refid = '" + lsMemID + "' and addressid = " + liAddressID;
                MySqlCommand lsComm10 = new MySqlCommand(lsSQL, conn);
                lsComm10.ExecuteNonQuery();
                lsSQL = "Insert Into address (refid, addressid, addressname, line1, "
                    + "provcode, subdistrictcode, districtcode, "
                    + "fax, email, telephone, website, postcode, addresscode) "
                    + "Values('" + lsMemID + "'," + liAddressID + ",'ที่อยู่ของโรงแรมภาษาไทย','" + lsLine1 + "','"
                    + lsProvCode + "','" + lsSubDistrict + "','" + lsDistrict + "','"
                    + lsFax + "','" + lsEmail + "','" + lsTele + "','" + lsWeb + "','" + lsPostCode + "','109')";
                MySqlCommand lsComm11 = new MySqlCommand(lsSQL, conn);
                lsComm11.ExecuteNonQuery();
                lsSQL = "Update member Set addressid = '" + liAddressID + "' Where memid = '" + lsMemID + "'";
                MySqlCommand lsComm31 = new MySqlCommand(lsSQL, conn);
                lsComm31.ExecuteNonQuery();
                liAddressID++;
                lsSoi = lsRead["mailsoit"].ToString();
                lsSubDistrict = lsRead["mailsubdistrictt"].ToString().Replace("ตำบล", "");
                lsSubDistrict = lsSubDistrict.Replace("แขวง", "");
                lsDistrict = lsRead["maildistrictt"].ToString();
                lsEmail = lsRead["mailemail"].ToString();
                lsWeb = lsRead["mailweb"].ToString();
                lsTele = lsRead["mailtele"].ToString();
                lsFax = lsRead["mailfax"].ToString();
                lsPostCode = lsRead["mailpostcode"].ToString();
                lsLine1 = lsRead["mailno"].ToString() + " " + lsSoi + " " + lsRead["mailroadt"].ToString();// +" " + lsSubDistrict + " " + lsDistrict;
                lsProvCode = lsRead["mailprovcode"].ToString();
                lsSQL = "Delete From address Where refid = '" + lsMemID + "' and addressid = " + liAddressID;
                MySqlCommand lsComm12 = new MySqlCommand(lsSQL, conn);
                lsComm12.ExecuteNonQuery();
                lsSQL = "Insert Into address (refid, addressid, addressname, line1, "
                    + "provcode, subdistrictcode, districtcode, "
                    + "fax, email, telephone, website, postcode, addresscode) "
                    + "Values('" + lsMemID + "'," + liAddressID + ",'ที่อยู่สำหรับส่งเอกสารภาษาไทย','" + lsLine1 + "','"
                    + lsProvCode + "','" + lsSubDistrict + "','" + lsDistrict + "','"
                    + lsFax + "','" + lsEmail + "','" + lsTele + "','" + lsWeb + "','" + lsPostCode + "','110')";
                MySqlCommand lsComm13 = new MySqlCommand(lsSQL, conn);
                lsComm13.ExecuteNonQuery();
                SL1.Text = i.ToString() + " " + Pb1.Maximum.ToString();
                Pb1.Value = i;
                Application.DoEvents();
            }
            lsRead.Close();
            lsSQL = "update address a, subdistrict s set a.subdistrictcode = s.subdistrictcode where a.subdistrictcode = s.subdistrictnamet";
            MySqlCommand lsComm14 = new MySqlCommand(lsSQL, conn);
            lsComm14.ExecuteNonQuery();
            lsSQL = "update address a, district d set a.districtcode = d.districtcode where a.districtcode = d.districtnamet";
            MySqlCommand lsComm15 = new MySqlCommand(lsSQL, conn);
            lsComm15.ExecuteNonQuery();
            acc.Close();
            conn.Close();
            Pb1.Visible = false;
            SL1.Visible = false;
        }

        private void ImportData_Load(object sender, EventArgs e)
        {
            Pb1.Visible = false;
            SL1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UTF8Encoding utf8 = new UTF8Encoding();

            // A Unicode string with two characters outside an 8-bit code range.
            String unicodeString ="";
            unicodeString = textBox1.Text;
            //Console.WriteLine("Original string:");
            //Console.WriteLine(unicodeString);
            // Encode the string.
            Byte[] encodedBytes = utf8.GetBytes(unicodeString);
            //Console.WriteLine();
            //Console.WriteLine("Encoded bytes:");
            //foreach (Byte b in encodedBytes)
            //{
            //    Console.Write("[{0}]", b);
            //    textBox2.Text = "[{0}]" + b;
            //}
            //Console.WriteLine();

            // Decode bytes back to string.
            // Notice Pi and Sigma characters are still present.
            String decodedString = utf8.GetString(encodedBytes);
            textBox2.Text = decodedString;
            //Console.WriteLine();
            //Console.WriteLine("Decoded bytes:");
            //Console.WriteLine(decodedString);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Int32 i = 0,j=0;
            IniFile lsIni = new IniFile("thahr30.ini");
            string lsServer = lsIni.GetString("thahr30", "serverdatabasename", "localhost");
            string lsDatabase = lsIni.GetString("thahr30", "databasename", "thahr3");
            string lsUserName = lsIni.GetString("thahr30", "username", "janepop");
            string lsPassword = lsIni.GetString("thahr30", "password", "Ekartc2c5");
            string lsSQL = "Select hotelcode, roomrate, vouno, counter1 From voucher Where memplcode in ('-','')";
            string lsVouNo="", lsMemId="", lsPlCode="", lsMemPlCode="";
            MySqlConnection conn = new MySqlConnection("Data Source=" + lsServer + ";Database=" + lsDatabase + ";User ID="+lsUserName+";Password="+lsPassword+"");
            conn.Open();
            MySqlConnection conn1 = new MySqlConnection("Data Source=" + lsServer + ";Database=" + lsDatabase + ";User ID="+lsUserName+";Password="+lsPassword+"");
            conn1.Open();
            MySqlConnection conn2 = new MySqlConnection("Data Source=" + lsServer + ";Database=" + lsDatabase + ";User ID="+lsUserName+";Password="+lsPassword+"");
            conn2.Open();
            MySqlConnection conn3 = new MySqlConnection("Data Source=" + lsServer + ";Database=" + lsDatabase + ";User ID="+lsUserName+";Password="+lsPassword+"");
            conn3.Open();
            MySqlCommand lsComm = new MySqlCommand(lsSQL, conn);
            MySqlDataReader lsRead;
            lsSQL = "";
            lsRead = lsComm.ExecuteReader();
            if (lsRead.HasRows)
            {
                //MySqlDataAdapter aaa = new MySqlDataAdapter();
                while (lsRead.Read())
                {
                    lsVouNo = lsRead["vouno"].ToString();
                    lsSQL = "Select plcode From memberpricelist Where memid = '" + lsRead["hotelcode"].ToString() + "' and pricestart <= " + lsRead["roomrate"].ToString() + " and priceend >= " + lsRead["roomrate"].ToString();
                    MySqlCommand lsComm1 = new MySqlCommand(lsSQL, conn1);
                    MySqlDataReader lsRead1;
                    lsRead1 = lsComm1.ExecuteReader();
                    if (lsVouNo == "")
                    {
                        lsSQL = "";
                    }
                    if (lsVouNo == "49002000023")
                    {
                        lsSQL = lsRead["hotelcode"].ToString();
                        //lsSQL = lsRead3["plcode"].ToString();
                    }
                    if (lsRead1.HasRows)
                    {
                        i++;
                        while (lsRead1.Read())
                        {
                            
                            textBox1.Text = i.ToString();
                            listBox2.Items.Add(i.ToString() + " " + lsRead["hotelcode"].ToString() + lsRead1 ["plcode"].ToString ());
                            lsSQL = "Update voucher Set memplcode = '" + lsRead["hotelcode"].ToString() + lsRead1 ["plcode"].ToString()
                                + "' Where vouno = '" + lsVouNo + "' and counter1 = '" + lsRead["counter1"].ToString() + "'";
                            MySqlCommand lsComm2 = new MySqlCommand(lsSQL, conn2);
                            lsComm2.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        j++;
                        listBox1.Items.Add(j.ToString () + " " + lsRead["hotelcode"].ToString());
                        textBox2.Text = j.ToString();
                        lsSQL = "Select plcode From memberpricelist Where memid = '" 
                            + lsRead["hotelcode"].ToString() + "' and priceend <= " + lsRead["roomrate"].ToString();
                        MySqlCommand lsComm3 = new MySqlCommand(lsSQL, conn2);
                        MySqlDataReader lsRead3;
                        lsRead3 = lsComm3.ExecuteReader();
                        if (lsRead3.HasRows)
                        {
                            lsMemId = lsRead["hotelcode"].ToString();
                            while (lsRead3.Read())
                            {
                                //lsSQL = lsRead["hotelcode"].ToString() + lsRead3["plcode"].ToString();
                                
                                lsPlCode = lsRead3["plcode"].ToString();
                                lsMemPlCode = lsMemId + lsPlCode;
                                listBox3.Items.Add(lsRead["hotelcode"].ToString() + lsRead3["plcode"].ToString());
                                lsSQL = "Update voucher Set memplcode = '" + lsMemPlCode +"' Where vouno = '" + lsVouNo + "'";
                                MySqlCommand lsComm4 = new MySqlCommand(lsSQL, conn3);
                                lsComm4.ExecuteNonQuery();
                            }
                        }
                        lsRead3.Close();
                    }
                    lsRead1.Close();
                    Application.DoEvents();
                }
            }
            lsRead.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Int32 i = 0,j=0;
            IniFile lsIni = new IniFile("thahr30.ini");
            string lsServer = lsIni.GetString("thahr30", "serverdatabasename", "localhost");
            string lsDatabase = lsIni.GetString("thahr30", "databasename", "thahr3");
            string lsUserName = lsIni.GetString("thahr30", "username", "janepop");
            string lsPassword = lsIni.GetString("thahr30", "password", "Ekartc2c5");
            string lsSQL = "Select memid, memnamee1 From member ";
            string lsMemId="";
            MySqlConnection conn = new MySqlConnection("Data Source=" + lsServer + ";Database=" + lsDatabase + ";User ID="+lsUserName+";Password="+lsPassword+"");
            conn.Open();
            MySqlConnection conn1 = new MySqlConnection("Data Source=" + lsServer + ";Database=" + lsDatabase + ";User ID="+lsUserName+";Password="+lsPassword+"");
            conn1.Open();
            MySqlConnection conn2 = new MySqlConnection("Data Source=" + lsServer + ";Database=" + lsDatabase + ";User ID="+lsUserName+";Password="+lsPassword+"");
            conn2.Open();
            MySqlDataReader lsRead;
            MySqlCommand lsComm = new MySqlCommand(lsSQL , conn);
            lsSQL = "";
            lsRead = lsComm.ExecuteReader();
            if (lsRead.HasRows)
            {
                while (lsRead.Read())
                {
                    lsMemId = lsRead["memid"].ToString();
                    lsSQL = "Select provcode From hotel Where hotelcode = '" + lsMemId + "'";
                    MySqlCommand Comm1 = new MySqlCommand(lsSQL, conn1);
                    MySqlDataReader lsRead1;
                    lsRead1 = Comm1.ExecuteReader();
                    if (lsRead1.Read())
                    {
                        lsSQL = "Update member Set provcode = '" + lsRead1["provcode"].ToString() + "' Where memid = '" + lsMemId + "'";
                        MySqlCommand Comm2 = new MySqlCommand(lsSQL, conn2);
                        Comm2.ExecuteNonQuery();
                        i++;
                        textBox1.Text = i.ToString();
                    }
                    else
                    {
                        j++;
                        textBox2.Text = j.ToString();
                    }
                    lsRead1.Close();
                }
            }
            lsRead.Close();
        }

        

        private void button6_Click(object sender, EventArgs e)
        {
            ImportVoucherOldData("1");

        }

        private void ImportVoucherOldData(string aFlag)
        {
            long i = 0;
            DateTime ldVouDate = new DateTime();
            DateTime ldResTime = new DateTime();
            DateTime ldCheckInDate = new DateTime();
            DateTime ldCheckOutDate = new DateTime();
            double ldoRoomRate1 = 0;
            string lsVouDate = "", lsResTime="", lsCheckInDate="", lsCheckOutDate="", lsRoomNo="", lsflagConfirm="", lsConfirmRemark="", lsFlag="1", lsConfirmPerson="";
            string lsName = "";
            IniFile lsIni = new IniFile("thahr30.ini");
            string lsServer = lsIni.GetString("thahr30", "serverdatabasename", "localhost");
            string lsDatabase = lsIni.GetString("thahr30", "databasename", "thahr3");
            string lsUserName = lsIni.GetString("thahr30", "username", "janepop");
            string lsPassword = lsIni.GetString("thahr30", "password", "Ekartc2c5");
            OleDbConnection acc = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=d:\\thahr30\\thahr20" + aFlag + ".mdb;");
            acc.Open();
            OleDbConnection acc1 = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=d:\\thahr30\\thahr20" + aFlag + ".mdb;");
            acc1.Open();
            MySqlConnection conn = new MySqlConnection("Data Source=" + lsServer + ";Database=" + lsDatabase + ";User ID="+lsUserName+";Password="+lsPassword+"");
            conn.Open();
            string lsSQL = "Select count(*) as cnt From voucher ";
            OleDbCommand accCom = new OleDbCommand(lsSQL, acc);
            OleDbDataReader lsAccRead1;
            lsAccRead1 = accCom.ExecuteReader();
            if (lsAccRead1.HasRows)
            {
                while (lsAccRead1.Read())
                {
                    Pb1.Minimum = 0;
                    lsSQL = lsAccRead1.GetValue(0).ToString();
                    Pb1.Maximum = Convert.ToInt32(lsAccRead1.GetValue(0).ToString());
                }
            }
            lsAccRead1.Close();
            Pb1.Visible = true;
            SL1.Visible = true;
            OleDbDataReader lsReadAcc;
            MySqlCommand lsCom = new MySqlCommand("Delete From voucher Where flagolddata = '" + aFlag + "'", conn);
            lsCom.ExecuteNonQuery();
            lsSQL = "Select * From voucher";
            accCom.CommandText = lsSQL;
            lsReadAcc = accCom.ExecuteReader();
            while (lsReadAcc.Read())
            {
                i++;
                lsName = lsReadAcc["guestname"].ToString();
                lsName = lsName.Replace("\\",  "");
                ldVouDate = Convert.ToDateTime(lsReadAcc["voudate"]);
                lsVouDate = ldVouDate.Year.ToString("0000") + "-" + ldVouDate.Month.ToString("00") + "-" + ldVouDate.Day.ToString("00");
                ldCheckInDate = Convert.ToDateTime(lsReadAcc["checkin"]);
                lsCheckInDate = ldCheckInDate.Year.ToString("0000") + "-" + ldCheckInDate.Month.ToString("00") + "-" + ldCheckInDate.Day.ToString("00");
                ldCheckOutDate = Convert.ToDateTime(lsReadAcc["checkout"]);
                lsCheckOutDate = ldCheckOutDate.Year.ToString("0000") + "-" + ldCheckOutDate.Month.ToString("00") + "-" + ldCheckOutDate.Day.ToString("00");
                ldResTime = Convert.ToDateTime(lsReadAcc["restime"]);
                lsResTime = ldResTime.Hour.ToString("00") + ":" + ldResTime.Minute.ToString("00") + ":" + ldResTime.Second.ToString("00");
                if (lsReadAcc["statuscode"].ToString() == "06")
                {
                    lsflagConfirm = "3";
                }
                if (lsReadAcc["statuscode"].ToString() == "02")
                {
                    lsflagConfirm = "3";
                }
                if (lsReadAcc["statuscode"].ToString() == "03")
                {
                    lsflagConfirm = "3";
                }
                if (lsReadAcc["statuscode"].ToString() == "01")
                {
                    lsflagConfirm = "4";
                }
                //lsSQL = "Select * From actinfo Where voucherno = '" + lsReadAcc["voucherno"].ToString() + "'";
                //OleDbCommand accCom1 = new OleDbCommand(lsSQL, acc1);
                //OleDbDataReader lsReadAcc1;
                //accCom1.CommandText = lsSQL;
                //lsReadAcc1 = accCom1.ExecuteReader();
                //lsConfirmPerson = "-";
                //ldoRoomRate1 = 0;
                //while (lsReadAcc1.Read())
                //{
                //    lsConfirmPerson = lsReadAcc1["confirmperson"].ToString();
                //    ldoRoomRate1 = Convert.ToDouble(lsReadAcc1["roomrate1"]);
                //}
                //lsReadAcc1.Close();
                lsSQL = "Insert Into voucher(vouno, staffcode, voudate, counter1, "
                + "shiftcode, restime, provcode, hotelcode, "
                + "guestfirstname, nationcode, roomcode, visitt, "
                + "pax, roomrate, statuscode, depositamt, "
                + "checkindate, checkoutdate, confirmperson, flagsend, "
                + "roomno, mac, flagconfirm, " 
                + "confirmremark, roomrate1, flagolddata, flag, couno) "
                + "Values('" + lsReadAcc["voucherno"].ToString() + "-" + i.ToString ("000000") + "','" + lsReadAcc["Staffcode"].ToString() + "','" + lsVouDate + "','" + lsReadAcc["counter1"].ToString() + "','"
                + lsReadAcc["shiftcode"].ToString() + "','" + lsResTime + "','" + lsReadAcc["provcode"].ToString() + "','" + lsReadAcc["hotelcode"].ToString() + "','"
                + lsName + "','" + lsReadAcc["nationcode"].ToString() + "','" + lsReadAcc["roomcode"].ToString() + "'," + lsReadAcc["days1"].ToString() + ","
                + lsReadAcc["pax"].ToString() + "," + lsReadAcc["roomrate"].ToString() + ",'" + lsReadAcc["statuscode"].ToString() + "'," + lsReadAcc["depositamt"].ToString() + ",'"
                + lsCheckInDate + "','" + lsCheckOutDate + "','" + lsConfirmPerson + "','2','" 
                + lsRoomNo + "','" + lsReadAcc["counter1"].ToString() + "','" + lsflagConfirm + "','" 
                + lsConfirmRemark + "'," + ldoRoomRate1 + ",'" + aFlag + "','" + lsFlag + "','')";
                MySqlCommand lsComm1 = new MySqlCommand(lsSQL, conn);
                lsComm1.ExecuteNonQuery();
                //Pb1.Value = Convert.ToInt32(i);
            }
            lsReadAcc.Close();
            //MessageBox.Show("OK", "", MessageBoxButtons.OK);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ImportVoucherOldData("2");
        }
        private void button5_Click(object sender, EventArgs e)
        {
            int i = 0, liContactID=0;
            IniFile lsIni = new IniFile("thahr30.ini");
            string lsCharSet = lsIni.GetString("thahr30", "charset", "tis620");
            string lsServer = lsIni.GetString("thahr30", "serverdatabasename", "localhost");
            string lsDatabase = lsIni.GetString("thahr30", "databasename", "thahr3");
            string lsUserName = lsIni.GetString("thahr30", "username", "janepop");
            string lsPassword = lsIni.GetString("thahr30", "password", "Ekartc2c5");
            OleDbConnection acc = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=d:\\thahr30\\thahr20.mdb;");
            acc.Open();
            MySqlConnection conn = new MySqlConnection("Data Source=" + lsServer + ";Database=" + lsDatabase + ";User ID=" + lsUserName + ";Password=" + lsPassword + ";CHARSET=" + lsCharSet + "");
            conn.Open();
            string lsSQL = "Select count(*) as cnt From regis ";
            OleDbCommand accCom = new OleDbCommand(lsSQL, acc);
            OleDbDataReader lsAccRead1;
            lsAccRead1 = accCom.ExecuteReader();
            if (lsAccRead1.HasRows)
            {

                while (lsAccRead1.Read())
                {
                    Pb1.Minimum = 0;
                    lsSQL = lsAccRead1.GetValue(0).ToString();
                    Pb1.Maximum = Convert.ToInt32(lsAccRead1.GetValue(0).ToString());
                }
            }
            lsAccRead1.Close();
            //lsSQL = "Select * From regis1";
            //accCom.CommandText = lsSQL;
            Pb1.Visible = true;
            SL1.Visible = true;
            OleDbDataReader lsRead;
            MySqlCommand lsCom = new MySqlCommand("truncate table membernote", conn);
            lsCom.ExecuteNonQuery();
            lsSQL = "Select * From regis";
            accCom.CommandText = lsSQL;
            lsRead = accCom.ExecuteReader();
            while (lsRead.Read())
            {
                i++;
                lsSQL = "select count(*) as cnt From membernote ";
                MySqlCommand lsComm5 = new MySqlCommand(lsSQL, conn);
                MySqlDataReader lsRead1 = lsComm5.ExecuteReader();
                while (lsRead1.Read())
                {
                    liContactID = Convert.ToInt32(lsRead1["cnt"]);
                }
                lsRead1.Close();
                liContactID++;
                lsSQL = "Insert Into membernote(noteid, memid, note) Values("+liContactID+",'" + lsRead["regisid"].ToString () + "','" + lsRead["remark"].ToString() + "')";
                MySqlCommand lsComm7 = new MySqlCommand(lsSQL, conn);
                lsComm7.ExecuteNonQuery();
                liContactID++;
                lsSQL = "Insert Into membernote(noteid, memid, note) Values(" + liContactID + ",'" + lsRead["regisid"].ToString() + "','" + lsRead["remark2"].ToString() + "')";
                MySqlCommand lsComm8 = new MySqlCommand(lsSQL, conn);
                lsComm8.ExecuteNonQuery();
                liContactID++;
                lsSQL = "Insert Into membernote(noteid, memid, note) Values(" + liContactID + ",'" + lsRead["regisid"].ToString() + "','" + lsRead["remark3"].ToString() + "')";
                MySqlCommand lsComm9 = new MySqlCommand(lsSQL, conn);
                lsComm9.ExecuteNonQuery();
                liContactID++;
                lsSQL = "Insert Into membernote(noteid, memid, note) Values(" + liContactID + ",'" + lsRead["regisid"].ToString() + "','" + lsRead["remark4"].ToString() + "')";
                MySqlCommand lsComm1 = new MySqlCommand(lsSQL, conn);
                lsComm1.ExecuteNonQuery();
                liContactID++;
                lsSQL = "Insert Into membernote(noteid, memid, note) Values(" + liContactID + ",'" + lsRead["regisid"].ToString() + "','" + lsRead["remark5"].ToString() + "')";
                MySqlCommand lsComm2 = new MySqlCommand(lsSQL, conn);
                lsComm2.ExecuteNonQuery();
                liContactID++;
            }
        }
        private void button8_Click(object sender, EventArgs e)
        {
            int i = 0, liContactID=0;
            string lsMemNameT="", lsMemID="";
            IniFile lsIni = new IniFile("thahr30.ini");
            string lsServer = lsIni.GetString("thahr30", "serverdatabasename", "localhost");
            string lsCharSet = lsIni.GetString("thahr30", "charset", "tis620");
            string lsDatabase = lsIni.GetString("thahr30", "databasename", "thahr3");
            string lsUserName = lsIni.GetString("thahr30", "username", "janepop");
            string lsPassword = lsIni.GetString("thahr30", "password", "Ekartc2c5");
            OleDbConnection acc = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=d:\\thahr30\\thahr20.mdb;");
            acc.Open();
            MySqlConnection conn = new MySqlConnection("Data Source=" + lsServer + ";Database=" + lsDatabase + ";User ID="+lsUserName+";Password="+lsPassword+";CHARSET=" + lsCharSet + "");
            conn.Open();
            string lsSQL = "Select count(*) as cnt From email ";
            OleDbCommand accCom = new OleDbCommand(lsSQL, acc);
            OleDbDataReader lsAccRead1;
            lsAccRead1 = accCom.ExecuteReader();
            if (lsAccRead1.HasRows)
            {

                while (lsAccRead1.Read())
                {
                    Pb1.Minimum = 0;
                    lsSQL = lsAccRead1.GetValue(0).ToString();
                    Pb1.Maximum = Convert.ToInt32(lsAccRead1.GetValue(0).ToString());
                }
            }
            textBox1.Text = Pb1.Maximum.ToString();
            lsAccRead1.Close();
            //lsSQL = "Select * From regis1";
            //accCom.CommandText = lsSQL;
            Pb1.Visible = true;
            SL1.Visible = true;
            OleDbDataReader lsRead;
            MySqlCommand lsCom = new MySqlCommand("delete from contact Where flagold = '2'", conn);
            lsCom.ExecuteNonQuery();
            lsSQL = "Select * From email";
            accCom.CommandText = lsSQL;
            lsRead = accCom.ExecuteReader();
            while (lsRead.Read())
            {
                i++;
                lsMemID = "";
                lsMemNameT = lsRead["nameeng"].ToString();
                lsMemNameT = lsMemNameT.Replace("'", "''");
                lsSQL = "Select distinct memid From member Where memnamee1 like '%" + lsMemNameT + "%'";
                MySqlCommand lsComm4 = new MySqlCommand(lsSQL, conn);
                MySqlDataReader lsRead2 = lsComm4.ExecuteReader();
                while (lsRead2.Read())
                {
                    lsMemID = lsRead2["memid"].ToString();
                }
                lsRead2.Close();
                if (lsMemID != "")
                {
                    //lsSQL = "Update member Set flagrestaurant = '"
                    //    + lsRead["vrestaurant"].ToString() + "', flagspa = '"
                    //    + lsRead["vspa"].ToString() + "', flagmeeting = '"
                    //    + lsRead["vmeeting"].ToString() + "', flagbusiness = '"
                    //    + lsRead["vbusiness"].ToString() + "', flagfitness = '" + lsRead["vfitness"].ToString() + "' Where memid = '" + lsRead["regisid"].ToString() + "'"; ;
                    lsSQL = "select max(contactid) as cnt From contact ";
                    MySqlCommand lsComm5 = new MySqlCommand(lsSQL, conn);
                    MySqlDataReader lsRead1 = lsComm5.ExecuteReader();
                    while (lsRead1.Read())
                    {
                        liContactID = Convert.ToInt32(lsRead1["cnt"]);
                    }
                    lsRead1.Close();
                    liContactID++;
                    i++;
                    lsSQL = "Insert Into contact(contactid, contactnamet, refid, email, flagold) "
                        + "Values(" + liContactID + ",'E-Mail " + lsMemNameT + i.ToString() + "','" + lsMemID + "','" + lsRead["e-mail"].ToString() + "','2')";
                    MySqlCommand lsComm6 = new MySqlCommand(lsSQL, conn);
                    lsComm6.ExecuteNonQuery();
                    OleDbCommand lsCom8 = new OleDbCommand("update email Set flag = '1' Where nameeng = '" + lsMemNameT + "'", acc);
                    lsCom8.ExecuteNonQuery();
                    //liContactID++;
                    //lsSQL = "Insert Into contact(contactid, contactnamet, contactnamee, contactsurnamet, contactsurnamee,"
                    //    + "positiont, positione, refid) "
                    //    + "Values(" + liContactID + ",'" + lsRead["name1"].ToString() + "','" + lsRead["name2"].ToString() + "','-','-','-','-','" + lsRead["regisid"].ToString() + "')";
                    //MySqlCommand lsComm7 = new MySqlCommand(lsSQL, conn);
                    //lsComm7.ExecuteNonQuery();
                    Application.DoEvents();
                    textBox3.Text = i.ToString();
                }
                else
                {
                    OleDbCommand lsCom9 = new OleDbCommand("update email Set flag = '0' Where nameeng = '" + lsMemNameT + "'", acc);
                    lsCom9.ExecuteNonQuery();
                }
            }
            lsRead.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Int32 i = 0;
            IniFile lsIni = new IniFile("thahr30.ini");
            string lsServer = lsIni.GetString("thahr30", "serverdatabasename", "localhost");
            string lsCharSet = lsIni.GetString("thahr30", "charset", "tis620");
            string lsDatabase = lsIni.GetString("thahr30", "databasename", "thahr3");
            string lsUserName = lsIni.GetString("thahr30", "username", "janepop");
            string lsPassword = lsIni.GetString("thahr30", "password", "Ekartc2c5");
            string lsSQL = "Select memid, memnamee1 From member where memid = '00707'";
            string lsMemId = "";
            MySqlConnection conn = new MySqlConnection("Data Source=" + lsServer + ";Database=" + lsDatabase + ";User ID=" + lsUserName + ";Password=" + lsPassword + ";CHARSET=" + lsCharSet + "");
            conn.Open();
            MySqlConnection conn1 = new MySqlConnection("Data Source=" + lsServer + ";Database=" + lsDatabase + ";User ID=" + lsUserName + ";Password=" + lsPassword + ";CHARSET=" + lsCharSet + "");
            conn1.Open();
            MySqlConnection conn2 = new MySqlConnection("Data Source=" + lsServer + ";Database=" + lsDatabase + ";User ID=" + lsUserName + ";Password=" + lsPassword + ";CHARSET=" + lsCharSet + "");
            conn2.Open();
            MySqlDataReader lsRead;
            MySqlCommand lsComm = new MySqlCommand(lsSQL, conn);
            lsSQL = "";
            lsRead = lsComm.ExecuteReader();
            if (lsRead.HasRows)
            {
                while (lsRead.Read())
                {
                    lsMemId = lsRead["memid"].ToString();
                    //lsSQL = "Select depositamt, memplcode From voucher Where hotelcode = '" + lsMemId + "'";
                    lsSQL = "Select max(noteid) noteid From membernote Where refid = '" + lsMemId + "'";
                    MySqlCommand Comm1 = new MySqlCommand(lsSQL, conn1);
                    MySqlDataReader lsRead1;
                    lsRead1 = Comm1.ExecuteReader();
                    if (lsRead1.Read())
                    {
                        lsSQL = lsRead1["noteid"].ToString();
                        if (lsSQL != "")
                        {
                            lsSQL = "Update member Set noteid = '" + lsRead1["noteid"].ToString()
                                + "' Where memid = '" + lsMemId + "'";
                            MySqlCommand Comm2 = new MySqlCommand(lsSQL, conn2);
                            Comm2.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        //j++;
                        //textBox2.Text = j.ToString();
                    }
                    i++;
                    textBox1.Text = i.ToString();
                    lsRead1.Close();
                    Application.DoEvents();
                }
            }
            lsRead.Close();
            MessageBox.Show("OK", "", MessageBoxButtons.OK);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            {
                int i = 0, liContactID = 0;
                Boolean lbFlag = false;
                IniFile lsIni = new IniFile("thahr30.ini");
                string lsServer = lsIni.GetString("thahr30", "serverdatabasename", "localhost");
                string lsCharSet = lsIni.GetString("thahr30", "charset", "tis620");
                string lsDatabase = lsIni.GetString("thahr30", "databasename", "thahr3");
                string lsUserName = lsIni.GetString("thahr30", "username", "janepop");
                string lsPassword = lsIni.GetString("thahr30", "password", "Ekartc2c5");
                OleDbConnection acc = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=d:\\thahr30\\thahr20.mdb;");
                acc.Open();
                MySqlConnection conn = new MySqlConnection("Data Source=" + lsServer + ";Database=" + lsDatabase + ";User ID=" + lsUserName + ";Password=" + lsPassword + ";CHARSET=" + lsCharSet + "");
                conn.Open();
                string lsSQL = "Select count(*) as cnt From regis ";
                OleDbCommand accCom = new OleDbCommand(lsSQL, acc);
                OleDbDataReader lsAccRead1;
                lsAccRead1 = accCom.ExecuteReader();
                if (lsAccRead1.HasRows)
                {

                    while (lsAccRead1.Read())
                    {
                        Pb1.Minimum = 0;
                        lsSQL = lsAccRead1.GetValue(0).ToString();
                        Pb1.Maximum = Convert.ToInt32(lsAccRead1.GetValue(0).ToString());
                    }
                }
                lsAccRead1.Close();
                //lsSQL = "Select * From regis1";
                //accCom.CommandText = lsSQL;
                Pb1.Visible = true;
                SL1.Visible = true;
                OleDbDataReader lsRead;
                MySqlCommand lsCom = new MySqlCommand("truncate table memberowner", conn);
                lsCom.ExecuteNonQuery();
                lsSQL = "Select * From regis";
                accCom.CommandText = lsSQL;
                lsRead = accCom.ExecuteReader();
                while (lsRead.Read())
                {
                    i++;
                    lsSQL = "select ownernamet From memberowner Where ownernamet = '" + lsRead["companyname"].ToString() + "'";
                    MySqlCommand lsComm7 = new MySqlCommand(lsSQL, conn);
                    lsComm7.ExecuteNonQuery();
                    MySqlDataReader lsRead2 = lsComm7.ExecuteReader();
                    if (lsRead2.HasRows == false)
                    {
                        lbFlag = true;
                    }
                    else
                    {
                        lbFlag = false;
                    }
                    lsRead2.Close();
                    if (lbFlag == true)
                    {
                        lsSQL = "select count(*) as cnt From memberowner ";
                        MySqlCommand lsComm5 = new MySqlCommand(lsSQL, conn);
                        MySqlDataReader lsRead1 = lsComm5.ExecuteReader();
                        while (lsRead1.Read())
                        {
                            liContactID = Convert.ToInt32(lsRead1["cnt"]);
                        }
                        lsRead1.Close();
                        liContactID++;
                        lsSQL = "Insert Into memberowner(refid, ownerid, ownernamet) "
                            + "Values('" + lsRead["regisid"].ToString() + "'," + liContactID + ",'" + lsRead["companyname"].ToString() + "')";
                        MySqlCommand lsComm6 = new MySqlCommand(lsSQL, conn);
                        lsComm6.ExecuteNonQuery();
                        lsSQL = "Update member Set ownerid = " + liContactID + " Where memid = '" + lsRead["regisid"].ToString() + "'";
                        MySqlCommand lsComm8 = new MySqlCommand(lsSQL, conn);
                        lsComm8.ExecuteNonQuery();
                    }
                }
                lsRead.Close();
            }
        }
    }
}