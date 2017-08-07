using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Reflection;
//using Outlook = Microsoft.Office.Interop.Outlook;
namespace ThaHr30
{
    public partial class MemberView : Form
    {
        private Int32 liColMemID = 0, liColMemNameE = 1, liColRoom = 2, liColRegion = 3, liColTMem = 4, liColHotelChain = 5, liColStar1 = 7, liColProvNameT=6;
        Int32 liColContactNameSkk9 = 8;
        Connection lsGdb = new Connection();
        Initial lsIniT = new Initial();
        IniFile lsIni = new IniFile();
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
        public MemberView()
        {
            InitializeComponent();
        }
        private void PaintGrdView()
        {
            
            //FarPoint.Win.Spread.Cell aCell;
            GrdView.Visible = false;
            GrdView.Reset();
            GrdView.ActiveSheet.RowCount = 1;
            GrdView.ActiveSheet.ColumnCount = 9;
            GrdView.Height = this .Height - GrdFilter.Height -60;
            GrdView.Width = this.Width - 30;
            GrdView.Top = 35;
            GrdView.Left = 12;
            FarPoint.Win.Spread.Column col;
            FarPoint.Win.Spread.CellType.TextCellType cell = new FarPoint.Win.Spread.CellType.TextCellType();
            col = GrdView.ActiveSheet.Columns[liColMemID, liColContactNameSkk9];
            col.CellType = cell;
            FarPoint.Win.Spread.CellType.NumberCellType cellNum = new FarPoint.Win.Spread.CellType.NumberCellType();
            col = GrdView.ActiveSheet.Columns[liColRoom];
            cellNum.DecimalPlaces = 0;
            col.CellType = cellNum;
            FarPoint.Win.Spread.CellType.ImageCellType cellImg = new FarPoint.Win.Spread.CellType.ImageCellType();
            col = GrdView.ActiveSheet.Columns[liColStar1];
            cellImg.Style = FarPoint.Win.RenderStyle.StretchAndScale;
            col.CellType = cellImg;
            GrdView.ActiveSheet.SetColumnWidth(liColMemID, 72);
            GrdView.ActiveSheet.SetColumnWidth(liColMemNameE, 300);
            GrdView.ActiveSheet.SetColumnWidth(liColRoom, 65);
            GrdView.ActiveSheet.SetColumnWidth(liColRegion, 150);
            GrdView.ActiveSheet.SetColumnWidth(liColTMem, 110);
            GrdView.ActiveSheet.SetColumnWidth(liColHotelChain, 150);
            GrdView.ActiveSheet.SetColumnWidth(liColStar1, 100);
            GrdView.ActiveSheet.SetColumnWidth(liColProvNameT, 110);
            GrdView.ActiveSheet.SetColumnLabel(0, liColMemID, "memid");
            GrdView.ActiveSheet.SetColumnLabel(0, liColMemNameE, "Member Name");
            GrdView.ActiveSheet.SetColumnLabel(0, liColRoom, "room");
            GrdView.ActiveSheet.SetColumnLabel(0, liColRegion, "Region");
            GrdView.ActiveSheet.SetColumnLabel(0, liColTMem, "Type Member");
            GrdView.ActiveSheet.SetColumnLabel(0, liColHotelChain, "Hotel Chain");
            GrdView.ActiveSheet.SetColumnLabel(0, liColStar1, "star");
            GrdView.ActiveSheet.SetColumnLabel(0, liColProvNameT, "province");
            GrdView.ActiveSheet.SetColumnLabel(0, liColContactNameSkk9, "ชื่อผู้แทน");
            GrdView.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Off;
            GrdView.BorderStyle = BorderStyle.None;
            GrdView.ActiveSheet.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            GrdView.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            GrdView.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            GrdView.Visible = true;
            //GrdView.Width = this.Width - 10;
            GrdFilter.ActiveSheet.RowCount = 0;
            GrdFilter.ActiveSheet.ColumnCount = 27;
            GrdFilter.Width = 1111;
            GrdFilter.Top = this .Height -80;
            GrdFilter.Left = 18;
            //GrdFilter.ActiveSheet.SetRowVisible(0, false);
            GrdFilter.ActiveSheet.RowHeaderVisible = false;
            //GrdFilter.h
            GrdFilter.Sheets[0].SetColumnLabel(0, 26, "ALL");
            GrdView.ActiveSheet.Columns[liColMemID, liColContactNameSkk9].AllowAutoSort = true;
            GrdView.ActiveSheet.Columns[liColMemID, liColContactNameSkk9].AllowAutoFilter = true;
            for (Int32 i = 0; i <= 26; i++)
            {
                GrdFilter.ActiveSheet.SetColumnWidth(i+1, 38);
            }
            GrdView.AllowColumnMove = true;
        }
        private Boolean SelectMember(string aColumn, string aMem)
        {
            if (lsGdb.Gdb.State == ConnectionState.Closed)
            {
                lsGdb.ConnectDatabase();
            }
            else
            {
                lsGdb.Gdb.Close();
                lsGdb.Gdb.Open();
                //lsGdb.ConnectDatabase();
            }
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Cursor.Show();
            PaintGrdView();
            Boolean lbReturn = true;
            string lsSQL = "", lsTMem="", lsRegionName="", lsSearch="";
            Int32 i = 0,j=0;
            //IniFile lsIni = new IniFile("thahr30.ini");
            //string lsServer = lsIni.GetString("thahr30", "serverdatabasename", "localhost");
            //string lsDatabase = lsIni.GetString("thahr30", "databasename", "thahr3");
            lsSearch = aMem.Replace("'", "''");
            if (aMem == "AA")
            {
                lsSQL = "Select count(*) cnt "
                    + "From member m left join hotelchain h on h.hotelchaincode =m.hotelchaincode left join province p on m.provcode = p.provcode "
                    + "Order By m.memnamee1";
            }
            else if (aMem == "modify")
            {
                lsSQL = "Select count(*) cnt "
                    + "From member m left join hotelchain h on h.hotelchaincode =m.hotelchaincode left join province p on m.provcode = p.provcode "
                    + "Where m.flag = '1' "//+ "Where flagoutlook = '1' "
                    + "Order By m.memnamee1";
            }
            else
            {
                lsSQL = "Select count(*) cnt "
                    + "From member m left join hotelchain h on h.hotelchaincode =m.hotelchaincode left join province p on m.provcode = p.provcode "
                    + "Where " + aColumn + " like '" + lsSearch + "%' "
                    + "Order By m.memnamee1";
            }
            MySqlCommand lsComm = new MySqlCommand(lsSQL, lsGdb.Gdb);
            MySqlDataReader lsRead;
            lsRead = lsComm.ExecuteReader();
            while (lsRead.Read())
            {
                i = Convert.ToInt32(lsRead["cnt"].ToString());
            }
            lsRead.Close();
            GrdView.ActiveSheet.RowCount = i + 1;
            if (aMem == "AA")
            {
                lsSQL = "Select memid, memnamee1, numroom, m.tmemcode, hotelchainname, star, m.regioncode, p.provnamet, m.flagresign, m.flagsale "
                    + "From member m left join hotelchain h on h.hotelchaincode =m.hotelchaincode left join province p on m.provcode = p.provcode "
                    //+ "Where c.contactid = (select c.contactid From contact c where c.refid = m.memid and c.flagskk9 ='1' having max(contactid)) "
                    + "Order By m.memnamee1";
            }
            else if (aMem == "")
            {
                lsSQL = "Select memid, memnamee1, numroom, m.tmemcode, hotelchainname, star, m.regioncode, p.provnamet, m.flagresign, m.flagsale "
                    + "From member m left join hotelchain h on h.hotelchaincode =m.hotelchaincode left join province p on m.provcode = p.provcode "
                    + "Where m.flag = '1' "//+ "Where flagoutlook = '1' "
                    + "Order By m.memnamee1";
            }
            else
            {
                lsSQL = "Select memid, memnamee1, numroom, m.tmemcode, hotelchainname, star, m.regioncode, p.provnamet, m.flagresign, m.flagsale "
                    + "From member m left join hotelchain h on h.hotelchaincode =m.hotelchaincode left join province p on m.provcode = p.provcode "
                    + "Where " + aColumn + " like '" + lsSearch + "%' "
                    + "Order By m.memnamee1";
            }
            lsComm.CommandText = lsSQL;
            lsRead = lsComm.ExecuteReader();
            i = 0;
            Pb1.Minimum = 0;
            Pb1.Maximum = GrdView.ActiveSheet.RowCount;
            Pb1.Visible = true;
            SL1.Visible = true;
            if (lsRead.HasRows)
            {
                while (lsRead.Read())
                {
                    j = i;
                    //if (lsRead["memid"].ToString() == "00774")
                    //{
                    //    lsSQL = "";
                    //}
                    lsTMem = lsIniT.SelectInitial(lsIniT.TblTypeMem, lsRead["tmemcode"].ToString(), Initial.WhereSelect.aCodetoName);
                    lsRegionName = lsIniT.SelectInitial(lsIniT.TblRegion, lsRead["regioncode"].ToString(), Initial.WhereSelect.aCodetoName);
                    GrdView.ActiveSheet.SetText(i, liColMemID, lsRead["memid"].ToString());
                    GrdView.ActiveSheet.SetText(i, liColMemNameE, lsRead["memnamee1"].ToString());
                    GrdView.ActiveSheet.SetText(i, liColRoom, lsRead["numroom"].ToString());
                    GrdView.ActiveSheet.SetText(i, liColRegion, lsRegionName);
                    GrdView.ActiveSheet.SetText(i, liColTMem, lsTMem);
                    GrdView.ActiveSheet.SetText(i, liColHotelChain, lsRead["hotelchainname"].ToString());
                    GrdView.ActiveSheet.SetText(i, liColStar1, lsRead["star"].ToString());
                    GrdView.ActiveSheet.SetText(i, liColProvNameT, lsRead["provnamet"].ToString());
                    //GrdView.ActiveSheet.SetText(i, liColContactNameSkk9, lsRead["contactnamet"].ToString() + " " + lsRead["contactsurnamet"].ToString());
                    //GrdView.ActiveSheet.SetActiveCell(i, 1);
                    Pb1.Value = i;
                    SL1.Text = i.ToString() + " / " + (GrdView.ActiveSheet.RowCount - 1);
                    j = i % 2;
                    if ((j % 2) != 0)
                    {
                        GrdView.ActiveSheet.Rows[i].BackColor = Color.LightGoldenrodYellow;
                    }
                    if (lsRead["flagresign"].ToString() == "1")
                    {
                        GrdView.ActiveSheet.Rows[i].BackColor = Color.RosyBrown;
                    }
                    else if (lsRead["flagsale"].ToString() == "0")
                    {
                        GrdView.ActiveSheet.Rows[i].BackColor = Color.BurlyWood;
                    }
                    switch (lsRead["star"].ToString())
                    {
                        case "1":
                            {
                                GrdView.ActiveSheet.SetValue(i, liColStar1, Img1.Images[0]);
                                break;
                            }
                        case "2":
                            {
                                GrdView.ActiveSheet.SetValue(i, liColStar1, Img2.Images[0]);
                                break;
                            }
                        case "3":
                            {
                                GrdView.ActiveSheet.SetValue(i, liColStar1, Img3.Images[0]);
                                break;
                            }
                        case "4":
                            {
                                GrdView.ActiveSheet.SetValue(i, liColStar1, Img4.Images[0]);
                                break;
                            }
                        case "5":
                            {
                                GrdView.ActiveSheet.SetValue(i, liColStar1, Img5.Images[0]);
                                break;
                            }
                    }
                    i++;
                    //Application.DoEvents();
                }
            }
            else
            {
                lbReturn = false;
            }
            Pb1.Visible = false;
            SL1.Visible = false;
            lsRead.Close();
            Cursor.Current = System.Windows.Forms.Cursors.Default;
            Cursor.Show();
            return lbReturn;
        }
        private void MemberView_Load(object sender, EventArgs e)
        {
            PaintGrdView();
            Pb1.Visible = false;
            SL1.Visible = false;
            if (lsGdb.Gdb.State == ConnectionState.Closed)
            {
                if (lsGdb.ConnectDatabase() == false)
                {
                    CloseForm();
                }
            }
            else
            {
                lsGdb.Gdb.Close();
                lsGdb.Gdb.Open();
                //lsGdb.ConnectDatabase();
            }
            lsGdb.SelectCbo(CboFilter.ComboBox, "cbomemviewfilter", Connection.TableIniT.CboMemViewFilter);
            lsIniT.CreateTblInitial(lsGdb.Gdb);
            CboFilter.ComboBox.Width = 275;
            //label1.Text = this .w
        }
        private void GrdFilter_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            //MessageBox.Show(e.Column.ToString(), GrdView.ActiveSheet.GetColumnAutoText(e.Column ));
            SelectMember("memnamee1", GrdView.ActiveSheet.GetColumnAutoText(e.Column));
        }
        private void GrdView_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            //MessageBox .Show ( GrdView.ActiveSheet.GetText(e.Row, 0));
            MemberAdd frm = new MemberAdd();
            frm.Connnection = lsGdb.Gdb;
            frm.lsMemID = GrdView.ActiveSheet.GetText(e.Row, 0);
            frm.Show(this);
            //frmMemAdd.Activate();
        }

        private void MemberView_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    {
                        this.CloseForm();
                        break;
                    }
            }
        }
        private void NewMember_Click(object sender, EventArgs e)
        {
            MemberAdd Frm = new MemberAdd();
            Frm.Connnection = lsGdb.Gdb;
            Frm.ShowDialog(this);
            SelectMember("memnamee1", Frm.lsMemNameE);
        }

        private void CboFilter_Click(object sender, EventArgs e)
        {

        }
        private void Exit_Click(object sender, EventArgs e)
        {
            CloseForm();
        }
        private void CloseForm()
        {
            this.Close();
        }

        private void TxtSearch_Click(object sender, EventArgs e)
        {

        }

        private void TxtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    if (SelectMember("memnamee1", TxtSearch.Text)==false)
                    {
                        SelectMember("memid", TxtSearch.Text);
                    }
                    break;
            }
        }

        private void GrdView_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {

        }
        //private void UpdateOutlookContact()
        //{
        //    Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
        //    Cursor.Show();
        //    string lsMemNameE = "", lsEMail = "", lsMemID = "", lsSQL = "", lsFirstName = "", lsLastName = "", lsPositionT = "";
        //    string lsWebsite = "", lsMobile = "", lsTele = "", lsLine1 = "";
        //    Boolean lbFind = false, lbSuccess = false;
        //    // Create the Outlook application.
        //    Outlook.Application oApp = new Outlook.Application();

        //    // Get the NameSpace and Logon information.
        //    Outlook.NameSpace oNS = oApp.GetNamespace("mapi");
        //    Outlook.MAPIFolder DL = oNS.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderContacts);
        //    Outlook.Items ItemDL = DL.Items;           
            
        //    // Log on by using a dialog box to choose the profile.
        //    string lsProfileOutlook = lsIni.GetString("thahr30", "profileoutlook", "1");
        //    string lsPasswordProfile = lsIni.GetString("thahr30", "passwordprofile", "1");
        //    //oNS.Logon(lsProfileOutlook, lsPasswordProfile, true, true);
        //    oNS.Logon(Missing.Value, Missing.Value, true, true);
        //    MySqlCommand lsComm = new MySqlCommand(lsSQL, lsGdb.Gdb);
        //    MySqlDataReader lsRead;
        //    Pb1.Visible = true;
        //    Pb1.Maximum = GrdView.ActiveSheet.RowCount - 1;
        //    for (Int32 i = 0; i <= GrdView.ActiveSheet.RowCount - 1; i++)
        //    {
        //        try
        //        {
        //            lsMemNameE = GrdView.ActiveSheet.GetText(i, liColMemNameE);
        //            lsMemID = GrdView.ActiveSheet.GetText(i, liColMemID);
        //            lsSQL = "Select * from contact Where refid = '" + lsMemID + "'";
        //            lsComm.CommandText = lsSQL;
        //            lsRead = lsComm.ExecuteReader();
        //            if (lsRead.HasRows)
        //            {
        //                while (lsRead.Read())
        //                {
        //                    lsEMail = "";
        //                    lsEMail = lsRead["email"].ToString();
        //                    lsPositionT = lsRead["positiont"].ToString();
        //                    lsFirstName = lsRead["contactnamet"].ToString();
        //                    lsLastName = lsRead["contactsurnamet"].ToString();
        //                    lsLine1 = lsRead["line1"].ToString();
        //                    lsTele = lsRead["telephone"].ToString();
        //                    lsMobile = lsRead["mobile"].ToString();
        //                    lsWebsite = "";
        //                    if (lsEMail != "")
        //                    {
        //                        Outlook.ContactItem contact = oApp.GetNamespace("mapi").GetDefaultFolder(Outlook.OlDefaultFolders.olFolderContacts)
        //                            .Items.Find(string.Format("[e-mail]='{0}' ", lsEMail)) as Outlook.ContactItem;
        //                        //Outlook.ContactItem contact = oApp.GetNamespace("mapi").GetDefaultFolder(Outlook.OlDefaultFolders.olFolderContacts)
        //                        //    .Items.Find(string.Format("[LastName]='{0}' AND [FirstName]='{1}'", TxtContactSurNameT.Text, TxtContactNameT.Text)) as Outlook.ContactItem;
        //                        if (contact != null)
        //                        {
        //                            contact.Delete();
        //                        }
        //                        // Alternate logon method that uses a specific profile.
        //                        // TODO: If you use this logon method, 
        //                        //  change the profile name to an appropriate value.
        //                        //oNS.Logon("YourValidProfile", Missing.Value, false, true);
        //                        Outlook.ContactItem OContact = (Outlook.ContactItem)oApp.CreateItem(Outlook.OlItemType.olContactItem);
        //                        OContact.FirstName = lsFirstName;
        //                        OContact.LastName = lsLastName;
        //                        OContact.CompanyName = lsMemNameE;
        //                        OContact.MobileTelephoneNumber = lsMobile;
        //                        OContact.WebPage = lsWebsite;
        //                        OContact.HomeTelephoneNumber = lsTele;
        //                        OContact.Email1Address = lsEMail;
        //                        OContact.HomeAddress = lsLine1;
        //                        OContact.JobTitle = lsPositionT;
        //                        OContact.Save();
        //                    }
        //                }
        //            }
        //            lsRead.Close();

        //            Int32 li = 0;
        //            string ls = "";

        //            Outlook.DistListItem oDistList = (Outlook.DistListItem)oApp.CreateItem(Outlook.OlItemType.olDistributionListItem);
        //            oDistList.DLName = lsMemNameE;
        //            ////oDistList.Delete();
        //            //Int32 liCount = ItemDL.Count;
        //            //lbFind = false;

                    
        //            foreach (object item in DL.Items)
        //            {
        //                lbFind = false;
        //                if (item is Outlook.DistListItem)
        //                {
        //                    li++;
        //                    ls = "";

        //                    Outlook.DistListItem list = (Outlook.DistListItem)item;
        //                    ls = list.DLName;
        //                    if (ls == lsMemNameE)
        //                    {
        //                        list.Delete();
        //                        break;
        //                    }
        //                }
        //            }

        //            //object item1 = new object();
        //            //item1 = DL.Items;
        //            //Outlook.DistListItem list1 = (Outlook.DistListItem)item1;
        //            //ls = list1.DLName;
        //            //if (ls == lsMemNameE)
        //            //{
        //            //    list1.Delete();
        //            //}


        //            //    }
        //            //}
        //            //foreach (object item in DL.Items)
        //            //{
        //            //    lbFind = false;
        //            //    if (item is Outlook.DistListItem)
        //            //    {
        //            //        li++;
        //            //        ls = "";

        //            //        Outlook.DistListItem list = (Outlook.DistListItem)item;
        //            //        ls = list.DLName;
        //            //        if (ls == lsMemNameE)
        //            //        {
        //            //            if (lbFind == false)
        //            //            {
        //            //                //list.Delete();
        //            //            }

        //            //            lbFind = true;
        //                        //for (int li1 = 0; li1 <= list.MemberCount; li1++)
        //                        //{
        //                        //    string name = null;
        //                        //    string phoneNo = null;

        //                        //    Outlook.Recipient recipient = list.GetMember(li1);
        //                        //    if (recipient != null)
        //                        //    {
        //                        //        string email = recipient.Address;

        //                        //        object o = DL.Items.Find("[Email1Address] = '" + email + "'");
        //                        //        if (o is Outlook.ContactItem)
        //                        //        {

        //                        //            name = ((Outlook.ContactItem)o).FullName;
        //                        //            phoneNo = ((Outlook.ContactItem)o).MobileTelephoneNumber;
        //                        //            try
        //                        //            {
        //                        //                //Add the items to a data table.
        //                        //            }
        //                        //            catch
        //                        //            { }
        //                        //        }
        //                        //    }
        //                        //}
        //                    //}
        //                    //lsSQL = "Select * from contact Where refid = '" + lsMemID + "'";
        //                    //lsComm.CommandText = lsSQL;
        //                    //lsRead = lsComm.ExecuteReader();
        //                    //if (lsRead.HasRows)
        //                    //{
        //                    //    lsEMail = "";
        //                    //    lsFirstName = "";
        //                    //    lsLastName = "";
        //                    //    while (lsRead.Read())
        //                    //    {
        //                    //        lsEMail = lsRead["email"].ToString();
        //                    //        lsPositionT = lsRead["positiont"].ToString();
        //                    //        lsFirstName = lsRead["contactnamet"].ToString();
        //                    //        lsLastName = lsRead["contactsurnamet"].ToString();
        //                    //        if (lsEMail != "")
        //                    //        {
        //                    //            Outlook.Recipient aaa;
        //                    //            aaa = oApp.Session.CreateRecipient(lsFirstName + " " + lsLastName);
        //                    //            aaa.Resolve();
        //                    //            //Outlook.DistListItem oDistList = (Outlook.DistListItem)oApp.de
        //                    //            oDistList.AddMember(aaa);
        //                    //            oDistList.Save();
        //                    //        }
        //                    //    }
        //                    //}
        //                    //lsRead.Close();
                        
        //            lsSQL = "Select * from contact Where refid = '" + lsMemID + "'";
        //            lsComm.CommandText = lsSQL;
        //            lsRead = lsComm.ExecuteReader();
        //            if (lsRead.HasRows)
        //            {
        //                lsEMail = "";
        //                lsFirstName = "";
        //                lsLastName = "";
        //                while (lsRead.Read())
        //                {
        //                    lsEMail = lsRead["email"].ToString();
        //                    lsPositionT = lsRead["positiont"].ToString();
        //                    lsFirstName = lsRead["contactnamet"].ToString();
        //                    lsLastName = lsRead["contactsurnamet"].ToString();
        //                    if (lsEMail != "")
        //                    {
        //                        Outlook.Recipient aaa;
        //                        aaa = oApp.Session.CreateRecipient(lsFirstName + " " + lsLastName);
        //                        aaa.Resolve();
        //                        //Outlook.DistListItem oDistList = (Outlook.DistListItem)oApp.de
        //                        oDistList.AddMember(aaa);
        //                        oDistList.Save();
        //                    }
        //                }
        //            }
        //            lsRead.Close();
        //            //oDistList.Save();
        //            //if (lbFind == false)
        //            //{
        //            //Outlook.Recipient aaa;
        //            //aaa = oApp.Session.CreateRecipient(lsFirstName + " " + lsLastName);
        //            //aaa.Resolve();
        //            //Outlook.DistListItem oDistList = (Outlook.DistListItem)oApp.CreateItem(Outlook.OlItemType.olDistributionListItem);
        //            ////Outlook.DistListItem oDistList = (Outlook.DistListItem)oApp.de
        //            //oDistList.DLName = lsMemNameE;
        //            //oDistList.AddMember(aaa);
        //            //oDistList.Save();
        //            //}
        //            lbSuccess = true;
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine("{0} Exception caught.", ex);
        //            MessageBox.Show(ex.Message.ToString(), ex.Source.ToString());
        //        }
        //        Application.DoEvents();
        //        Pb1.Value = i;
        //    }
        //    Pb1.Visible = false;
        //    Cursor.Current = System.Windows.Forms.Cursors.Default;
        //    Cursor.Show();
        //    if (lbSuccess)
        //    {
        //        MessageBox.Show("Update Outlook success", "");
        //    }
        //}
        //private void CreateDistributionlist()
        //{
        //    Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
        //    Cursor.Show();
        //    Int32 li = 0, liCnt=0,i=0;
        //    Boolean lbFind = false,lbSuccess = false; ;
        //    string lsSQL = "", lsRegionName = "", ls = "", lsRegionCode = "", lsPositionT="", lsFirstName = "", lsLastName="", lsEMail="";
        //    Outlook.Application oApp = new Outlook.Application();

        //    // Get the NameSpace and Logon information.
        //    Outlook.NameSpace oNS = oApp.GetNamespace("mapi");

        //    // Log on by using a dialog box to choose the profile.
        //    string lsServer = lsIni.GetString("thahr30", "serverdatabasename", "localhost");
        //    string lsDatabase = lsIni.GetString("thahr30", "databasename", "thahr3");
        //    string lsUserName = lsIni.GetString("thahr30", "username", "janepop");
        //    string lsPassword = lsIni.GetString("thahr30", "password", "Ekartc2c5");
        //    string lsCharSet = lsIni.GetString("thahr30", "charset", "tis620");
        //    string lsProfileOutlook = lsIni.GetString("thahr30", "profileoutlook", "1");
        //    string lsPasswordProfile = lsIni.GetString("thahr30", "passwordprofile", "1");
        //    //oNS.Logon(lsProfileOutlook, lsPasswordProfile, true, true);
        //    oNS.Logon(Missing.Value, Missing.Value, true, true);
        //    MySqlConnection conn = new MySqlConnection("Data Source=" + lsServer + ";Database=" + lsDatabase + ";User ID=" + lsUserName + ";Password=" + lsPassword + ";CHARSET=" + lsCharSet + "");
        //    conn.Open();
        //    lsSQL = "Selet count(*) as cnt From region ";
        //    MySqlCommand lsComm = new MySqlCommand(lsSQL, conn);
        //    MySqlDataReader lsRead;
        //    lsRead = lsComm.ExecuteReader();
        //    if (lsRead.HasRows)
        //    {
        //        while (lsRead.Read())
        //        {
        //            liCnt = Convert.ToInt32(lsRead["cnt"]);
        //        }
        //    }
        //    lsRead.Close();
        //    Pb1.Visible = true;
        //    Pb1.Maximum = liCnt;
        //    lsSQL = "select * From region r ";
        //    lsComm.CommandText = lsSQL;            
        //    lsRead = lsComm.ExecuteReader();
        //    if (lsRead.HasRows)
        //    {
        //        while (lsRead.Read())
        //        {
        //            try
        //            {
        //                lsRegionName = lsRead["regionname"].ToString();
        //                lsRegionCode = lsRead["regioncode"].ToString();
        //                Outlook.MAPIFolder DL = oNS.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderContacts);
        //                Outlook.Items ItemDL = DL.Items;
        //                Outlook.DistListItem oDistList = (Outlook.DistListItem)oApp.CreateItem(Outlook.OlItemType.olDistributionListItem);
        //                oDistList.DLName = lsRegionName;
        //                //oDistList.Delete();
        //                Int32 liCount = ItemDL.Count;
        //                lbFind = false;
        //                foreach (object item in DL.Items)
        //                {
        //                    lbFind = false;
        //                    if (item is Outlook.DistListItem)
        //                    {
        //                        li++;
        //                        ls = "";

        //                        Outlook.DistListItem list = (Outlook.DistListItem)item;
        //                        ls = list.DLName;
        //                        if (ls == lsRegionName)
        //                        {
        //                            list.Delete();
        //                        }
        //                    }
        //                }
        //                lsSQL = "Select c.email, c.positiont, c.contactnamet, c.contactsurnamet, m.memnamee1 from contact c, member m, region r "
        //                    + " Where c.refid = m.memid and m.regioncode= r.regioncode and m.regioncode = '"+ lsRegionCode +"'";
        //                MySqlCommand lsComm1 = new MySqlCommand(lsSQL, lsGdb.Gdb);
        //                lsComm.CommandText = lsSQL;
        //                MySqlDataReader lsRead1;
        //                lsRead1 = lsComm1.ExecuteReader();
        //                if (lsRead1.HasRows)
        //                {
        //                    lsEMail = "";
        //                    lsFirstName = "";
        //                    lsLastName = "";
        //                    while (lsRead1.Read())
        //                    {
        //                        lsEMail = lsRead1["email"].ToString();
        //                        lsPositionT = lsRead1["positiont"].ToString();
        //                        lsFirstName = lsRead1["memnamee1"].ToString();
        //                        //lsLastName = lsRead1["contactsurnamet"].ToString();
        //                        if (lsEMail != "")
        //                        {
        //                            Outlook.Recipient aaa;
        //                            //aaa = oApp.Session.CreateRecipient(lsFirstName + " " + lsLastName);
        //                            aaa = oApp.Session.CreateRecipient(lsFirstName);
        //                            aaa.Resolve();
        //                            //Outlook.DistListItem oDistList = (Outlook.DistListItem)oApp.de
        //                            oDistList.AddMember(aaa);
        //                            oDistList.Save();
        //                        }
        //                    }
        //                }
        //                lsRead1.Close();
        //            }
        //            catch (Exception ex)
        //            {
        //                Console.WriteLine("{0} Exception caught.", ex);
        //                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString());
        //            }
        //            Application.DoEvents();
        //            i++;
        //            Pb1.Value = i;
        //        }
        //        lbSuccess = true;
        //    }
        //    lsRead.Close();
        //    Pb1.Visible = false;
        //    Cursor.Current = System.Windows.Forms.Cursors.Default;
        //    Cursor.Show();
        //    if (lbSuccess)
        //    {
        //        MessageBox.Show("Update Outlook success", "");
        //    }
        //}
        private void updateContactOutlook_Click(object sender, EventArgs e)
        {
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Cursor.Show();
            //UpdateOutlookContact();
            //CreateDistributionlist();
            Cursor.Current = System.Windows.Forms.Cursors.Default;
            Cursor.Show();
        }

        private void updateContactOutlookALL_Click(object sender, EventArgs e)
        {
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Cursor.Show();
            SelectMember("memnamee1", "AA");
            Application.DoEvents();
            //UpdateOutlookContact();
            //CreateDistributionlist();
            Cursor.Current = System.Windows.Forms.Cursors.Default;
            Cursor.Show();
        }

        private void updateContactOutlookModify_Click(object sender, EventArgs e)
        {
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Cursor.Show();
            SelectMember("memnamee1", "modify");
            Application.DoEvents();
            //UpdateOutlookContact();
            //CreateDistributionlist();
            Cursor.Current = System.Windows.Forms.Cursors.Default;
            Cursor.Show();
        }

        private void Print_Click(object sender, EventArgs e)
        {
            GrdView.PrintSheet(0);
        }
    }
}