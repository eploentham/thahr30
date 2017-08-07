using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data.OleDb;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Windows.Forms;
namespace ThaHr30
{
    public partial class VoucherAdd : Form
    {
        Connection lsGdb = new Connection();
        IniFile lsIni = new IniFile("thahr30.ini");
        public string lsVouNO = "", lsCounter="", lsMac="", lsFlagPrintVoucheronScreen="", lsVoucherFileName="";
        public string lsAccess = "", lsServerDatabaseName = "", lsDatabaseName="", lsFlag="";
        decimal ldoPriceEnd = 0;
        private Boolean lbPageLoad = false;
        private string lsSQL = "";
        VoucherFlag leFlag;
        Voucher lstblVou = new Voucher();
        enum VoucherFlag
        {
            Using=1, Cancel=3
        }
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
        public VoucherAdd()
        {
            InitializeComponent();
        }
        private void SelectResTime()
        {
            string lsTime = "";
            //if 
            lsTime = TxtResTime.Text.ToString().Substring(0, 2);
            switch (lsTime)
            {
                case "01":
                    {
                        CboShift.SelectedValue = "03";
                        break;
                    }
                case "02":
                    {
                        CboShift.SelectedValue = "03";
                        break;
                    }
                case "03":
                    {
                        CboShift.SelectedValue = "03"; 
                        break;
                    }
                case "04":
                    {
                        CboShift.SelectedValue = "03";
                        break;
                    }
                case "05":
                    {
                        CboShift.SelectedValue = "01";
                        break;
                    }
                case "06":
                    {
                        CboShift.SelectedValue = "03";
                        break;
                    }
                case "07":
                    {
                        CboShift.SelectedValue = "01";
                        break;
                    }
                case "08":
                    {
                        CboShift.SelectedValue = "01";
                        break;
                    }
                case "09":
                    {
                        CboShift.SelectedValue = "01";
                        break;
                    }
                case "10":
                    {
                        CboShift.SelectedValue = "01";
                        break;
                    }
                case "11":
                    {
                        CboShift.SelectedValue = "01";
                        break;
                    }
                case "12":
                    {
                        CboShift.SelectedValue = "01";
                        break;
                    }
                case "13":
                    {
                        CboShift.SelectedValue = "01";
                        break;
                    }
                case "14":
                    {
                        CboShift.SelectedValue = "02";
                        break;
                    }
                case "15":
                    {
                        CboShift.SelectedValue = "02";
                        break;
                    }
                case "16":
                    {
                        CboShift.SelectedValue = "02";
                        break;
                    }
                case "17":
                    {
                        CboShift.SelectedValue = "02";
                        break;
                    }
                case "18":
                    {
                        CboShift.SelectedValue = "02";
                        break;
                    }
                case "19":
                    {
                        CboShift.SelectedValue = "03";
                        break;
                    }
                case "20":
                    {
                        CboShift.SelectedValue = "03";
                        break;
                    }
                case "21":
                    {
                        CboShift.SelectedValue = "03";
                        break;
                    }
                case "22":
                    {
                        CboShift.SelectedValue = "03";
                        break;
                    }
                case "23":
                    {
                        CboShift.SelectedValue = "03";
                        break;
                    }
                default:
                    {
                        CboShift.SelectedValue = "01";
                        break;
                    }
            }
        }
        private void SelectMemberPriceList(string aMemID, string aPlCode)
        {
            string lsSQL = "Select p.plcode, p.priceend, m.typevat, m.deposit, p.pricestart, m.typepricebaht,p.deposit as depositamt From member m, memberpricelist p " 
                + "Where m.memid = '" + aMemID + "' and p.plcode = '" + aPlCode + "' and m.memid = p.memid";
            MySqlCommand Comm = new MySqlCommand(lsSQL, lsGdb.Gdb);
            MySqlDataReader lsRead;
            lsRead = Comm.ExecuteReader();
            if (lsRead.HasRows)
            {
                while (lsRead.Read())
                {
                    TxtPLID.Text = aMemID + lsRead["plcode"].ToString();
                    if (lsRead["typevat"].ToString()=="1")
                    {
                        CboStatus.SelectedValue = "-";
                        ChkInVat.Checked = true ;
                        ChkExVat.Checked = false;
                        TxtRoomRate.Value = Convert.ToDecimal(lsRead["priceend"]);
                        TxtRoomRate1.Value = Convert.ToDecimal(lsRead["pricestart"]);
                        TxtDepositAMT.Value = Convert.ToDecimal(lsRead["depositamt"]);
                        TxtPriceStart.Text = lsRead["pricestart"].ToString();
                        TxtPriceEnd.Text = lsRead["priceend"].ToString();
                        ldoPriceEnd = Convert.ToDecimal(lsRead["priceend"]);
                    }
                    else
                    {
                        ChkExVat.Checked = true;
                        ChkInVat.Checked = false;
                    }
                }
            }
            lsRead.Close();
        }
        private void SelectVoucher(string aVouNO)
        {
            try
            {
                lbPageLoad = true;
                string lsSQL = "", lsRoomCode = "";
                Int32 i = 0;
                //MySqlConnection Conn = new MySqlConnection("Data Source=" + lsServerDatabaseName + ";Database=" + lsDatabaseName + ";User ID=root;Password=Ekartc2c5");
                //Conn.Open();
                lsSQL = "Select * From voucher Where vouno = '" + aVouNO + "'";
                MySqlCommand Comm = new MySqlCommand(lsSQL, lsGdb.Gdb);
                MySqlDataReader lsRead;
                lsRead = Comm.ExecuteReader();
                i = 0;
                while (lsRead.Read())
                {
                    i++;
                    TxtVouNO.Text = lsRead["vouno"].ToString();
                    TxtFirstName.Text = lsRead["guestfirstname"].ToString();
                    TxtLastName.Text = lsRead["guestlastname"].ToString();
                    CboNation.SelectedValue = lsRead["nationcode"].ToString();
                    TxtResRoom.Value = Convert.ToInt32(lsRead["resrooms"]);
                    TxtVisitT.Value = Convert.ToInt32(lsRead["visitt"]);
                    TxtPersonTrip.Value = Convert.ToInt32(lsRead["personintrip"]);
                    TxtCheckInDate.Text = lsGdb.SelectDate(Convert.ToDateTime(lsRead["checkindate"].ToString()), Connection.FlagDate .DateShow , lsIni);
                    TxtCheckOutDate.Text = lsGdb.SelectDate(Convert.ToDateTime(lsRead["checkoutdate"].ToString()), Connection.FlagDate .DateShow , lsIni);
                    TxtVouDate.Text = lsGdb.SelectDate(Convert.ToDateTime(lsRead["voudate"].ToString()), Connection.FlagDate .DateShow , lsIni);
                    TxtDepositAMT.Value = Convert.ToDecimal(lsRead["depositamt"]);
                    TxtRoomRate.Value = Convert.ToDecimal(lsRead["roomrate"]);
                    TxtRoomRate1.Value = Convert.ToDecimal(lsRead["roomrate1"]);
                    CboStaff.SelectedValue = lsRead["staffcode"].ToString();
                    CboStatus.SelectedValue = lsRead["statuscode"].ToString();
                    CboProv.SelectedValue = lsRead["provcode"].ToString();
                    CboHotel.SelectedValue = lsRead["hotelcode"].ToString();
                    lsRoomCode = lsRead["roomcode"].ToString();
                    CboShift.SelectedValue = lsRead["shiftcode"].ToString().Trim();
                    //lsSQL = lsRead.GetValue(1).ToString();
                    CboPrefix.SelectedValue = lsRead["prefix"].ToString();
                    TxtRemark.Text = lsRead["remark"].ToString();
                    TxtResTime.Text = lsRead["restime"].ToString();
                    TxtRoomNO.Text = lsRead["roomno"].ToString();
                    TxtConfirmedBy.Text = lsRead["confirmperson"].ToString();
                    //lsFlag = lsRead["flag"].ToString();
                    TxtRoomRate1.Value = Convert.ToDecimal(lsRead["roomrate1"].ToString());
                    TxtPLID.Text = lsRead["memplcode"].ToString();
                    CboRoomCode.SelectedValue = lsRead["roomcode"].ToString();
                    CboTypePayment.SelectedValue = lsRead["pay_type"].ToString();
                    ldoPriceEnd = Convert.ToDecimal(lsRead["priceend"]);
                    //TxtPriceStart.Text = lsRead["pricestart"].ToString();
                    TxtPriceEnd.Text = lsRead["priceend"].ToString();
                    TxtCounter.Text = lsRead["counter1"].ToString();
                    TxtMac.Text = lsRead["mac"].ToString();
                    if (lsRead["breakfast"].ToString() == "1")
                    {
                        ChkBreakfast.Checked = true;
                    }
                    else
                    {
                        ChkBreakfast.Checked = false;
                    }
                    if (lsRead["taxi"].ToString() == "1")
                    {
                        ChkTaxi.Checked = true;
                    }
                    else
                    {
                        ChkTaxi.Checked = false;
                    }
                    FlagVoucher(lsRead["flag"].ToString());
                }
                lsRead.Close();
                if (CboHotel.SelectedValue != null)
                {
                    lsGdb.SelectCbo(CboRoomCode, CboHotel.SelectedValue.ToString(), Connection.TableIniT.TypeRoom);
                }
                CboRoomCode.SelectedValue = lsRoomCode;
                lbPageLoad = false;
            }
            //catch (Exception e)
            //{
            //    lsSQL = "";
            //    string ls = "ไม่สามารถดึงข้อมูลได้ " + lsSQL;
            //    lsGdb.WriteLogError(ls, e, lsSQL);
            //    MessageBox.Show(ls + " " + e.Message.ToString(), e.Source.ToString(), MessageBoxButtons.OK);
            //}
            catch (MySqlException eMySql)
            {
                string ls = "ไม่สามารถดึงข้อมูลได้ " + lsSQL;
                lsGdb.WriteLogError(ls, eMySql, lsSQL, "SelectVoucher ");
                MessageBox.Show(ls + " " + eMySql.Message.ToString(), eMySql.Source.ToString(), MessageBoxButtons.OK);
            }
        }
        private void FlagVoucher(string aFlag)
        {
            switch (aFlag)
            {
                case "0":
                    {
                        label38.Text = "Status Voucher : New";
                        leFlag = VoucherFlag.Using;
                        cancelvoid.Enabled = false;
                        cancelnoshow.Enabled = false;
                        cancelreturn.Enabled = false;
                        break;
                    }
                case "1":
                    {
                        label38.Text = "Status Voucher : Using";
                        leFlag = VoucherFlag.Using;
                        cancelvoid.Enabled = false;
                        cancelnoshow.Enabled = false;
                        cancelreturn.Enabled = false;
                        break;
                    }
                case "3":
                    {
                        label38.Text = "Status Voucher : Cancel";
                        voidvoucher.Enabled = false;
                        cancelvoid.Enabled = true;
                        noshow.Enabled = false;
                        cancelnoshow.Enabled = false;
                        leFlag = VoucherFlag.Cancel;
                        break;
                    }
                case "5":
                    {
                        label38.Text = "Status Voucher : Return";
                        returnvoucher.Enabled = false;
                        cancelreturn.Enabled = true;
                        break;
                    }
                case "4":
                    {
                        label38.Text = "Status Voucher : No Show";
                        noshow.Enabled = false;
                        cancelnoshow.Enabled = true;
                        voidvoucher.Enabled = true;
                        cancelvoid.Enabled = false;
                        break;
                    }
                case "2":
                    {
                        label38.Text = "Status Voucher : Using(C)";
                        cancelvoid.Enabled = false;
                        cancelnoshow.Enabled = false;
                        cancelreturn.Enabled = false;
                        break;
                    }
            }
        }
        private void PrintGenVoucher(string aVoucher)
        {
            string lsFullName = "", lsHotelName = "", lsCity = "", lsNation = "", lsDetail = "";
            string lsVouDate = "";
            double ldoDeposit = 0;
            OleDbConnection acc = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + lsAccess + ";");
            lsSQL = "Delete From rptvoucher";
            acc.Open();
            OleDbCommand accCom = new OleDbCommand(lsSQL, acc);
            accCom.ExecuteNonQuery();
            //acc.Close(); Application.DoEvents();
            //acc.Open();
            lsFullName = "Guest Name : " + CboPrefix.Text + " " + TxtLastName.Text + " " + TxtFirstName.Text;
            if (lsFullName.Contains("'"))
            {
                lsFullName = lsFullName.Replace("'", "''");
            }
            lsHotelName = "Hotel : " + CboHotel.Text;
            if (lsHotelName.Contains("'"))
            {
                lsHotelName = lsHotelName.Replace("'", "''");
            }
            lsCity = "City : " + CboProv.Text;
            lsNation = "Nationality : " + CboNation.Text;
            lsDetail = CboRoomCode.Text;
            if (ChkTaxi.Checked)
            {
                lsDetail = lsDetail + " Taxi ";
            }
            if (ChkBreakfast.Checked)
            {
                lsDetail = lsDetail + " + Breakfast";
            }
            ldoDeposit = Convert .ToDouble ( TxtDepositAMT.Value);
            //lsDeposit = TxtDepositAMT.Value.ToString();
            //if (lsDeposit.Length >= 3)
            //{
            //    lsDeposit=lsDeposit.Substring(lsDeposit.Length - 3, 3);
            //    if (lsDeposit == ".00")
            //    {
            //        lsDeposit = TxtDepositAMT.Value.ToString().Substring(0, TxtDepositAMT.Value.ToString().Length - 4);
            //    }
            //}
            //else
            //{
            //    lsDeposit = "0";
            //}
            lsVouDate = aVoucher + " " + TxtResTime.Text;
            lsSQL = "Insert Into rptvoucher(vouno, voudate, fullname, checkin, "
                + "checkout, deposit, hotelname, nationality, "
                + "city, person, days, rate1, detail, roomrate, confirmby, remark) "
                + "Values('" + aVoucher + "','" + lsVouDate + "','" + lsFullName + "','" + TxtCheckInDate.Text + "','"
                + TxtCheckOutDate.Text + "','" + TxtDepositAMT.Value + "','" + lsHotelName + "','" + lsNation + "','"
                + lsCity + "','" + TxtPersonTrip.Value.ToString() + "','" + TxtVisitT.Value.ToString() + "'," + TxtRoomRate1.Value.ToString() + ",'" + lsDetail + "'," + TxtRoomRate.Value.ToString() + ",'" + TxtConfirmedBy.Text + "','" + TxtRemark.Text + "')";
            OleDbCommand accCom2 = new OleDbCommand(lsSQL, acc);
            accCom2.ExecuteNonQuery();
            Application.DoEvents();
            //PrintVoucher();
        }
        private void PrintVoucher(string aVoucher)
        {
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Cursor.Show();
            PrintGenVoucher(aVoucher);
            if (lsFlagPrintVoucheronScreen == "0")
            {
                PrintHide(aVoucher);
            }
            else
            {
                PrintShow();
            }
            Cursor.Current = System.Windows.Forms.Cursors.Default;
            Cursor.Show();
        }
        private void PrintShow()
        {
            ReportView frmRpt = new ReportView();
            frmRpt.lsReportName = "rptvoucher";
            frmRpt.Show(this);
        }
        private void PrintHide(string aVoucher)
        {
            string lsFileName = Application.StartupPath + "\\rptvoucher.rpt";
            CrystalReportViewer Rpt = new CrystalReportViewer();
            ReportDocument RptExport = new ReportDocument();
            string lsDetail = CboRoomCode.Text;
            string lsRate1 = "", lsRoomRate="", lsLabelRate="";
            decimal ldoRate = 0;
            if (ChkTypePriceBaht.Checked == true)
            {
                lsLabelRate = "Rate";
                lsRate1 = TxtRoomRate1.Value.ToString();
                lsRoomRate = TxtRoomRate.Value.ToString();
            }
            else
            {
                ldoRate = TxtRoomRate1.Value * TxtCurrentRate.Value;
                lsLabelRate = "Rate(US$)";
                lsRate1 = TxtRoomRate1.Value.ToString("###,###,###.00") + " * " + TxtCurrentRate.Value.ToString("###,###,###.00") + " = " + 
                    ldoRate.ToString("###,###,###.00");
                ldoRate = TxtRoomRate.Value * TxtCurrentRate.Value;
                lsRoomRate = TxtRoomRate.Value.ToString("###,###,###.00") + " * " + TxtCurrentRate.Value.ToString("###,###,###.00") + " = " +
                    ldoRate.ToString("###,###,###.00");
            }
            if (ChkTaxi.Checked)
            {
                lsDetail = lsDetail + " Taxi ";
            }
            if (ChkBreakfast.Checked)
            {
                lsDetail = lsDetail + " + Breakfast";
            }
            if (ChkExtraBed.Checked)
            {
                lsDetail = lsDetail + " + Extra Bed " + TxtExtraBedAmount.Value.ToString();
            }
            RptExport.Load(lsFileName);
            RptExport.DataDefinition.FormulaFields["voucherno"].Text = "\"" + "Voucher NO : " + aVoucher + "\"";
            RptExport.DataDefinition.FormulaFields["voucherdate"].Text = "\"" + "Voucher Date : " + TxtVouDate.Text + "\"";
            RptExport.DataDefinition.FormulaFields["fullname"].Text = "\"" + "Guest Name : " + CboPrefix.Text + " " + TxtLastName.Text + " " + TxtFirstName.Text + "\"";
            RptExport.DataDefinition.FormulaFields["hotelname"].Text = "\"" + "Hotel Name : " + CboHotel.Text + "\"";
            RptExport.DataDefinition.FormulaFields["nationality"].Text = "\"" + "Nationality : " + CboNation.Text + "\"";
            RptExport.DataDefinition.FormulaFields["detail"].Text = "\"" + lsDetail + "\"";
            RptExport.DataDefinition.FormulaFields["labeldeposit"].Text = "\"" + "Deposit Baht : " + TxtDepositAMT.Value.ToString("###,###,###.00") + "\"";
            RptExport.DataDefinition.FormulaFields["days"].Text = "\"" + TxtVisitT.Value.ToString() + "\"";
            RptExport.DataDefinition.FormulaFields["person"].Text = "\"" +TxtPersonTrip.Value.ToString() + "\"";
            RptExport.DataDefinition.FormulaFields["checkin"].Text = "\"" + TxtCheckInDate.Text + "\"";
            RptExport.DataDefinition.FormulaFields["checkout"].Text = "\"" + TxtCheckOutDate.Text + "\"";
            RptExport.DataDefinition.FormulaFields["rate1"].Text = "\"" + lsRate1 + "\"";
            RptExport.DataDefinition.FormulaFields["roomrate"].Text = "\"" + lsRoomRate + "\"";
            RptExport.DataDefinition.FormulaFields["labelrate"].Text = "\"" + lsLabelRate + "\"";
            RptExport.Load(lsFileName);
            RptExport.PrintToPrinter(1, true, 1, 1);
            RptExport.ExportToDisk(ExportFormatType.Excel, Application.StartupPath + "\\aaaa.xls");
            RptExport.Dispose();
            Rpt.Dispose();
        }
        private string SaveVoucher()
        {
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Cursor.Show();
            string lsReturn = "";
            string lsVoucher = "";
            try
            {
                if (TxtFirstName.Text == "")
                {
                    MessageBox.Show("Please fill Guest First Name", "", MessageBoxButtons.OK);
                    return lsReturn;
                }
                if (TxtLastName.Text == "")
                {
                    MessageBox.Show("Please fill Guest Last Name", "", MessageBoxButtons.OK);
                    return lsReturn;
                }
                if (CboHotel.Text == "")
                {
                    MessageBox.Show("Please select Hotel", "", MessageBoxButtons.OK);
                    return lsReturn;
                }
                if (CboRoomCode.Text == "")
                {
                    MessageBox.Show("Please select Room Type", "", MessageBoxButtons.OK);
                    return lsReturn;
                }
                if (CboStaff.Text == "")
                {
                    MessageBox.Show("Please select Staff", "", MessageBoxButtons.OK);
                    return lsReturn;
                }
                if (CboStatus.Text == "")
                {
                    MessageBox.Show("Please select status", "", MessageBoxButtons.OK);
                    return lsReturn;
                }
                if (CboProv.Text == "")
                {
                    MessageBox.Show("Please select province", "", MessageBoxButtons.OK);
                    return lsReturn;
                }
                if (CboTypePayment.Text == "")
                {
                    MessageBox.Show("Please select Type payment", "", MessageBoxButtons.OK);
                    return lsReturn;
                }
                
                lstblVou.TableName = "voucher";
                lstblVou.HostName = "local";
                lstblVou.Pay_Type = CboTypePayment.SelectedValue.ToString();
                lstblVou.VouDate = Convert.ToDateTime(TxtVouDate.Text);
                lstblVou.VouNO = TxtVouNO.Text;
                lstblVou.GuestFirstName = TxtFirstName.Text;
                lstblVou.GuestLastName = TxtLastName.Text;
                lstblVou.ResRooms = Convert.ToInt32(TxtResRoom.Value);
                lstblVou.CreaditCardID = TxtCreditCard.Text;
                if (CboProv.SelectedValue != null)
                {
                    lstblVou.ProvCode = CboProv.SelectedValue.ToString();
                }
                else
                {
                    lstblVou.ProvCode = "-";
                }
                if (CboHotel.SelectedValue != null)
                {
                    lstblVou.HotelCode = CboHotel.SelectedValue.ToString();
                }
                else
                {
                    lstblVou.HotelCode = "-";
                }
                if (CboRoomCode.SelectedValue != null)
                {
                    lstblVou.RoomCode = CboRoomCode.SelectedValue.ToString();
                }
                else
                {
                    lstblVou.RoomCode = "-";
                }
                lstblVou.ResTime = TxtResTime.Text;
                if (CboShift.SelectedValue != null)
                {
                    lstblVou.ShiftCode = CboShift.SelectedValue.ToString();
                }
                else
                {
                    lstblVou.ShiftCode = "-";
                }
                //lstblVou.CheckOutTime = aaaa;
                lstblVou.CheckInTime = Convert.ToDateTime(TxtCheckInDate.Text);
                lstblVou.CheckOutTime = Convert.ToDateTime(TxtCheckOutDate.Text);
                lstblVou.DepositAMT = Convert.ToInt32(TxtDepositAMT.Value);
                lstblVou.RoomRate = Convert.ToInt32(TxtRoomRate.Text);
                lstblVou.VisitT = Convert.ToInt32(TxtVisitT.Value);
                if (CboStaff.SelectedValue != null)
                {
                    lstblVou.StaffCode = CboStaff.SelectedValue.ToString();
                }
                else
                {
                    lstblVou.StaffCode = "-";
                }
                if (CboStatus.SelectedValue != null)
                {
                    lstblVou.StatusCode = CboStatus.SelectedValue.ToString();
                }
                else
                {
                    lstblVou.StatusCode = "-";
                }
                lstblVou.ConfirmPerson = "-";
                lstblVou.Remark = TxtRemark.Text;
                lstblVou.RoomNO = TxtRoomNO.Text;
                lstblVou.NationCode = CboNation.SelectedValue.ToString();
                if (CboNation.SelectedValue != null)
                {
                    lstblVou.NationCode = CboNation.SelectedValue.ToString();
                }
                else
                {
                    lstblVou.NationCode = "-";
                }
                if (CboPrefix.SelectedValue != null)
                {
                    lstblVou.PreFix = Convert.ToInt32(CboPrefix.SelectedValue);
                }
                else
                {
                    lstblVou.PreFix = 2;
                }
                lstblVou.MAC = TxtMac.Text;
                lstblVou.Counter1 = TxtCounter.Text;
                lstblVou.PersoninTrip = Convert.ToInt32(TxtPersonTrip.Value);
                lstblVou.TableName = "voucher";
                lstblVou.RoomNO = TxtRoomNO.Text;
                lstblVou.RoomRate1 = TxtRoomRate1.Value;
                lstblVou.ConfirmPerson = TxtConfirmedBy.Text;
                lstblVou.MemPlCode = TxtPLID.Text;
                lstblVou.PriceEnd = ldoPriceEnd;
                lstblVou.Taxi = ChkTaxi.Checked.ToString();
                lstblVou.Breakfast = ChkBreakfast.Checked.ToString();
                lstblVou.Flag = Convert.ToString(leFlag);
                lsVoucher = lstblVou.CreateVoucher(lsGdb.Gdb);
                lsReturn = lsVoucher;
            }
            catch (Exception e)
            {
                lsSQL = "";
                string ls = "ไม่สามารถบันทึกข้อมูลได้ " + lsSQL;
                lsGdb.WriteLogError(ls, e, lsSQL, "SaveVoucher ");
                MessageBox.Show(ls + " " + e.Message.ToString(), e.Source.ToString(), MessageBoxButtons.OK);
            }
            Cursor.Current = System.Windows.Forms.Cursors.Default;
            Cursor.Show();
            return lsReturn;
        }
        private void CheckExtraBed()
        {
            if (ChkExtraBed.Checked == true)
            {
                TxtExtraBedAmount.Visible = true;
            }
            else
            {
                TxtExtraBedAmount.Visible = false;
            }
        }
        private void CheckTypePriceBaht()
        {
            if (ChkTypePriceBaht.Checked == true)
            {
                label36.Visible = false;
                TxtCurrentRate.Visible = false;
            }
            else
            {
                label36.Visible = true;
                TxtCurrentRate.Visible = true;
            }
        }
        private void VoucherAdd_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSetThaHr3.nationality' table. You can move, or remove it, as needed.
            lbPageLoad = true;
            //lsGdb.ConnectDatabase();
            if (lsGdb.Gdb.State == ConnectionState.Closed)
            {
                lsGdb.ConnectDatabase();
            }
            lsGdb.SelectCbo(CboNation, "", Connection.TableIniT.Nationality);
            lsGdb.SelectCbo(CboProv, "", Connection.TableIniT.Province);
            lsGdb.SelectCbo(CboHotel, "", Connection.TableIniT.Member);
            lsGdb.SelectCbo(CboShift, "", Connection.TableIniT.Shift);
            CboShift.SelectedValue = "04";
            lsGdb.SelectCbo(CboRoomCode, "", Connection.TableIniT.TypeRoom);
            lsGdb.SelectCbo(CboStaff, "", Connection.TableIniT.Staff);
            lsGdb.SelectCbo(CboStatus, "", Connection.TableIniT.Status);
            lsGdb.SelectCbo(CboPrefix, "cboprefix", Connection.TableIniT.CboPrefix);
            lsGdb.SelectCbo(CboTypePayment, "", Connection.TableIniT.CboTypePayment);
            lsCounter = lsIni.GetString("thahr30", "counter", "0");
            lsMac  = lsIni.GetString("thahr30", "mac", "0");
            lsFlagPrintVoucheronScreen = lsIni.GetString("thahr30", "printvouchertoscreen", "0");
            lsVoucherFileName = lsIni.GetString("thahr30", "voucherfilename", "voucher.rpt");
            lsAccess = lsIni.GetString("thahr30", "accessdatabase", "0");
            lsServerDatabaseName = lsIni.GetString("thahr30", "serverdatabasename", "0");
            lsDatabaseName = lsIni.GetString("thahr30", "databasename", "0");
            lsCounter = lsIni.GetString("thahr30", "counter", "0");
            lsMac = lsIni.GetString("thahr30", "mac", "0");
            TxtCurrentRate.Value = Convert.ToDecimal(lsIni.GetString("thahr30", "USTOBAHT", "34.00"));
            TxtCounter.Text = lsCounter;
            TxtMac.Text = lsMac;
            TxtVouDate.Text = lsGdb.SelectDate(DateTime.Today, Connection.FlagDate .DateShow , lsIni);
            TxtCheckInDate.Text = lsGdb.SelectDate(DateTime.Today, Connection.FlagDate .DateShow , lsIni);
            TxtResTime.Text = System.DateTime.Now.Hour.ToString("00") + DateTime.Now.Minute.ToString("00");
            CboStatus.SelectedValue = "-";
            CboStaff.SelectedValue = "-";
            CboTypePayment.SelectedValue = "1";
            FlagVoucher("0");
            if (lsVouNO != "")
            {
                SelectVoucher(lsVouNO);
            }
            lbPageLoad = false;
            Tip1.AutoPopDelay = 500;
            Tip1.InitialDelay = 100;
            //Tip1.ReshowDelay = 500;
            // Force the ToolTip text to be displayed whether or not the form is active.
            Tip1.ShowAlways = true;
            Tip1.SetToolTip(this.TxtFirstName, "ชื่อ ลูกค้า");
            Tip1.SetToolTip(this.TxtLastName, "นามสกุล ลูกค้า");
            TxtCreditCard.Visible = false;
            label35.Visible = false;
            CheckExtraBed();
            //Rpt.ReportSource = "D:\\ThaHr30\\ThaHr30\\Voucher.rpt";
            //Rpt.ReportSource = "D:\\ThaHr30\\ThaHr30\\Voucher.rpt";
        }
        private void VoucherAdd_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    {
                        this.Hide();
                        break;
                    }
                case Keys.F2:
                    VoucherAdd lsReserveForm = new VoucherAdd();
                    lsReserveForm.ShowDialog(this);
                    break;
            }
        }
        private void CboStaff_SelectedValueChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(CboStaff.SelectedValue.ToString () );
        }

        private void CboProv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbPageLoad == false)
            {
                lbPageLoad = true;
                lsGdb.SelectCbo(CboHotel, CboProv.SelectedValue.ToString(), Connection.TableIniT.Member);
                lbPageLoad = false;
            }
        }
        private void ChangeCheckOutData()
        {
            if (TxtVisitT.Value > 1)
            {
                DateTime ld = new DateTime();
                string ls = "";
                ld = Convert.ToDateTime(TxtCheckInDate.Text).AddDays(Convert.ToDouble(TxtVisitT.Value));
                ls = ld.Day.ToString("00") + "/" + ld.Month.ToString("00") + "/" + (Convert.ToInt16(ld.Year) + 543);
                TxtCheckOutDate.Text = ls;
            }
            else if (TxtVisitT .Value == 1)
            {
                DateTime ld = new DateTime();
                string ls = "";
                ld = Convert.ToDateTime(TxtCheckInDate.Text).AddDays(1);
                ls = ld.Day.ToString("00") + "/" + ld.Month.ToString("00") + "/" + (Convert.ToInt16(ld.Year) + 543);
                TxtCheckOutDate.Text = ls;
            }
        }
        private void TxtVisitT_ValueChanged(object sender, EventArgs e)
        {
            if (lbPageLoad == false)
            {
                ChangeCheckOutData();
            }
        }
        private void TxtFirstName_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    {
                        if (TxtFirstName.Text.ToLower() == "void")
                        {
                            MessageBox.Show("กรุณาทำ Void ที่ More Action...", "", MessageBoxButtons.OK);
                            TxtFirstName.Text = "";
                        }
                        else
                        {
                            TxtLastName.SelectAll();
                            TxtLastName.Focus();
                        }
                        break;
                    }
            }
        }
        private void CboPrefix_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    {
                        TxtFirstName.SelectAll();
                        TxtFirstName.Focus();                       
                        break;
                    }
            }
        }
        private void TxtLastName_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    {
                        if (TxtLastName.Text.ToLower() == "void")
                        {
                            MessageBox.Show("กรุณาทำ Void ที่ More Action...", "", MessageBoxButtons.OK);
                            TxtLastName.Text = "";
                        }
                        else
                        {
                            CboNation.SelectAll();
                            CboNation.Focus();
                        }
                        break;
                    }
            }
        }
        private void CboNation_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    {
                        CboReasonT.SelectAll();
                        CboReasonT.Focus();
                        break;
                    }
            }
        }
        private void TxtResRoom_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    {
                        //TxtVisitT.SelectAll();
                        TxtVisitT.Select(1, TxtVisitT.Value.ToString().Length);
                        TxtVisitT.Focus();
                        break;
                    }
            }
        }
        private void TxtVisitT_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    {
                        //TxtPersonTrip.s
                        TxtPersonTrip.Focus();
                        break;
                    }
            }
        }
        private void TxtPersonTrip_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    {
                        TxtResTime.SelectAll();
                        TxtResTime.Focus();
                        break;
                    }
            }
        }
        private void CboReasonT_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    {
                        //TxtResRoom.SelectAll();
                        TxtResRoom.Focus();
                        break;
                    }
            }
        }
        private void CboProv_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    {
                        CboHotel.SelectAll();
                        CboHotel.Focus();
                        break;
                    }
            }
        }
        private void CboHotel_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    {
                        CboRoomCode.SelectAll();
                        CboRoomCode.Focus();
                        break;
                    }
            }
        }
        private void CboRoomCode_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    {
                        CboTypePayment.SelectAll();
                        CboTypePayment.Focus();
                        break;
                    }
            }
        }
        private void TxtResTime_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    {
                        SelectResTime();
                        CboStaff.SelectAll();
                        CboStaff.Focus();
                        break;
                    }
            }
        }
        private void CboShift_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    {
                        CboStaff.SelectAll();
                        CboStaff.Focus();
                        break;
                    }
            }
        }
        private void CboReasonS_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    {
                        TxtCheckInDate.SelectAll();
                        TxtCheckInDate.Focus();
                        break;
                    }
            }
        }
        private void TxtDepositAMT_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    {
                        TxtRemark.SelectAll();
                        TxtRemark.Focus();
                        break;
                    }
            }
        }
        private void TxtRoomRate_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    {
                        //TxtDepositAMT.SelectAll();
                        TxtDepositAMT.Focus();
                        break;
                    }
            }
        }
        private void CboStaff_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    {
                        //TxtCheckInDate.SelectAll();
                        CboReasonS.SelectAll();
                        CboReasonS.Focus();
                        break;
                    }
            }
        }
        private void CboStatus_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    {
                        TxtRemark.SelectAll();
                        TxtRemark.Focus();
                        break;
                    }
            }
        }
        private void voidvoucher_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ต้องการ Void Voucher " + TxtVouNO.Text, "Void Voucher", MessageBoxButtons.OKCancel)== DialogResult.OK)
            {
                Voucher lstblVou = new Voucher();
                lstblVou.VoidVoucher(TxtCounter.Text, TxtVouNO.Text);
                MessageBox.Show("Void sucess", "Void Voucher", MessageBoxButtons.OK);
                CloseFrm();
            }
        }
        private void CboHotel_SelectedValueChanged(object sender, EventArgs e)
        {
            if (lbPageLoad == false)
            {
                lbPageLoad = true;
                lsGdb.SelectCbo(CboRoomCode, CboHotel.SelectedValue.ToString(), Connection.TableIniT.TypeRoom);
                CboRoomCode.Text = "-";
                string lsSQL = "Select typepricebaht From member Where memid = '" + CboHotel.SelectedValue.ToString() + "'";
                MySqlCommand lsComm = new MySqlCommand(lsSQL, lsGdb.Gdb);
                MySqlDataReader lsRead;
                lsRead = lsComm.ExecuteReader();
                if (lsRead.HasRows)
                {
                    while (lsRead.Read())
                    {
                        if (lsRead["typepricebaht"].ToString() == "0")
                        {
                            ChkTypePriceBaht.Checked = true;
                            ChkTypePriceUS.Checked = false;
                        }
                        else
                        {
                            ChkTypePriceBaht.Checked = false;
                            ChkTypePriceUS.Checked = true;
                        }
                    }
                }
                lsRead.Close();
                lbPageLoad = false;
            }
        }

        private void CboRoomCode_SelectedValueChanged(object sender, EventArgs e)
        {
            if (lbPageLoad == false)
            {
                SelectMemberPriceList(CboHotel.SelectedValue.ToString(), CboRoomCode.SelectedValue.ToString());
            }
        }

        private void CboRoomCode_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cancelvoid_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ต้องการยกเลิกการ Void Voucher " + TxtVouNO.Text, "Cancel Void Voucher", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Voucher lstblVou = new Voucher();
                lstblVou.CancelVoidVoucher(TxtCounter.Text, TxtVouNO.Text);
                MessageBox.Show("Void sucess", "Cancel Void Voucher", MessageBoxButtons.OK);
                CloseFrm();
            }
        }

        private void CboShift_SelectedIndexChanged(object sender, EventArgs e)
        {
            //TxtResTime.Text = CboShift.SelectedValue.ToString();
        }

        private void returnvoucher_Click(object sender, EventArgs e)
        {
            VoucherReturn frm = new VoucherReturn();
            frm.Connnection = lsGdb.Gdb;
            frm.lsVouNO = TxtVouNO.Text;
            frm.ShowDialog(this);
        }
        private void Save(Boolean aClose)
        {
            string lsVoucher = SaveVoucher();
            if (lsVoucher!="")
            {
                string lsAutoPrintVoucher = lsIni.GetString("thahr30", "autoprintvoucher", "0");
                if (lsAutoPrintVoucher == "1")
                {
                    PrintVoucher(lsVoucher);
                }
                string ls = lsIni.GetString("thahr30", "flagupdatedeposit", "1");
                if (ls == "1")
                {
                    Member lsTblMember = new Member();
                    lsTblMember.UpdateDepositMemberPriceList(TxtPLID.Text, TxtDepositAMT.Value, lsGdb.Gdb);
                }
                MessageBox.Show("Save OK", "Add Voucher", MessageBoxButtons.OK);
                if (aClose)
                {
                    CloseFrm();
                }
            }
            else
            {
                MessageBox.Show("ไม่สามารถบันทึกข้อมุลได้", "Add Voucher", MessageBoxButtons.OK);
            }
        }
        private void saveclose_Click(object sender, EventArgs e)
        {
            Save(true);
        }

        private void exit_Click(object sender, EventArgs e)
        {
            CloseFrm();
        }
        private void CloseFrm()
        {
            this.Close();
        }

        private void noshow_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ต้องการ No Show Voucher " + TxtVouNO.Text, "No Show Voucher", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Voucher lstblVou = new Voucher();
                lstblVou.NoShowVoucher(TxtCounter.Text, TxtVouNO.Text);
                MessageBox.Show("No Show sucess", "No Show Voucher", MessageBoxButtons.OK);
                CloseFrm();
            }
        }

        private void cancelnoshow_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ต้องการยกเลิกการ No Show Voucher " + TxtVouNO.Text, "Cancel No Show Voucher", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Voucher lstblVou = new Voucher();
                lstblVou.CancelNoShowVoucher(TxtCounter.Text, TxtVouNO.Text);
                MessageBox.Show("No Show sucess", "Cancel No Show Voucher", MessageBoxButtons.OK);
                CloseFrm();
            }
        }
        private void TxtVouDate_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    {
                        TxtResTime.SelectAll();
                        TxtResTime.Focus();
                        break;
                    }
            }
        }
        private void TxtVouDate_ModifiedChanged(object sender, EventArgs e)
        {
            if (lbPageLoad == false)
            {
                TxtCheckInDate.Text = TxtVouDate.Text;
                ChangeCheckOutData();
            }
        }
        private void TxtCheckInDate_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    {
                        TxtCheckOutDate.Focus();
                        break;
                    }
            }
        }
        private void savenew_Click(object sender, EventArgs e)
        {
            Save(false);
        }

        private void TxtFirstName_Enter(object sender, EventArgs e)
        {
            TxtFirstName.BackColor = Color.SkyBlue;
        }

        private void TxtFirstName_Leave(object sender, EventArgs e)
        {
            TxtFirstName.BackColor = Color.White;
        }

        private void CboNation_Leave(object sender, EventArgs e)
        {
            CboNation.BackColor = Color.White;
        }

        private void CboNation_Enter(object sender, EventArgs e)
        {
            CboNation.BackColor = Color.SkyBlue;
        }

        private void TxtLastName_Enter(object sender, EventArgs e)
        {
            TxtLastName.BackColor = Color.SkyBlue;
        }

        private void TxtLastName_Leave(object sender, EventArgs e)
        {
            TxtLastName.BackColor = Color.White;
        }

        private void CboReasonT_Leave(object sender, EventArgs e)
        {
            CboReasonT.BackColor = Color.White;
        }

        private void CboReasonT_Enter(object sender, EventArgs e)
        {
            CboReasonT.BackColor = Color.SkyBlue;
        }

        private void CboPrefix_Enter(object sender, EventArgs e)
        {
            CboPrefix.BackColor = Color.SkyBlue;
        }

        private void CboPrefix_Leave(object sender, EventArgs e)
        {
            CboPrefix.BackColor = Color.White;
        }

        private void TxtResRoom_Leave(object sender, EventArgs e)
        {
            TxtResRoom.BackColor = Color.White;
        }

        private void TxtResRoom_Enter(object sender, EventArgs e)
        {
            TxtResRoom.BackColor = Color.SkyBlue;
        }

        private void TxtVisitT_Enter(object sender, EventArgs e)
        {
            TxtVisitT.BackColor = Color.SkyBlue;
        }

        private void TxtVisitT_Leave(object sender, EventArgs e)
        {
            TxtVisitT.BackColor = Color.White;
        }

        private void TxtPersonTrip_Leave(object sender, EventArgs e)
        {
            TxtPersonTrip.BackColor = Color.White;
        }

        private void TxtPersonTrip_Enter(object sender, EventArgs e)
        {
            TxtPersonTrip.BackColor = Color.SkyBlue;
        }

        private void TxtResTime_Enter(object sender, EventArgs e)
        {
            TxtResTime.BackColor = Color.SkyBlue;
        }

        private void TxtResTime_Leave(object sender, EventArgs e)
        {
            TxtResTime.BackColor = Color.White;
        }

        private void TxtVouDate_Leave(object sender, EventArgs e)
        {
            TxtVouDate.BackColor = Color.White;
        }

        private void TxtVouDate_Enter(object sender, EventArgs e)
        {
            TxtVouDate.BackColor = Color.SkyBlue;
        }

        private void CboShift_Enter(object sender, EventArgs e)
        {
            CboShift.BackColor = Color.SkyBlue;
        }

        private void CboShift_Leave(object sender, EventArgs e)
        {
            CboShift.BackColor = Color.White;
        }

        private void CboStaff_Leave(object sender, EventArgs e)
        {
            CboStaff.BackColor = Color.White;
        }

        private void CboStaff_Enter(object sender, EventArgs e)
        {
            CboStaff.BackColor = Color.SkyBlue;
        }

        private void CboReasonS_Enter(object sender, EventArgs e)
        {
            CboReasonS.BackColor = Color.SkyBlue;
        }

        private void CboReasonS_Leave(object sender, EventArgs e)
        {
            CboReasonS.BackColor = Color.White;
        }

        private void TxtCheckInDate_Leave(object sender, EventArgs e)
        {
            TxtCheckInDate.BackColor = Color.White;
        }

        private void TxtCheckInDate_Enter(object sender, EventArgs e)
        {
            TxtCheckInDate.BackColor = Color.SkyBlue;
        }

        private void TxtCheckOutDate_Enter(object sender, EventArgs e)
        {
            TxtCheckOutDate.BackColor = Color.SkyBlue;
        }

        private void TxtCheckOutDate_Leave(object sender, EventArgs e)
        {
            TxtCheckOutDate.BackColor = Color.White;
            //switch (e.KeyCode)
            //{
            //    case Keys.Enter:
            //        {
            //            CboProv.SelectAll();
            //            CboProv.Focus();
            //            break;
            //        }
            //}
        }

        private void CboProv_Enter(object sender, EventArgs e)
        {
            CboProv.BackColor = Color.SkyBlue;
        }

        private void CboProv_Leave(object sender, EventArgs e)
        {
            CboProv.BackColor = Color.White;
        }

        private void CboHotel_Leave(object sender, EventArgs e)
        {
            CboHotel.BackColor = Color.White;
        }

        private void CboHotel_Enter(object sender, EventArgs e)
        {
            CboHotel.BackColor = Color.SkyBlue;
        }

        private void CboRoomCode_Enter(object sender, EventArgs e)
        {
            CboRoomCode.BackColor = Color.SkyBlue;
        }

        private void CboRoomCode_Leave(object sender, EventArgs e)
        {
            CboRoomCode.BackColor = Color.White;
        }
        private void TxtRoomRate_Leave(object sender, EventArgs e)
        {
            TxtRoomRate.BackColor = Color.White;
        }
        private void TxtRoomRate_Enter(object sender, EventArgs e)
        {
            TxtRoomRate.BackColor = Color.SkyBlue;
        }
        private void TxtDepositAMT_Enter(object sender, EventArgs e)
        {
            TxtDepositAMT.BackColor = Color.SkyBlue;
        }
        private void TxtDepositAMT_Leave(object sender, EventArgs e)
        {
            TxtDepositAMT.BackColor = Color.White;
        }
        private void TxtAmount_Enter(object sender, EventArgs e)
        {
            TxtAmount.BackColor = Color.SkyBlue;
        }
        private void TxtAmount_Leave(object sender, EventArgs e)
        {
            TxtAmount.BackColor = Color.White;
        }
        private void TxtRemark_Leave(object sender, EventArgs e)
        {
            TxtRemark.BackColor = Color.White;
        }
        private void TxtRemark_Enter(object sender, EventArgs e)
        {
            TxtRemark.BackColor = Color.SkyBlue;
        }
        private void TxtCheckOutDate_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    {
                        CboProv.SelectAll();
                        CboProv.Focus();
                        break;
                    }
            }
        }
        private void print_Click(object sender, EventArgs e)
        {
            try
            {
                string lsVoucher = SaveVoucher();
                if (lsVoucher!="")
                {
                    PrintVoucher(lsVoucher);
                }
                else
                {
                    MessageBox.Show("Can't Save", "Can't Print Voucher", MessageBoxButtons.OK);
                }
            }
            catch (OleDbException eAcc)
            {
                string ls = "ไม่สามารถเตรียมข้อมูล Print ได้ " + lsAccess;
                lsGdb.WriteLogError(ls, eAcc, lsSQL, "printToolStripButton_Click ");
                MessageBox.Show(ls + " " + eAcc.Message.ToString(), eAcc.Source.ToString(), MessageBoxButtons.OK);
            }
        }
        private void CboReasonT_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void CboTypePayment_Enter(object sender, EventArgs e)
        {
            CboTypePayment.BackColor = Color.SkyBlue;
        }
        private void CboTypePayment_Leave(object sender, EventArgs e)
        {
            CboTypePayment.BackColor = Color.White;
        }
        private void CboTypePayment_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    {
                        //TxtRoomRate.SelectAll();
                        TxtRoomRate.Focus();
                        break;
                    }
            }
        }
        private void CboTypePayment_SelectedValueChanged(object sender, EventArgs e)
        {
            if (lbPageLoad == false)
            {
                lbPageLoad = true;
                if (CboTypePayment.SelectedValue.ToString() == "3")
                {
                    TxtCreditCard.Visible = true;
                    label35.Visible = true;
                }
                else
                {
                    TxtCreditCard.Visible = false;
                    label35.Visible = false;
                }
                lbPageLoad = false;
            }
        }
        private void CboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void CboHotel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void ChkExtraBed_CheckedChanged(object sender, EventArgs e)
        {
            CheckExtraBed();
        }
        private void ChkTypePriceBaht_CheckedChanged(object sender, EventArgs e)
        {
            CheckTypePriceBaht();
        }
        private void ChkTypePriceUS_CheckedChanged(object sender, EventArgs e)
        {
            CheckTypePriceBaht();
        }
    }
}