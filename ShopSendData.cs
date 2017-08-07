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
    public partial class ShopSendData : Form
    {
        Connection lsGdb = new Connection();
        public ShopSendData()
        {
            InitializeComponent();
        }
        private void PaintGrdView()
        {
            //FarPoint.Win.Spread.Cell aCell;            
            GrdSend.Visible = false;            
            GrdSend.ActiveSheet.RowCount = 13;
            GrdSend.ActiveSheet.ColumnCount = 4;
            GrdSend.Height = 682;
            GrdSend.Width = 1017;
            GrdSend.ActiveSheet.SetColumnWidth(0, 65);
            GrdSend.ActiveSheet.SetColumnWidth(1, 200);
            GrdSend.ActiveSheet.SetColumnWidth(2, 55);
            GrdSend.ActiveSheet.SetColumnWidth(3, 35);
            GrdSend.ActiveSheet.SetColumnLabel(0, 0, "Vou NO");
            GrdSend.ActiveSheet.SetColumnLabel(0, 1, "Guest Name");
            GrdSend.ActiveSheet.SetColumnLabel(0, 2, "Vou Date");
            GrdSend.ActiveSheet.SetColumnLabel(0, 3, "MAC");
            GrdSend.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Off;
            GrdSend.BorderStyle = BorderStyle.None;
            GrdSend.Visible = true;
        }
        private void VisibleCondition()
        {
            switch (CboTSend.Text )
            {
                case "ที่ยังไม่ได้ส่ง":
                    label3.Visible = false;
                    label4.Visible = false;
                    TxtStartDate.Visible = false;
                    TxtEndDate.Visible = false;
                    break ;
                case "ตั้งแต่วันที่ - ถึงวันที่":
                    label3.Visible = true;
                    label4.Visible = true;
                    TxtStartDate.Visible = true;
                    TxtEndDate.Visible = true;
                    break;
            }
        }
        private void BtnSend_Click(object sender, EventArgs e)
        {
            DialUP lsDial = new DialUP();
            Int32 liConnect = lsDial.DialUp();
            Int32 i = 0;
            DateTime ldDate = new DateTime();
            string lsSQL = "Select * From voucher Where flagsend = '2' Order By mac, vouno";
            BtnSend.Enabled = false;
            lsGdb.ConnectDatabase();
            switch (CboTSend.Text)
            {
                case "ที่ยังไม่ได้ส่ง":
                    lsSQL = "Select * From voucher Where flagsend = '2' Order By mac, vouno";
                    break;
                case "ตั้งแต่วันที่ - ถึงวันที่":
                    string lsStartDate, lsEndDate;
                    lsStartDate = TxtStartDate.Value.Year.ToString() + "-" + TxtStartDate.Value.Month.ToString() + "-" + TxtStartDate.Value.Day.ToString();
                    lsEndDate = TxtEndDate.Value.Year.ToString() + "-" + TxtEndDate.Value.Month.ToString() + "-" + TxtEndDate.Value.Day.ToString();
                    lsSQL = "Select * From voucher Where voudate >= '" 
                        + lsStartDate + "' and voudate <= '" + lsEndDate + "' Order By mac, vouno";
                    break;
            }            
            MySqlConnection ConnRemote = new MySqlConnection("Data Source=localhost;Database=thahr3;User ID=root;Password=Ekartc2c5");
            ConnRemote.Open();
            MySqlCommand lsComm = new MySqlCommand(lsSQL, ConnRemote);
            MySqlDataReader lsRead;
            lsRead = lsComm.ExecuteReader();
            Voucher lsSendVoucher = new Voucher();
            //lsSendVoucher.ConnectDatabase();
            while (lsRead.Read())
            {                
                lsSendVoucher.TableName = "sendvoucher";
                lsSendVoucher.HostName = "office";
                //lsSendVoucher.ConnectDatabase();
                lsSendVoucher.VouNO = lsRead["vouno"].ToString();
                lsSendVoucher.VouDate = Convert.ToDateTime(lsRead["voudate"].ToString());
                lsSendVoucher.VisitT = Convert.ToInt32(lsRead["visitt"].ToString());
                lsSendVoucher.GuestFirstName = lsRead["guestfirstname"].ToString();
                lsSendVoucher.GuestLastName = lsRead["guestlastname"].ToString();
                lsSendVoucher.ShiftCode = lsRead["shiftcode"].ToString();
                lsSendVoucher.ResRooms = Convert.ToInt32(lsRead["resrooms"].ToString());
                lsSendVoucher.ProvCode = lsRead["provcode"].ToString();
                lsSendVoucher.HotelCode = lsRead["hotelcode"].ToString();
                lsSendVoucher.RoomCode = lsRead["roomcode"].ToString();
                lsSendVoucher.ResTime = lsRead["restime"].ToString();
                if (lsRead.GetValue(17).ToString() != "")
                {
                    lsSendVoucher.CheckInTime = Convert.ToDateTime(lsRead["checkindate"].ToString());
                }
                else
                {
                    lsSendVoucher.CheckInTime = ldDate;
                }
                if (lsRead.GetValue(18).ToString() != "")
                {
                    lsSendVoucher.CheckOutTime = Convert.ToDateTime(lsRead["checkoutdate"].ToString());
                }
                else
                {
                    lsSendVoucher.CheckOutTime = ldDate;
                }
                lsSendVoucher.DepositAMT = Convert.ToDecimal(lsRead["depositamt"].ToString());
                lsSendVoucher.RoomRate = Convert.ToDecimal(lsRead["roomrate"].ToString());
                lsSendVoucher.StaffCode = lsRead["staffcode"].ToString();
                lsSendVoucher.StatusCode = lsRead["statuscode"].ToString();
                lsSendVoucher.ConfirmPerson = lsRead["confirmperson"].ToString();
                lsSendVoucher.Counter1 = lsRead["counter1"].ToString();
                lsSendVoucher.CouNO = lsRead["couno"].ToString();
                lsSendVoucher.NationCode = lsRead["nationcode"].ToString();
                lsSendVoucher.Remark = lsRead["remark"].ToString();
                lsSendVoucher.Flag = lsRead["flag"].ToString();
                lsSendVoucher.RoomNO = lsRead["roomno"].ToString();
                lsSendVoucher.MAC = lsRead["mac"].ToString();
                lsSendVoucher.CreateVoucher(ConnRemote);
                lsSendVoucher.UpdateFlagSend(ConnRemote);
                i++;
                GrdSend.ActiveSheet.Cells[i, 0].Text = lsSendVoucher.VouNO;
                GrdSend.ActiveSheet.Cells[i, 1].Text = lsSendVoucher.GuestFirstName + " " + lsSendVoucher.GuestLastName;
                GrdSend.ActiveSheet.Cells[i, 2].Text = lsSendVoucher.VouDate.ToShortDateString();
                GrdSend.ActiveSheet.Cells[i, 3].Text = lsSendVoucher.MAC;
            }
            lsRead.Close();
            BtnSend.Enabled = true;
        }
        private void SendData_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    {
                        this.Hide();
                        break;
                    }
            }
        }
        private void CboTSend_SelectedValueChanged(object sender, EventArgs e)
        {
            VisibleCondition();
        }
        private void SendData_Load(object sender, EventArgs e)
        {
            CboTSend.Text = "ที่ยังไม่ได้ส่ง";
            PaintGrdView();
        }
    }
}