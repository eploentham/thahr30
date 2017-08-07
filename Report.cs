using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data.OleDb;
using System.Windows.Forms;
namespace ThaHr30
{
    class Report
    {        
        Connection lsGdb = new Connection();
        IniFile lsIni = new IniFile("thahr30.ini");
        Initial lsIniT = new Initial();
        private string lsSQL = "";
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
        
        public void PrintGrd(FarPoint.Win.Spread.FpSpread Grd )
        {
            string lsSQL = "", lsCol = "", lsAccess = "", ls="", lsAddress="";
            Boolean lbFlag = false;
            lsAccess = lsIni.GetString("thahr30", "accessdatabase", "0");
            lsSQL = "Delete From rptreport";
            OleDbConnection acc = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + lsAccess + ";");
            acc.Open();
            OleDbCommand accCom = new OleDbCommand(lsSQL, acc);
            accCom.ExecuteNonQuery();
            for (int i = 0; i <= Grd.Sheets[0].RowCount - 1; i++)
            {
                if (i == 279)
                {
                    MessageBox.Show("i="+i.ToString());
                }

                try
                {
                    lsSQL = Grd.Sheets[0].GetText(i, 0);
                    lsAddress = "";
                    lsAddress = Grd.Sheets[0].GetText(i, 14) + " " + Grd.Sheets[0].GetText(i, 15) + " " + Grd.Sheets[0].GetText(i, 16) + " "
                        + Grd.Sheets[0].GetText(i, 17) + " " + Grd.Sheets[0].GetText(i, 18);
                    lbFlag = Convert.ToBoolean(Grd.Sheets[0].GetValue(i, 0));
                    if (lbFlag)
                    {
                        lsSQL = "Insert Into rptreport(code, name, col1, "
                        + "col2, col3, col4, "
                        + "col5, col6, col7, " 
                        + "col8, col9, col10, "
                        + "col11, col12, col13) "
                        + "Values('" + Grd.Sheets[0].GetText(i, 1).Replace("'", "''") + "','" + Grd.Sheets[0].GetText(i, 2).Replace("'", "''") + "','" + Grd.Sheets[0].GetText(i, 10).Replace("'", "''")
                        + "','" + Grd.Sheets[0].GetText(i, 4).Replace("'", "''") + "','" + Grd.Sheets[0].GetText(i, 12).Replace("'", "''") + "','" + Grd.Sheets[0].GetText(i, 3).Replace("'", "''")
                        + "','" + Grd.Sheets[0].GetText(i, 5).Replace("'", "''") + "','" + Grd.Sheets[0].GetText(i, 9).Replace("'", "''") + "','" + Grd.Sheets[0].GetText(i, 12).Replace("'", "''")
                        + "','" + Grd.Sheets[0].GetText(i, 7).Replace("'", "''") + "','" + Grd.Sheets[0].GetText(i, 8).Replace("'", "''") + "','" + lsAddress.Replace("'", "''")
                        + "','" + Grd.Sheets[0].GetText(i, 13).Replace("'", "''") + "','" + Grd.Sheets[0].GetText(i, 18).Replace("'", "''") + "','" + Grd.Sheets[0].GetText(i, 23).Replace("'", "''") + "')";
                        OleDbCommand accCom2 = new OleDbCommand(lsSQL, acc);
                        accCom2.ExecuteNonQuery();
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(ls + "\n" + " " + e.Message.ToString(), e.Source.ToString(), MessageBoxButtons.OK);
                }

            }
            acc.Close();
        }
        public void PrintGrdMeeting(FarPoint.Win.Spread.FpSpread Grd)
        {
            string sql = "", lsCol = "", lsAccess = "", ls = "", lsAddress = "", lsMemName="", lsMemName1="";
            string lsCol3 = "", lsCol2 = "", lsCol1 = "", lsBreakPage = "", lsBreakPageTemp = "", col9="";
            Int32 ii = 0, liSort=0, breakPage=0;
            Boolean lbFlag = false;
            lsAccess = lsIni.GetString("thahr30", "accessdatabase", "0");
            sql = "Delete From rptreport";
            OleDbConnection acc = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + lsAccess + ";");
            acc.Open();
            OleDbCommand accCom = new OleDbCommand(sql, acc);
            accCom.ExecuteNonQuery();
            for (int i = 0; i <= Grd.Sheets[0].RowCount - 1; i++)
            {
                try
                {
                    sql = Grd.Sheets[0].GetText(i, 0);
                    lsMemName = Grd.Sheets[0].GetText(i, 2);
                    lsCol1 = Grd.Sheets[0].GetText(i, 1);
                    lsCol2 = Grd.Sheets[0].GetText(i, 4);
                    lsCol3 = Grd.Sheets[0].GetText(i, 5);
                    col9 = Grd.Sheets[0].GetText(i, 9);
                    if (lsMemName.Length > 1)
                    {
                        lsBreakPage = lsMemName.Substring(0, 1);
                        //if lsbr
                        lsBreakPageTemp = lsBreakPage;
                        breakPage++;
                        //lsBreakPage += breakPage.ToString();
                        if (breakPage > 5)
                        {
                            breakPage = 0;
                        }
                    }
                    if (lsMemName == "SIMA THANI HOTEL")
                    {
                        //lsBreakPage = "";
                    }
                    lsMemName = lsMemName.Replace("'", "''");
                    lsCol1 = lsCol1.Replace("'", "''");
                    lsCol2 = lsCol2.Replace("'", "''");
                    lsCol3 = lsCol3.Replace("'", "''");
                    col9 = col9.Replace("'", "''");
                    liSort = i;
                    //if (lsMemName != lsMemName1)
                    //{
                    //    lsMemName1 = lsMemName;
                    //    ii = 0;
                    //}
                    //else
                    //{
                    //    ii++;
                    //}
                    //lbFlag = Convert.ToBoolean(Grd.Sheets[0].GetValue(i, 0));
                    //if (lbFlag)
                    //{
                    sql = "Insert Into rptreport(code, name, col1, "
                    + "col2, col3, col4, 01, 02, col5) "
                    + "Values('" + i.ToString() + "','" + lsMemName + "','" + lsCol1
                    + "','" + lsCol2 + "','" + lsCol3 + "','" + lsBreakPage + "'," + liSort + "," + breakPage+",'"+col9+"')";
                    OleDbCommand accCom2 = new OleDbCommand(sql, acc);
                    accCom2.ExecuteNonQuery();
                    //}
                }
                catch (Exception e)
                {
                    MessageBox.Show(ls + "\n" + " " + e.Message.ToString(), e.Source.ToString(), MessageBoxButtons.OK);
                }
            }
            sql = "Select count(*) as cnt, name From rptreport Group by name";
            accCom.CommandText = sql;
            OleDbDataReader accRead;
            accRead = accCom.ExecuteReader();
            if (accRead.HasRows)
            {
                while (accRead.Read())
                {
                    lsMemName = accRead["name"].ToString();
                    ii = Convert.ToInt32(accRead["cnt"]);
                    if (ii < 5)
                    {
                        for (Int32 iii = 1; iii <= 5-ii; iii++)
                        {
                            lsMemName = lsMemName.Replace("'", "''");
                            if (lsMemName.Length > 1)
                            {
                                lsBreakPage = lsMemName.Substring(0, 1);
                                //if lsbr
                                lsBreakPageTemp = Convert.ToString(10000 + iii);
                            }
                            liSort = 10000 + iii;
                            sql = "Insert Into rptreport(code, name, col1, "
                                + "col2, col3, col4, 01) "
                                + "Values('" + lsBreakPageTemp + "','" + lsMemName + "','.','.','.','" + lsBreakPage + "'," + liSort + ")";
                            OleDbCommand accCom3 = new OleDbCommand(sql, acc);
                            accCom3.ExecuteNonQuery();
                        }
                    }
                }
            }
            accRead.Close();
            acc.Close();
        }
        public void PrintGrdMeetingLabel(FarPoint.Win.Spread.FpSpread Grd, string aMeetingNameT,string aMeetingDescription, string aMeetingPlace)
        {
            string sql = "", lsCol = "", lsAccess = "", ls = "", lsAddress = "", lsMemName = "", lsMemName1 = "";
            string lsCol3 = "", lsCol5="", lsCol2 = "", lsCol1 = "", lsMeetingNameT="", lsMeetingDescription="", lsMeetingPlace="";
            Int32 ii = 0;
            Boolean lbFlag = false;
            lsAccess = lsIni.GetString("thahr30", "accessdatabase", "0");
            sql = "Delete From rptreport";
            OleDbConnection acc = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + lsAccess + ";");
            acc.Open();
            OleDbConnection accselect = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + lsAccess + ";");
            accselect.Open();
            OleDbCommand accCom = new OleDbCommand(sql, acc);
            OleDbCommand accComselect = new OleDbCommand(sql, accselect);
            OleDbDataReader rs;
            accCom.ExecuteNonQuery();
            lsMeetingNameT = aMeetingNameT.Replace("'", "''");
            lsMeetingDescription = aMeetingDescription.Replace("'", "''");
            lsMeetingPlace = aMeetingPlace.Replace("'", "''");
            int NumberData = 0;
            string dd;
            for (int i = 0; i <= Grd.Sheets[0].RowCount - 1; i++)
            {
                try
                {
                    sql = Grd.Sheets[0].GetText(i, 0);
                    lsMemName = Grd.Sheets[0].GetText(i, 2);
                    lsCol1 = Grd.Sheets[0].GetText(i, 1);
                    lsCol2 = Grd.Sheets[0].GetText(i, 3);
                    lsCol3 = Grd.Sheets[0].GetText(i, 4);
                    lsCol5 = Grd.Sheets[0].GetText(i, 8);
                    dd=Grd.Sheets[0].Cells[i, 8].Column.DataField.ToLower();
                    lsMemName = lsMemName.Replace("'", "''");
                    lsCol1 = lsCol1.Replace("'", "''");
                    lsCol2 = lsCol2.Replace("'", "''");
                    lsCol3 = lsCol3.Replace("'", "''");
                    if (lsMemName == "FIRST HOTEL")
                    {
                        sql = "";
                    }
                    if ((lsCol5 == "1") || (lsCol5.ToLower() == "true"))
                    {
                        //sql = "Select name From rptreport Where name = '" + lsMemName + "' and col4 ='-'";
                        //accComselect.CommandText = sql;
                        //rs = accComselect.ExecuteReader();
                        //if (rs.HasRows)
                        //{
                        //    //sql = "Insert Into rptreport(code, name, col4, "
                        //    //    + "col5, col6, col7, col8, col9, col10) "
                        //    //    + "Values('" + i.ToString() + "','" + lsMemName + "','" + lsCol1
                        //    //    + "','" + lsCol2 + "','" + lsCol3 + "','" + lsMeetingNameT + "','" + lsMeetingDescription + "','" + lsMeetingPlace + "','" + lsCol5 + "')";
                        //    sql = "Update rptreport Set col4 = '" + lsCol1 + "', col5 = '"+lsCol2+"', "
                        //        +"col6 = '"+lsCol2+"', col7='"+lsMeetingNameT+"', col8='"+lsMeetingDescription+"', "
                        //        + "col9 = '" + lsMeetingPlace + "', col10='" + lsCol5 + "' Where name = '"+lsMemName+"' and col4 = '-'";
                        //}
                        //else
                        //{
                        //    sql = "Insert Into rptreport(code, name, col1, "
                        //        + "col2, col3,col7, "
                        //        + "col8, col9, col10, col4) "
                        //        + "Values('" + i.ToString() + "','" + lsMemName + "','" + lsCol1
                        //        + "','" + lsCol2 + "','" + lsCol3 + "','" + lsMeetingNameT + "','"
                        //        + lsMeetingDescription + "','" + lsMeetingPlace + "','" + lsCol5 + "','-')";
                        //}
                        //rs.Close();
                        if ((NumberData % 2) != 0)
                        {
                            sql = "Update rptreport Set col4 = '" + lsCol1 + "', col5 = '" + lsMemName + "', "
                                + "col6 = '" + lsCol2 + "', col7='" + lsMeetingNameT + "', col8='" + lsMeetingDescription + "', "
                                + "col9 = '" + lsMeetingPlace + "', col10='" + lsCol5 + "' Where code = '" + (NumberData - 1) + "'";
                        }
                        else
                        {
                            sql = "Insert Into rptreport(code, name, col1, "
                                + "col2, col3,col7, "
                                + "col8, col9, col10, col4) "
                                + "Values('" + NumberData.ToString() + "','" + lsMemName + "','" + lsCol1
                                + "','" + lsCol2 + "','" + lsCol3 + "','" + lsMeetingNameT + "','"
                                + lsMeetingDescription + "','" + lsMeetingPlace + "','" + lsCol5 + "','-')";
                        }
                        NumberData++;
                        OleDbCommand accCom2 = new OleDbCommand(sql, acc);
                        accCom2.ExecuteNonQuery();
                    }
                    
                }
                catch (Exception e)
                {
                    MessageBox.Show(ls + "\n" + " " + e.Message.ToString(), e.Source.ToString(), MessageBoxButtons.OK);
                }
            }
            acc.Close();
        }
        public void SumTypeMember(Boolean aCreateIniT)
        {
            string lsAccess = "", lsTMemCode = "", lsTmemNameE = "", lsVouDate="";
            double ldoCnt = 0, ldoSum = 0;
            if (lsGdb.Gdb.State == System.Data.ConnectionState.Closed)
            {
                lsGdb.ConnectDatabase();
            }
            if (aCreateIniT)
            {
                lsIniT.CreateTblInitial(lsGdb.Gdb);
            }
            lsAccess = lsIni.GetString("thahr30", "accessdatabase", "0");
            lsSQL = "Delete From rptvoucher";
            OleDbConnection acc = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + lsAccess + ";");
            acc.Open();
            OleDbCommand accCom = new OleDbCommand(lsSQL, acc);
            accCom.ExecuteNonQuery();
            lsSQL = "Select count(*) as cnt, sum(numroom) as numroom, tmemcode From member Where flag = '1' Group by tmemcode";
            MySqlCommand lsComm = new MySqlCommand(lsSQL, lsGdb.Gdb);
            MySqlDataReader lsRead;
            lsRead = lsComm.ExecuteReader();
            if (lsRead.HasRows)
            {
                //j= lsRead.RecordsAffected;
                lsVouDate = DateTime.Today.Day.ToString("00") + "/" + DateTime.Today.Month.ToString("00") + "/" + DateTime.Today.Year.ToString("0000");
                while (lsRead.Read())
                {
                    try
                    {
                        lsTMemCode = lsRead["tmemcode"].ToString();
                        ldoCnt = Convert.ToDouble(lsRead["cnt"]);
                        ldoSum = Convert.ToDouble(lsRead["numroom"]);
                        lsTmemNameE = lsIniT.SelectInitial(lsIniT.TblTypeMem, lsTMemCode, Initial.WhereSelect.aCodetoName);
                        lsSQL = "Insert Into rptvoucher(vouno, fullname, deposit, rate1, checkin, checkout)"
                            + "Values('"+ lsTMemCode + "','"+ lsTmemNameE + "'," + ldoCnt + "," + ldoSum +",'" + lsVouDate + "','" + lsVouDate + "')";
                        OleDbCommand accCom2 = new OleDbCommand(lsSQL, acc);
                        accCom2.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        //lsSQL = "";
                        string ls = "มีข้อมูลบางแห่งผิดพลาด รายงานอาจได้ข้อมูลที่ไม่ถูกต้อง ";
                        lsGdb.WriteLogError(ls, e, lsSQL, "SumTypeMember ");
                        MessageBox.Show(ls + "\n" + " " + e.Message.ToString(), e.Source.ToString(), MessageBoxButtons.OK);
                    }
                }
                lsRead.Close();
                acc.Close();
                acc.Dispose();
                accCom.Dispose();
            }
        }
        public void SumTypeMemberRegion(Boolean aCreateIniT)
        {
            string lsAccess = "", lsTMemCode = "", lsTmemNameE = "", lsVouDate = "", lsRegionCode = "", lsRegionNameE = "";
            double ldoCnt = 0, ldoSum = 0;
            if (lsGdb.Gdb.State == System.Data.ConnectionState.Closed)
            {
                lsGdb.ConnectDatabase();
            }
            if (aCreateIniT)
            {
                lsIniT.CreateTblInitial(lsGdb.Gdb);
            }
            lsAccess = lsIni.GetString("thahr30", "accessdatabase", "0");
            lsSQL = "Delete From rptvoucher";
            OleDbConnection acc = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + lsAccess + ";");
            acc.Open();
            OleDbCommand accCom = new OleDbCommand(lsSQL, acc);
            accCom.ExecuteNonQuery();
            lsSQL = "Select count(m.memid) as cnt, sum(m.numroom) as numroom, m.tmemcode, m.regioncode, r.sort1 From member m, region r Where m.flag in ('1','2') and m.regioncode = r.regioncode Group by m.regioncode";
            MySqlCommand lsComm = new MySqlCommand(lsSQL, lsGdb.Gdb);
            MySqlDataReader lsRead;
            lsRead = lsComm.ExecuteReader();
            if (lsRead.HasRows)
            {
                //j= lsRead.RecordsAffected;
                lsVouDate = DateTime.Today.Day.ToString("00") + "/" + DateTime.Today.Month.ToString("00") + "/" + DateTime.Today.Year.ToString("0000");
                while (lsRead.Read())
                {
                    try
                    {
                        lsTMemCode = lsRead["tmemcode"].ToString();
                        lsRegionCode = lsRead["regioncode"].ToString();
                        ldoCnt = Convert.ToDouble(lsRead["cnt"]);
                        ldoSum = Convert.ToDouble(lsRead["numroom"]);
                        lsTmemNameE = lsIniT.SelectInitial(lsIniT.TblTypeMem, lsTMemCode, Initial.WhereSelect.aCodetoName);
                        lsRegionNameE = lsIniT.SelectInitial(lsIniT.TblRegion, lsRegionCode, Initial.WhereSelect.aCodetoName);
                        lsSQL = "Insert Into rptvoucher(vouno, fullname, deposit, rate1, checkin, checkout, detail, hotelname, pax)"
                            + "Values('" + lsTMemCode + "','" + lsTmemNameE + "'," + ldoCnt + "," + ldoSum + ",'" + lsVouDate + "','" + lsVouDate + "','" + lsRegionCode + "','" + lsRegionNameE + "'," + lsRead["sort1"].ToString() + ")";
                        OleDbCommand accCom2 = new OleDbCommand(lsSQL, acc);
                        accCom2.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        //lsSQL = "";
                        string ls = "มีข้อมูลบางแห่งผิดพลาด รายงานอาจได้ข้อมูลที่ไม่ถูกต้อง ";
                        lsGdb.WriteLogError(ls, e, lsSQL, "SumTypeMember ");
                        MessageBox.Show(ls + "\n" + " " + e.Message.ToString(), e.Source.ToString(), MessageBoxButtons.OK);
                    }
                }
                lsRead.Close();
                acc.Close();
                acc.Dispose();
                accCom.Dispose();
            }
        }
        public void CreateStatusMember(string aStartDateMySQL, string aEndDateMySQL, string aStatusMember)
        {
            string lsAccess = "", lsTMemCode = "", lsTmemNameE = "", lsVouDate = "", lsRegionCode = "", lsRegionNameE = "", lsMemNameE="";
            double ldoCnt = 0, ldoSum = 0;
            //if (lsGdb.Gdb.State == System.Data.ConnectionState.Closed)
            //{
            //    lsGdb.ConnectDatabase();
            //}
            //if (aCreateIniT)
            //{
            //    lsIniT.CreateTblInitial(lsGdb.Gdb);
            //}
            lsAccess = lsIni.GetString("thahr30", "accessdatabase", "0");
            lsSQL = "Delete From rptreport";
            OleDbConnection acc = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + lsAccess + ";");
            acc.Open();
            OleDbCommand accCom = new OleDbCommand(lsSQL, acc);
            accCom.ExecuteNonQuery();
            lsSQL = "Select * From member m Where m.flag = '"+aStatusMember +"'";
            MySqlCommand lsComm = new MySqlCommand(lsSQL, lsGdb.Gdb);
            MySqlDataReader lsRead;
            lsRead = lsComm.ExecuteReader();
            if (lsRead.HasRows)
            {
                while (lsRead.Read())
                {
                    try
                    {
                        lsTMemCode = lsRead["tmemcode"].ToString();
                        lsRegionCode = lsRead["regioncode"].ToString();
                        ldoSum = Convert.ToDouble(lsRead["numroom"]);
                        lsMemNameE = lsRead["memnamee1"].ToString();
                        lsSQL = "Insert Into rptreport(code, name)"
                            + "Values('" + lsRead ["code"].ToString() + "','" + lsMemNameE + "')";
                        OleDbCommand accCom2 = new OleDbCommand(lsSQL, acc);
                        accCom2.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        //lsSQL = "";
                        string ls = "มีข้อมูลบางแห่งผิดพลาด รายงานอาจได้ข้อมูลที่ไม่ถูกต้อง ";
                        lsGdb.WriteLogError(ls, e, lsSQL, "Status Member ");
                        MessageBox.Show(ls + "\n" + " " + e.Message.ToString(), e.Source.ToString(), MessageBoxButtons.OK);
                    }
                }
                lsRead.Close();
                acc.Close();
                acc.Dispose();
                accCom.Dispose();
            }
        }
        public void CreateVoucherAcc(string aReportName, string aStartDate, string aEndDate, string aFrHotalName, string aToHotelName, string aCounter, string aShift, Boolean aCreateIniT)
        {
            DateTime ldVouDate = new DateTime();
            double ldoCash = 0, ldoCredit = 0;
            string lsAccess="", lsCheckInDate="", lsCheckOutDate="", lsHotelName="", lsCity="", lsNation="", lsDetail="", lsCounter="", lsShiftName="", lsMemNameFrom="", lsMemNameTO="";
            string lsPlName = "", lsPlCode="", lsShiftCode="", lsStaffName="", lsStatusName="", lsFlagBkk="", lsPrefix="";
            if (lsGdb.Gdb.State == System.Data.ConnectionState.Closed)
            {
                lsGdb.ConnectDatabase();
            }
            if (aCreateIniT)
            {
                lsIniT.CreateTblInitial(lsGdb.Gdb);
            }
            lsMemNameFrom = aFrHotalName.Replace("'", "''");
            lsMemNameTO = aToHotelName.Replace("'", "''");
            lsAccess = lsIni.GetString("thahr30", "accessdatabase", "0");
            lsSQL = "Delete From rptvoucher";
            string lsVouDate = "", lsVouDate1 = "", lsFullName = "";
            OleDbConnection acc = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + lsAccess + ";");
            acc.Open();
            OleDbCommand accCom = new OleDbCommand(lsSQL, acc);
            accCom.ExecuteNonQuery();
            switch (aReportName)
            {
                case "rptdailypayinrecordpayment":
                    {
                        lsSQL = "Select v.*, m.provcode From voucher v, member m Where v.voudate >='" + aStartDate + "' and v.voudate <='"
                            + aEndDate + "' and v.flag <> '3' and m.memid = v.hotelcode ";
                        break;
                    }
                case "rptdailypayinrecord":
                    {
                        lsSQL = "Select v.*, m.provcode From voucher v, member m Where v.voudate >='" + aStartDate + "' and v.voudate <='"
                            + aEndDate + "' and v.flag <> '3' and m.memid = v.hotelcode ";
                        break;
                    }
                case "rptdailypayinrecordmanager":
                    {
                        lsSQL = "Select v.*, m.provcode From voucher v, member m Where v.voudate >='" + aStartDate + "' and v.voudate <='"
                            + aEndDate + "' and v.flag <> '3' and m.memid = v.hotelcode ";
                        break;
                    }
                case "rptdailypayinrecordsu":
                    {
                        lsSQL = "Select v.*, m.provcode From voucher v, member m Where v.voudate >='" + aStartDate + "' and v.voudate <='"
                            + aEndDate + "' and v.flag <> '3' and m.memid = v.hotelcode ";
                        break;
                    }
                case "rptdailypayinrecordsuemail":
                    {
                        lsSQL = "Select v.*, m.provcode From voucher v, member m Where v.voudate >='" + aStartDate + "' and v.voudate <='"
                            + aEndDate + "' and v.flag <> '3' and m.memid = v.hotelcode ";
                        break;
                    }
                case "rptrecordofdeposit":
                    {
                        lsSQL = "Select v.* From voucher v Where v.voudate >='" + aStartDate + "' and v.voudate <='" 
                            + aEndDate + "' and v.flag <> '3' ";
                        break;
                    }
                case "rptrecordofdepositkingpower":
                    {
                        lsSQL = "Select v.* From voucher v Where v.voudate >='" + aStartDate + "' and v.voudate <='"
                            + aEndDate + "' and v.flag <> '3' ";
                        break;
                    }
                case "rptsalereport":
                    {
                        lsSQL = "Select v.*, m.provcode From voucher v, member m Where v.voudate >='" + aStartDate + "' and v.voudate <='"
                            + aEndDate + "' and v.flag <> '3' and m.memid = v.hotelcode ";
                        break;
                    }
                case "rptsalereportcounter":
                    {
                        lsSQL = "Select v.*, m.provcode From voucher v, member m Where v.voudate >='" + aStartDate + "' and v.voudate <='"
                            + aEndDate + "' and v.flag <> '3' and m.memid = v.hotelcode ";
                        break;
                    }
                case "rptmonthlysalereport":
                    {
                        if (aFrHotalName != "" && aToHotelName != "")
                        {
                            lsSQL = "Select v.* From voucher v, member m Where v.checkindate >='" + aStartDate + "' and v.checkindate <='"
                                + aEndDate + "' and m.memnamee1 >='" + lsMemNameFrom + "' and m.memnamee1 <='"
                                + lsMemNameTO + "' and v.flag in ('1','2') and v.hotelcode = m.memid";
                        }
                        else if (aFrHotalName == "" && aToHotelName != "")
                        {
                            lsSQL = "Select v.* From voucher v, member m Where v.checkindate >='" + aStartDate + "' and v.checkindate <='"
                                + aEndDate + "' and m.memnamee1 <='" + lsMemNameTO + "' and v.flag in ('1','2') and v.hotelcode = m.memid";
                        }
                        else if (aFrHotalName != "" && aToHotelName == "")
                        {
                            lsSQL = "Select v.* From voucher v, member m Where v.checkindate >='" + aStartDate + "' and v.checkindate <='"
                                + aEndDate + "' and m.memnamee1 >='" + lsMemNameFrom + "' and v.flag in ('1','2') and v.hotelcode = m.memid";
                        }
                        else
                        {
                            lsSQL = "Select v.* From voucher v, member m Where v.checkindate >='" + aStartDate + "' and v.checkindate <='"
                                + aEndDate + "' and v.flag in ('1','2') and v.hotelcode = m.memid";
                        }
                        break;
                    }
            }
            if (aCounter != "")
            {
                if (aCounter != "000")
                {
                    lsCounter = lsIniT.SelectInitial(lsIniT.TblCounter, aCounter, Initial.WhereSelect.aNametoCode);
                    lsSQL = lsSQL + " and v.counter1 = '" + lsCounter + "'";
                }
            }
            if (aShift != "")
            {
                lsShiftCode = lsIniT.SelectInitial(lsIniT.TblShift, aShift, Initial.WhereSelect.aNametoCode);
                lsSQL = lsSQL + " and shiftcode = '" + lsShiftCode + "'";
            }
            MySqlCommand lsComm = new MySqlCommand(lsSQL, lsGdb.Gdb);
            MySqlDataReader lsRead;
            lsRead = lsComm.ExecuteReader();
            if (lsRead.HasRows)
            {
                //j= lsRead.RecordsAffected;
                while (lsRead.Read())
                {
                    try
                    {
                        ldVouDate = Convert.ToDateTime(lsRead["voudate"].ToString());
                        lsVouDate = ldVouDate.Day.ToString("00") + "/" + ldVouDate.Month.ToString("00") + "/" + ldVouDate.Year.ToString("0000");
                        lsVouDate1 = ldVouDate.Year.ToString("0000") + ldVouDate.Month.ToString("00") + ldVouDate.Day.ToString("00");
                        lsNation = lsIniT.SelectInitial(lsIniT.TblNationality, lsRead["nationcode"].ToString(), Initial.WhereSelect.aCodetoName);
                        lsHotelName = lsIniT.SelectInitial(lsIniT.TblMember, lsRead["hotelcode"].ToString(), Initial.WhereSelect.aCodetoName);
                        lsCounter = lsIniT.SelectInitial(lsIniT.TblCounter, lsRead["counter1"].ToString(), Initial.WhereSelect.aCodetoName);
                        lsShiftName = lsIniT.SelectInitial(lsIniT.TblShift, lsRead["shiftcode"].ToString(), Initial.WhereSelect.aCodetoName);
                        lsStaffName = lsIniT.SelectInitial(lsIniT.TblStaff, lsRead["staffcode"].ToString(), Initial.WhereSelect.aCodetoName);
                        lsPrefix = lsIniT.SelectInitial(lsIniT.TblPrefix, lsRead["prefix"].ToString(), Initial.WhereSelect.aCodetoName);
                        lsPlCode = lsRead["memplcode"].ToString();
                        lsPlName = "-";
                        if (lsPlCode.Length >= 7)
                        {
                            lsPlCode = lsPlCode.Substring(5, 2);
                            lsPlName = lsIniT.SelectInitial(lsIniT.TblTypeRoom, lsPlCode, Initial.WhereSelect.aCodetoName);
                        }
                        //if (lsRead["memplcode"].ToString() != "")
                        //{
                        //}
                        //lsFullName = lsPrefix + " " + lsRead["guestfirstname"].ToString()+ " " + lsRead["guestlastname"].ToString();
                        lsFullName = lsPrefix + " " + lsRead["guestlastname"].ToString() + " " + lsRead["guestfirstname"].ToString();
                        lsFullName = lsFullName.Replace("'", "''");
                        lsHotelName = lsHotelName.Replace("'", "''");
                        lsStaffName = lsStaffName.Replace("'", "''");
                        switch (aReportName)
                        {
                            case "rptdailysummarypayinrecord":
                                if (lsRead["provcode"].ToString() == "10")
                                {
                                    lsFlagBkk = "Bangkok";
                                }
                                else
                                {
                                    lsFlagBkk = "Up Country";
                                }
                                break;
                            default:
                                lsFlagBkk = "";
                                break;
                        }
                        //lsFlagBkk =
                        lsSQL = lsIniT.SelectInitial(lsIniT.TblNationality, lsSQL, Initial.WhereSelect.aCodetoName);
                        switch (lsRead["flag"].ToString())
                        {
                            case "3":
                                lsStatusName = "Void";
                                break;
                            case "4":
                                lsStatusName = "No Show";
                                break;
                            default:
                                lsStatusName = lsIniT.SelectInitial(lsIniT.TblStatus, lsRead["statuscode"].ToString(), Initial.WhereSelect.aCodetoName);
                                break;
                        }
                        switch (lsRead["pay_type"].ToString())
                        {
                            case "1": // cash
                                {
                                    ldoCash = Convert.ToDouble(lsRead["depositamt"].ToString());
                                    ldoCredit = 0;
                                    break;
                                }
                            case "3": // credit
                                {
                                    ldoCash = 0;
                                    ldoCredit = Convert.ToDouble(lsRead["depositamt"].ToString()); ;
                                    break;
                                }
                        }
                        lsSQL = "Insert Into rptvoucher(vouno, voudate, fullname, checkin, "
                            + "checkout, deposit, hotelname, nationality, "
                            + "city, person, days, rate1, "
                            + "detail, hotelcode, counterid, countername, "
                            + "room, shiftcode, shiftname, voudate1, "
                            + "roomrate, roomno, plname, staff, "
                            + "plcode, time1, statusname, flagbkk, confirmby, cash, credit) "
                            + "Values('" + lsRead["vouno"].ToString() + "','" + lsVouDate + "','" + lsFullName + "','" + lsCheckInDate + "','"
                            + lsCheckOutDate + "','" + lsRead["depositamt"].ToString() + "','" + lsHotelName + "','" + lsNation + "','"
                            + lsCity + "'," + lsRead["personintrip"].ToString() + "," + lsRead["visitt"].ToString() + "," + lsRead["roomrate1"].ToString() + ",'"
                            + lsDetail + "','" + lsRead["hotelcode"].ToString() + "','" + lsRead["counter1"].ToString() + "','" + lsCounter + "'," + lsRead["resrooms"].ToString() + ",'"
                            + lsRead["shiftcode"].ToString() + "','" + lsShiftName + "','" + lsVouDate1 + "',"
                            + lsRead["roomrate"].ToString() + ",'" + lsRead["roomno"].ToString() + "','" + lsPlName + "','" + lsStaffName + "','"
                            + lsPlCode + "','" + lsRead["restime"].ToString() + "','" + lsStatusName + "','" + lsFlagBkk + "','"+lsRead["confirmperson"].ToString()+"',"+ ldoCash + "," + ldoCredit + ")";
                        OleDbCommand accCom2 = new OleDbCommand(lsSQL, acc);
                        accCom2.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        //lsSQL = "";
                        string ls = "มีข้อมูลบางแห่งผิดพลาด รายงานอาจได้ข้อมูลที่ไม่ถูกต้อง " ;
                        lsGdb.WriteLogError(ls, e, lsSQL, "CreateVoucherAcc ");
                        MessageBox.Show(ls + "\n" + " " + e.Message.ToString(), e.Source.ToString(), MessageBoxButtons.OK);
                    }
                }
            }
            lsRead.Close();
            acc.Close();
            acc.Dispose();
            accCom.Dispose();
        }
    }
}
