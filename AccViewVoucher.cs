using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ThaHr30
{
    public partial class AccViewVoucher : Form
    {
        int liColVoucher = 1, liColDays = 2, liColPax = 3, liColDepositAMT = 6, liColDepositPay = 7, liColRoomRate = 4, liColRoomRate1 = 5;
        private void PaintGrdMain()
        {
            GrdView.Sheets[0].ColumnCount = 8;
            GrdView.Sheets[0].RowCount = 1;
            GrdView.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            GrdView.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            GrdView.Sheets[0].SetColumnWidth(liColVoucher, 70);
            GrdView.Sheets[0].SetColumnWidth(liColDays, 50);
            GrdView.Sheets[0].SetColumnWidth(liColPax, 50);
            GrdView.Sheets[0].SetColumnWidth(liColDepositAMT, 60);
            GrdView.Sheets[0].SetColumnWidth(liColDepositPay, 60);
            GrdView.Sheets[0].SetColumnWidth(liColRoomRate, 60);
            GrdView.Sheets[0].SetColumnWidth(liColRoomRate1, 60);

            FarPoint.Win.Spread.Column col;
            FarPoint.Win.Spread.CellType.TextCellType cell = new FarPoint.Win.Spread.CellType.TextCellType();
            GrdView.Sheets[0].Columns[liColVoucher].CellType = cell;
            FarPoint.Win.Spread.CellType.NumberCellType celldeposit = new FarPoint.Win.Spread.CellType.NumberCellType();
            GrdView.Sheets[0].Columns[liColDays, liColDepositPay].CellType = celldeposit;
            GrdView.Sheets[0].Columns[liColVoucher, liColDepositPay].Locked = true;

            GrdView.Sheets[0].SetColumnLabel(0, liColVoucher, "Voucher NO");
            GrdView.Sheets[0].SetColumnLabel(0, liColDays, "Days");
            GrdView.Sheets[0].SetColumnLabel(0, liColPax, "PAX");
            GrdView.Sheets[0].SetColumnLabel(0, liColRoomRate, "Rate");
            GrdView.Sheets[0].SetColumnLabel(0, liColRoomRate1, "Rate++");
            GrdView.Sheets[0].SetColumnLabel(0, liColDepositAMT, "Deposit");
            GrdView.Sheets[0].SetColumnLabel(0, liColDepositPay, "Pay/Rec");
            GrdView.AllowColumnMove = true;
            GrdView.Sheets[0].Columns[0].Visible = false;
        }
        public AccViewVoucher()
        {
            InitializeComponent();
        }

        private void TB1_Scroll(object sender, EventArgs e)
        {
            double ldoOpa = 0;
            ldoOpa = TB1.Value / 100;
            //this.Opacity = TB1.Value/100;
        }

        private void AccViewVoucher_Load(object sender, EventArgs e)
        {
            TB1.Minimum = 50;
            TB1.Maximum = 100;
            this.Opacity = .75;
            PaintGrdMain();
            GrdView.Focus();
        }

        private void AccViewVoucher_KeyUp(object sender, KeyEventArgs e)
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

        private void AccViewVoucher_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GrdView_Click(object sender, EventArgs e)
        {
            
        }

        private void GrdView_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            this.Close();
        }
    }
}