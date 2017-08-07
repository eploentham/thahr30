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
    public partial class AddressDistrict : Form
    {
        string lsFormName = "", lsStaffID = "", lsStaffName = "", lsCouCode="", lsProvCode="";
        Connection lsGdb = new Connection();
        IniFile lsIni = new IniFile();
        Boolean lbPageLoad = false;
        Int32 liColCode = 0, liColDistrictNameT = 1, liColDistrictNameE = 2, liColFlag = 4, liColPostCode=3, liColCouCode=5, liColProvCode=6, liColDistrictCode=7 ;
        FormName1 lfForm;
        Address lsTblAddress = new Address();
        public enum FormName1
        {
            FormDistrict, FormSubDistrict
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
        public string StaffID
        {
            get
            {
                return lsStaffID;
            }
            set
            {
                lsStaffID = value;
            }
        }
        public FormName1 FormName
        {
            get
            {
                return lfForm;
            }
            set
            {
                lfForm = value;
            }
        }
        private void PaintGrdView()
        {
            GrdView.Visible = false;
            GrdView.Reset();
            GrdView.BorderStyle = BorderStyle.None;
            GrdView.ActiveSheet.RowCount = 1;
            GrdView.ActiveSheet.ColumnCount = 8;
            GrdView.ActiveSheet.SetColumnWidth(liColDistrictCode, 200);
            GrdView.ActiveSheet.SetColumnWidth(liColDistrictNameT, 250);
            GrdView.ActiveSheet.SetColumnWidth(liColDistrictNameE, 150);
            GrdView.ActiveSheet.SetColumnWidth(liColPostCode, 150);
            GrdView.ActiveSheet.SetColumnLabel(0, liColDistrictCode, "รหัส");
            GrdView.ActiveSheet.SetColumnLabel(0, liColDistrictNameT, "ชื่อภาษาไทย");
            GrdView.ActiveSheet.SetColumnLabel(0, liColDistrictNameE, "Name English");
            GrdView.ActiveSheet.SetColumnLabel(0, liColPostCode , "Postcode");
            GrdView.ActiveSheet.SetColumnLabel(0, liColProvCode, "provcode");
            GrdView.ActiveSheet.SetColumnLabel(0, liColCouCode, "coucode");
            GrdView.ActiveSheet.SetColumnLabel(0, liColDistrictCode, "districtcode");
            GrdView.ActiveSheet.SetColumnLabel(0, liColFlag, "flag");
            FarPoint.Win.Spread.Column col;
            FarPoint.Win.Spread.CellType.TextCellType cell = new FarPoint.Win.Spread.CellType.TextCellType();
            col = GrdView.ActiveSheet.Columns[liColCode, liColDistrictCode];
            //col.Locked = true;
            col.CellType = cell;
            GrdView.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Off;
            GrdView.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            GrdView.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            GrdView.ActiveSheet.Columns[liColCode, liColDistrictCode].AllowAutoSort = true;
            GrdView.ActiveSheet.Columns[liColCode, liColDistrictCode].AllowAutoFilter = true;

            //GrdView.ActiveSheet.Columns[liColProvCode].Visible = false;
            //GrdView.ActiveSheet.Columns[liColCouCode].Visible = false;
            //GrdView.ActiveSheet.Columns[liColDistrictCode].Visible = false;

            GrdView.Visible = true;
        }
        private Boolean SaveDistrict()
        {
            string lsSQl = "", lsDistrictCode="", lsDistrictNameE="", lsDistrictNameT="", lsFlag="", lsPostCode="", lsCouCode="", lsProvcode = "";
            string lsSubDistrictCode = "";
            //Address ltbAddress = new Address();
            for (Int32 i = 0; i < GrdView.ActiveSheet.RowCount; i++)
            {
                lsDistrictCode = "";
                lsDistrictNameE = "";
                lsDistrictNameT = "";
                lsFlag = "";
                lsFlag = GrdView.ActiveSheet.GetText(i, liColFlag);
                if (lsFlag == "1")
                {
                    if (lfForm == FormName1.FormDistrict)
                    {
                        lsDistrictCode = GrdView.ActiveSheet.GetText(i, liColCode);
                        lsDistrictNameE = GrdView.ActiveSheet.GetText(i, liColDistrictNameE);
                        lsDistrictNameT = GrdView.ActiveSheet.GetText(i, liColDistrictNameT);
                        lsProvcode = GrdView.ActiveSheet.GetText(i, liColProvCode);
                        lsCouCode = GrdView.ActiveSheet.GetText(i, liColCouCode);
                        lsTblAddress.UpdateDistrict(lsCouCode, lsProvcode, lsDistrictCode, lsDistrictNameT, lsDistrictNameE, lsGdb.Gdb);
                    }
                    else
                    {
                        lsSubDistrictCode = GrdView.ActiveSheet.GetText(i, liColCode);
                        lsDistrictNameE = GrdView.ActiveSheet.GetText(i, liColDistrictNameE);
                        lsDistrictNameT = GrdView.ActiveSheet.GetText(i, liColDistrictNameT);
                        lsProvcode = GrdView.ActiveSheet.GetText(i, liColProvCode);
                        lsCouCode = GrdView.ActiveSheet.GetText(i, liColCouCode);
                        lsPostCode = GrdView.ActiveSheet.GetText(i, liColPostCode);
                        lsDistrictCode = GrdView.ActiveSheet.GetText(i, liColDistrictCode);
                        lsTblAddress.UpdateSubDistrict(lsCouCode , lsProvCode, lsDistrictCode, lsSubDistrictCode , lsDistrictNameT, lsDistrictNameE, lsPostCode, lsGdb.Gdb);
                    }
                }
            }
            return true;
        }
        private void SelectDistrict(string aProvCode, string aDistrictCode)
        {
            PaintGrdView();
            string lsSQL = "";
            Int32 i = 0;
            if (lfForm == FormName1.FormDistrict)
            {
                lsSQL = "Select count(*) as cnt From district Where provcode = '" + aProvCode + "'";
            }
            else
            {
                lsSQL = "Select count(*) as cnt From subdistrict Where provcode = '" + aProvCode + "' and districtcode = '"+aDistrictCode+"'";
            }
            MySqlCommand lsComm = new MySqlCommand(lsSQL, lsGdb.Gdb);
            MySqlDataReader lsRead;
            lsRead = lsComm.ExecuteReader();
            while (lsRead.Read())
            {
                i = Convert.ToInt32(lsRead.GetValue(0).ToString());
            }
            lsRead.Close();
            GrdView.ActiveSheet.RowCount = 0;
            GrdView.ActiveSheet.RowCount = i + 1;
            Pb1.Visible = true;
            if (lfForm == FormName1.FormDistrict)
            {
                lsSQL = "Select * From district Where provcode = '" + aProvCode + "' Order By districtnamet ";
            }
            else
            {
                lsSQL = "Select subdistrictcode as districtcode, subdistrictnamet as districtnamet, subdistrictnamee as districtnamee, postcode, coucode "
                    + "From subdistrict Where provcode = '" + aProvCode + "' and districtcode = '" 
                    + aDistrictCode + "' Order By subdistrictnamet";
            }
            lsComm.CommandText = lsSQL;
            lsRead = lsComm.ExecuteReader();
            i = 0;
            while (lsRead.Read())
            {
                //i++;
                lsSQL = lsRead.GetValue(0).ToString();
                GrdView.ActiveSheet.SetText(i, liColCode, lsRead["districtcode"].ToString());
                GrdView.ActiveSheet.SetText(i, liColDistrictNameT, lsRead["districtnamet"].ToString());
                GrdView.ActiveSheet.SetText(i, liColDistrictNameE, lsRead["districtnamee"].ToString());
                lsCouCode = lsRead["coucode"].ToString();
                lsProvCode = aProvCode;
                GrdView.ActiveSheet.SetText(i, liColCouCode, lsCouCode);
                GrdView.ActiveSheet.SetText(i, liColProvCode, lsProvCode); 
                if (lfForm == FormName1.FormSubDistrict)
                {
                    GrdView.ActiveSheet.SetText(i, liColPostCode, lsRead["postcode"].ToString());
                    GrdView.ActiveSheet.SetText(i, liColDistrictCode, aDistrictCode);
                }
                GrdView.ActiveSheet.SetText(i, liColFlag, "0");
                lsSQL = lsRead.GetValue(0).ToString();
                i++;
                Pb1.Value = i;
                if ((i % 2) != 0)
                {
                    GrdView.ActiveSheet.Rows[i].BackColor = Color.LightGoldenrodYellow;
                }
            }
            lsRead.Close();
            if (i > 30)
            {
                GrdView.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Always;
            }
            Pb1.Visible = false;
        }
        private void CloseForm()
        {
            this.Close();
        }
        public AddressDistrict()
        {
            InitializeComponent();
        }
        private void AddressDistrict_Load(object sender, EventArgs e)
        {
            lbPageLoad = true;
            GrdView.Height = this.Height - 120;
            GrdView.Width = this.Width - 30;
            PaintGrdView();
            if (lsGdb.Gdb.State == ConnectionState.Closed)
            {
                lsGdb.ConnectDatabase();
            }
            if (lfForm == FormName1.FormDistrict)
            {
                CboDistrict.Visible = false;
                lBDistrict.Visible = false;
            }
            else
            {
                CboDistrict.Visible = true;
                lBDistrict.Visible = true;
            }
            lsGdb.SelectCbo(CboProv.ComboBox, "", Connection.TableIniT.Province);
            SL1.Visible = false;
            Pb1.Visible = false;
            lbPageLoad = false;
        }
        private void Exit_Click(object sender, EventArgs e)
        {
            CloseForm();
        }
        private void search_Click(object sender, EventArgs e)
        {
            if (lfForm == FormName1.FormDistrict)
            {
                SelectDistrict(CboProv.ComboBox.SelectedValue.ToString(),"");
            }
            else
            {
                if (CboDistrict.Text != "")
                {
                    SelectDistrict(CboProv.ComboBox.SelectedValue.ToString(), CboDistrict.ComboBox.SelectedValue.ToString());
                }
            }
        }
        private void save_Click(object sender, EventArgs e)
        {
            if (SaveDistrict())
            {
                MessageBox.Show("บันทึกข้อมูลเรียบร้อย", "บันทึก", MessageBoxButtons.OK);
                if (lfForm == FormName1.FormDistrict)
                {
                    SelectDistrict(CboProv.ComboBox.SelectedValue.ToString(),"");
                }
                else
                {
                    SelectDistrict(CboProv.ComboBox.SelectedValue.ToString(), CboDistrict.ComboBox.SelectedValue.ToString());
                }
            }
        }
        private void GrdView_Change(object sender, FarPoint.Win.Spread.ChangeEventArgs e)
        {
            GrdView.ActiveSheet.SetText(e.Row, liColFlag, "1");
            GrdView.ActiveSheet.Cells[e.Row, liColCode, e.Row, liColFlag].ForeColor = Color.Red;
            GrdView.ActiveSheet.Cells[e.Row, liColCode, e.Row, liColFlag].Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
        }
        private void CboProv_DropDownClosed(object sender, EventArgs e)
        {
            if (lfForm == FormName1.FormSubDistrict)
            {
                lsGdb.SelectCbo(CboDistrict.ComboBox, CboProv.ComboBox.SelectedValue.ToString(), Connection.TableIniT.CboDistrictFromProvCode);
            }
            else if (lfForm == FormName1.FormDistrict)
            {
                SelectDistrict(CboProv.ComboBox.SelectedValue.ToString(), "");
            }
            else
            {
                if (CboDistrict.Text != "")
                {
                    SelectDistrict(CboProv.ComboBox.SelectedValue.ToString(), CboDistrict.ComboBox.SelectedValue.ToString());
                }
            }
        }
        private void CboProv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbPageLoad != true)
            {
                if (lfForm == FormName1.FormDistrict)
                {
                    SelectDistrict(CboProv.ComboBox.SelectedValue.ToString(), "");
                }
                else
                {
                    if (CboDistrict.Text != "")
                    {
                        SelectDistrict(CboProv.ComboBox.SelectedValue.ToString(), CboDistrict.ComboBox.SelectedValue.ToString());
                    }
                }
            }
        }
        private void NewDistrict_Click(object sender, EventArgs e)
        {
            if (lfForm == FormName1.FormDistrict)
            {
                GrdView.ActiveSheet.AddRows(0, 1);
                
                string lsMax = lsTblAddress.NewDistrictCode(CboProv.ComboBox.SelectedValue.ToString(), lsGdb.Gdb);
                //GrdView.ActiveSheet.RowCount = GrdView.ActiveSheet.RowCount + 1;
                GrdView.ActiveSheet.SetText(0, liColCode, lsMax);
                GrdView.ActiveSheet.SetText(0, liColCouCode, lsCouCode);
                GrdView.ActiveSheet.SetText(0, liColProvCode, lsProvCode);
                GrdView.ActiveSheet.SetActiveCell(0, liColDistrictNameE);
            }
            else
            {
                GrdView.ActiveSheet.AddRows(0, 1);
                //Address lsTblAddress = new Address();
                string lsMax = lsTblAddress.NewSubDistrictCode(CboDistrict.ComboBox.SelectedValue.ToString(), lsGdb.Gdb);
                //GrdView.ActiveSheet.RowCount = GrdView.ActiveSheet.RowCount + 1;
                GrdView.ActiveSheet.SetText(0, liColCode, lsMax);
                GrdView.ActiveSheet.SetText(0, liColCouCode, lsCouCode);
                GrdView.ActiveSheet.SetText(0, liColProvCode, lsProvCode);
                GrdView .ActiveSheet .SetText(0,liColDistrictCode ,CboDistrict.ComboBox.SelectedValue.ToString());
                GrdView.ActiveSheet.SetActiveCell(0, liColDistrictNameE);
            }
        }
    }
}