using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
namespace ThaHr30
{
    public partial class MemberSendEmailTO : Form
    {
        Connection gdb = new Connection();
        IniFile ini = new IniFile(Environment.CurrentDirectory+"\\thahr30.ini");
        private Int32 colFlag = 0, colEmail = 1, colEmailFlag = 2, rowgrdView = 1;
        public FarPoint.Win.Spread.FpSpread getGrd()
        {
            return GrdView;
        }
        public MemberSendEmailTO()
        {
            InitializeComponent();
        }
        private void CloseForm()
        {
            this.Close();
        }
        private void PaintGrdView()
        {
            //FarPoint.Win.Spread.Cell aCell;
            GrdView.Visible = false;
            GrdView.Reset();
            rowgrdView = 1;
            GrdView.ActiveSheet.RowCount = rowgrdView;
            GrdView.ActiveSheet.ColumnCount = 3;
            //GrdView.Height = this.Height - 60;
            //GrdView.Width = this.Width - 30;
            //GrdView.Top = 30;
            //GrdView.Left = 500;

            FarPoint.Win.Spread.CellType.TextCellType cellTxt = new FarPoint.Win.Spread.CellType.TextCellType();
            GrdView.Sheets[0].Columns[colEmail, colEmailFlag].CellType = cellTxt;
            //GrdView.Sheets[0].Columns[colMemID, colMemID].CellType = cellTxt;
            FarPoint.Win.Spread.CellType.CheckBoxCellType cellGrdCheck = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            cellGrdCheck.TextTrue = "use";
            cellGrdCheck.TextFalse = "use";
            GrdView.ActiveSheet.Columns[colFlag].CellType = cellGrdCheck;
            GrdView.ActiveSheet.SetColumnLabel(0, colFlag, "USE");
            GrdView.ActiveSheet.SetColumnLabel(0, colEmail, "EMail");
            GrdView.ActiveSheet.SetColumnLabel(0, colEmailFlag, "Flag");
            GrdView.ActiveSheet.SetColumnWidth(colFlag, 60);
            GrdView.ActiveSheet.SetColumnWidth(colEmail, 200);
            GrdView.ActiveSheet.SetColumnWidth(colEmail, 100);
            GrdView.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            GrdView.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            GrdView.Visible = true;
        }
        
        private void MemberSendEmailTO_Load(object sender, EventArgs e)
        {
            PaintGrdView();
            //ini = new IniFile(Environment.CurrentDirectory + "\\thahr30.ini");
            string aaa = "D:\thahr30\thahr30.ini";
            //aaa = aaa.Replace("EXE", "ini");
            //aaa = aaa.ToLower();
            string accessemail = ini.GetString("thahr30", "accessdatabaseemail", "D:\\thahr30\\email.mdb");
            string sql = "";
            OleDbConnection acc = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + accessemail + ";");
            acc.Open();
            OleDbCommand accCom = new OleDbCommand(sql, acc);
            sql = "Select locaprovname From members Group By locaprovname Order By locaprovname";
            accCom.CommandText = sql;
            OleDbDataReader rsacc;
            rsacc = accCom.ExecuteReader();
            if (rsacc.HasRows)
            {
                while (rsacc.Read())
                {
                    CboProvince.Items.Add(rsacc["locaprovname"].ToString());
                }
            }
            rsacc.Close();
            sql = "Select regname From members Group By regname Order By regname";
            accCom.CommandText = sql;
            
            rsacc = accCom.ExecuteReader();
            if (rsacc.HasRows)
            {
                while (rsacc.Read())
                {
                    cboRegion.Items.Add(rsacc["regname"].ToString());
                }
            }
            rsacc.Close();
            sql = "Select typecode From members Group By typecode Order By typecode";
            accCom.CommandText = sql;

            rsacc = accCom.ExecuteReader();
            if (rsacc.HasRows)
            {
                while (rsacc.Read())
                {
                    cboType.Items.Add(rsacc["typecode"].ToString());
                }
            }
            rsacc.Close();
            acc.Close();
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        private void btnProvinceOK_Click(object sender, EventArgs e)
        {
            if (chkProvinceAll.Checked)
            {
                for (int i = 0; i <= GrdView.Sheets[0].RowCount - 1; i++)
                {
                    if ((GrdView.Sheets[0].Cells[i, colFlag].Value!=null) 
                        && (Boolean)GrdView.Sheets[0].Cells[i, colFlag].Value == true
                        && (string)GrdView.Sheets[0].Cells[i, colEmail].Value != "ทั้งหมด"
                        && (string)GrdView.Sheets[0].Cells[i, colEmailFlag].Value == "จังหวัด")
                    {
                        GrdView.Sheets[0].Cells[i, colFlag].Value = false;
                    }
                }
                GrdView.Sheets[0].Cells[rowgrdView - 1, colFlag].Value = true;
                GrdView.Sheets[0].Cells[rowgrdView - 1, colEmailFlag].Value = "จังหวัด";
                GrdView.Sheets[0].Cells[rowgrdView - 1, colEmail].Value = "ทั้งหมด";
                rowgrdView++;
                GrdView.Sheets[0].RowCount = rowgrdView;
            }
            else
            {
                for (int i = 0; i <= GrdView.Sheets[0].RowCount - 1; i++)
                {
                    if ((GrdView.Sheets[0].Cells[i, colFlag].Value != null) 
                        && (Boolean)GrdView.Sheets[0].Cells[i, colFlag].Value == true
                        && (string)GrdView.Sheets[0].Cells[i, colEmail].Value == "ทั้งหมด"
                        && (string)GrdView.Sheets[0].Cells[i, colEmailFlag].Value == "จังหวัด")
                    {
                        GrdView.Sheets[0].Cells[i, colFlag].Value = false;
                    }
                }
                GrdView.Sheets[0].Cells[rowgrdView - 1, colFlag].Value = true;
                GrdView.Sheets[0].Cells[rowgrdView - 1, colEmailFlag].Value = "จังหวัด";
                ArrayList sendemail = gdb.MemberSendEmailSelect("province", CboProvince.SelectedItem.ToString()); 
                GrdView.Sheets[0].Cells[rowgrdView - 1, colEmail].Value = CboProvince.SelectedItem.ToString()+" ("+sendemail.Count.ToString()+")";
                rowgrdView++;
                GrdView.Sheets[0].RowCount = rowgrdView;
            }
            
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            PaintGrdView();
        }
        private void btnRegionOK_Click(object sender, EventArgs e)
        {
            if (chkRegionAll.Checked)
            {
                for (int i = 0; i <= GrdView.Sheets[0].RowCount - 1; i++)
                {
                    if ((GrdView.Sheets[0].Cells[i, colFlag].Value != null)
                        && (Boolean)GrdView.Sheets[0].Cells[i, colFlag].Value == true
                        && (string)GrdView.Sheets[0].Cells[i, colEmail].Value != "ทั้งหมด"
                        && (string)GrdView.Sheets[0].Cells[i, colEmailFlag].Value == "region")
                    {
                        GrdView.Sheets[0].Cells[i, colFlag].Value = false;
                    }
                }
                GrdView.Sheets[0].Cells[rowgrdView - 1, colFlag].Value = true;
                GrdView.Sheets[0].Cells[rowgrdView - 1, colEmailFlag].Value = "region";
                GrdView.Sheets[0].Cells[rowgrdView - 1, colEmail].Value = "ทั้งหมด";
                rowgrdView++;
                GrdView.Sheets[0].RowCount = rowgrdView;
            }
            else
            {
                for (int i = 0; i <= GrdView.Sheets[0].RowCount - 1; i++)
                {
                    if ((GrdView.Sheets[0].Cells[i, colFlag].Value != null)
                        && (Boolean)GrdView.Sheets[0].Cells[i, colFlag].Value == true
                        && (string)GrdView.Sheets[0].Cells[i, colEmail].Value == "ทั้งหมด"
                        && (string)GrdView.Sheets[0].Cells[i, colEmailFlag].Value == "region")
                    {
                        GrdView.Sheets[0].Cells[i, colFlag].Value = false;
                    }
                }
                GrdView.Sheets[0].Cells[rowgrdView - 1, colFlag].Value = true;
                GrdView.Sheets[0].Cells[rowgrdView - 1, colEmailFlag].Value = "region";
                ArrayList sendemail = gdb.MemberSendEmailSelect("region", cboRegion.SelectedItem.ToString());
                GrdView.Sheets[0].Cells[rowgrdView - 1, colEmail].Value = cboRegion.SelectedItem.ToString()+" ("+sendemail.Count.ToString()+")";
                rowgrdView++;
                GrdView.Sheets[0].RowCount = rowgrdView;
            }
        }
        private void btntypeOK_Click(object sender, EventArgs e)
        {
            if (chkRegionAll.Checked)
            {
                for (int i = 0; i <= GrdView.Sheets[0].RowCount - 1; i++)
                {
                    if ((GrdView.Sheets[0].Cells[i, colFlag].Value != null)
                        && (Boolean)GrdView.Sheets[0].Cells[i, colFlag].Value == true
                        && (string)GrdView.Sheets[0].Cells[i, colEmail].Value != "ทั้งหมด"
                        && (string)GrdView.Sheets[0].Cells[i, colEmailFlag].Value == "type")
                    {
                        GrdView.Sheets[0].Cells[i, colFlag].Value = false;
                    }
                }
                GrdView.Sheets[0].Cells[rowgrdView - 1, colFlag].Value = true;
                GrdView.Sheets[0].Cells[rowgrdView - 1, colEmailFlag].Value = "type";
                GrdView.Sheets[0].Cells[rowgrdView - 1, colEmail].Value = "ทั้งหมด";
                rowgrdView++;
                GrdView.Sheets[0].RowCount = rowgrdView;
            }
            else
            {
                for (int i = 0; i <= GrdView.Sheets[0].RowCount - 1; i++)
                {
                    if ((GrdView.Sheets[0].Cells[i, colFlag].Value != null)
                        && (Boolean)GrdView.Sheets[0].Cells[i, colFlag].Value == true
                        && (string)GrdView.Sheets[0].Cells[i, colEmail].Value == "ทั้งหมด"
                        && (string)GrdView.Sheets[0].Cells[i, colEmailFlag].Value == "type")
                    {
                        GrdView.Sheets[0].Cells[i, colFlag].Value = false;
                    }
                }
                GrdView.Sheets[0].Cells[rowgrdView - 1, colFlag].Value = true;
                GrdView.Sheets[0].Cells[rowgrdView - 1, colEmailFlag].Value = "type";
                ArrayList sendemail = gdb.MemberSendEmailSelect("type", cboType.SelectedItem.ToString());
                GrdView.Sheets[0].Cells[rowgrdView - 1, colEmail].Value = cboType.SelectedItem.ToString()+" ("+sendemail.Count.ToString()+")";
                rowgrdView++;
                GrdView.Sheets[0].RowCount = rowgrdView;
            }
        }
    }
}