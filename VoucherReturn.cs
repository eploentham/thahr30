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
    public partial class VoucherReturn : Form
    {
        Connection lsGdb = new Connection();
        IniFile lsIni = new IniFile("thahr30.ini");
        public string lsVouNO = "";
        public string lsServer, lsDatabase, lsCounter;
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
        public VoucherReturn()
        {
            InitializeComponent();
            lsServer = lsIni.GetString("thahr30", "serverdatabasename", "localhost");
            lsDatabase = lsIni.GetString("thahr30", "databasename", "thahr3");
            lsCounter = lsIni.GetString("thahr30", "counter", "001");
        }
        private void SelectVoucher(string aFlag)
        {
            string lsSQL = "";
            Int32 i = 0;
            
            //MySqlConnection Conn = new MySqlConnection("Data Source=" + lsServer + ";Database=" + lsDatabase + ";User ID=root;Password=Ekartc2c5");
            //Conn.Open();
            lsSQL = "Select * From voucher Where vouno = '" + aFlag + "'";
            MySqlCommand Comm = new MySqlCommand(lsSQL, lsGdb.Gdb);
            MySqlDataReader lsRead;
            lsRead = Comm.ExecuteReader();
            i = 0;
            while (lsRead.Read())
            {
                i++;
                TxtVouNO.Text = lsRead["vouno"].ToString();
                TxtCheckInDate.Text = lsRead["checkindate"].ToString();
                TxtCheckOutDate.Text = lsRead["checkoutdate"].ToString();
                TxtDepositAMT.Value = Convert.ToDecimal(lsRead["depositamt"].ToString());
                TxtRoomRate.Value = Convert.ToDecimal(lsRead["roomrate"].ToString());
                TxtStaff.Text = lsRead["staffcode"].ToString();
                TxtStatus.Text = lsRead["statuscode"].ToString();
                TxtRemark.Text = lsRead["remarkreturn"].ToString();
            }
        }
        private void VoucherReturn_Load(object sender, EventArgs e)
        {
            //lsGdb.ConnectDatabase();
            if (lsGdb.Gdb.State == ConnectionState.Closed)
            {
                lsGdb.ConnectDatabase();
            }
            SelectVoucher(lsVouNO);
        }

        private void save_Click(object sender, EventArgs e)
        {
            Voucher lsVou = new Voucher();
            if (lsVou.ReturnVoucher(TxtVouNO.Text,TxtRemark.Text,TxtReturnDate.Value, lsGdb.Gdb))
            {
                MessageBox.Show("Save OK", "Confirm Voucher", MessageBoxButtons.OK);
                this.Close();
            }
        }
    }
}