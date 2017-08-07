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
    public partial class AccMemberYear : Form
    {
        private int liColHotelCode = 0, liColMemNameE1 = 1, liColRoom = 2, liColMeeting = 5, liColSubTotal = 6, liColVAT = 7;
        private int liColTotal = 8, liColSale=4, liColMemberFee=3;
        Connection lsGdb = new Connection();
        Initial lsIniT = new Initial();
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
        public AccMemberYear()
        {
            InitializeComponent();
        }
        private void PaintGrdMain()
        {
            GrdView.Left = 12;
            GrdView.Height = this.Height - 100;
            GrdView.Width = this.Width - 30;
            GrdView.Sheets[0].SheetName = "Member";
            GrdView.Top = 35;
            GrdView.Left = 12;
            GrdView.Sheets[0].ColumnCount = 9;
            GrdView.Sheets[0].RowCount = 500;
            GrdView.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            GrdView.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            GrdView.Sheets[0].SetColumnWidth(liColHotelCode, 82);
            GrdView.Sheets[0].SetColumnWidth(liColMemNameE1, 260);
            GrdView.Sheets[0].SetColumnWidth(liColRoom, 50);
            GrdView.Sheets[0].SetColumnWidth(liColSale, 70);
            GrdView.Sheets[0].SetColumnWidth(liColMemberFee, 70);
            GrdView.Sheets[0].SetColumnWidth(liColMeeting, 60);
            GrdView.Sheets[0].SetColumnWidth(liColSubTotal, 80);
            GrdView.Sheets[0].SetColumnWidth(liColVAT, 65);
            GrdView.Sheets[0].SetColumnWidth(liColTotal, 90);
            FarPoint.Win.Spread.Column col;
            FarPoint.Win.Spread.CellType.TextCellType cell = new FarPoint.Win.Spread.CellType.TextCellType();
            col = GrdView.Sheets[0].Columns[liColMemNameE1, liColSubTotal];
            col.CellType = cell;
            FarPoint.Win.Spread.CellType.NumberCellType celldeposit = new FarPoint.Win.Spread.CellType.NumberCellType();
            GrdView.Sheets[0].Columns[liColVAT].CellType = celldeposit;
            GrdView.Sheets[0].Columns[liColMemNameE1, liColVAT].Locked = true;
            GrdView.Sheets[0].SetColumnLabel(0, liColHotelCode, "hotelcode");
            GrdView.Sheets[0].SetColumnLabel(0, liColMemNameE1, "Member Name E");
            GrdView.Sheets[0].SetColumnLabel(0, liColRoom, "Room");
            GrdView.Sheets[0].SetColumnLabel(0, liColMemberFee, "Member Fee ");
            GrdView.Sheets[0].SetColumnLabel(0, liColSale, "Sale ");
            GrdView.Sheets[0].SetColumnLabel(0, liColMeeting, "Meeting");
            GrdView.Sheets[0].SetColumnLabel(0, liColSubTotal, "Sub Total");
            GrdView.Sheets[0].SetColumnLabel(0, liColVAT, "VAT");
            GrdView.Sheets[0].SetColumnLabel(0, liColTotal, "Total");
            GrdView.AllowColumnMove = true;
            GrdView.Sheets[0].Columns[0].Visible = false;
        }
        private void SelectNewStatementMember()
        {
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Cursor.Show();
            Pb1.Visible = true;
            Int32 i = 0, j = 0;
            string lsSQL = "";
            double ldoMeeting = 0, ldoSale = 0, ldoMeetingSum = 0, ldoSaleSum = 0,ldoRoomSum=0, ldoRoom=0, ldoMemberFeeSum=0, ldoMemberFee=0, ldoVat=0, ldoVatSum=0, ldoSubTotal=0, ldoSubTotalSum=0, ldoTotal=0, ldoTotalSum=0;
            lsSQL = "Select count(*) as cnt From member Where flag in ('1','2') ";
            MySqlCommand lsComm1 = new MySqlCommand(lsSQL, lsGdb.Gdb);
            MySqlDataReader lsReadMain1;
            lsReadMain1 = lsComm1.ExecuteReader();
            if (lsReadMain1.HasRows)
            {
                while (lsReadMain1.Read())
                {
                    j = Convert.ToInt32(lsReadMain1["cnt"]);
                }
            }
            lsReadMain1.Close();
            GrdView.Sheets[0].RowCount = j + 1;
            Pb1.Minimum = 0;
            Pb1.Maximum = j;
            lsSQL = "Select memid, memnamee1, numroom From member Where flag in ('1','2') Order By memnamee1";
            MySqlCommand lsComm = new MySqlCommand(lsSQL, lsGdb.Gdb);
            MySqlDataReader lsReadMain;
            lsReadMain = lsComm.ExecuteReader();
            if (lsReadMain.HasRows)
            {
                ldoMeeting = Convert.ToDouble(TxtMeeting.Text);
                ldoMemberFee = Convert.ToDouble(TxtMemberFee.Text);
                while (lsReadMain.Read())
                {
                    ldoRoom = Convert.ToDouble(lsReadMain["numroom"]);
                    ldoSale = ldoRoom * Convert.ToDouble(TxtRoom.Text);
                    GrdView.Sheets[0].SetText(i, liColHotelCode, lsReadMain["memid"].ToString());
                    GrdView.Sheets[0].SetText(i, liColMemNameE1, lsReadMain["memnamee1"].ToString());
                    GrdView.Sheets[0].SetText(i, liColRoom, lsReadMain["numroom"].ToString());
                    GrdView.Sheets[0].SetText(i, liColSale, ldoSale.ToString());
                    GrdView.Sheets[0].SetText(i, liColMemberFee, ldoMemberFee.ToString());
                    GrdView.Sheets[0].SetText(i, liColMeeting, ldoMeeting.ToString());
                    ldoSubTotal = ldoRoom + ldoSale + ldoMeeting;
                    ldoVat = ldoSubTotal * Convert.ToDouble(TxtVatRate.Text) / 100;
                    ldoTotal = ldoSubTotal + ldoVat;
                    GrdView.Sheets[0].SetText(i, liColSubTotal, ldoSubTotal.ToString());
                    GrdView.Sheets[0].SetText(i, liColVAT, ldoVat.ToString());
                    GrdView.Sheets[0].SetText(i, liColTotal, ldoTotal.ToString());
                    ldoRoomSum = ldoRoomSum + ldoRoom;
                    ldoMeetingSum = ldoMeetingSum + ldoMeeting;
                    ldoMemberFeeSum = ldoMemberFeeSum + ldoMemberFee;
                    ldoSubTotalSum = ldoSubTotalSum + ldoSubTotal;
                    ldoSaleSum = ldoSaleSum + ldoSale;
                    ldoVatSum = ldoVatSum + ldoVat;
                    ldoTotalSum = ldoTotalSum + ldoTotal;
                    i++;
                    Pb1.Value = i;
                }
            }
            lsReadMain.Close();
            TxtMeetingSum.Text = ldoMeetingSum.ToString();
            TxtRoomSum.Text = ldoRoomSum.ToString();
            TxtMemberSum.Text = i.ToString();
            TxtMemberFeeSum.Text = ldoMemberFeeSum.ToString();
            TxtSaleSum.Text = ldoSaleSum.ToString();
            TxtVATSum.Text = ldoVatSum.ToString();
            TxtSubTotal.Text = ldoSubTotalSum.ToString();
            TxtTotal.Text = ldoTotalSum.ToString();
            if (GrdView.Sheets[0].RowCount > 29)
            {
                GrdView.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Always;
            }
            //lsConn.Gdb.Close();
            Pb1.Visible = false;
            Cursor.Current = System.Windows.Forms.Cursors.Default;
            Cursor.Show();
        }
        private void AccMemberYear_Load(object sender, EventArgs e)
        {
            Pb1.Visible = false;
            if (lsGdb.Gdb.State == ConnectionState.Closed)
            {
                lsGdb.ConnectDatabase();
            }
            lsIniT.CreateTblInitial(lsGdb.Gdb);
            lsGdb.SelectCbo(CboYear.ComboBox, "", Connection.TableIniT.YearName);
            GrdView.Top = this.Top + 35;
            GrdView.Left = this.Left + 15;
            GrdView.Height = this.Height - 100;
            GrdView.Width = this.Width - 25;
            GbSum.Top = 45;
            GbSum.Left = 800;
            CboYear.ComboBox.SelectedValue = Convert.ToString(DateTime.Today.Year + 543);
            PaintGrdMain();
        }
        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            SelectNewStatementMember();
        }

        private void GrdView_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            AccMemberYearDetail frm = new AccMemberYearDetail();
            frm.ShowDialog(this);
        }

        private void printToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void save_Click(object sender, EventArgs e)
        {

        }
    }
}