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
    public partial class VoucherConfirm : Form
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
        public VoucherConfirm()
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
                TxtVouNO.Text = lsRead.GetValue(0).ToString();
                TxtCheckInDate.Value = Convert.ToDateTime(lsRead.GetValue(17).ToString());
                TxtCheckOutDate.Value = Convert.ToDateTime(lsRead.GetValue(18).ToString());
                TxtDepositAMT.Value = Convert.ToDecimal(lsRead.GetValue(16).ToString());
                TxtRoomRate.Value = Convert.ToDecimal(lsRead.GetValue(14).ToString());
                TxtRoomNO.Text = lsRead.GetValue(25).ToString();
                CboStaff.SelectedValue = lsRead.GetValue(1).ToString();
                CboStatus.SelectedValue = lsRead.GetValue(15).ToString();
                TxtConfirmedBy.Text = lsRead.GetValue(19).ToString();
                TxtRemark.Text = lsRead.GetValue(20).ToString();
                TxtRoomRate1.Value = Convert.ToDecimal(lsRead.GetValue(31).ToString());
            }
            lsRead.Close();
        }
        private void VoucherConfirm_Load(object sender, EventArgs e)
        {
            //lsGdb.ConnectDatabase();
            if (lsGdb.Gdb.State == ConnectionState.Closed)
            {
                lsGdb.ConnectDatabase();
            }
            lsGdb.SelectCbo(CboStaff, "", Connection.TableIniT.Staff);
            lsGdb.SelectCbo(CboStatus, "", Connection.TableIniT.Status);
            CboStaff.SelectedValue = "-";
            SelectVoucher(lsVouNO);
        }
        private void save_Click(object sender, EventArgs e)
        {
            Voucher lsVou = new Voucher();
            if (lsVou.ConfirmVoucher(TxtVouNO.Text, TxtConfirmedBy.Text, TxtRoomNO.Text, TxtRemark.Text, TxtRoomRate1.Value, lsGdb.Gdb))
            {
                MessageBox .Show ("Save OK","Confirm Voucher", MessageBoxButtons .OK );
                this.Hide();
            }
        }
        private void VoucherConfirm_KeyUp(object sender, KeyEventArgs e)
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

        private void TxtRoomNO_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    {
                        //TxtRoomRate1.SelectAll();
                        TxtRoomRate1.Focus();
                        break;
                    }
            }
        }

        private void TxtRoomRate1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    {
                        TxtConfirmedBy.SelectAll();
                        TxtConfirmedBy.Focus();
                        break;
                    }
            }
        }

        private void TxtRoomRate1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void TxtConfirmedBy_KeyUp(object sender, KeyEventArgs e)
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
    }
}