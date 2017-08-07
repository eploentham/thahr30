using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Collections;
using System.IO;
namespace ThaHr30
{
    class KingPower
    {
        IniFile lsIni = new IniFile("thahr30.ini");
        Initial lsIniT = new Initial();
        Connection lsGdb = new Connection();
        string lsMem="";
        private string lsTextFileName = "", lsTextSaleFileName="";
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
        public string TextFileName
        {
            get
            {
                return lsTextFileName;
            }
            set
            {
                lsTextFileName = value.Trim();
            }
        }
        public string TextSaleFileName
        {
            get
            {
                return lsTextSaleFileName;
            }
            set
            {
                lsTextSaleFileName = value.Trim();
            }
        }
        Int32 j=0;
        public string lsCalAmt = "", lsFlagVAT = "";
        public struct MasterKingPower
        {
            public string ShopCode, Std_Cate_Code, Branch_Code, ShpBnd_Code, Currency_code;
            public string Rate, Unit_Code;
            public string VatRate, UStoBaht;
            public string BarCode, Trans_Type, Vat_Type, Vat_Rate;
            public string Ref_Code_1, Ref_Code_2, Ref_Code_3, Ref_Code_4, Ref_Code_5;
            public string ReQuest_Date, Request_Exc_Vat, Request_Inc_Vat, RequestEFF_SDate, RequestEFF_EDate, Ref_Price, Ref_Price_SRC, Ref_Price_Date;
            public double ReVat;
        }
        public struct SalesHeader
        {
            public string ShopCode, Branch_Code, Sale_NO, POS_NO, Sale_TYPE, Sale_Date, Shift_NO, Doc_Date, Create_Date, Trans_Date;
            public string Member_ID, SVC_ID, Name, Flight_NO, Flight_Date, Nation_Code, PassPort_NO, Birth_Date, Sex, Vat_Type;
            public string AMT_EXC_VAT, AMT_INC_VAT, VAT_AMT, Pro_Code, Disc_Vat_AMT, Disc_AMT_Exc_Vat, Disc_AMT_INC_VAT, Service_Charge, Void_Date, Void_Reason;
            public string Ref_Sale_NO, Ref_POS_NO, Ref_Sale_Date, Return_Reason;
        }
        public struct SalesDetail
        {
            public string ShopCode, Branch_Code, Sale_NO, POS_NO, Sale_TYPE, Sale_Date, SEQ, Std_Cate_Code, Prod_Serv_code, Prod_Serv_Name;
            public string Vat_Type, Vat_Rate, Prod_Serv_QTY, Unit_Code, AOT_Price_Exc_VAT, AOT_Price_Inc_VAT, AMT_EXC_VAT, VAT_AMT, AMT_INC_VAT, Pro_Code, Disc_Price_Exc_VAT, Disc_Price_INC_VAT, Service_Charge;
        }
        public struct SaleSPayment
        {
            public string ShopCode, Branch_Code, Sale_NO, POS_NO, Sale_TYPE, Sale_Date, Pay_TYPE, Currency_Code, Rate, Amount, Baht_AMT;
        }
        public struct SumPayment
        {
            public string ShopCode, Branch_Code, Sale_Date, Pay_TYPE, Currency_Code, Rate, Amount, Baht_AMT;
        }
        public struct SumSales
        {
            public string ShopCode, Branch_Code, Sale_Date, Sale_Header_AMT, Net_Sale_Header_AMT, Sale_DTL_AMT, Net_Sale_DTL_AMT, Payment_AMT;
        }
        public Boolean CreateTextProductFile(string aFlag, MySqlDataReader aRead)
        {
            if (aFlag == "master")
            {
                MasterKingPower lsMaster = new MasterKingPower();
                if (lsGdb.Gdb.State == System.Data.ConnectionState.Closed)
                {
                    lsGdb.ConnectDatabase();
                }
                if (lsIniT.TblMember.Count == 0)
                {
                    lsIniT.CreateTblMember(lsGdb.Gdb);
                }
                if (lsIniT.TblNationality.Count == 0)
                {
                    lsIniT.CreateTblNationality(lsGdb.Gdb);
                }
                if (lsIniT.TblCounter.Count == 0)
                {
                    lsIniT.CreateTblCounter(lsGdb.Gdb);
                }
                if (lsIniT.TblShift.Count == 0)
                {
                    lsIniT.CreateTblShift(lsGdb.Gdb);
                }
                if (lsIniT.TblTypeMem.Count == 0)
                {
                    lsIniT.CreateTblTypeMem(lsGdb.Gdb);
                }
                if (lsIniT.TblTypeRoom.Count == 0)
                {
                    lsIniT.CreateTblTypeRoom(lsGdb.Gdb);
                }
                //lsIniT.CreateTblInitial(lsGdb.Gdb);
                lsMaster.ShopCode = lsIni.GetString("kingpower", "shopcode", "0");
                string lsFileName = "", lsPath = "D://thahr30//";
                lsFileName = lsMaster.ShopCode + "_Product_" + System.DateTime.Now.Year.ToString("0000") + System.DateTime.Now.Month.ToString("00") + System.DateTime.Now.Day.ToString("00") + System.DateTime.Now.Hour.ToString("00") + System.DateTime.Now.Minute.ToString("00") + System.DateTime.Now.Second.ToString("00");
                lsPath = lsIni.GetString("kingpower", "pathtextfilekingpower", "D://thahr30//text//");
                lsTextFileName = lsPath + lsFileName + ".Txt";
                StreamWriter lsSW = new StreamWriter(lsPath + lsFileName + ".Txt");
                //KingPower lsGen = new KingPower();
                string[] lsData = new string[2000];
                lsData = GenMasterFileKingPower(aRead);
                //if (lsData[1] != "")
                //{
                //    MessageBox.Show("เตรียมข้อมูลทั้งหมด เรียบร้อย", "Prepare Data All", MessageBoxButtons.OK);
                //}
                lsSW.WriteLine("[Product]");
                foreach (string lsD in lsData)
                {
                    if (lsD != null)
                    {
                        lsSW.WriteLine(lsD);
                    }
                }
                //lsSW.WriteLine(lsData);
                lsSW.Close();
            }
            return true;
        }
        public void CreateTextProductFile(string[] aData, string aYYYYMMDDHHMMSS)
        {
            string lsFileName = "", lsPath = "D://thahr30//";
            try
            {
                MasterKingPower lsMaster = new MasterKingPower();                
                lsPath = lsIni.GetString("kingpower", "pathtextfilekingpower", "D://thahr30//text//");
                lsMaster.ShopCode = lsIni.GetString("kingpower", "shopcode", "0");
                //lsPath = lsIni.GetString("kingpower", "pathtextfilekingpower", "D://thahr30//");
                lsFileName = lsMaster.ShopCode + "_Product_" + aYYYYMMDDHHMMSS.Substring(0, 4) + aYYYYMMDDHHMMSS.Substring(5, 2) + aYYYYMMDDHHMMSS.Substring(8, 8);
                lsTextFileName = lsPath + lsFileName + ".Txt";
                StreamWriter lsSW = new StreamWriter(lsPath + lsFileName + ".Txt");
                //lsSW.WriteLine("[Product]");
                foreach (string lsD in aData)
                {
                    if (lsD != null)
                    {
                        lsSW.WriteLine(lsD);
                    }
                }
                lsSW.Close();
            }
            catch (Exception e)
            {
                string ls = "ไม่สามารถสร้าง Text Fileได้ " + lsPath + lsFileName;
                lsGdb.WriteLogError(ls, e, "", "CreateTextFile");
                //MessageBox.Show(ls + " " + e.Message.ToString(), e.Source.ToString(), MessageBoxButtons.OK);
            }
        }
        private string[] GenMasterFileKingPower(MySqlDataReader aRead, double aPriceBaht)
        {
            MasterKingPower lsMaster = new MasterKingPower();
            if (lsGdb.Gdb.State == System.Data.ConnectionState.Closed)
            {
                lsGdb.ConnectDatabase();
            }
            lsIniT.CreateTblMember(lsGdb.Gdb);
            lsIniT.CreateTblNationality(lsGdb.Gdb);
            lsIniT.CreateTblCounter(lsGdb.Gdb);
            lsIniT.CreateTblShift(lsGdb.Gdb);
            lsIniT.CreateTblTypeMem(lsGdb.Gdb);
            lsMaster.ReVat = 1.07;
            lsMaster.ShopCode = lsIni.GetString("kingpower", "shopcode", "0");
            lsMaster.Std_Cate_Code = lsIni.GetString("kingpower", "std_cate_code", "0");
            lsMaster.Branch_Code = lsIni.GetString("kingpower", "branch_code", "0");
            lsMaster.ShpBnd_Code = lsIni.GetString("kingpower", "shpbnd_code", "0");
            lsMaster.Currency_code = lsIni.GetString("kingpower", "currency_code", "0");
            lsMaster.Rate = lsIni.GetString("kingpower", "rate", "0");
            lsMaster.Unit_Code = lsIni.GetString("kingpower", "unit_code", "0");
            lsMaster.VatRate = lsIni.GetString("thahr30", "vatrate", "0");
            lsMaster.UStoBaht = lsIni.GetString("thahr30", "USTOBAHT", "0");
            Int32 i = 0;
            double ldoPriceStart, ldoPriceEnd;
            string[] lsData = new string[2000];
            string lsSQL = "", lsVouDate = "", lsDay = "";
            string lsData1_10 = "", lsData11_23 = "", lsMemID = "", lsMemName = "";
            lsDay = Convert.ToString(System.DateTime.Now.Day - 1);
            lsVouDate = System.DateTime.Now.Year.ToString("0000") + "-" + System.DateTime.Now.Month.ToString("00") + "-" + lsDay;
            if (aRead.HasRows)
            {
                //lsVat_Rate = lsMaster.lsVatRate;
                lsMaster.Vat_Type = lsIni.GetString("kingpower", "vat_type", "1");
                lsMaster.ReQuest_Date = System.DateTime.Now.Year.ToString("0000") + "-" + System.DateTime.Now.Month.ToString("00") + "-" + System.DateTime.Now.Day.ToString("00");
                
                lsMaster.Request_Exc_Vat = "";
                lsMaster.Request_Inc_Vat = "";
                lsMaster.RequestEFF_SDate = System.DateTime.Now.Year.ToString("0000") + "-" + System.DateTime.Now.Month.ToString("00") + "-" + System.DateTime.Now.Day.ToString("00") + " " + System.DateTime.Now.Hour.ToString("00") + ":" + System.DateTime.Now.Minute.ToString("00") + ":" + System.DateTime.Now.Second.ToString("00");
                lsMaster.RequestEFF_SDate = "2006-09-28 00:00:00";
                lsMaster.RequestEFF_EDate = "2011-09-27 23:59:59";
                lsMaster.Ref_Price = "7.0";
                lsMaster.Ref_Price_SRC = "Don Muang";
                lsMaster.Ref_Price_Date = "2006-09-27";
                lsMaster.Ref_Code_1 = "";
                lsMaster.Ref_Code_2 = "";
                lsMaster.Ref_Code_3 = "";
                lsMaster.Ref_Code_4 = "";
                lsMaster.Ref_Code_5 = "";
                while (aRead.Read())
                {
                    i++;
                    lsMaster.Trans_Type = "1";
                    lsMemID = aRead.GetValue(0).ToString();
                    lsSQL = aRead.GetValue(1).ToString();
                    lsMemName = aRead.GetValue(1).ToString();
                    lsMaster.Ref_Price_SRC = lsMemName;
                    ldoPriceStart = Convert.ToDouble(aRead.GetValue(12));
                    lsSQL = Convert.ToString(aRead.GetValue(12));
                    decimal cc = Convert.ToDecimal(aRead.GetValue(12));
                    ldoPriceStart = (Convert.ToDouble(aRead.GetValue(12)) * Convert.ToDouble(lsMaster.UStoBaht));
                    //ldoPriceStart = decimal.Round(ldoPriceStart, 2);
                    //decimal bbb = Convert.ToDecimal(ldoPriceStart);
                    decimal aa = decimal.Round(Convert.ToDecimal(ldoPriceStart / lsMaster.ReVat), 2);                        //lsMaster.Request_Inc_Vat = Convert.ToString(decimal.Round(Convert.ToDecimal(ldoPriceStart), 2));
                    lsMaster.Request_Inc_Vat = ldoPriceStart.ToString("0.00");
                    lsMaster.Request_Exc_Vat = Convert.ToString(aa);
                    //lsMaster.Request_Inc_Vat = lsMaster.Request_Inc_Vat;
                    lsMaster.Ref_Price = lsMaster.Request_Exc_Vat;
                    if (lsMemID == lsMem)
                    {
                        j++;
                    }
                    else
                    {
                        lsMem = lsMemID;
                        j = 1;
                    }
                    ldoPriceEnd = aPriceBaht;
                    decimal bb = decimal.Round(Convert.ToDecimal(ldoPriceEnd / lsMaster.ReVat), 2);

                    //lsMaster.Request_Inc_Vat = Convert.ToString(decimal.Round(Convert.ToDecimal(ldoPriceEnd), 2));
                    lsMaster.Request_Inc_Vat = ldoPriceEnd.ToString("0.00");
                    lsMaster.Request_Exc_Vat = Convert.ToString(bb);
                    //lsMaster.Request_Inc_Vat = lsMaster.Request_Inc_Vat;
                    lsMaster.Ref_Price = lsMaster.Request_Exc_Vat;
                    lsData1_10 = lsMaster.ShopCode + "|" + lsMaster.Std_Cate_Code + "|" + lsMemID + j.ToString("00000") + "|" + lsMemName + "|" + lsMaster.ShpBnd_Code + "|" + lsMaster.BarCode + "|" + lsMaster.Trans_Type + "|" + lsMaster.Vat_Type + "|" + lsMaster.VatRate + "|" + lsMaster.Unit_Code;
                    lsData11_23 = lsMaster.ReQuest_Date + "|" + lsMaster.Request_Exc_Vat + "|" + lsMaster.Request_Inc_Vat + "|" + lsMaster.RequestEFF_SDate + "|" + lsMaster.RequestEFF_EDate + "|" + lsMaster.Ref_Price + "|" + lsMaster.Ref_Price_SRC + "|" + lsMaster.Ref_Price_Date + "|" + lsMaster.Ref_Code_1 + "|" + lsMaster.Ref_Code_2 + "|" + lsMaster.Ref_Code_3 + "|" + lsMaster.Ref_Code_4 + "|" + lsMaster.Ref_Code_5;
                    lsData[i] = lsData1_10 + "|" + lsData11_23;
                    //lsSW.WriteLine(lsData);
                    //lsSW.WriteLine(lsData);
                }
            }
            return lsData;
        }
        private string[] GenMasterFileKingPower(MySqlDataReader aRead)
        {
            Int32 i = 0, j = 0;
            double ldoPriceStart;
            string[] lsData = new string[3000];
            string lsSQL = "", lsVouDate = "", lsDay = "", lsTRoomName="";
            string lsData1_10 = "", lsData11_23 = "", lsMemID = "", lsMemName = "";
            string lsUserName = lsIni.GetString("thahr30", "username", "janepop");
            string lsPassword = lsIni.GetString("thahr30", "password", "Ekartc2c5");
            string lsServer = lsIni.GetString("thahr30", "serverdatabasename", "localhost");
            string lsDatabase = lsIni.GetString("thahr30", "databasename", "localhost");
            string StrConn = "Data Source=" + lsServer + ";Database=" + lsDatabase + ";User ID=" + lsUserName + ";Password=" + lsPassword + "";
            MySqlConnection Conn = new MySqlConnection(StrConn);
            MasterKingPower lsMaster = new MasterKingPower();
            double ldoMulti = 0;
            try
            {
                //lsIniT.CreateTblTypeRoom(lsGdb.Gdb);
                lsMaster.ReVat = 1.07;
                lsMaster.ShopCode = lsIni.GetString("kingpower", "shopcode", "0");
                lsMaster.Std_Cate_Code = lsIni.GetString("kingpower", "std_cate_code", "0");
                lsMaster.Branch_Code = lsIni.GetString("kingpower", "branch_code", "0");
                lsMaster.ShpBnd_Code = lsIni.GetString("kingpower", "shpbnd_code", "0");
                lsMaster.Currency_code = lsIni.GetString("kingpower", "currency_code", "0");
                lsMaster.Rate = lsIni.GetString("kingpower", "rate", "0");
                lsMaster.Unit_Code = lsIni.GetString("kingpower", "unit_code", "0");
                lsMaster.VatRate = lsIni.GetString("thahr30", "vatrate", "0");
                lsMaster.UStoBaht = lsIni.GetString("thahr30", "USTOBAHT", "0");
                ldoMulti = Convert.ToDouble(lsIni.GetString("kingpower", "ratekingpower", "15.00"));
                //lsMaster.ReVat = lsMaster.Vat_Rate;
                Conn.Open();
                lsDay = Convert.ToString(System.DateTime.Now.Day - 1);
                lsVouDate = System.DateTime.Now.Year.ToString("0000") + "-" + System.DateTime.Now.Month.ToString("00") + "-" + lsDay;
                if (aRead.HasRows)
                {
                    //lsVat_Rate = lsMaster.lsVatRate;
                    lsMaster.Vat_Type = lsIni.GetString("kingpower", "vat_type", "1");
                    lsMaster.ReQuest_Date = System.DateTime.Now.Year.ToString("0000") + "-" + System.DateTime.Now.Month.ToString("00") + "-" + System.DateTime.Now.Day.ToString("00");
                    //lsMaster.ReQuest_Date = "2006-09-28";
                    lsMaster.Request_Exc_Vat = "";
                    lsMaster.Request_Inc_Vat = "";
                    lsMaster.RequestEFF_SDate = System.DateTime.Now.Year.ToString("0000") + "-" + System.DateTime.Now.Month.ToString("00") + "-" + System.DateTime.Now.Day.ToString("00") + " " + System.DateTime.Now.Hour.ToString("00") + ":" + System.DateTime.Now.Minute.ToString("00") + ":" + System.DateTime.Now.Second.ToString("00");
                    /*if ((System.DateTime.Now.Year.ToString("0000") + "-" + System.DateTime.Now.Month.ToString("00") + "-" + System.DateTime.Now.Day.ToString("00") + " " + System.DateTime.Now.Hour.ToString("00") + ":" + System.DateTime.Now.Minute.ToString("00") + ":" + System.DateTime.Now.Second.ToString("00")) > (System.DateTime.Now.AddYears(1).Year.ToString("0000") + "-09-27 23:59:59"))
                    {
                        lsMaster.RequestEFF_EDate = System.DateTime.Now.AddYears(1).Year.ToString("0000") + "-09-27 23:59:59";
                        lsMaster.Ref_Price_Date = "2006-09-27";
                    }
                    else
                    {*/
                        lsMaster.RequestEFF_EDate = System.DateTime.Now.AddYears(1).Year.ToString("0000") + "-09-27 23:59:59";
                        lsMaster.Ref_Price_Date = System.DateTime.Now.AddYears(1).Year.ToString("0000") +"-09-27";
                    //}
                    //lsMaster.RequestEFF_SDate = "2006-09-28 00:00:00";
                    //lsMaster.RequestEFF_EDate = "2011-09-27 23:59:59";
                    //lsMaster.RequestEFF_EDate = DateTime.Now.AddYears(1).tos;
                    
                    lsMaster.Ref_Price = "7.0";
                    lsMaster.Ref_Price_SRC = "Don Muang";
                    //lsMaster.Ref_Price_Date = "2006-09-27";
                    lsMaster.Ref_Code_1 = "";
                    lsMaster.Ref_Code_2 = "";
                    lsMaster.Ref_Code_3 = "";
                    lsMaster.Ref_Code_4 = "";
                    lsMaster.Ref_Code_5 = "";
                    while (aRead.Read())
                    {
                        lsMemID = aRead.GetValue(0).ToString();
                        if (lsMemID == "-")
                        {
                            lsSQL = "";
                        }
                        lsSQL = "select * From memberpricelist Where memid = '" + lsMemID + "' and flagsendkingpower = '1'";
                        MySqlCommand Comm = new MySqlCommand(lsSQL, Conn);
                        MySqlDataReader Read;
                        Read = Comm.ExecuteReader();
                        if (Read.HasRows)
                        {
                            j = 0;
                            while (Read.Read())
                            {
                                i++;
                                if (Read["flagoldkingpower"].ToString()=="1")
                                {
                                    lsMaster.Trans_Type = "1";
                                }
                                else 
                                {
                                    lsMaster.Trans_Type = "2";
                                }
                                lsSQL = aRead.GetValue(1).ToString();
                                lsMemName = aRead.GetValue(1).ToString();
                                lsMaster.Ref_Price_SRC = lsMemName;
                                ldoPriceStart = Convert.ToDouble(aRead.GetValue(12));
                                lsSQL = Convert.ToString(aRead.GetValue(12));
                                decimal cc = Convert.ToDecimal(aRead.GetValue(12));
                                //ldoPriceStart = (Convert.ToDouble(aRead.GetValue(12)) * Convert.ToDouble(lsMaster.UStoBaht));
                                if (Read["remark"].ToString() == "US$")
                                {
                                    ldoPriceStart = (Convert.ToDouble(Read["pricestart"]) * Convert.ToDouble(lsMaster.UStoBaht));
                                }
                                else
                                {
                                    ldoPriceStart = Convert.ToDouble(Read["pricestart"]);
                                }
                                ldoPriceStart = (ldoPriceStart * ldoMulti) / 100;
                                //decimal bbb = Convert.ToDecimal(ldoPriceStart);
                                decimal aa = decimal.Round(Convert.ToDecimal(ldoPriceStart * lsMaster.ReVat), 2); //lsMaster.Request_Inc_Vat = Convert.ToString(decimal.Round(Convert.ToDecimal(ldoPriceStart), 2));
                                //lsMaster.Request_Inc_Vat = ldoPriceStart.ToString("0.00");
                                //lsMaster.Vat_Type;
                                //lsMaster.Request_Inc_Vat = ldoPriceStart.ToString("0.00");
                                if (lsMaster.Vat_Type == "2")
                                {
                                    decimal aaa = Convert.ToDecimal(ldoPriceStart + (ldoPriceStart * Convert.ToDouble(lsMaster.VatRate)/100));
                                    lsMaster.Request_Inc_Vat = aaa.ToString("0.00");
                                    lsMaster.Request_Exc_Vat = ldoPriceStart.ToString("0.00");
                                }
                                else
                                {
                                    lsMaster.Request_Inc_Vat = Convert.ToString(aa);
                                    lsMaster.Request_Exc_Vat = Convert.ToString(ldoPriceStart);
                                }
                                //lsMaster.Request_Inc_Vat = lsMaster.Request_Inc_Vat;
                                lsMaster.Ref_Price = lsMaster.Request_Exc_Vat;
                                lsTRoomName = lsIniT.SelectInitial(lsIniT.TblTypeRoom, Read["plcode"].ToString(), Initial.WhereSelect.aCodetoName);
                                j++;
                                lsData1_10 = lsMaster.ShopCode + "|" + lsMaster.Std_Cate_Code + "|" + lsMemID + Read["plcode"].ToString() + "|" + lsMemName + "[" + lsTRoomName + "]" + "|" + lsMaster.ShpBnd_Code + "|" + lsMaster.BarCode + "|" + lsMaster.Trans_Type + "|" + lsMaster.Vat_Type + "|" + lsMaster.VatRate + "|" + lsMaster.Unit_Code;
                                lsData11_23 = lsMaster.ReQuest_Date + "|" + lsMaster.Request_Exc_Vat + "|" + lsMaster.Request_Inc_Vat + "|" + lsMaster.RequestEFF_SDate + "|" + lsMaster.RequestEFF_EDate + "|" + lsMaster.Ref_Price + "|" + lsMaster.Ref_Price_SRC + "|" + lsMaster.Ref_Price_Date + "|" + lsMaster.Ref_Code_1 + "|" + lsMaster.Ref_Code_2 + "|" + lsMaster.Ref_Code_3 + "|" + lsMaster.Ref_Code_4 + "|" + lsMaster.Ref_Code_5;
                                lsData[i] = lsData1_10 + "|" + lsData11_23;
                            }
                        }
                        Read.Close();
                    }
                }
                Conn.Close();
            }
            catch (Exception e)
            {
                string ls = "ไม่สามารถเตรียมข้อมูล Print ได้ ";
                lsGdb.WriteLogError(ls, e, "", "GenMasterFileKingPower ");
                //MessageBox.Show(ls + " " + eAcc.Message.ToString(), eAcc.Source.ToString(), MessageBoxButtons.OK);
            }
            return lsData;
        }
        public Boolean GenSaleDailyKingPower(string aYYYYMMDDHHMMSS)
        {
            Boolean lbReturn = false;
            string lsError = "", lsSQL = "";
            try
            {                
                Initial lsIniT = new Initial();
                if (lsGdb.Gdb.State == System.Data.ConnectionState.Closed)
                {
                    lsGdb.ConnectDatabase();
                }
                lsIniT.CreateTblInitial(lsGdb.Gdb);
                SalesHeader lsSH = new SalesHeader();
                SalesDetail lsSD = new SalesDetail();
                SaleSPayment lsSPa = new SaleSPayment();
                SumPayment lsSPy = new SumPayment();
                SumSales lsSSa = new SumSales();
                //KingPower lsGen = new KingPower();
                double ldoMulti = 0;
                DateTime ldSaleDate, ldVoidDate, ldReturnDate;
                Int32 i = 0, j = 0;
                string lsDataSH1_10 = "", lsDataSH11_20 = "", lsDataSH21_34 = "", lsPlNameE = "";
                string lsDataSD1_10 = "", lsDataSD11_23 = "";
                string lsDataSPa1_11 = "", lsTime = "";
                string lsDataSPy1_8 = "";
                string lsDataSSa1_8 = "";
                string[] lsDataSH = new string[200];
                string[] lsDataSD = new string[200];
                string[] lsDataSPa = new string[200];
                string[] lsDataSPy = new string[200];
                string[] lsDataSSa = new string[200];
                string[] lsMaster = new string[2000];
                string[] lsData = new string[2000];
                //ArrayList lsList = new ArrayList();
                string lsFileName = "", lsVouDate = "", lsPath = "D://thahr30//", lsMemID = "", lsVatRate = "";
                IniFile lsIni = new IniFile("thahr30.ini");
                lsSH.ShopCode = lsIni.GetString("kingpower", "shopcode", "0");
                
                lsSD.ShopCode = lsSH.ShopCode;
                lsSPa.ShopCode = lsSH.ShopCode;
                lsSPy.ShopCode = lsSH.ShopCode;
                lsSSa.ShopCode = lsSH.ShopCode;
                lsSH.Branch_Code = lsIni.GetString("kingpower", "branch_code", "0");
                lsSD.Branch_Code = lsSH.Branch_Code;
                lsSPa.Branch_Code = lsSH.Branch_Code;
                lsSPy.Branch_Code = lsSH.Branch_Code;
                lsSSa.Branch_Code = lsSH.Branch_Code;
                lsSD.Std_Cate_Code = lsIni.GetString("kingpower", "std_cate_code", "0");
                lsSD.Vat_Rate = lsIni.GetString("thahr30", "vatrate", "0");
                lsSD.Unit_Code = lsIni.GetString("kingpower", "unit_code", "0");
                lsSPa.Currency_Code = lsIni.GetString("kingpower", "currency_code", "THB");
                lsSH.Vat_Type = lsIni.GetString("kingpower", "vat_type", "1");
                lsSD.Vat_Type = lsSH.Vat_Type;
                ldoMulti = Convert.ToDouble(lsIni.GetString("kingpower", "ratekingpower", "15.00"));
                lsSPy.Currency_Code = lsSPa.Currency_Code;
                lsSPa.Rate = lsIni.GetString("thahr30", "USTOBAHT", "0");
                lsSPy.Rate = lsSPa.Rate;
                string lsServer = lsIni.GetString("thahr30", "serverdatabasename", "localhost");
                string lsDatabase = lsIni.GetString("thahr30", "databasename", "thahr3");
                string lsUserName = lsIni.GetString("thahr30", "username", "janepop");
                string lsPassword = lsIni.GetString("thahr30", "password", "Ekartc2c5");
                lsVatRate = lsIni.GetString("thahr30", "vatrate", "7.00");
                lsPath = lsIni.GetString("kingpower", "pathtextfilekingpower", "D://thahr30//text//");
                lsFileName = lsSH.ShopCode + "_SALES_" + aYYYYMMDDHHMMSS.Substring(0, 4) + aYYYYMMDDHHMMSS.Substring(5, 2) + aYYYYMMDDHHMMSS.Substring(8, 8);
                MySqlConnection conn = new MySqlConnection("Data Source=" + lsServer + ";Database=" + lsDatabase + ";User ID="+lsUserName+";Password="+lsPassword+"");
                conn.Open();
                //conn = lsGdb.Gdb;
                MySqlConnection conn1 = new MySqlConnection("Data Source=" + lsServer + ";Database=" + lsDatabase + ";User ID="+lsUserName+";Password="+lsPassword+"");
                conn1.Open();
                //conn1 = lsGdb.Gdb;
                string lsDate = aYYYYMMDDHHMMSS.Substring(0, 4) + "-" + aYYYYMMDDHHMMSS.Substring(5, 2) + "-" + aYYYYMMDDHHMMSS.Substring(8, 2);
                lsSQL = "Select v.vouno, v.staffcode, v.voudate, v.counter1, v.couno, v.shiftcode, v.restime, v.provcode, "  //0-7
                    + "v.hotelcode, v.guestfirstname, v.nationcode, v.roomcode, v.visitt, v.pax, v.roomrate, "  //8-14
                    + "v.statuscode, v.depositamt, v.checkindate, v.checkoutdate, v.confirmperson, v.remark, " // 15-20
                    + "v.flag, v.resrooms, v.flagsend, v.guestlastname, v.roomno, v.mac, v.flagconfirm, " // 21-27
                    + "v.confirmremark, v.personintrip, v.prefix, v.roomrate1, v.pay_type, v.currency_code, m.memnamee1, v.memplcode, v.voiddate, v.returndate, v.remarkreturn " // 28-34
                    + "From voucher v, member m Where v.flag <> '4' and v.voudate = '" + lsDate + "' and m.memid = v.hotelcode and v.memplcode not in ('-','') ";
                lsSQL = lsSQL + "Union ";
                lsSQL = lsSQL + "Select v.vouno, v.staffcode, v.voudate, v.counter1, v.couno, v.shiftcode, v.restime, v.provcode, "  //0-7
                    + "v.hotelcode, v.guestfirstname, v.nationcode, v.roomcode, v.visitt, v.pax, v.roomrate, "  //8-14
                    + "v.statuscode, v.depositamt, v.checkindate, v.checkoutdate, v.confirmperson, v.remark, " // 15-20
                    + "v.flag, v.resrooms, v.flagsend, v.guestlastname, v.roomno, v.mac, v.flagconfirm, " // 21-27
                    + "v.confirmremark, v.personintrip, v.prefix, v.roomrate1, v.pay_type, v.currency_code, m.memnamee1, v.memplcode, v.voiddate, v.returndate, v.remarkreturn " // 28-34
                    + "From voucher v, member m Where v.flag = '5' and v.returndate = '" + lsDate + "' and m.memid = v.hotelcode and v.memplcode not in ('-','') ";
                MySqlCommand lsComm = new MySqlCommand(lsSQL, conn);
                MySqlDataReader lsRead;
                lsRead = lsComm.ExecuteReader();
                StreamWriter lsSW = new StreamWriter(lsPath + lsFileName + ".Txt");
                lsTextSaleFileName = lsPath + lsFileName + ".Txt";
                lsDataSH[0] = "[SALESHEADER]";
                lsDataSD[0] = "[SALESDETAIL]";
                lsDataSPa[0] = "[SALESPAYMENT]";
                lsDataSPy[0] = "[SUMPAYMENT]";
                lsDataSSa[0] = "[SUMSALES]";
                lsSPy.Sale_Date = lsVouDate;
                lsSSa.Sale_Date = lsSPy.Sale_Date;
                if (lsRead.HasRows)
                {
                    //lsVat_Rate = lsMaster.lsVatRate;
                    double ldoAmt_Inv_Vat = 0, ldoAmt_EXC_Vat = 0, ldoVat_Amt = 0, ldoAmt = 0;
                    while (lsRead.Read())
                    {
                        i++;
                        lsSH.Branch_Code = lsRead["counter1"].ToString();
                        lsSD.Branch_Code = lsSH.Branch_Code;
                        lsSPa.Branch_Code = lsSH.Branch_Code;
                        lsSPy.Branch_Code = lsSH.Branch_Code;
                        lsSSa.Branch_Code = lsSH.Branch_Code;
                        lsSH.Sale_NO = lsRead["vouno"].ToString();
                        lsSD.Sale_NO = lsSH.Sale_NO;
                        lsSPa.Sale_NO = lsSH.Sale_NO;
                        lsSH.POS_NO = lsRead["mac"].ToString();
                        lsSD.POS_NO = lsSH.POS_NO;
                        lsSPa.POS_NO = lsSH.POS_NO;
                        lsSH.Sale_TYPE = "1";
                        lsSD.Sale_TYPE = lsSH.Sale_TYPE;
                        lsSPa.Sale_TYPE = lsSH.Sale_TYPE;
                        ldSaleDate = Convert.ToDateTime(lsRead["voudate"]);
                        if (lsRead["flag"].ToString() == "3")
                        {
                            //MySqlDbType.Datetime aaa;
                            //aaa = lsRead.GetMySqlDateTime(36);
                            //ldVoidDate = Convert.ToDateTime(lsRead.GetMySqlDateTime(36));
                            Boolean lbVoid = lsRead.GetMySqlDateTime(36).IsValidDateTime;
                            lsSQL = lsRead.GetMySqlDateTime(36).ToString();
                            if (lbVoid)
                            {
                                ldVoidDate = Convert.ToDateTime(lsSQL);
                                lsSH.Void_Date = ldVoidDate.Year.ToString("0000") + "-" + ldVoidDate.Month.ToString("00") + "-" + ldVoidDate.Day.ToString("00") + " " + ldVoidDate.Hour.ToString("00") + ":" + ldVoidDate.Minute.ToString("00") + ":" + ldVoidDate.Second.ToString("00");
                            }
                            else
                            {
                                lsSH.Void_Date = "";
                            }
                        }
                        else
                        {
                            lsSH.Void_Date = "";
                        }
                        lsSH.Void_Reason = "";
                        lsSH.Sale_Date = ldSaleDate.Year.ToString("0000") + "-" + ldSaleDate.Month.ToString("00") + "-" + ldSaleDate.Day.ToString("00");
                        if (lsRead["flag"].ToString() == "5")
                        {
                            Boolean lbReturnVoucher = lsRead.GetMySqlDateTime(37).IsValidDateTime;
                            if (lbReturnVoucher)
                            {
                                ldReturnDate = Convert.ToDateTime(lsRead["returndate"]);
                                lsSH.Return_Reason = lsRead["remarkreturn"].ToString();
                                lsSH.Sale_Date = ldReturnDate.Year.ToString("0000") + "-" + ldReturnDate.Month.ToString("00") + "-" + ldReturnDate.Day.ToString("00");
                            }
                            else
                            {
                                lsSH.Return_Reason = "";
                            }
                        }
                        else
                        {
                            
                        }
                        lsSD.Sale_Date = lsSH.Sale_Date;
                        lsSPa.Sale_Date = lsSH.Sale_Date;
                        lsSD.SEQ = "1";
                        lsSH.Shift_NO = lsRead["shiftcode"].ToString();
                        lsMemID = lsRead["hotelcode"].ToString();
                        if (lsMemID == lsMem)
                        {
                            j++;
                        }
                        else
                        {
                            lsMem = lsMemID;
                            j = 1;
                        }
                        lsPlNameE = lsRead["memplcode"].ToString();
                        lsPlNameE = lsIniT.SelectInitial(lsIniT.TblTypeRoom, lsPlNameE.Substring(5, 2), Initial.WhereSelect.aCodetoName);
                        lsSD.Prod_Serv_Name = lsRead.GetValue(34).ToString() + " [" + lsPlNameE + "]";
                        lsSD.Prod_Serv_code = lsRead["memplcode"].ToString();
                        lsSD.Prod_Serv_QTY = lsRead.GetValue(13).ToString();
                        lsSD.Prod_Serv_QTY = "1";
                        lsTime = "";
                        lsTime = lsRead["restime"].ToString();
                        if (lsTime.Length < 5)
                        {
                            lsTime = "00:00";
                        }
                        lsSH.Doc_Date = lsSH.Sale_Date + " " + lsTime + ":00";
                        lsSH.Create_Date = lsSH.Doc_Date;
                        lsSH.Trans_Date = lsSH.Doc_Date;
                        lsSH.Member_ID = "";
                        lsSH.SVC_ID = "";
                        lsSH.Name = lsRead["guestfirstname"].ToString() + " " + lsRead["guestlastname"].ToString();
                        lsSH.Flight_NO = "";
                        lsSH.Flight_Date = "";
                        lsSH.Nation_Code = lsRead["nationcode"].ToString();
                        lsSH.Nation_Code = "";
                        lsSH.PassPort_NO = "";
                        lsSH.Birth_Date = "";
                        lsSH.Sex = "";
                        //lsSH.Vat_Type = "1";
                        lsSD.Vat_Type = lsSH.Vat_Type;
                        ldoAmt = Convert.ToDouble(lsRead[lsCalAmt]);
                        ldoAmt = (ldoAmt * ldoMulti) / 100;
                        if (lsFlagVAT == "exclude")
                        {
                            ldoAmt_EXC_Vat = ldoAmt;
                            ldoAmt_Inv_Vat = ldoAmt + (ldoAmt * (Convert.ToDouble(lsVatRate) / 100));
                        }
                        else
                        {
                            ldoAmt_Inv_Vat = ldoAmt;
                            ldoAmt_EXC_Vat = ldoAmt_Inv_Vat / 1.07;
                        }
                        lsError = lsSH.Name;
                        lsSH.AMT_EXC_VAT = ldoAmt_EXC_Vat.ToString("0.00");
                        lsSD.AMT_EXC_VAT = lsSH.AMT_EXC_VAT;
                        lsSH.AMT_INC_VAT = ldoAmt_Inv_Vat.ToString("0.00");
                        lsSD.AMT_INC_VAT = lsSH.AMT_INC_VAT;
                        if (lsFlagVAT == "exclude")
                        {
                            lsSPa.Amount = lsSH.AMT_EXC_VAT;
                            lsSPa.Baht_AMT = lsSH.AMT_EXC_VAT;
                        }
                        else
                        {
                            lsSPa.Amount = lsSH.AMT_INC_VAT;
                            lsSPa.Baht_AMT = lsSH.AMT_INC_VAT;
                        }
                        lsSD.AOT_Price_Inc_VAT = lsSD.AMT_INC_VAT;
                        lsSD.AOT_Price_Exc_VAT = lsSD.AMT_EXC_VAT;
                        ldoVat_Amt = ldoAmt_Inv_Vat - ldoAmt_EXC_Vat;
                        lsSH.VAT_AMT = ldoVat_Amt.ToString("0.00");
                        lsSD.VAT_AMT = lsSH.VAT_AMT;
                        lsSH.Pro_Code = "";
                        lsSD.Pro_Code = "";
                        lsSH.Disc_Vat_AMT = "";
                        lsSH.Disc_AMT_Exc_Vat = "";
                        lsSD.Disc_Price_Exc_VAT = lsSH.Disc_AMT_Exc_Vat;
                        lsSH.Disc_AMT_INC_VAT = "";
                        lsSD.Disc_Price_INC_VAT = lsSH.Disc_AMT_INC_VAT;
                        lsSH.Service_Charge = "";
                        lsSD.Service_Charge = lsSH.Service_Charge;
                        lsSH.Ref_Sale_NO = "";
                        lsSH.Ref_POS_NO = "";
                        lsSH.Ref_Sale_Date = "";
                        lsSH.Return_Reason = "";
                        switch (lsRead["hotelcode"].ToString())
                        {
                            case "01":
                                lsSPa.Pay_TYPE = "1";
                                break;
                            case "02":
                                lsSPa.Pay_TYPE = "2";
                                break;
                            case "03":
                                lsSPa.Pay_TYPE = "3";
                                break;
                            default:
                                lsSPa.Pay_TYPE = "1";
                                break;
                        }
                        if (lsSD.Sale_NO == "49001000094")
                        {
                            lsSQL = "";
                        }
                        lsDataSH1_10 = lsSH.ShopCode + "|" + lsSH.Branch_Code + "|" + lsSH.Sale_NO + "|" + lsSH.POS_NO + "|" + lsSH.Sale_TYPE + "|" + lsSH.Sale_Date + "|" + lsSH.Shift_NO + "|" + lsSH.Doc_Date + "|" + lsSH.Create_Date + "|" + lsSH.Trans_Date;
                        lsDataSH11_20 = lsSH.Member_ID + "|" + lsSH.SVC_ID + "|" + lsSH.Name + "|" + lsSH.Flight_NO + "|" + lsSH.Flight_Date + "|" + lsSH.Nation_Code + "|" + lsSH.PassPort_NO + "|" + lsSH.Birth_Date + "|" + lsSH.Sex + "|" + lsSH.Vat_Type;
                        lsDataSH21_34 = lsSH.AMT_EXC_VAT + "|" + lsSH.VAT_AMT + "|" + lsSH.AMT_INC_VAT + "|" + lsSH.Pro_Code + "|" + lsSH.Disc_Vat_AMT + "|" + lsSH.Disc_AMT_Exc_Vat + "|" + lsSH.Disc_AMT_INC_VAT + "|" + lsSH.Service_Charge + "|" + lsSH.Void_Date + "|" + lsSH.Void_Reason + "|" + lsSH.Ref_Sale_NO + "|" + lsSH.Ref_POS_NO + "|" + lsSH.Ref_Sale_Date + "|" + lsSH.Return_Reason;
                        lsDataSH[i] = lsDataSH1_10 + "|" + lsDataSH11_20 + "|" + lsDataSH21_34;
                        lsDataSD1_10 = lsSD.ShopCode + "|" + lsSD.Branch_Code + "|" + lsSD.Sale_NO + "|" + lsSD.POS_NO + "|" + lsSD.Sale_TYPE + "|" + lsSD.Sale_Date + "|" + lsSD.SEQ + "|" + lsSD.Std_Cate_Code + "|" + lsSD.Prod_Serv_code + "|" + lsSD.Prod_Serv_Name;
                        lsDataSD11_23 = lsSD.Vat_Type + "|" + lsSD.Vat_Rate + "|" + lsSD.Prod_Serv_QTY + "|" + lsSD.Unit_Code + "|" + lsSD.AOT_Price_Exc_VAT + "|" + lsSD.AOT_Price_Inc_VAT + "|" + lsSD.AMT_EXC_VAT + "|" + lsSD.VAT_AMT + "|" + lsSD.AMT_INC_VAT + "|" + lsSD.Pro_Code + "|" + lsSD.Disc_Price_Exc_VAT + "|" + lsSD.Disc_Price_INC_VAT + "|" + lsSD.Service_Charge;
                        lsDataSD[i] = lsDataSD1_10 + "|" + lsDataSD11_23;
                        lsDataSPa1_11 = lsSPa.ShopCode + "|" + lsSPa.Branch_Code + "|" + lsSPa.Sale_NO + "|" + lsSPa.POS_NO + "|" + lsSPa.Sale_TYPE + "|" + lsSPa.Sale_Date + "|" + lsSPa.Pay_TYPE + "|" + lsSPa.Currency_Code + "|" + lsSPa.Rate + "|" + lsSPa.Amount + "|" + lsSPa.Baht_AMT;
                        lsDataSPa[i] = lsDataSPa1_11;
                        lsSQL = "Select * From member Where memid = '" + lsSD.Prod_Serv_code + "' and pricestart <> " + ldoAmt_Inv_Vat;
                        MySqlCommand lsCommPrice = new MySqlCommand(lsSQL, conn1);
                        MySqlDataReader lsReadPrice;
                        lsReadPrice = lsCommPrice.ExecuteReader();
                        lsError = lsRead["vouno"].ToString();
                        if (lsReadPrice.HasRows)
                        {
                            j++;
                            //lsData = lsGen.GenMasterFileKingPower(lsReadPrice, ldoAmt_Inv_Vat);
                            lsData = GenMasterFileKingPower(lsReadPrice, ldoAmt_Inv_Vat);
                            foreach (string lsD in lsData)
                            {
                                if (lsD != null)
                                {
                                    lsMaster[j] = lsD;
                                }
                            }
                        }
                        lsReadPrice.Close();
                    }
                }
                lsRead.Close();
                double ldoAmount = 0;
                lsSQL = "Select pay_type, counter1, currency_code, sum(roomrate) as roomrate, voudate, sum(roomrate1) as roomrate1 From voucher, member "
                    + "Where voudate = '" + lsDate + "' and voucher.flag <> '4' and memplcode not in ('-','') and hotelcode = memid Group By pay_type, currency_code, counter1, voudate ";
                MySqlCommand lsCommSpy = new MySqlCommand(lsSQL, conn);
                MySqlDataReader lsReadSpy;
                lsReadSpy = lsCommSpy.ExecuteReader();
                if (lsReadSpy.HasRows)
                {
                    i = 0;
                    while (lsReadSpy.Read())
                    {
                        i++;
                        lsSPy.Pay_TYPE = lsReadSpy["pay_type"].ToString();
                        lsSPy.Currency_Code = lsReadSpy["currency_code"].ToString();
                        ldSaleDate = Convert.ToDateTime(lsReadSpy["voudate"]);
                        lsSPy.Sale_Date = ldSaleDate.Year.ToString("0000") + "-" + ldSaleDate.Month.ToString("00") + "-" + ldSaleDate.Day.ToString("00");
                        lsSPy.Branch_Code = lsReadSpy["counter1"].ToString();
                        //ldoAmount = Convert.ToDouble(lsReadSpy["roomrate"]);
                        //ldoAmount = (ldoAmount * ldoMulti) / 100;
                        ldoAmount = Convert.ToDouble(lsReadSpy[lsCalAmt]);
                        ldoAmount = (ldoAmount * ldoMulti) / 100;
                        if (lsFlagVAT == "exclude")
                        {
                            ldoAmount = ldoAmount;
                        }
                        else
                        {
                            //ldoAmount = ldoAmount / 1.07;
                            ldoAmount = ldoAmount + (ldoAmount * (Convert.ToDouble(lsVatRate) / 100));
                        }
                        lsSPy.Amount = ldoAmount.ToString("0.00");
                        lsSPy.Baht_AMT = lsSPy.Amount;
                        lsDataSPy1_8 = lsSPy.ShopCode + "|" + lsSPy.Branch_Code + "|" + lsSPy.Sale_Date + "|" + lsSPy.Pay_TYPE + "|" + lsSPy.Currency_Code.ToUpper() + "|" + lsSPy.Rate + "|" + lsSPy.Amount + "|" + lsSPy.Amount;
                        lsDataSPy[i] = lsDataSPy1_8;
                    }
                }
                lsReadSpy.Close();
                lsSQL = "Select counter1, sum(roomrate) as roomrate, sum(roomrate1) as roomrate1, voudate From voucher, member "
                    + "Where voucher.flag <> '4' and voudate = '" + lsDate + "' and memplcode not in ('-','') and hotelcode = memid Group By counter1, voudate ";
                MySqlCommand lsCommSSa = new MySqlCommand(lsSQL, conn);
                MySqlDataReader lsReadSSa;
                lsReadSSa = lsCommSSa.ExecuteReader();
                if (lsReadSSa.HasRows)
                {
                    i = 0;
                    while (lsReadSSa.Read())
                    {
                        i++;
                        lsSSa.Branch_Code = lsReadSSa["counter1"].ToString();
                        ldSaleDate = Convert.ToDateTime(lsReadSSa["voudate"]);
                        lsSSa.Sale_Date = ldSaleDate.Year.ToString("0000") + "-" + ldSaleDate.Month.ToString("00") + "-" + ldSaleDate.Day.ToString("00");
                        //ldoAmount = Convert.ToDouble(lsReadSSa["amt"]);
                        //ldoAmount = (ldoAmount * ldoMulti) / 100;

                        ldoAmount = Convert.ToDouble(lsReadSSa[lsCalAmt]);
                        ldoAmount = (ldoAmount * ldoMulti) / 100;
                        if (lsFlagVAT == "exclude")
                        {
                            ldoAmount = ldoAmount;
                        }
                        else
                        {
                            //ldoAmount = ldoAmount / 1.07;
                            ldoAmount = ldoAmount + (ldoAmount * (Convert.ToDouble(lsVatRate) / 100));
                        }
                        lsSSa.Sale_Header_AMT = ldoAmount.ToString("0.00");
                        lsSSa.Net_Sale_Header_AMT = ldoAmount.ToString("0.00");
                        lsSSa.Sale_DTL_AMT = ldoAmount.ToString("0.00");
                        lsSSa.Net_Sale_DTL_AMT = ldoAmount.ToString("0.00");
                        lsSSa.Payment_AMT = ldoAmount.ToString("0.00");
                        lsDataSSa1_8 = lsSSa.ShopCode + "|" + lsSSa.Branch_Code + "|" + lsSSa.Sale_Date + "|" + lsSSa.Sale_Header_AMT + "|" + lsSSa.Net_Sale_Header_AMT + "|" + lsSSa.Sale_DTL_AMT + "|" + lsSSa.Net_Sale_DTL_AMT + "|" + lsSSa.Payment_AMT;
                        lsDataSSa[i] = lsDataSSa1_8;
                    }
                }
                lsReadSpy.Close();
                //lsSW.WriteLine(lsDataD[0]);
                foreach (string lsD in lsDataSH)
                {
                    if (lsD != null)
                    {
                        lsSW.WriteLine(lsD);
                    }
                }
                foreach (string lsD in lsDataSD)
                {
                    if (lsD != null)
                    {
                        lsSW.WriteLine(lsD);
                    }
                }
                foreach (string lsD in lsDataSPa)
                {
                    if (lsD != null)
                    {
                        lsSW.WriteLine(lsD);
                    }
                }
                foreach (string lsD in lsDataSPy)
                {
                    if (lsD != null)
                    {
                        lsSW.WriteLine(lsD);
                    }
                }
                foreach (string lsD in lsDataSSa)
                {
                    if (lsD != null)
                    {
                        lsSW.WriteLine(lsD);
                    }
                }
                lsSW.Close();
                conn.Close();
                conn1.Close();
                //KingPower lsGen = new KingPower();
                //lsGen.CreateTextFile(lsMaster, aYYYYMMDDHHMMSS);
                CreateTextProductFile(lsMaster, aYYYYMMDDHHMMSS);
                lbReturn = true;
            }                
            catch(Exception e)
            {
                string ls = "ไม่สามารถเตรียมข้อมูล Print ได้ ";
                lsGdb.WriteLogError(ls, e, lsError, "GenSaleDailyKingPower ");
                //MessageBox.Show(ls + " " + eAcc.Message.ToString(), eAcc.Source.ToString(), MessageBoxButtons.OK);
            }
            return lbReturn;
        }
    }
}
