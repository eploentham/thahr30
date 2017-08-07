using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace ThaHr30
{
    public partial class ShopView : Form
    {
        private int liColMainHotelCode = 0, liColMainMemNamee1 = 1, liColMainVoucher = 2, liColMainDays = 3, liColMainPax = 4, liColMainDepositAMT = 5;
        private int liColDetailCounterID = 0, liColDetailCounter = 1, liColDetailDays = 3, liColDetailPax = 4, liColDetailDepositAMT = 5;
        private int liColVouNo = 0, liColGuestName = 1, liColVouDate = 2, liColCounter = 3, liColMac = 4, liColRoomRate = 5, liColRoomRate1 = 6, liColStaffName = 7;
        private int liColStatus = 8, liColCheckInDate = 9, liColCheckOutDate = 10, liColDays = 11, liColPax = 12, liColDeposit = 13, liColRoomNO = 14;
        IniFile lsIni = new IniFile("thahr30.ini");
        private string lsStartDate = "", lsEndDate = "";
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
        Initial lsIniT = new Initial();
        public ShopView()
        {
            InitializeComponent();
        }
        private void PaintGrdMain()
        {
            GrdView.Left = 12;
            GrdView.Height = this.Height - 100;
            GrdView.Width = this.Width - 30;
            GrdView.Sheets[1].SheetName = "Summary Member";
            GrdView.Top = 35;
            GrdView.Left = 12;
            GrdView.Sheets[0].ColumnCount = 6;
            GrdView.Sheets[0].RowCount = 500;
            GrdView.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            GrdView.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            GrdView.Sheets[0].SetColumnWidth(liColMainHotelCode, 82);
            GrdView.Sheets[0].SetColumnWidth(liColMainMemNamee1, 300);
            GrdView.Sheets[0].SetColumnWidth(liColMainVoucher, 70);
            GrdView.Sheets[0].SetColumnWidth(liColMainDays, 65);
            GrdView.Sheets[0].SetColumnWidth(liColMainPax, 65);
            GrdView.Sheets[0].SetColumnWidth(liColMainDepositAMT, 100);
            FarPoint.Win.Spread.Column col;
            FarPoint.Win.Spread.CellType.TextCellType cell = new FarPoint.Win.Spread.CellType.TextCellType();
            col = GrdView.Sheets[0].Columns[liColMainMemNamee1, liColMainPax];
            col.CellType = cell;
            FarPoint.Win.Spread.CellType.NumberCellType celldeposit = new FarPoint.Win.Spread.CellType.NumberCellType();
            GrdView.Sheets[0].Columns[liColMainDepositAMT].CellType = celldeposit;
            GrdView.Sheets[0].Columns[liColMainMemNamee1, liColMainDepositAMT].Locked = true;
            GrdView.Sheets[0].SetColumnLabel(0, liColMainHotelCode, "hotelcode");
            GrdView.Sheets[0].SetColumnLabel(0, liColMainMemNamee1, "Member Name E");
            GrdView.Sheets[0].SetColumnLabel(0, liColMainVoucher, "Vou NO");
            GrdView.Sheets[0].SetColumnLabel(0, liColMainDays, "Days");
            GrdView.Sheets[0].SetColumnLabel(0, liColMainPax, "PAX");
            GrdView.Sheets[0].SetColumnLabel(0, liColMainDepositAMT, "Deposit");
            GrdView.Sheets[0].Columns[0].Visible = false;
        }
        private void PaintGrdMainSumDate()
        {
            GrdView.Left = 12;
            GrdView.Height = this.Height - 100;
            GrdView.Width = this.Width - 30;
            GrdView.Top = 35;
            GrdView.Left = 12;
            GrdView.Sheets[1].ColumnCount = 6;
            GrdView.Sheets[1].RowCount = 500;
            GrdView.Sheets[1].SheetName = "Summary Date";
            GrdView.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            GrdView.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            GrdView.Sheets[1].SetColumnWidth(liColMainHotelCode, 82);
            GrdView.Sheets[1].SetColumnWidth(liColMainMemNamee1, 300);
            GrdView.Sheets[1].SetColumnWidth(liColMainVoucher, 70);
            GrdView.Sheets[1].SetColumnWidth(liColMainDays, 65);
            GrdView.Sheets[1].SetColumnWidth(liColMainPax, 65);
            GrdView.Sheets[1].SetColumnWidth(liColMainDepositAMT, 100);
            FarPoint.Win.Spread.Column col;
            FarPoint.Win.Spread.CellType.TextCellType cell = new FarPoint.Win.Spread.CellType.TextCellType();
            col = GrdView.Sheets[1].Columns[liColMainMemNamee1, liColMainPax];
            col.CellType = cell;
            FarPoint.Win.Spread.CellType.NumberCellType celldeposit = new FarPoint.Win.Spread.CellType.NumberCellType();
            celldeposit.DecimalSeparator = ".";
            celldeposit.Separator = ",";
            celldeposit.ShowSeparator = true;
            celldeposit.DecimalPlaces = 2;
            GrdView.Sheets[1].Columns[liColMainDepositAMT].CellType = celldeposit;
            GrdView.Sheets[1].Columns[liColMainMemNamee1, liColMainDepositAMT].Locked = true;
            GrdView.Sheets[1].Columns[liColMainDays, liColMainDepositAMT].AllowAutoSort = true;
            GrdView.Sheets[1].SetColumnLabel(0, liColMainHotelCode, "hotelcode");
            GrdView.Sheets[1].SetColumnLabel(0, liColMainMemNamee1, "Voucher Date");
            GrdView.Sheets[1].SetColumnLabel(0, liColMainVoucher, "Vou NO");
            GrdView.Sheets[1].SetColumnLabel(0, liColMainDays, "Days");
            GrdView.Sheets[1].SetColumnLabel(0, liColMainPax, "PAX");
            GrdView.Sheets[1].SetColumnLabel(0, liColMainDepositAMT, "Deposit");
            GrdView.Sheets[1].Columns[0].Visible = false;
        }
        private void PaintGrdView(Int32 aGrd)
        {
            GrdView.Sheets[aGrd].ColumnCount = 15;
            GrdView.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            GrdView.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            GrdView.Sheets[aGrd].SetColumnWidth(liColVouNo, 82);
            GrdView.Sheets[aGrd].SetColumnWidth(liColGuestName, 220);
            GrdView.Sheets[aGrd].SetColumnWidth(liColVouDate, 70);
            GrdView.Sheets[aGrd].SetColumnWidth(liColCounter, 75);
            GrdView.Sheets[aGrd].SetColumnWidth(liColMac, 65);
            GrdView.Sheets[aGrd].SetColumnWidth(liColRoomRate, 82);
            GrdView.Sheets[aGrd].SetColumnWidth(liColRoomRate1, 82);
            GrdView.Sheets[aGrd].SetColumnWidth(liColStaffName, 85);
            GrdView.Sheets[aGrd].SetColumnWidth(liColStatus, 65);
            GrdView.Sheets[aGrd].SetColumnWidth(liColCheckInDate, 65);
            GrdView.Sheets[aGrd].SetColumnWidth(liColCheckOutDate, 65);
            GrdView.Sheets[aGrd].SetColumnWidth(liColDays, 45);
            GrdView.Sheets[aGrd].SetColumnWidth(liColPax, 45);
            GrdView.Sheets[aGrd].SetColumnWidth(liColDeposit, 82);
            GrdView.Sheets[aGrd].SetColumnWidth(liColRoomNO, 60);

            FarPoint.Win.Spread.Column col;
            FarPoint.Win.Spread.CellType.TextCellType cell = new FarPoint.Win.Spread.CellType.TextCellType();
            col = GrdView.Sheets[aGrd].Columns[liColVouNo, liColRoomNO];
            col.CellType = cell;

            GrdView.Sheets[aGrd].Columns[liColDetailCounterID, liColDetailDepositAMT].Locked = true;
            GrdView.Sheets[aGrd].SetColumnLabel(0, liColVouNo, "Vou No");
            GrdView.Sheets[aGrd].SetColumnLabel(0, liColGuestName, "Guest Name");
            GrdView.Sheets[aGrd].SetColumnLabel(0, liColVouDate, "Vou Date");
            GrdView.Sheets[aGrd].SetColumnLabel(0, liColCounter, "Counter");
            GrdView.Sheets[aGrd].SetColumnLabel(0, liColMac, "MAC");
            GrdView.Sheets[aGrd].SetColumnLabel(0, liColRoomRate, "Room Rate");
            GrdView.Sheets[aGrd].SetColumnLabel(0, liColRoomRate1, "Room Rate++");
            GrdView.Sheets[aGrd].SetColumnLabel(0, liColStaffName, "Staff");
            GrdView.Sheets[aGrd].SetColumnLabel(0, liColStatus, "Status");
            GrdView.Sheets[aGrd].SetColumnLabel(0, liColCheckInDate, "in Date");
            GrdView.Sheets[aGrd].SetColumnLabel(0, liColCheckOutDate, "out Date");
            GrdView.Sheets[aGrd].SetColumnLabel(0, liColPax, "PAX");
            GrdView.Sheets[aGrd].SetColumnLabel(0, liColDays, "Days");
            GrdView.Sheets[aGrd].SetColumnLabel(0, liColDeposit, "Deposit");
            GrdView.Sheets[aGrd].SetColumnLabel(0, liColRoomNO, "Room NO");
            GrdView.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Off;
            GrdView.BorderStyle = BorderStyle.None;
            GrdView.Sheets[aGrd].Columns[0].Visible = false;
            FarPoint.Win.Spread.HideRowFilter hideRowFilter = new FarPoint.Win.Spread.HideRowFilter(GrdView.ActiveSheet);
            GrdView.Sheets[aGrd].Columns[liColGuestName].AllowAutoFilter = true;
            GrdView.Sheets[aGrd].Columns[liColVouDate].AllowAutoFilter = true;
            GrdView.Sheets[aGrd].Columns[liColCounter].AllowAutoFilter = true;
            GrdView.Sheets[aGrd].Columns[liColStaffName].AllowAutoFilter = true;
            GrdView.Sheets[aGrd].Columns[liColCheckInDate].AllowAutoFilter = true;
            //GrdView.Visible = true;
        }
        private void SelectVoucher(string aMonth)
        {
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Cursor.Show();
            Int32 i = 0, liCountVoucherMain = 0, liCountDaysMain = 0, liCountPaxMain = 0, liRow = 0;
            double ldoDepositAMT = 0, ldoDeposit = 0;
            string lsSQL = "", lsHotelName = "", lsCounterName = "", lsHotelCode="";
            //PaintGrdMain();
            DateTime ld = new DateTime();
            //Connection lsConn = new Connection();
            //lsConn.ConnectDatabase();
            Int32 li = Convert.ToInt32(aMonth);
            CboYear.Text = "2555";
            lsStartDate = CboYear.Text + "-" + li.ToString("00") + "-01";
            ld = lsGdb.LastDayofMonth(Convert.ToDateTime(lsStartDate));
            lsStartDate = (Convert.ToInt16(CboYear.Text) - 543) + "-" + li.ToString("00") + "-01";
            lsEndDate = lsGdb.SelectDateMySQL(ld);
            lsSQL = "Select v.hotelcode as hotelcode, count(v.hotelcode) voucher, sum(v.visitt)as Days, "
                + "sum(personintrip) as PAX, sum(depositamt) as Deposit, counter1 as counter From voucher v "
                + "Where v.voudate >= '" + lsStartDate + "' and v.voudate <= '"
                + lsEndDate + "' and v.flag in ('1','2') Group By hotelcode ";
            MySqlCommand lsComm = new MySqlCommand(lsSQL, lsGdb.Gdb);
            MySqlDataAdapter lsAdap = new MySqlDataAdapter();
            DataSet lsDSMain = new DataSet();
            DataTable lsDTHotel = new DataTable();
            DataTable lsDTVoucher = new DataTable();
            lsDTHotel = lsDSMain.Tables.Add("hotel");
            lsDTVoucher = lsDSMain.Tables.Add("voucher");
            lsDTHotel.Columns.AddRange(new DataColumn[] {new DataColumn("hotelcode", typeof(string)), 
                new DataColumn("memnamee1", typeof(string)), new DataColumn("voucher", typeof(string)), 
                new DataColumn("Days", typeof(string)), new DataColumn("PAX", typeof(string)),
                new DataColumn("DepositAMT", typeof(string)),new DataColumn("counter", typeof(string))});
            MySqlDataReader lsReadMain;
            lsReadMain = lsComm.ExecuteReader();
            if (lsReadMain.HasRows)
            {
                while (lsReadMain.Read())
                {
                    try
                    {
                        liRow++;
                        ldoDeposit = Convert.ToDouble(lsReadMain["Deposit"]);
                        liCountVoucherMain = liCountVoucherMain + Convert.ToInt32(lsReadMain["voucher"]);
                        liCountDaysMain = liCountDaysMain + Convert.ToInt32(lsReadMain["days"]);
                        liCountPaxMain = liCountPaxMain + Convert.ToInt32(lsReadMain["pax"]);
                        ldoDepositAMT = ldoDepositAMT + ldoDeposit;
                        lsHotelCode = lsReadMain["hotelcode"].ToString();
                        lsHotelName = lsIniT.SelectInitial(lsIniT.TblMember, lsHotelCode, Initial.WhereSelect.aCodetoName);
                        lsDTHotel.Rows.Add(new object[] {lsHotelCode, lsHotelName, lsReadMain["voucher"].ToString(), 
                        lsReadMain["days"].ToString(), lsReadMain["pax"].ToString(), ldoDeposit .ToString ("0,000.00") });
                    }
                    catch (Exception e)
                    {
                        liRow++;
                        lsSQL = "";
                        string ls = "มีข้อมูลบางแห่งไม่ถูกต้อง ";
                        lsGdb.WriteLogError(ls, e, lsSQL, "ShopView-SelectVoucher ");
                        MessageBox.Show(ls + "\n " + e.Message.ToString(), e.Source.ToString(), MessageBoxButtons.OK);
                    }
                }
                lsDTHotel.Rows.Add(new object[] { "", "", liCountVoucherMain.ToString(), liCountDaysMain.ToString(), liCountPaxMain.ToString(), ldoDepositAMT.ToString() });
            }
            lsReadMain.Close();
            lsDTVoucher.Columns.AddRange(new DataColumn[] {new DataColumn("counter", typeof(string)), 
                new DataColumn("voucher", typeof(string)), 
                new DataColumn("Days", typeof(string)), new DataColumn("PAX", typeof(string)),
                new DataColumn("DepositAMT", typeof(string)),new DataColumn("-", typeof(string))});
            lsSQL = "Select count(v.hotelcode) voucher, sum(v.visitt)as Days, "
                + "sum(personintrip) as PAX, sum(depositamt) as Deposit, counter1 as Counter, hotelcode From voucher v "
                + "Where v.voudate >= '" + lsStartDate + "' and v.voudate <= '"
                + lsEndDate + "' and v.flag in ('1','2') Group By hotelcode, counter1 Order By counter1";
            MySqlDataReader lsReadVoucher;
            MySqlCommand lsComm1 = new MySqlCommand(lsSQL, lsGdb.Gdb);
            lsReadVoucher = lsComm1.ExecuteReader();
            if (lsReadVoucher.HasRows)
            {
                while (lsReadVoucher.Read())
                {
                    try
                    {
                        lsCounterName = lsIniT.SelectInitial(lsIniT.TblCounter, lsReadVoucher["Counter"].ToString(), Initial.WhereSelect.aCodetoName);
                        lsDTVoucher.Rows.Add(new object[] { lsCounterName, lsReadVoucher["voucher"].ToString(), 
                        lsReadVoucher["days"].ToString(), lsReadVoucher["pax"].ToString(), lsReadVoucher["Deposit"].ToString(),lsReadVoucher["hotelcode"].ToString()});
                    }
                    catch (Exception e)
                    {
                        liRow++;
                        lsSQL = "";
                        string ls = "มีข้อมูลบางแห่งไม่ถูกต้อง ";
                        lsGdb.WriteLogError(ls, e, lsSQL, "ShopView-SelectVoucher ");
                        MessageBox.Show(ls + "\n " + e.Message.ToString(), e.Source.ToString(), MessageBoxButtons.OK);
                    }
                }
            }
            lsReadVoucher.Close();
            lsDSMain.Relations.Add("root", lsDSMain.Tables["hotel"].Columns["hotelcode"], lsDSMain.Tables["voucher"].Columns["-"]);
            GrdView.Sheets[0].DataSource = lsDSMain;
            PaintGrdMain();
            if (GrdView.Sheets[0].RowCount > 29)
            {
                GrdView.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Always;
            }
            if ((i % 2) != 0)
            {
                GrdView.Sheets[0].Rows[i].BackColor = Color.LightGoldenrodYellow;
            }
            TxtVoucherSum.Text = liCountVoucherMain.ToString("#,###,###");
            TxtVoucherUse.Text = "0";
            TxtDays.Text = liCountDaysMain.ToString("#,###,###");
            TxtPAX.Text = liCountPaxMain.ToString("#,###,###");
            TxtDeposit.Text = ldoDepositAMT.ToString("#,###,###.00");
            GrdView.Sheets[0].RowCount = liRow + 1;
            Cursor.Current = System.Windows.Forms.Cursors.Default;
            Cursor.Show();
        }
        private void SelectVoucherSumDay(string aMonth)
        {
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Cursor.Show();
            Int32 i = 0,liCountVoucherMain = 0, liCountDaysMain = 0, liCountPaxMain = 0, liRow = 0;
            double ldoDepositAMT = 0, ldoDeposit = 0;
            string lsSQL = "", lsHotelName = "", lsCounterName = "";
            //PaintGrdMain();
            DateTime ld = new DateTime();
            DateTime ldVouDate = new DateTime();
            //Connection lsConn = new Connection();
            //lsConn.ConnectDatabase();
            Int32 li = Convert.ToInt32(aMonth);
            lsStartDate = CboYear.Text + "-" + li.ToString("00") + "-01";
            ld = lsGdb.LastDayofMonth(Convert.ToDateTime(lsStartDate));
            lsStartDate = (Convert.ToInt16(CboYear.Text) - 543) + "-" + li.ToString("00") + "-01";
            lsEndDate = ld.Year.ToString("0000") + "-" + ld.Month.ToString("00") + "-" + ld.Day.ToString("00");
            lsSQL = "Select v.voudate as hotelcode, count(v.hotelcode) voucher, sum(v.visitt)as Days, "
                + "sum(personintrip) as PAX, sum(depositamt) as Deposit, counter1 as counter From voucher v "
                + "Where v.voudate >= '" + lsStartDate + "' and v.voudate <= '"
                + lsEndDate + "' and v.flag in ('1','2') Group By voudate ";
            MySqlCommand lsComm = new MySqlCommand(lsSQL, lsGdb.Gdb);
            MySqlDataAdapter lsAdap = new MySqlDataAdapter();
            DataSet lsDSMain = new DataSet();
            DataTable lsDTHotel = new DataTable();
            DataTable lsDTVoucher = new DataTable();
            lsDTHotel = lsDSMain.Tables.Add("hotel");
            lsDTVoucher = lsDSMain.Tables.Add("voucher");
            lsDTHotel.Columns.AddRange(new DataColumn[] {new DataColumn("hotelcode", typeof(string)), 
                new DataColumn("memnamee1", typeof(string)), new DataColumn("voucher", typeof(string)), 
                new DataColumn("Days", typeof(string)), new DataColumn("PAX", typeof(string)),
                new DataColumn("DepositAMT", typeof(string)),new DataColumn("counter", typeof(string))});
            MySqlDataReader lsReadMain;
            lsReadMain = lsComm.ExecuteReader();
            if (lsReadMain.HasRows)
            {
                while (lsReadMain.Read())
                {
                    try
                    {
                        liRow++;
                        ldoDeposit = Convert.ToDouble(lsReadMain["Deposit"]);
                        liCountVoucherMain = liCountVoucherMain + Convert.ToInt32(lsReadMain["voucher"]);
                        liCountDaysMain = liCountDaysMain + Convert.ToInt32(lsReadMain["days"]);
                        liCountPaxMain = liCountPaxMain + Convert.ToInt32(lsReadMain["pax"]);
                        ldoDepositAMT = ldoDepositAMT + ldoDeposit;
                        ldVouDate = Convert.ToDateTime(lsReadMain["hotelcode"].ToString());
                        lsSQL = ldVouDate.Day.ToString() + "/" + ldVouDate.Month.ToString("00") + "/" + Convert.ToString(ldVouDate.Year + 543);
                        //lsSQL = lsReadMain["hotelcode"].ToString();
                        lsHotelName = "";
                        //lsHotelName = lsIniT.SelectInitial(lsIniT.TblMember, lsReadMain["hotelcode"].ToString(), Initial.WhereSelect.aCodetoName);
                        lsDTHotel.Rows.Add(new object[] {lsSQL, lsSQL, lsReadMain["voucher"].ToString(), 
                        lsReadMain["days"].ToString(), lsReadMain["pax"].ToString(), ldoDeposit .ToString ("0,000.00") });
                    }
                    catch (Exception e)
                    {
                        liRow++;
                        lsSQL = "";
                        string ls = "มีข้อมูลบางแห่งไม่ถูกต้อง ";
                        lsGdb.WriteLogError(ls, e, lsSQL, "ShopView-SelectVoucherSumDay ");
                        MessageBox.Show(ls + "\n " + e.Message.ToString(), e.Source.ToString(), MessageBoxButtons.OK);
                    }
                }
                lsDTHotel.Rows.Add(new object[] { "", "", liCountVoucherMain.ToString(), liCountDaysMain.ToString(), liCountPaxMain.ToString(), ldoDepositAMT.ToString()});
            }
            lsReadMain.Close();
            lsDTVoucher.Columns.AddRange(new DataColumn[] {new DataColumn("counter", typeof(string)), 
                new DataColumn("voucher", typeof(string)), 
                new DataColumn("Days", typeof(string)), new DataColumn("PAX", typeof(string)),
                new DataColumn("DepositAMT", typeof(string)),new DataColumn("-", typeof(string))});
            lsSQL = "Select count(v.hotelcode) voucher, sum(v.visitt)as Days, "
                + "sum(personintrip) as PAX, sum(depositamt) as Deposit, counter1 as Counter, voudate as hotelcode From voucher v "
                + "Where v.voudate >= '" + lsStartDate + "' and v.voudate <= '"
                + lsEndDate + "' and v.flag in ('1','2') Group By voudate, counter1 Order By counter1";
            MySqlDataReader lsReadVoucher;
            MySqlCommand lsComm1 = new MySqlCommand(lsSQL, lsGdb.Gdb);
            lsReadVoucher = lsComm1.ExecuteReader();
            if (lsReadVoucher.HasRows)
            {
                while (lsReadVoucher.Read())
                {
                    try
                    {
                        ldVouDate = Convert.ToDateTime(lsReadVoucher["hotelcode"].ToString());
                        lsSQL = ldVouDate.Day.ToString() + "/" + ldVouDate.Month.ToString("00") + "/" + Convert.ToString(ldVouDate.Year + 543);
                        lsCounterName = lsIniT.SelectInitial(lsIniT.TblCounter, lsReadVoucher["Counter"].ToString(), Initial.WhereSelect.aCodetoName);
                        lsDTVoucher.Rows.Add(new object[] { lsCounterName, lsReadVoucher["voucher"].ToString(), 
                        lsReadVoucher["days"].ToString(), lsReadVoucher["pax"].ToString(), lsReadVoucher["Deposit"].ToString(),lsSQL});
                    }
                    catch (Exception e)
                    {
                        lsSQL = "";
                        string ls = "มีข้อมูลบางแห่งไม่ถูกต้อง ";
                        lsGdb.WriteLogError(ls, e, lsSQL, "ShopView-SelectVoucherSumDay ");
                        MessageBox.Show(ls + "\n " + e.Message.ToString(), e.Source.ToString(), MessageBoxButtons.OK);
                    }
                }
            }
            lsReadVoucher.Close();
            lsDSMain.Relations.Add("root", lsDSMain.Tables["hotel"].Columns["hotelcode"], lsDSMain.Tables["voucher"].Columns["-"]);
            GrdView.Sheets[1].DataSource = lsDSMain;
            PaintGrdMainSumDate();
            if (GrdView.Sheets[1].RowCount > 29)
            {
                GrdView.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Always;
            }
            if ((i % 2) != 0)
            {
                GrdView.Sheets[1].Rows[i].BackColor = Color.LightGoldenrodYellow;
            }
            TxtVoucherSum.Text = liCountVoucherMain.ToString("#,###,###");
            TxtVoucherUse.Text = "0";
            TxtDays.Text = liCountDaysMain.ToString("#,###,###");
            TxtPAX.Text = liCountPaxMain.ToString("#,###,###");
            TxtDeposit.Text = ldoDepositAMT.ToString("#,###,###.00");
            GrdView.Sheets[1].RowCount = liRow + 1;
            Cursor.Current = System.Windows.Forms.Cursors.Default;
            Cursor.Show();
        }
        private void SelectVoucherDetail(string aMemId, int aGrdIndex)
        {

            Int32 i = 0, j = 0;
            string lsSQL = "", ls = "", lsCounterName = "", lsStatus = "", lsStaffName = "";
            DateTime ld = new DateTime();
            PaintGrdView(aGrdIndex);
            lsSQL = "Select count(*) cnt From voucher Where voudate >= '" + lsStartDate + "' and voudate <= '"
                + lsEndDate + "' and hotelcode = '" + aMemId + "' and flag in ('1','2') ";
            MySqlCommand lsComm1 = new MySqlCommand(lsSQL, lsGdb.Gdb);
            MySqlDataReader lsRead1;
            lsRead1 = lsComm1.ExecuteReader();
            if (lsRead1.HasRows)
            {
                while (lsRead1.Read())
                {
                    i = Convert.ToInt32(lsRead1["cnt"]);
                }
            }
            lsRead1.Close();
            GrdView.Sheets[aGrdIndex].RowCount = i;
            lsSQL = "Select vouno, guestfirstname, guestlastname, voudate, counter1, mac, "
                + "roomno, roomrate, roomrate1, staffcode, statuscode, checkindate, checkoutdate, "
                + "visitt, pax, depositamt, roomno From voucher Where voudate >= '" + lsStartDate + "' and voudate <= '"
                + lsEndDate + "' and hotelcode = '" + aMemId + "' and flag in ('1','2') Order By counter1, voudate, vouno";
            MySqlCommand lsComm2 = new MySqlCommand(lsSQL, lsGdb.Gdb);
            MySqlDataReader lsRead2;
            lsRead2 = lsComm2.ExecuteReader();
            if (lsRead2.HasRows)
            {
                j = 0;
                while (lsRead2.Read())
                {
                    try
                    {
                        lsCounterName = lsIniT.SelectInitial(lsIniT.TblCounter, lsRead2["counter1"].ToString(), Initial.WhereSelect.aCodetoName);
                        lsStaffName = lsIniT.SelectInitial(lsIniT.TblStaff, lsRead2["staffcode"].ToString(), Initial.WhereSelect.aCodetoName);
                        lsStatus = lsIniT.SelectInitial(lsIniT.TblStatus, lsRead2["statuscode"].ToString(), Initial.WhereSelect.aCodetoName);
                        GrdView.Sheets[aGrdIndex].Cells[j, liColVouNo].Text = lsRead2["vouno"].ToString();
                        GrdView.Sheets[aGrdIndex].SetText(j, liColGuestName, lsRead2["guestfirstname"].ToString() + " " + lsRead2["guestlastname"].ToString());
                        ld = Convert.ToDateTime(lsRead2["voudate"]);
                        ls = ld.Day.ToString("00") + "/" + ld.Month.ToString("00") + "/" + ld.Year.ToString("0000");
                        GrdView.Sheets[aGrdIndex].Cells[j, liColVouDate].Text = ls;
                        GrdView.Sheets[aGrdIndex].Cells[j, liColCounter].Text = lsCounterName;
                        GrdView.Sheets[aGrdIndex].Cells[j, liColMac].Text = lsRead2["mac"].ToString().Substring(6, 3);
                        GrdView.Sheets[aGrdIndex].Cells[j, liColRoomRate].Text = lsRead2["roomrate"].ToString();
                        GrdView.Sheets[aGrdIndex].Cells[j, liColRoomRate1].Text = lsRead2["roomrate1"].ToString();
                        GrdView.Sheets[aGrdIndex].Cells[j, liColStaffName].Text = lsStaffName;
                        GrdView.Sheets[aGrdIndex].Cells[j, liColStatus].Text = lsStatus;
                        ld = Convert.ToDateTime(lsRead2["checkindate"]);
                        ls = ld.Day.ToString("00") + "/" + ld.Month.ToString("00") + "/" + ld.Year.ToString("0000");
                        GrdView.Sheets[aGrdIndex].Cells[j, liColCheckInDate].Text = ls;
                        ld = Convert.ToDateTime(lsRead2["checkoutdate"]);
                        ls = ld.Day.ToString("00") + "/" + ld.Month.ToString("00") + "/" + ld.Year.ToString("0000");
                        GrdView.Sheets[aGrdIndex].Cells[j, liColCheckOutDate].Text = ls;
                        GrdView.Sheets[aGrdIndex].Cells[j, liColDays].Text = lsRead2["visitt"].ToString();
                        GrdView.Sheets[aGrdIndex].Cells[j, liColPax].Text = lsRead2["pax"].ToString();
                        GrdView.Sheets[aGrdIndex].Cells[j, liColDeposit].Text = lsRead2["depositamt"].ToString();
                        GrdView.Sheets[aGrdIndex].Cells[j, liColRoomNO].Text = lsRead2["roomno"].ToString();
                        if ((j % 2) != 0)
                        {
                            GrdView.Sheets[aGrdIndex].Rows[j].BackColor = Color.LightGoldenrodYellow;
                        }
                        j++;
                    }
                    catch (Exception e)
                    {
                        j++;
                        lsSQL = "";
                        string ls1 = "มีข้อมูลบางแห่งไม่ถูกต้อง " ;
                        lsGdb.WriteLogError(ls1, e, lsSQL, "SelectVoucherDetail ");
                        MessageBox.Show(ls1 + "\n " + e.Message.ToString(), e.Source.ToString(), MessageBoxButtons.OK);
                    }
                }                
            }
            lsRead2.Close();
            if (GrdView.Sheets[aGrdIndex].RowCount > 29)
            {
                GrdView.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Always;
            }
        }
        private void VisibleGbSum(Boolean aVisible)
        {
            if (aVisible)
            {
                GbSum.Visible = true;
            }
            else
            {
                GbSum.Visible = false;
            }
        }
        private void ShopView_Load(object sender, EventArgs e)
        {
            Pb1.Visible = false;
            //lsGdb.ConnectDatabase();  flagcounterlink=1
            if (lsGdb.Gdb.State == ConnectionState.Closed)
            {
                lsGdb.ConnectDatabase();
            }
            string lsCounterLink = lsIni.GetString("thahr30", "flagcounterlink", "0");
            if (lsCounterLink == "1")
            {
                BtnRec.Enabled = false;
            }
            lsIniT.CreateTblInitial(lsGdb.Gdb);
            lsGdb.SelectCbo(CboYear.ComboBox, "", Connection.TableIniT.YearName);
            lsGdb.SelectCbo(CboMonth.ComboBox, "", Connection.TableIniT.MonthName);
            GrdView.Top = this.Top + 35;
            GrdView.Left = this.Left + 15;
            GrdView.Height = this.Height - 100;
            GrdView.Width = this.Width - 25;
            GbSum.Top = 37;
            GbSum.Left = 700;
            CboMonth.ComboBox.SelectedValue = DateTime.Today.Month.ToString();
            CboYear.ComboBox.SelectedValue = Convert.ToString(DateTime.Today.Year + 543);
            GrdView.Sheets.Count = 2;
            PaintGrdMain();
            PaintGrdMainSumDate();
            VisibleGbSum(true);
            SelectVoucher(CboMonth.ComboBox.SelectedValue.ToString());
            SelectVoucherSumDay(CboMonth.ComboBox.SelectedValue.ToString());
        }

        private void ShopView_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    {
                        this.Close();
                        break;
                    }
            }
        }
        private void GrdView_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            //DateTime ldDate = new DateTime();            
            //VoucherView frm = new VoucherView();
            ////frm.lsVouNO = GrdView.ActiveSheet.GetText(e.Row, 0);
            //ldDate = Convert .ToDateTime(GrdView.ActiveSheet.GetText(e.Row, 0));
            //frm.SetStartDate(Convert .ToDateTime(GrdView.ActiveSheet.GetText(e.Row, 0)));
            //frm.SetEndDate(Convert.ToDateTime(GrdView.ActiveSheet.GetText(e.Row, 0)));
            //frm.SetFlag();
            //frm.lsCounter = GrdView.ActiveSheet.GetText(e.Row, 1);
            //frm.ShowDialog(this);
            //SelectVoucher();


            Boolean lbTrue = true;
            string lsSheetName = GrdView.Sheets[0].Cells[e.Row, 1].Text;
            for (int j = 0; j <= GrdView.Sheets.Count - 1; j++)
            {
                if (lsSheetName == GrdView.Sheets[j].SheetName)
                {
                    lbTrue = false;
                }
            }
            if (lbTrue)
            {
                int i = GrdView.Sheets.Count + 1;
                GrdView.Sheets.Count = i;
                GrdView.Sheets[i - 1].SheetName = GrdView.Sheets[0].Cells[e.Row, 1].Text;
                SelectVoucherDetail(GrdView.Sheets[0].Cells[e.Row, 0].Text, i - 1);
            }
            else
            {
                MessageBox.Show("โรงแรมนี้ถูกเพิ่มไปแล้ว", "", MessageBoxButtons.OK);
            }
        }
        private void BtnOk_Click(object sender, EventArgs e)
        {
            SelectVoucher(CboMonth.ComboBox.SelectedValue.ToString());
            SelectVoucherSumDay(CboMonth.ComboBox.SelectedValue.ToString());
        }

        private void printToolStripButton_Click(object sender, EventArgs e)
        {
            GrdView.PrintSheet(GrdView.ActiveSheet);
        }

        private void GrdView_ActiveSheetChanged(object sender, EventArgs e)
        {
            if (GrdView.ActiveSheet.SheetName.ToLower() == "sheet1")
            {
                VisibleGbSum(true);
            }
            else if (GrdView.ActiveSheet.SheetName.ToLower() == "summary date")
            {
                VisibleGbSum(true);
            }
            else
            {
                VisibleGbSum(false);
            }
        }

        private void BtnRec_Click(object sender, EventArgs e)
        {
            ShopAdjust frm = new ShopAdjust();
            frm.Connnection = lsGdb.Gdb;
            frm.FlagHD = false;
            frm.ShowDialog(this);
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnKPS_Click(object sender, EventArgs e)
        {
            KingPowerGenData frm7 = new KingPowerGenData();
            frm7.ShowDialog(this);
        }

        private void Btnwebkps_Click(object sender, EventArgs e)
        {
            KingPowerWeb frm15 = new KingPowerWeb();
            //frm15.lsReportName = e.Node.Name;
            frm15.Show(this);
        }

        private void Btnsendemail_Click(object sender, EventArgs e)
        {
            ShopSendEmail FrmSemdEmail = new ShopSendEmail();
            FrmSemdEmail.Connnection = lsGdb.Gdb;
            FrmSemdEmail.ShowDialog(this);
        }

        private void BtnOffice_Click(object sender, EventArgs e)
        {
            ShopAdjust frm = new ShopAdjust();
            frm.Connnection = lsGdb.Gdb;
            frm.FlagHD = true;
            frm.ShowDialog(this);
        }

        private void CboYear_Click(object sender, EventArgs e)
        {

        }
    }
}