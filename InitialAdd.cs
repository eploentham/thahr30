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
    public partial class InitialAdd : Form
    {
        Int32 liMax = 0;
        Boolean lbSave = false;
        Initial lstblIni = new Initial();
        public string TableName="", ColumnCode="", ColumnNameE="", OrderBy="";
        Connection lsGdb = new Connection();
        public InitialAdd()
        {
            InitializeComponent();            
        }
        private void PaintGrdView()
        {
            //FarPoint.Win.Spread.Cell aCell;
            GrdView.Reset();
            GrdView.Visible = false;
            GrdView.ActiveSheet.RowCount = 1;
            GrdView.ActiveSheet.ColumnCount = 2;
            //GrdView.Height = this.Height - 150;
            //GrdView.Width = this.Width - 30;
            //GrdView.Top = 75;
            //GrdView.Left = 12;
            GrdView.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            GrdView.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            GrdView.ActiveSheet.SetColumnWidth(0, 35);
            GrdView.ActiveSheet.SetColumnWidth(1, 300);
            FarPoint.Win.Spread.Column col;
            FarPoint.Win.Spread.CellType.TextCellType cell = new FarPoint.Win.Spread.CellType.TextCellType();
            col = GrdView.ActiveSheet.Columns[1];
            col.CellType = cell;
            col = GrdView.ActiveSheet.Columns[0];
            col.CellType = cell;
            GrdView.ActiveSheet.Columns[0 , 0].Locked = true;
            GrdView.ActiveSheet.SetColumnLabel(0, 0, "NO");
            GrdView.ActiveSheet.SetColumnLabel(0, 1, "Name");
            GrdView.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Off;
            GrdView.BorderStyle = BorderStyle.None;
            GrdView.Visible = true;
        }
        private void SelectInitial()
        {
            PaintGrdView();            
            string lsSQL = "";
            Int32 i = 0;

            lsSQL = "Select count(*) as cnt From " + TableName;
            MySqlCommand Comm1 = new MySqlCommand(lsSQL, lsGdb.Gdb);
            MySqlDataReader lsRead1;
            lsRead1 = Comm1.ExecuteReader();
            while (lsRead1.Read())
            {
                i = Convert.ToInt32(lsRead1.GetValue(0).ToString());
            }
            lsRead1.Close();
            GrdView.ActiveSheet.RowCount = 0;
            GrdView.ActiveSheet.RowCount = i + 1;

            lsSQL = "Select "+ColumnCode +", "+ColumnNameE + " From "+ TableName                 
                + " Order By "+ OrderBy ;
            MySqlCommand Comm = new MySqlCommand(lsSQL, lsGdb.Gdb);
            MySqlDataReader lsRead;            
            lsRead = Comm.ExecuteReader();
            i = 0;
            //Pb1.Minimum = 0;
            //Pb1.Maximum = GrdView.ActiveSheet.RowCount;
            //Pb1.Visible = true;
            //SL1.Visible = true;
            while (lsRead.Read())
            {
                //i++;                
                lsSQL = lsRead.GetValue(0).ToString();
                GrdView.ActiveSheet.SetText(i, 0, lsRead.GetValue(0).ToString());
                GrdView.ActiveSheet.SetText(i, 1, lsRead.GetValue(1).ToString());                
                lsSQL = lsRead.GetValue(0).ToString();                
                i++;
                if ((i % 2) != 0)
                {
                    GrdView.ActiveSheet.Rows[i].BackColor = Color.LightGoldenrodYellow;
                }
                //GrdView.ActiveSheet.SetActiveCell(i, 1);
                //Pb1.Value = i;
                //SL1.Text = i.ToString() + " / " + (GrdView.ActiveSheet.RowCount - 1);
                //Application.DoEvents();
            }
            lsRead.Close();
        }
        private void InitialAdd_Load(object sender, EventArgs e)
        {
            lsGdb.ConnectDatabase();
            SelectInitial();
            lbSave = true;
        }

        private void save_Click(object sender, EventArgs e)
        {
            Int32 i = 0;            
            lstblIni.TableName = TableName;
            lstblIni.ColumnCode = ColumnCode;
            lstblIni.ColumnNameE = ColumnNameE;
            for (i = 0; i <= GrdView.ActiveSheet.RowCount-1; i++)
            {
                
                lstblIni.DataCode = GrdView.ActiveSheet.GetText(i, 0).ToString();
                lstblIni.DataNameE = GrdView.ActiveSheet.GetText(i, 1).ToString();
                //lstblIni.DataNameE = GrdView.ActiveSheet.GetValue(i, 1).ToString();
                lstblIni .DataFlag = "1";
                if (lstblIni.DataCode != "")
                {
                    lstblIni.CreateInitial(lsGdb.Gdb);
                }
            }
            MessageBox.Show("บันทึกข้อมูลเรียบร้อย", "บันทึก", MessageBoxButtons.OK);
            lbSave = true;
        }
        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            //GrdView.ActiveSheet.RowCount = GrdView.ActiveSheet.RowCount + 1;
            GrdView.ActiveSheet.Rows.Add(0, 1);
            if (lbSave)
            {
                liMax = Convert.ToInt32(lstblIni.SelectMax(TableName, lsGdb.Gdb));
            }            
            string lsMax ="";
            if (liMax >= 99)
            {
                //MessageBox.Show("can't add new nationality", "", MessageBoxButtons.OK);
                //this.Close();
                liMax = liMax + 11;
            }
            else
            {
                if ((lbSave) & (liMax > 83) & (liMax <99))
                {
                    liMax = liMax -10;
                }
            }
            liMax++;
            switch (TableName)
            {
                case "nationality":
                    {
                        lsMax = liMax.ToString("000");
                        break;
                    }
                default :
                    lsMax = liMax.ToString("00");
                    break;
            }            
            GrdView.ActiveSheet.SetText(0, 0, lsMax);
            if (GrdView.ActiveSheet.RowCount > 13)
            {
                GrdView.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Always;
            }
            //GrdView .ActiveSheet.Rows.a
            GrdView.ActiveSheet.SetActiveCell(0, 1, true);
            //GrdView .ActiveSheet.SetActiveCell (
            lbSave = false;
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}