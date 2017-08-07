using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data.OleDb;
namespace ThaHr30
{
    public partial class ReportCriteria: Form
    {
        public string lsReportName = "";
        IniFile lsIni = new IniFile("thahr30.ini");
        Initial lsIniT = new Initial();
        Connection lsGdb = new Connection();
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
        public ReportCriteria()
        {
            InitializeComponent();
        }
        public Int32 PBMax
        {
            get
            {
                return Pb1 .Maximum;
            }
            set
            {
                Pb1.Maximum = value;
            }
        }
        public Int32 PBMin
        {
            get
            {
                return Pb1.Minimum;
            }
            set
            {
                Pb1.Minimum = value;
            }
        }
        public Boolean PBVisible
        {
            get
            {
                return Pb1.Visible;
            }
            set
            {
                Pb1.Visible = value;
            }
        }
        public Int32 PBValue
        {
            get
            {
                return Pb1.Value ;
            }
            set
            {
                Pb1.Value = value;
                Application.DoEvents();
            }
        }
        private void VisibleFalse()
        {
            lblFrHotel.Visible = false;
            lblToHotel.Visible = false;
            CboFromMember.Visible = false;
            CboToMember.Visible = false;
            Cbo1.Visible = false;
            Cbo2.Visible = false;
            TxtStartDate.Visible = false;
            TxtEndDate.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            CboMonth.Visible = false;
            CboYear.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            ChkSummary.Visible = false;
            GbMonth.Visible = false;
            GbBKK.Visible = false;
            BtnExport.Visible = false;
            Pb1.Visible = false;
            SL1 .Visible = false;
        }
        private void VisibleTrue(string aReportName)
        {
            switch (aReportName)
            {
                case "rptdailypayinrecord": //rptdailypayinrecordpayment
                    {
                        lsGdb.SelectCbo(Cbo1, "report", Connection.TableIniT.Counter);
                        lsGdb.SelectCbo(Cbo2, "", Connection.TableIniT.Shift);
                        label3.Visible = true;
                        label4.Visible = true;
                        Cbo1.Visible = true;
                        Cbo2.Visible = true;
                        label1.Visible = true;
                        label2.Visible = true;
                        TxtStartDate.Visible = true;
                        TxtEndDate.Visible = true;
                        ChkSummary.Visible = true;
                        label3.Text = "Counter :";
                        label4.Text = "Shift :";
                        break;
                    }
                case "rptdailypayinrecordpayment": //rptdailypayinrecordpayment
                    {
                        lsGdb.SelectCbo(Cbo1, "report", Connection.TableIniT.Counter);
                        lsGdb.SelectCbo(Cbo2, "", Connection.TableIniT.Shift);
                        label3.Visible = true;
                        label4.Visible = true;
                        Cbo1.Visible = true;
                        Cbo2.Visible = true;
                        label1.Visible = true;
                        label2.Visible = true;
                        TxtStartDate.Visible = true;
                        TxtEndDate.Visible = true;
                        ChkSummary.Visible = true;
                        label3.Text = "Counter :";
                        label4.Text = "Shift :";
                        break;
                    }
                case "rptdailypayinrecordsu":
                    {
                        lsGdb.SelectCbo(Cbo1, "report", Connection.TableIniT.Counter);
                        lsGdb.SelectCbo(Cbo2, "", Connection.TableIniT.Shift);
                        label3.Visible = true;
                        label4.Visible = true;
                        Cbo1.Visible = true;
                        Cbo2.Visible = true;
                        label1.Visible = true;
                        label2.Visible = true;
                        TxtStartDate.Visible = true;
                        TxtEndDate.Visible = true;
                        ChkSummary.Visible = true;
                        label3.Text = "Counter :";
                        label4.Text = "Shift :";
                        break;
                    }
                case "rptrecordofdeposit":
                    {
                        lsGdb.SelectCbo(Cbo1, "", Connection.TableIniT.Counter);
                        lsGdb.SelectCbo(Cbo2, "", Connection.TableIniT.Shift);
                        label3.Visible = true;
                        label4.Visible = true;
                        Cbo1.Visible = true;
                        Cbo2.Visible = true;
                        label1.Visible = true;
                        label2.Visible = true;
                        TxtStartDate.Visible = true;
                        TxtEndDate.Visible = true;
                        ChkSummary.Visible = true;
                        label3.Text = "Counter :";
                        label4.Text = "Shift :";
                        break;
                    }
                case "rptrecordofdepositkingpower":
                    {
                        lsGdb.SelectCbo(Cbo1, "", Connection.TableIniT.Counter);
                        lsGdb.SelectCbo(Cbo2, "", Connection.TableIniT.Shift);
                        label3.Visible = true;
                        label4.Visible = true;
                        Cbo1.Visible = true;
                        Cbo2.Visible = true;
                        label1.Visible = true;
                        label2.Visible = true;
                        TxtStartDate.Visible = true;
                        TxtEndDate.Visible = true;
                        label3.Text = "Counter :";
                        label4.Text = "Shift :";
                        break;
                    }
                case "rptsalereport":
                    {
                        lsGdb.SelectCbo(Cbo1, "", Connection.TableIniT.Counter);
                        lsGdb.SelectCbo(Cbo2, "", Connection.TableIniT.Shift);
                        label3.Visible = true;
                        label4.Visible = true;
                        Cbo1.Visible = true;
                        Cbo2.Visible = true;
                        label1.Visible = true;
                        label2.Visible = true;
                        TxtStartDate.Visible = true;
                        TxtEndDate.Visible = true;
                        label3.Text = "Counter :";
                        label4.Text = "Shift :";
                        break;
                    }
                case "rptsalereportcounter":
                    {
                        lsGdb.SelectCbo(Cbo1, "", Connection.TableIniT.Counter);
                        lsGdb.SelectCbo(Cbo2, "", Connection.TableIniT.Shift);
                        label3.Visible = true;
                        label4.Visible = true;
                        Cbo1.Visible = true;
                        Cbo2.Visible = true;
                        label1.Visible = true;
                        label2.Visible = true;
                        TxtStartDate.Visible = true;
                        TxtEndDate.Visible = true;
                        label3.Text = "Counter :";
                        label4.Text = "Shift :";
                        break;
                    }
                case "rptmonthlysalereport":
                    {
                        lsGdb.SelectCbo(Cbo1, "", Connection.TableIniT.Counter);
                        lsGdb.SelectCbo(CboMonth, "", Connection.TableIniT.MonthName);
                        lsGdb.SelectCbo(CboYear, "", Connection.TableIniT.YearName);
                        CboYear.Text = Convert.ToString(System.DateTime.Now.Year + 543);
                        CboMonth.SelectedValue = System.DateTime.Now.Month.ToString();
                        CboMonth.Visible = true;
                        CboYear.Visible = true;
                        label5.Visible = true;
                        label6.Visible = true;
                        label5.Top = label1.Top;
                        label6.Top = label2.Top;
                        CboMonth.Top = TxtStartDate.Top;
                        CboYear.Top = TxtEndDate.Top;
                        lblFrHotel.Visible = true;
                        lblToHotel.Visible = true;
                        CboFromMember.Visible = true;
                        CboToMember.Visible = true;
                        lsGdb.SelectCbo(CboFromMember, "", Connection.TableIniT.Member);
                        lsGdb.SelectCbo(CboToMember, "", Connection.TableIniT.Member);
                        label3.Text = "Counter :";
                        break;
                    }
                case "rptmonthlysummarydeposit":
                    {
                        lsGdb.SelectCbo(Cbo1, "", Connection.TableIniT.Counter);
                        lsGdb.SelectCbo(CboMonth, "", Connection.TableIniT.MonthName);
                        lsGdb.SelectCbo(CboYear, "", Connection.TableIniT.YearName);
                        CboYear.Text = Convert.ToString(System.DateTime.Now.Year + 543);
                        CboMonth.SelectedValue = System.DateTime.Now.Month.ToString();
                        GbMonth.Visible = true;
                        GbBKK.Visible = true;
                        CboMonth.Visible = true;
                        CboYear.Visible = true;
                        label5.Visible = true;
                        label6.Visible = true;
                        label5.Top = label1.Top;
                        label6.Top = label2.Top;
                        CboMonth.Top = TxtStartDate.Top;
                        CboYear.Top = TxtEndDate.Top;
                        lblFrHotel.Visible = true;
                        lblToHotel.Visible = true;
                        CboFromMember.Visible = true;
                        CboToMember.Visible = true;
                        lsGdb.SelectCbo(CboFromMember, "", Connection.TableIniT.Member);
                        lsGdb.SelectCbo(CboToMember, "", Connection.TableIniT.Member);
                        label3.Text = "Counter :";
                        break;
                    }
                case "rptdailypayinrecordmanager":
                    {
                        lsGdb.SelectCbo(Cbo1, "report", Connection.TableIniT.Counter);
                        lsGdb.SelectCbo(Cbo2, "", Connection.TableIniT.Shift);
                        label3.Visible = true;
                        label4.Visible = true;
                        Cbo1.Visible = true;
                        Cbo2.Visible = true;
                        label1.Visible = true;
                        label2.Visible = true;
                        TxtStartDate.Visible = true;
                        TxtEndDate.Visible = true;
                        ChkSummary.Visible = true;
                        label3.Text = "Counter :";
                        label4.Text = "Shift :";
                        break;
                    }
                case "rptmemberstatus":
                    {
                        label3.Visible = true;
                        Cbo1.Visible = true;
                        lsGdb.SelectCbo(Cbo1, "", Connection.TableIniT.MemberStatus);
                        label3.Text = "สถานะสมาชิก :";
                        TxtStartDate.Visible = true;
                        TxtEndDate.Visible = true;
                        break;
                    }
            }
        }
        public void CreateMonthlySummaryDeposit(string aStartDate, string aEndDate, string aFrHotal, string aToHotel, string aCounter, string aShift, Boolean aFlagBKK)
        {
            string lsSQL = "";
            Int32 j = 0;
            Pb1.Visible = true;
            SL1.Visible = true;
            if (lsGdb.Gdb.State == System.Data.ConnectionState.Closed)
            {
                lsGdb.ConnectDatabase();
            }
            //lsIniT.CreateTblInitial(lsGdb.Gdb);
            string lsStartDate = "", lsEndDate = "";
            double ldoAmount = 0;
            DateTime ldStartDate = new DateTime();
            DateTime ldEndDate = new DateTime();
            DateTime ldEndDateCheck = new DateTime();
            Int32 liDay = 0,k=0;
            ldStartDate = Convert.ToDateTime(aStartDate);
            lsStartDate = (ldStartDate.Year) + "-" + ldStartDate.Month.ToString("00") + "-01";
            //lsStartDate = lsGdb.SelectDateMySQL(ldStartDate);
            ldEndDate = lsGdb.LastDayofMonth(Convert.ToDateTime(aStartDate));
            lsEndDate = lsGdb.SelectDateMySQL(ldEndDate);
            string lsName = "", lsCode = "", lsDate = "";
            string lsRate15 = lsIni.GetString("kingpower", "ratekingpower", "15.00");
            string lsRate20 = lsIni.GetString("kingpower", "ratekingpowervoucher", "20.00");
            DateTime ldDate = new DateTime();
            string lsAccess = lsIni.GetString("thahr30", "accessdatabase", "0");
            lsSQL = "Delete From rptreport";
            lsGdb.ConnectDatabase();
            OleDbConnection acc = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + lsAccess + ";");
            acc.Open();
            OleDbCommand accCom = new OleDbCommand(lsSQL, acc);
            accCom.ExecuteNonQuery();
            if (aFrHotal != "" && aToHotel != "")
            {
                if (aFlagBKK == true)
                {                    
                        lsSQL = "Select v.hotelcode, m.memnamee1 From voucher v, member m Where v.voudate >= '"
                            + lsStartDate + "' and v.voudate <= '"
                            + lsEndDate + "' and v.flag in ('1','2') and v.hotelcode = m.memid and m.memnamee1 >= '"
                            + aFrHotal + "' and m.memnamee1 <= '" + aToHotel + "' and v.provcode = '100000' Group By v.hotelcode Order By v.hotelcode";
                }
                else
                {                    
                        lsSQL = "Select v.hotelcode, m.memnamee1 From voucher v, member m Where v.voudate >= '"
                            + lsStartDate + "' and v.voudate <= '"
                            + lsEndDate + "' and v.flag in ('1','2') and v.hotelcode = m.memid and m.memnamee1 >= '"
                            + aFrHotal + "' and m.memnamee1 <= '" + aToHotel + "' and v.provcode <> '100000' Group By v.hotelcode Order By v.hotelcode";
                }
            }
            else if (aFrHotal == "" && aToHotel != "")
            {
                if (aFlagBKK == true)
                {
                    lsSQL = "Select v.hotelcode, m.memnamee1 From voucher v, member m Where v.voudate >= '"
                        + lsStartDate + "' and v.voudate <= '"
                        + lsEndDate + "' and v.flag in ('1','2') and v.hotelcode = m.memid and m.memnamee1 <= '" 
                        + aToHotel + "' and v.provcode = '100000' Group By v.hotelcode Order By v.hotelcode";
                }
                else
                {
                    lsSQL = "Select v.hotelcode, m.memnamee1 From voucher v, member m Where v.voudate >= '"
                        + lsStartDate + "' and v.voudate <= '"
                        + lsEndDate + "' and v.flag in ('1','2') and v.hotelcode = m.memid and m.memnamee1 <= '"
                        + aToHotel + "' and v.provcode <> '100000' Group By v.hotelcode Order By v.hotelcode";
                }
            }
            else if (aFrHotal != "" && aToHotel == "")
            {
                if (aFlagBKK == true)
                {
                    lsSQL = "Select v.hotelcode, m.memnamee1 From voucher v, member m Where v.voudate >= '"
                        + lsStartDate + "' and v.voudate <= '"
                        + lsEndDate + "' and v.flag in ('1','2') and v.hotelcode = m.memid and m.memnamee1 >= '" 
                        + aFrHotal + "' and v.provcode = '100000' Group By v.hotelcode Order By v.hotelcode";
                }
                else
                {
                    lsSQL = "Select v.hotelcode, m.memnamee1 From voucher v, member m Where v.voudate >= '"
                        + lsStartDate + "' and v.voudate <= '"
                        + lsEndDate + "' and v.flag in ('1','2') and v.hotelcode = m.memid and m.memnamee1 >= '"
                        + aFrHotal + "' and v.provcode <> '100000' Group By v.hotelcode Order By v.hotelcode";
                }
            }
            else
            {
                if (aFlagBKK == true)
                {                    
                        lsSQL = "Select m.memid as hotelcode, m.memnamee1 From voucher v, member m Where v.voudate >= '"
                        + lsStartDate + "' and v.voudate <= '"
                        + lsEndDate + "' and v.flag in ('1','2') and v.hotelcode = m.memid and m.provcode = '100000' Group By m.memid Order By m.memid";
                    }
                else
                {                    
                        lsSQL = "Select m.memid as hotelcode, m.memnamee1 From voucher v, member m Where  v.voudate >= '"
                        + lsStartDate + "' and v.voudate <= '"
                        + lsEndDate + "' and v.flag in ('1','2') and v.hotelcode = m.memid and m.provcode <> '100000' Group By m.memid Order By m.memid";
                }
            }
            MySqlCommand lsComm = new MySqlCommand(lsSQL, lsGdb.Gdb);
            MySqlDataReader lsRead;
            lsRead = lsComm.ExecuteReader();
            if (lsRead.HasRows)
            {
                while (lsRead.Read())
                {
                    k++;
                    lsName = lsRead["memnamee1"].ToString();
                    lsName = lsName.Replace("'", "''");
                    lsSQL = "Insert Into rptreport(code, name) Values('" + lsRead["hotelcode"].ToString() + "','" + lsName + "')";
                    OleDbCommand accCom2 = new OleDbCommand(lsSQL, acc);
                    accCom2.ExecuteNonQuery();
                }
            }
            lsRead.Close();
            Pb1.Maximum = k;
            Pb1.Minimum = 0;
            lsSQL = "Select code, name From rptreport";
            OleDbCommand lsAccCom1 = new OleDbCommand(lsSQL, acc);
            OleDbCommand accComUpdate = new OleDbCommand(lsSQL, acc);
            OleDbDataReader lsAccRead;
            lsAccRead = lsAccCom1.ExecuteReader();
            ldEndDateCheck = ldEndDate;
            ldEndDate = Convert.ToDateTime(aEndDate);
            if (lsAccRead.HasRows)
            {
                MySqlCommand lsComm1 = new MySqlCommand();
                lsComm1.Connection = lsGdb.Gdb;
                MySqlDataReader lsRead1;
                while (lsAccRead.Read())
                {
                    try
                    {
                        j++;
                        liDay = ldStartDate.Day;
                        ldDate = ldStartDate.AddDays(-1);
                        Pb1.Value = j;
                        //Application.DoEvents();
                        for (Int32 i = liDay; i <= ldEndDate.Day; i++)
                        {
                            ldDate = ldDate.AddDays(1);
                            lsDate = lsGdb.SelectDateMySQL(ldDate);
                            lsCode = lsAccRead["code"].ToString();
                            lsName = lsAccRead["name"].ToString();
                            SL1.Text = lsCode + " " + ldDate.ToShortDateString();
                            Application.DoEvents();
                            lsSQL = "Select sum(ifnull(roomrate1,0)) as sumdeposit From voucher Where flag in ('1','2') and voudate = '" + lsDate + "' and hotelcode = '" + lsCode + "'";
                            lsComm1.CommandText = lsSQL;
                            lsRead1 = lsComm1.ExecuteReader();
                            if (lsRead1.HasRows)
                            {
                                while (lsRead1.Read())
                                {
                                    lsSQL = lsRead1["sumdeposit"].ToString();
                                    if (lsRead1["sumdeposit"].ToString() == "")
                                    {
                                        ldoAmount = 0;
                                    }
                                    else
                                    {
                                        ldoAmount = lsRead1.GetDouble("sumdeposit");
                                        //ldoAmount = ldoAmount * (Convert.ToDouble(lsRate15) / 100) * (Convert.ToDouble(lsRate20) / 100);

                                    }
                                    lsSQL = "Update rptreport Set " + i.ToString("00") + " = " + ldoAmount + " Where code = '" + lsCode + "'";
                                    accComUpdate.CommandText = lsSQL;
                                    accComUpdate.ExecuteNonQuery();
                                }
                            }
                            lsRead1.Close();
                        }
                        Application.DoEvents();
                    }
                    catch (Exception e)
                    {
                        string ls = "มีข้อมูลบางแห่งผิดพลาด รายงานอาจได้ข้อมูลที่ไม่ถูกต้อง ";
                        lsGdb.WriteLogError(ls, e, lsSQL, "CreateMonthlySummaryDeposit ");
                        MessageBox.Show(ls + "\n" + " " + e.Message.ToString(), e.Source.ToString(), MessageBoxButtons.OK);
                    }
                }
            }
            lsAccRead.Close();
            if (Chk23.Checked == true)
            {
                lsSQL = "Select code, name From rptreport";
                lsAccCom1.CommandText = lsSQL;
                lsAccRead = lsAccCom1.ExecuteReader();
                if (lsAccRead.HasRows)
                {
                    j = 0;
                    lsStartDate = lsStartDate.Substring (0,lsStartDate.Length-2) + "01";
                    ldEndDate = lsGdb.LastDayofMonth(Convert.ToDateTime(aStartDate));
                    lsEndDate = lsGdb.SelectDateMySQL(ldEndDate);
                    while (lsAccRead.Read())
                    {
                        lsCode = lsAccRead["code"].ToString();
                        lsSQL = "Select sum(ifnull(roomrate1,0)) as sumdeposit From voucher "
                            + "Where flag in ('1','2') and voudate >= '" + lsStartDate + "' and voudate <= '"
                            + lsEndDate + "' and hotelcode = '" + lsCode + "'";
                        lsComm.CommandText = lsSQL;
                        lsRead = lsComm.ExecuteReader();
                        if (lsRead.HasRows)
                        {
                            while (lsRead.Read())
                            {
                                lsSQL = lsRead["sumdeposit"].ToString();
                                if (lsRead["sumdeposit"].ToString() == "")
                                {
                                    ldoAmount = 0;
                                }
                                else
                                {
                                    ldoAmount = lsRead.GetDouble("sumdeposit");
                                    //ldoAmount = ldoAmount * (Convert.ToDouble(lsRate15) / 100) * (Convert.ToDouble(lsRate20) / 100);
                                }
                                lsSQL = "Update rptreport Set 01 = " + ldoAmount + " Where code = '" + lsCode + "'";
                                accComUpdate.CommandText = lsSQL;
                                accComUpdate.ExecuteNonQuery();
                            }
                        }
                        j++;
                        Pb1.Value = j;
                        lsRead.Close();
                    }
                }
                lsAccRead.Close();
            }
            acc.Close();
            acc.Dispose();
            Pb1.Visible = false;
            SL1.Visible = false;
        }
        private void ReportCriteria_Load(object sender, EventArgs e)
        {
            //Pb1.Visible = false;
            //lsGdb.ConnectDatabase();
            if (lsGdb.Gdb.State == ConnectionState.Closed)
            {
                lsGdb.ConnectDatabase();
            }
            VisibleFalse();
            VisibleTrue(lsReportName);
            
        }
        private void BtnOK_Click(object sender, EventArgs e)
        {
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Cursor.Show();
            //lsGdb.ConnectDatabase();
            string lsStartDate = "", lsEndDate = "";
            switch (lsReportName)
            {
                case "rptmonthlysalereport":
                    {
                        Int32 li = Convert.ToInt32(CboMonth.SelectedValue);
                        DateTime ld = new DateTime();
                        lsStartDate = CboYear.Text + "-" + li.ToString("00") + "-01";
                        ld = lsGdb.LastDayofMonth(Convert.ToDateTime(lsStartDate));
                        lsEndDate = lsGdb.SelectDateMySQL(ld);
                        lsStartDate = (Convert.ToInt16(CboYear.Text) -543) + "-" + li.ToString("00") + "-01";
                        break;
                    }
                case "rptmonthlysummarydeposit":
                    {
                        Int32 li = Convert.ToInt32(CboMonth.SelectedValue);
                        DateTime ld = new DateTime();
                        //lsStartDate = CboYear.Text + "-" + li.ToString("00") + "-01";
                        lsStartDate = "01/" + li.ToString("00") + "/" + CboYear.Text;
                        ld = lsGdb.LastDayofMonth(Convert.ToDateTime(lsStartDate));
                        //lsEndDate = lsGdb.SelectDateMySQL(ld);
                        lsEndDate = lsGdb.SelectDateBudda(ld);
                        //lsStartDate = (Convert.ToInt16(CboYear.Text)-543) + "-" + li.ToString("00") + "-01";
                        break;
                    }
                case "rptmemberstatus":
                    {
                        lsStartDate = lsGdb.SelectDateMySQL(TxtStartDate.Value);
                        lsEndDate = lsGdb.SelectDateMySQL(TxtEndDate.Value);
                        break;
                    }
                default:
                    {
                        lsStartDate = lsGdb.SelectDateMySQL(TxtStartDate.Value);
                        lsEndDate = lsGdb.SelectDateMySQL(TxtEndDate.Value);
                        break;
                    }
            }
            //lsFromMember = CboFromMember.SelectedValue.ToString();
            //lsToMember = CboToMember.SelectedValue.ToString(); 
            Report lsRpt = new Report();
            lsRpt.Connnection = lsGdb.Gdb;
            switch (lsReportName)
            {
                case "rptmonthlysummarydeposit":
                    {
                        string lsEndDate1 = "";
                        DateTime ldEndDate;
                        if (Chk0111.Checked)
                        {
                            lsEndDate = "11" + lsEndDate.Substring(2);
                        }
                        else if (Chk1222.Checked)
                        {
                            lsStartDate = "12" + lsStartDate.Substring(2);
                            lsEndDate = "22" + lsEndDate.Substring(2);
                        }
                        else
                        {
                            ldEndDate = lsGdb.LastDayofMonth(Convert.ToDateTime(lsStartDate));
                            lsStartDate = "23" + lsStartDate.Substring(2);
                            lsEndDate = ldEndDate.Day.ToString("00") + "/" + ldEndDate.Month.ToString("00") + "/" + (ldEndDate.Year+ 543);
                        }
                        CreateMonthlySummaryDeposit(lsStartDate,lsEndDate,CboFromMember.Text,CboToMember.Text,Cbo1.Text,Cbo2.Text,ChkBKK.Checked);
                        break;
                    }
                case "rptmemberstatus":
                    {
                        lsRpt.CreateStatusMember(lsStartDate, lsEndDate, "1");
                        break;
                    }
                default:
                    {
                        lsRpt.CreateVoucherAcc(lsReportName, lsStartDate, lsEndDate, CboFromMember.Text, CboToMember.Text, Cbo1.Text, Cbo2.Text, true);
                        break;
                    }
            }
            Cursor.Current = System.Windows.Forms.Cursors.Default;
            Cursor.Show();
            ReportView frm = new ReportView();
            if (lsReportName != "rptmonthlysummarydeposit")
            {
                frm.HLine1 = lsIni.GetString("thahr30", "companyname", "Thai Hotels ");
                frm.HLine2 = lsIni.GetString("report", lsReportName, "DAILY SUMMARY DEPOSIT REPORT ");
                frm.HLine3 = "For date : " + TxtStartDate.Value.ToShortDateString() + " to " + TxtEndDate.Value.ToShortDateString();

            }
            
            switch (lsReportName)
            {
                case "rptdailypayinrecordpayment":
                    {
                        frm.HLine1 = lsIni.GetString("thahr30", "companyname", "Thai Hotels ");
                        frm.HLine2 = lsIni.GetString("report", lsReportName, "- ");
                        frm.lsReportName = lsReportName;
                        break;
                    }
                case "rptdailypayinrecordsu":
                    {
                        frm.HLeft2 = "From : " + Cbo1.Text;
                        frm.lsReportName = lsReportName;
                        break;
                    }
                case "rptmonthlysalereport":
                    {
                        frm.HLine3 = "For the month of : " + CboMonth.Text + " " + (Convert.ToInt16(CboYear.Text) -543);
                        frm.lsReportName = lsReportName;
                        break;
                    }
                case "rptmonthlysummarydeposit":
                    {
                        string lsBKK = "";
                        if (ChkBKK.Checked == true)
                        {
                            lsBKK = "[hotel in bangkok]";
                        }
                        else
                        {
                            lsBKK = "[hotel out of bangkok]";
                        }
                        frm.HLine3 = "For the month of : " + CboMonth.Text + " " + (Convert.ToInt16(CboYear.Text) - 543) + " " + lsBKK;
                        if (Chk0111.Checked)
                        {
                            frm.lsReportName = lsReportName + "01_11";
                        }
                        else if (Chk1222.Checked)
                        {
                            frm.lsReportName = lsReportName + "12_22";
                        }
                        else
                        {
                            frm.lsReportName = lsReportName + "23_31";
                        }
                        break;
                    }
                case "":
                    {
                        frm.HLine3 = Cbo1.Text;
                        break;
                    }
                default:
                    {
                        if (ChkSummary.Checked)
                        {
                            frm.lsReportName = lsReportName + "summary";
                        }
                        else
                        {
                            frm.lsReportName = lsReportName;
                        }
                        break;
                    }
            }
            frm.Show(this);
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            ReportDocument RptExport = new ReportDocument();
            string reportPath = Application.StartupPath + "\\RptRecordofDeposit.rpt";
            RptExport.Load(reportPath);
            RptExport.ExportToDisk(ExportFormatType.PortableDocFormat, "d:\\thahr30\\aaaa.pdf");
        }

        private void ChkBKK_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}