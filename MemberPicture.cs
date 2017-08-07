using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
namespace ThaHr30
{
    public partial class MemberPicture : Form
    {
        string lsSQL = "", lsFileName = "", lsPath = Application.StartupPath + "\\member", lsMemID = "";
        public string MemID
        {
            get
            {
                return lsMemID;
            }
            set
            {
                lsMemID = value.Trim();
            }
        }
        private void PaintGrdView()
        {
            //FarPoint.Win.Spread.Cell aCell;
            GrdView.Visible = false;
            PicView.Height = this.Height - 10;
            PicView.Width = this.Width - 220;
            PicView.Top = this.Top + 5;
            PicView.Left = this.Left + 5;
            GrdView.Left = this.Width - 190;
            GrdView.Top = PicView.Top;
            GrdView.Height = PicView.Height;
            GrdView.ActiveSheet.RowCount = 20;
            GrdView.ActiveSheet.ColumnCount = 2;
            FarPoint.Win.Spread.CellType.TextCellType cellText = new FarPoint.Win.Spread.CellType.TextCellType();
            GrdView.Sheets[0].Columns[0].CellType = cellText;
            FarPoint.Win.Spread.CellType.ImageCellType cellPic = new FarPoint.Win.Spread.CellType.ImageCellType();
            cellPic.Style = FarPoint.Win.RenderStyle.Stretch;
            GrdView.Sheets[0].Columns[1].CellType = cellPic;
            GrdView.ActiveSheet.SetColumnLabel(0, 0, " ");
            GrdView.ActiveSheet.SetColumnWidth(1, 185);
            GrdView.Sheets[0].SetRowHeight(1, 145);
            GrdView.Width = 185;
            GrdView.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Off;
            GrdView.BorderStyle = BorderStyle.None;
            GrdView.Sheets[0].RowHeader.Visible = false;
            GrdView.Sheets[0].ColumnHeader.Visible = false;
            GrdView.Sheets[0].Columns[0].Visible = false;
            //GrdView .setr
            GrdView.Visible = true;
        }
        private void LoadNewPict( string aFileName)
        {
            Int32 liHeight = 0;
            // You should replace the bold image 
            // in the sample below with an icon of your own choosing.
            // Note the escape character used (@) when specifying the path.
            //PicView.Image = Image.FromFile(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal)+ @"\Image.gif");
            Image img = Image.FromFile(aFileName);
            PicView.Image = img;
            PicView.SizeMode = PictureBoxSizeMode.StretchImage;
            //img.Dispose();
        }
        public string lsHotelCode = "";
        public bool ThumbnailCallback()
        {
            return false;
        }
        public MemberPicture()
        {
            InitializeComponent();
        }

        private void ViewPicture_Load(object sender, EventArgs e)
        {
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Cursor.Show();
            PaintGrdView();
            SelectPicture();
            Cursor.Current = System.Windows.Forms.Cursors.Default;
            Cursor.Show();
        }

        private void SelectPicture()
        {
            int i = 0;
            string lsFileName = "";
            Boolean lbFirst = true;
            DirectoryInfo lsDic = new DirectoryInfo(lsPath + "\\" + lsMemID + "\\");
            FileInfo[] fi = lsDic.GetFiles();
            foreach (FileInfo fiTemp in fi)
            {
                lsFileName = fiTemp.Name;
                GrdView.Sheets[0].SetText(i, 0, lsPath + "\\" + lsMemID + "\\" + lsFileName);
                if (lsFileName.ToLower() != "thumbs.db")
                {
                    Image img = Image.FromFile(lsPath + "\\" + lsMemID + "\\" + lsFileName);
                    GrdView.Sheets[0].Cells[i, 1].Value = img;
                    GrdView.Sheets[0].SetRowHeight(i, 145);
                    if (lbFirst)
                    {
                        LoadNewPict(lsPath + "\\" + lsMemID + "\\" + lsFileName);
                        lbFirst = false;
                    }
                }
                i++;
            }
        }

        private void ViewPicture_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    {
                        this.Hide();
                        break;
                    }
                case Keys.F2:
                    VoucherAdd lsReserveForm = new VoucherAdd();
                    lsReserveForm.ShowDialog(this);
                    break;
            }
        }
        private void GrdView_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Cursor.Show();
            LoadNewPict(GrdView.Sheets[0].GetText(e.Row ,0));
            Cursor.Current = System.Windows.Forms.Cursors.Default;
            Cursor.Show();
        }
    }
}