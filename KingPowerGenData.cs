using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Collections;
using MySql.Data.MySqlClient;

namespace ThaHr30
{
    public partial class KingPowerGenData : Form
    {
        Boolean lbPageLoad = false;
        Connection lsGdb = new Connection();
        Initial lsIniT = new Initial();
        IniFile lsIni = new IniFile("thahr30.ini");
        KingPower lsGen = new KingPower();
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
        string lsTextFileName = "", lsTextSaleFileName="";
        public KingPowerGenData()
        {
            InitializeComponent();
        }
        private void SendFlagKingPower(Boolean aFlag, string aMemId, FarPoint.Win.Spread.FpSpread aGrd )
        {
            string lsSQL = "", lsMemId = "", lsPlCode="", lsFlag="", lsFlagSend ="";
            lsMemId = aMemId;
            if (aFlag)
            {
                for (int i = 0; i <= aGrd.ActiveSheet.RowCount - 1; i++)
                {
                    lsPlCode = aGrd.ActiveSheet.GetText(i, 4);
                    lsFlag = aGrd.ActiveSheet.GetText(i, 5);
                    lsFlagSend = aGrd.ActiveSheet.GetText(i, 3);
                    if (lsFlagSend == "True")
                    {
                        lsFlagSend = "1";
                    }
                    else
                    {
                        lsFlagSend = "0";
                    }
                    if (lsFlag == "แก้ไข")
                    {
                        lsFlag = "2";
                    }
                    else
                    {
                        lsFlag = "1";
                    }
                    if (lsFlagSend != "1")
                    {
                        lsFlagSend = "2";
                    }
                        lsSQL = "Update memberpricelist Set flagoldkingpower = '" + lsFlag + "', flagsendkingpower = '"
                            + lsFlagSend + "' Where memid = '" + lsMemId + "' and plcode = '" + lsPlCode + "'";
                        MySqlCommand lsComm = new MySqlCommand(lsSQL, lsGdb.Gdb);
                        lsComm.ExecuteNonQuery();


                }
            }
            else
            {
                lsSQL = "Update memberpricelist Set flagoldkingpower = '1', flagsendkingpower = '1' Where memid = '" + lsMemId + "'";
                MySqlCommand lsComm = new MySqlCommand(lsSQL, lsGdb.Gdb);
                lsComm.ExecuteNonQuery();
            }
        }
        private void BtnMember_Click(object sender, EventArgs e)
        {
            BtnMember.Enabled = false;
            if (ChkMemAll.Checked)
            {
                PrepareDateMaster("masterall");
            }
            else
            {
                SendFlagKingPower(true, CboMember.SelectedValue.ToString(), GrdPriceList);
                PrepareDateMaster("mastersome");
                SendFlagKingPower(false, CboMember.SelectedValue.ToString(), GrdPriceList);
            }
            BtnMember.Enabled = true;
        }
        private void BtnAll_Click(object sender, EventArgs e)
        {
            BtnAll.Enabled = false;
            PrepareDateMaster("masterall");
            BtnAll.Enabled = true;
        }
        private void VisibleMemberSome(Boolean aflag)
        {
            if (aflag)
            {
                GbMemSome.Visible = true;
            }
            else
            {
                GbMemSome.Visible = false;
            }
        }
        private void PaintGrdPrice()
        {
            GrdPriceList.Visible = false;
            GrdPriceList.Reset();
            GrdPriceList.BorderStyle = BorderStyle.None;
            GrdPriceList.ActiveSheet.RowCount = 1;
            GrdPriceList.ActiveSheet.ColumnCount = 6;
            GrdPriceList.ActiveSheet.SetColumnWidth(0, 100);
            GrdPriceList.ActiveSheet.SetColumnWidth(1, 85);
            GrdPriceList.ActiveSheet.SetColumnWidth(2, 85);
            GrdPriceList.ActiveSheet.SetColumnWidth(3, 100);
            GrdPriceList.ActiveSheet.SetColumnWidth(5, 65);
            GrdPriceList.ActiveSheet.SetColumnLabel(0, 0, "ประเภทห้อง");
            GrdPriceList.ActiveSheet.SetColumnLabel(0, 1, "ราคาเริ่มต้น");
            GrdPriceList.ActiveSheet.SetColumnLabel(0, 2, "ราคาสิ้นสุด");
            GrdPriceList.ActiveSheet.SetColumnLabel(0, 3, " ");
            GrdPriceList.ActiveSheet.SetColumnLabel(0, 4, "plcode");
            GrdPriceList.ActiveSheet.SetColumnLabel(0, 5, "สถานะ");
            FarPoint.Win.Spread.Column col;
            FarPoint.Win.Spread.CellType.TextCellType cell = new FarPoint.Win.Spread.CellType.TextCellType();
            col = GrdPriceList.ActiveSheet.Columns[0, 2];
            col.Locked = true;
            col.CellType = cell;
            col = GrdPriceList.ActiveSheet.Columns[4];
            col.Locked = true;
            col.CellType = cell;
            FarPoint.Win.Spread.CellType.CheckBoxCellType cell3 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            col = GrdPriceList.ActiveSheet.Columns[3];
            cell3.TextTrue = "Gen Text File";
            cell3.TextFalse = "Gen Text File";
            col.CellType = cell3;
            FarPoint.Win.Spread.CellType.ComboBoxCellType cell5 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            cell5.Items = new string[] { "ใหม่", "แก้ไข" };
            col = GrdPriceList.ActiveSheet.Columns[5];
            col.CellType = cell5;
            GrdPriceList.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Off;
            GrdPriceList.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            GrdPriceList.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            GrdPriceList.Visible = true;
        }
        private void SelectPriceList( string aMemID)
        {
            PaintGrdPrice();
            GrdPriceList.ActiveSheet.RowCount = 19;
            string lsSQL = "";
            Int32 i = 0;
            lsSQL = "Select count(*) as cnt "
                + "From memberpricelist m, typeroom p Where memid = '" + aMemID + "' and m.plcode = p.plcode";
            MySqlCommand Comm1 = new MySqlCommand(lsSQL, lsGdb.Gdb);
            MySqlDataReader lsRead1;
            lsRead1 = Comm1.ExecuteReader();
            if (lsRead1.HasRows)
            {
                while (lsRead1.Read())
                {
                    i = Convert .ToInt32 ( lsRead1["cnt"]);
                }
            }
            lsRead1.Close();
            GrdPriceList.ActiveSheet.RowCount = i;
            i = 0;
            lsSQL = "Select m.memid, m.plcode, m.pricestart, m.priceend, m.remark, p.plnamee "
                + "From memberpricelist m, typeroom p Where memid = '" + aMemID + "' and m.plcode = p.plcode";
            MySqlCommand Comm = new MySqlCommand(lsSQL, lsGdb.Gdb);
            MySqlDataReader lsRead;
            lsRead = Comm.ExecuteReader();
            if (lsRead.HasRows)
            {
                while (lsRead.Read())
                {
                    lsSQL = lsRead["plnamee"].ToString();
                    GrdPriceList.ActiveSheet.SetText(i, 0, lsRead["plnamee"].ToString());
                    GrdPriceList.ActiveSheet.SetText(i, 1, lsRead["pricestart"].ToString());
                    GrdPriceList.ActiveSheet.SetText(i, 2, lsRead["priceend"].ToString());
                    GrdPriceList.ActiveSheet.SetText(i, 4, lsRead["plcode"].ToString());
                    GrdPriceList.ActiveSheet.SetText(i, 3, "1");
                    GrdPriceList.ActiveSheet.SetText(i, 5, "ใหม่");
                    i++;
                }
                //GrdView.DataSource = lsRead;
            }
            lsRead.Close();
            if (GrdPriceList.ActiveSheet.RowCount >= 6)
            {
                GrdPriceList.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Always;
            }
        }
        private void PrepareDateMaster(string aMaster)
        {            
            string lsServer = lsIni.GetString("thahr30", "serverdatabasename", "localhost");
            string lsDatabase = lsIni.GetString("thahr30", "databasename", "thahr3");
            string lsUserName = lsIni.GetString("thahr30", "username", "janepop");
            string lsPassword = lsIni.GetString("thahr30", "password", "Ekartc2c5");
            string lsSQL = "Select * From member ";
            MySqlConnection conn = new MySqlConnection("Data Source=" + lsServer + ";Database=" + lsDatabase + ";User ID="+lsUserName+";Password="+lsPassword+"");
            try
            {                
                conn.Open();
                if (aMaster == "masterall")
                {
                    lsSQL = "Select * From member ";
                }
                else
                {
                    lsSQL = "Select * From member Where memid = '" + CboMember.SelectedValue.ToString() + "'";
                }
                MySqlCommand lsComm = new MySqlCommand(lsSQL, conn);
                MySqlDataReader lsRead;
                lsRead = lsComm.ExecuteReader();
                //lsGen.CreateTextFile("master", lsRead);
                //lsSendVoucher.ConnectDatabase();
                if (lsGen.CreateTextProductFile("master", lsRead))
                {
                    lsTextFileName = lsGen.TextFileName;
                    MessageBox.Show("เตรียมข้อมูล เรียบร้อย", "Prepare Data All", MessageBoxButtons.OK);
                }
                lsRead.Close();
            }
            catch (MySqlException e)
            {
                string ls = "ไม่สามารถสร้าง เตรียมข้อมูล Master ได้ " ;
                lsGdb.WriteLogError(ls, e, "", "KingPowerGenData ");
                MessageBox.Show(ls + " " + e.Message.ToString(), e.Source.ToString(), MessageBoxButtons.OK);
            }
        }
        private void PrepareData_Load(object sender, EventArgs e)
        {
            lbPageLoad = true;
            Pb1.Visible = false;
            ChkMemSome.Checked = true;
            VisibleMemberSome(true);
            //lsGdb.ConnectDatabase();
            if (lsGdb.Gdb.State == ConnectionState.Closed)
            {
                lsGdb.ConnectDatabase();
            }
            lsGdb.SelectCbo(CboMember , "", Connection.TableIniT.Member);
            PaintGrdPrice();
            lbPageLoad = false;
        }
        private void BtnVoucher_Click(object sender, EventArgs e)
        {            
            BtnVoucher.Enabled = false;
            if (ChkRoomRate.Checked)
            {
                lsGen.lsCalAmt = "roomrate";
            }
            else 
            {
                lsGen.lsCalAmt = "roomrate1";
            }
            if (ChkExcludeVAT.Checked)
            {
                lsGen.lsFlagVAT = "exclude";
            }
            else
            {
                lsGen.lsFlagVAT = "include";
            }
            string lsVouDate = TxtDate.Value.Year.ToString("0000") + "-" + TxtDate.Value.Month.ToString("00") + "-" + TxtDate.Value.Day.ToString("00") + TxtDate.Value.Hour.ToString("00") + TxtDate.Value.Minute.ToString("00") + TxtDate.Value.Second.ToString("00");
            lsGen.Connnection = lsGdb.Gdb;
            if (lsGen.GenSaleDailyKingPower(lsVouDate))
            {
                MessageBox.Show("เตรียมข้อมูลเรียบร้อย", "gen text file", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("ไม่สามารถ เตรียมข้อมูลเรียบร้อย", "gen text file", MessageBoxButtons.OK);
            }
            lsTextSaleFileName = lsGen.TextSaleFileName;
            BtnVoucher.Enabled = true;
        }

        private void ChkMemAll_Click(object sender, EventArgs e)
        {
            VisibleMemberSome(false);
        }

        private void ChkMemSome_Click(object sender, EventArgs e)
        {
            VisibleMemberSome(true);
        }

        private void CboMember_SelectedValueChanged(object sender, EventArgs e)
        {
            if (lbPageLoad == false)
            {
                SelectPriceList(CboMember.SelectedValue.ToString());
            }
        }

        private void GrdPriceList_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {

        }

        private void BtnOpenMaster_Click(object sender, EventArgs e)
        {
            OpenTextFile();
        }

        private void OpenTextFile()
        {
            KingPowerOpenText frm = new KingPowerOpenText();
            frm.lsFileName = lsTextFileName;
            frm.Show(this);
        }
        private void OpenTextSaleFile()
        {
            KingPowerOpenText frm = new KingPowerOpenText();
            frm.lsFileName = lsTextSaleFileName;
            frm.Show(this);
        }
        private void BtnOpenSale_Click(object sender, EventArgs e)
        {
            OpenTextSaleFile();
        }

        private void ChkMemSome_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}