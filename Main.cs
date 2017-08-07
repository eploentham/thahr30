using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using ZedGraph;
namespace ThaHr30
{
    public partial class Main : Form
    {
        Connection lsGdb = new Connection();
        IniFile lsIni = new IniFile();
        string lsStaffName = "", lsStaffID = "", lsLastUpdate = " [ 21-06-2552 ] ";
        public Main()
        {
            InitializeComponent();
        }
        public string  staffName
        {
            get
            {
                return lsStaffName;
            }
            set
            {
                lsStaffName = value;
            }
        }
        public string staffID
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
        private void SelectStaffPrivileges(string aStaffID)
        {
            string lsSQL = "";
            Int32 liCount = 0;
            TreeNode ltN, ltC;
            TvwMain.BeginUpdate();
            TvwMain.Nodes.Clear();
            lsSQL = "Select * From screenname Where flag = '0' Order By sort1";
            MySqlCommand Comm = new MySqlCommand(lsSQL, lsGdb.Gdb);
            MySqlDataReader lsRead;
            lsRead = Comm.ExecuteReader();
            ltN = new TreeNode("root");
            if (lsRead.HasRows)
            {
                ltN.Text = "สมาคมโรงแรมไทย";
                ltN.Name = "root";
                TvwMain.Nodes.Add(ltN);
                TvwMain.SelectedNode = ltN;
                while (lsRead.Read())
                {
                    try
                    {
                        ltC = new TreeNode(lsRead["nodeid"].ToString());
                        ltC.Text = lsRead ["nodenamet"].ToString();
                        ltC.Name = lsRead["nodeid"].ToString();
                        TvwMain.SelectedNode.Nodes.Add(ltC);
                        liCount++;
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message.ToString(), e.Source.ToString());
                    }
                }
            }
            lsRead.Close();
            //TvwMain.SelectedNode.Name = "report";
            //ltC = new TreeNode("reportdaily");
            //ltC.Text = "รายงานประจำวัน";
            //ltC.Name = "reportdaily";
            //TvwMain.SelectedNode.Nodes.Add(ltC);
            TvwMain.SelectedNode = ltN;
            for (int i = 0; i <= liCount-1; i++)
            {
                if (i == 0)
                {
                    TvwMain.SelectedNode = TvwMain.SelectedNode.FirstNode;
                }
                else
                {
                    TvwMain.SelectedNode = TvwMain.SelectedNode.NextNode;
                }
                lsSQL = "Select p.screenname, s.nodenamet From staffprivileges p, screenname s "
                    + "Where s.screenname = p.screenname and p.nodeparentid = '" + TvwMain.SelectedNode.Name + "' and p.staffid = '"
                    +aStaffID+"' and privilegesview = '1' Order By s.sort1";
                Comm.CommandText = lsSQL;
                lsRead = Comm.ExecuteReader();
                if (lsRead.HasRows)
                {
                    while (lsRead.Read())
                    {
                        try
                        {
                            ltN = new TreeNode(lsRead["screenname"].ToString());
                            ltN.Text = lsRead["nodenamet"].ToString();
                            ltN.Name = lsRead["screenname"].ToString();
                            TvwMain.SelectedNode.Nodes.Add(ltN);
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.Message.ToString(), e.Source.ToString());
                        }
                    }
                }
                lsRead.Close();
                lsSQL = TvwMain.SelectedNode.Name;
                if (lsSQL == "report")
                {

                }
            }
            TvwMain.EndUpdate();
        }
        //private void CreateGraph(ZedGraphControl zgc)
        //{
        //    GraphPane myPane = zgc.GraphPane;
        //    // Set the titles and axis labels
        //    myPane.Title.Text = "My Test Graph";
        //    myPane.XAxis.Title.Text = "X Value";
        //    myPane.YAxis.Title.Text = "My Y Axis";
        //    // Make up some data points from the Sine function
        //    PointPairList list = new PointPairList();
        //    for (double x = 0; x < 36; x++)
        //    {
        //        double y = Math.Sin(x * Math.PI / 15.0);
        //        list.Add(x, y);
        //    }
        //    // Generate a blue curve with circle symbols, and "My Curve 2" in the legend
        //    LineItem myCurve = myPane.AddCurve("My Curve", list, Color.Blue, SymbolType.Circle);
        //    // Fill the area under the curve with a white-red gradient at 45 degrees
        //    myCurve.Line.Fill = new Fill(Color.White, Color.Red, 45F);
        //    // Make the symbols opaque by filling them with white
        //    myCurve.Symbol.Fill = new Fill(Color.White);
        //    // Fill the axis background with a color gradient
        //    myPane.Chart.Fill = new Fill(Color.White, Color.LightGoldenrodYellow, 45F);
        //    // Fill the pane background with a color gradient
        //    myPane.Fill = new Fill(Color.White, Color.FromArgb(220, 220, 255), 45F);
        //    // Calculate the Axis Scale Ranges
        //    zgc.AxisChange();
        //}
        private void CreateGraph(ZedGraphControl zgc)
        {
            GraphPane myPane = zgc.GraphPane;
            // Set the titles and axis labels
            myPane.Title.Text = "TYPE of MEMBER";
            myPane.XAxis.Title.Text = "ประเภทสมาชิก";
            myPane.YAxis.Title.Text = "จำนวนสมาชิก";
            // Make up some data points from the Sine function
            PointPairList list = new PointPairList();
            //for (double x = 0; x < 36; x++)
            //{
            //    double y = Math.Sin(x * Math.PI / 15.0);
            //    list.Add(x, y);
            //}
            string lsSQL = "Select * From typemem ";
            MySqlCommand lsComm = new MySqlCommand(lsSQL, lsGdb.Gdb);
            MySqlDataReader lsRead;
            lsRead = lsComm.ExecuteReader();
            if (lsRead.HasRows)
            {
                while (lsRead.Read())
                {
                    lsSQL = lsRead["tmemcode"].ToString();
                    if (lsSQL != "-")
                    {
                        list.Add(Convert.ToDouble(lsRead["tmemcode"]), Convert.ToDouble(lsRead["tmemcode"]));
                    }
                }
            }
            lsRead.Close();
            // Generate a blue curve with circle symbols, and "My Curve 2" in the legend
            LineItem myCurve = myPane.AddCurve("My Curve", list, Color.Blue, SymbolType.Circle);
            // Fill the area under the curve with a white-red gradient at 45 degrees
            myCurve.Line.Fill = new Fill(Color.White, Color.Red, 45F);
            // Make the symbols opaque by filling them with white
            myCurve.Symbol.Fill = new Fill(Color.White);
            // Fill the axis background with a color gradient
            myPane.Chart.Fill = new Fill(Color.White, Color.LightGoldenrodYellow, 45F);
            // Fill the pane background with a color gradient
            myPane.Fill = new Fill(Color.White, Color.FromArgb(220, 220, 255), 45F);
            // Calculate the Axis Scale Ranges
            zgc.AxisChange();
        }
        private void TvwMain_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Cursor.Show();
            if (lsGdb.Gdb.State == ConnectionState.Closed)
            {
                lsGdb.ConnectDatabase();
            }
            switch (e.Node.Name)
            {
                case "voucheradd":
                    VoucherAdd frm = new VoucherAdd();
                    frm.Connnection = lsGdb.Gdb;
                    frm.Show(this);
                    break;
                case "voucherview":
                    VoucherView frm1 = new VoucherView();
                    frm1.Connnection = lsGdb.Gdb;
                    frm1.Show();
                    break;
                case "memberview":
                    MemberView frm2 = new MemberView();
                    frm2.Connnection = lsGdb.Gdb;
                    frm2.Show(this);
                    break;
                case "memberadd":
                    MemberAdd frm3 = new MemberAdd();
                    frm3.Connnection = lsGdb.Gdb;
                    frm3.Show(this);
                    break;
                case "importdata":
                    ImportData frm4 = new ImportData();
                    frm4.Show(this);
                    break;
                case "membersearch":
                    MemberSearch frm5 = new MemberSearch();
                    frm5.Show(this);
                    break;
                case "senddata":
                    ShopSendData frm6 = new ShopSendData();
                    frm6.Show(this);
                    break;
                case "preparedata":
                    KingPowerGenData frm7 = new KingPowerGenData();
                    frm7.Connnection = lsGdb.Gdb;
                    frm7.Show(this);
                    break;
                case "nationality":
                    InitialAdd frm8 = new InitialAdd();
                    frm8.TableName = e.Node.Name;
                    frm8.ColumnCode = "nationcode";
                    frm8.ColumnNameE = "nationname";
                    frm8.OrderBy = "nationcode";
                    frm8.Show(this);
                    break;
                case "salutation":
                    InitialAdd frm9 = new InitialAdd();
                    frm9.TableName = "salutation";
                    frm9.ColumnCode = "salcode";
                    frm9.ColumnNameE = "salnamee";
                    frm9.OrderBy = "salcode";
                    frm9.Show(this);
                    break;
                case "shopview":
                    ShopView frm10 = new ShopView();
                    frm10.Connnection = lsGdb.Gdb;
                    frm10.Show(this);
                    break;
                case "rptdailypayinrecord":
                    ReportCriteria frm11 = new ReportCriteria();
                    frm11.Connnection = lsGdb.Gdb;
                    frm11.lsReportName = e.Node.Name;
                    frm11.Show(this);
                    break;
                case "rptrecordofdeposit":
                    ReportCriteria frm12 = new ReportCriteria();
                    frm12.Connnection = lsGdb.Gdb;
                    frm12.lsReportName = e.Node.Name;
                    frm12.Show(this);
                    break;
                case "rptmonthlysalereport":
                    ReportCriteria frm13 = new ReportCriteria();
                    frm13.Connnection = lsGdb.Gdb;
                    frm13.lsReportName = e.Node.Name;
                    frm13.Show(this);
                    break;
                case "rptmonthlysummarydeposit":
                    ReportCriteria frm14 = new ReportCriteria();
                    frm14.Connnection = lsGdb.Gdb;
                    frm14.lsReportName = e.Node.Name;
                    frm14.Show(this);
                    break;
                case "webkingpower":
                    KingPowerWeb frm15 = new KingPowerWeb();
                    //frm15.lsReportName = e.Node.Name;
                    frm15.Show(this);
                    break;
                case "accrecvoucher":
                    AccRecVoucher frm16 = new AccRecVoucher();
                    frm16.Connnection = lsGdb.Gdb;
                    frm16.Show(this);
                    break;
                case "rptrecordofdepositkingpower":
                    ReportCriteria frm17 = new ReportCriteria();
                    frm17.Connnection = lsGdb.Gdb;
                    frm17.lsReportName = e.Node.Name;
                    frm17.Show(this);
                    break;
                case "typebis":
                    InitialAdd frm18 = new InitialAdd();
                    frm18.TableName = "typebis";
                    frm18.ColumnCode = "tbiscode";
                    frm18.ColumnNameE = "tbisname";
                    frm18.OrderBy = "tbiscode";
                    frm18.Show(this);
                    break;
                case "typemem":
                    InitialAdd frm19 = new InitialAdd();
                    frm19.TableName = "typemem";
                    frm19.ColumnCode = "tmemcode";
                    frm19.ColumnNameE = "tmemname";
                    frm19.OrderBy = "tmemcode";
                    frm19.Show(this);
                    break;
                case "typeroom":
                    InitialAdd frm20 = new InitialAdd();
                    frm20.TableName = "typeroom";
                    frm20.ColumnCode = "plcode";
                    frm20.ColumnNameE = "plnamee";
                    frm20.OrderBy = "plcode";
                    frm20.Show(this);
                    break;
                case "shift":
                    InitialAdd frm21 = new InitialAdd();
                    frm21.TableName = "shift";
                    frm21.ColumnCode = "shiftcode";
                    frm21.ColumnNameE = "shiftname";
                    frm21.OrderBy = "shiftcode";
                    frm21.Show(this);
                    break;
                case "location":
                    InitialAdd frm22 = new InitialAdd();
                    frm22.TableName = "location";
                    frm22.ColumnCode = "locationcode";
                    frm22.ColumnNameE = "locationnamet";
                    frm22.OrderBy = "locationcode";
                    frm22.Show(this);
                    break;
                case "accinvoice":
                    AccInvoice frm23 = new AccInvoice();
                    frm23.Connnection = lsGdb.Gdb;
                    frm23.Show(this);
                    break;
                case "rptsalereport":
                    ReportCriteria frm24 = new ReportCriteria();
                    frm24.Connnection = lsGdb.Gdb;
                    frm24.lsReportName = e.Node.Name;
                    frm24.Show(this);
                    break;
                case "rptsalereportcounter":
                    ReportCriteria frm29 = new ReportCriteria();
                    frm29.Connnection = lsGdb.Gdb;
                    frm29.lsReportName = e.Node.Name;
                    frm29.Show(this);
                    break;
                case "rptdailypayinrecordmanager":
                    ReportCriteria frm25 = new ReportCriteria();
                    frm25.Connnection = lsGdb.Gdb;
                    frm25.lsReportName = e.Node.Name;
                    frm25.Show(this);
                    break;
                case "accmemberyear":
                    AccMemberYear frm26 = new AccMemberYear();
                    frm26.Connnection = lsGdb.Gdb;
                    frm26.Show(this);
                    break;
                case "rptsumtypemember":
                    //ReportCriteria frm27 = new ReportCriteria();  rptsumtypememregion
                    //frm27.Connnection = lsGdb.Gdb;
                    //frm27.lsReportName = e.Node.Name;
                    //frm26.Show(this);
                    Report Report = new Report();
                    Report.SumTypeMember(true);
                    ReportView Rpt = new ReportView();
                    Rpt.ReportFileName = e.Node.Name;
                    Rpt.Show(this);
                    break;
                case "rptsumtypememberregion":
                    //ReportCriteria frm27 = new ReportCriteria();  rptsumtypememregion
                    //frm27.Connnection = lsGdb.Gdb;
                    //frm27.lsReportName = e.Node.Name;
                    //frm26.Show(this);
                    Report Report1 = new Report();
                    Report1.SumTypeMemberRegion(true);
                    ReportView Rpt1 = new ReportView();
                    Rpt1.HLine2 = "Report Summary Member Group By region";
                    Rpt1.ReportFileName = e.Node.Name;
                    Rpt1.Show(this);
                    break;
                case "memberskk9":
                    MemberSKK9 frm27 = new MemberSKK9();
                    frm27.Connnection = lsGdb.Gdb;
                    frm27.Show(this);
                    break;
                case "staffview":
                    StaffView  frm28 = new StaffView();
                    frm28.FlagStafF = StaffView.FlagStaff.Staff;
                    frm28.Connnection = lsGdb.Gdb;
                    frm28.Show(this);
                    break;
                case "committeeview":
                    StaffView frm37 = new StaffView();
                    frm37.FlagStafF = StaffView.FlagStaff.Committee;
                    frm37.Connnection = lsGdb.Gdb;
                    frm37.Show(this);
                    break;
                case "prview":
                    StaffView frm38 = new StaffView();
                    frm38.FlagStafF = StaffView.FlagStaff.PR;
                    frm38.Connnection = lsGdb.Gdb;
                    frm38.Show(this);
                    break;
                case "guessview":
                    StaffView frm39 = new StaffView();
                    frm39.FlagStafF = StaffView.FlagStaff.Guess;
                    frm39.Connnection = lsGdb.Gdb;
                    frm39.Show(this);
                    break;
                case "addressdistrict":
                    AddressDistrict frm30 = new AddressDistrict();
                    frm30.Connnection = lsGdb.Gdb;
                    frm30.FormName = AddressDistrict.FormName1.FormDistrict;
                    frm30.Show(this);
                    break;
                case "addresssubdistrict":
                    AddressDistrict frm31 = new AddressDistrict();
                    frm31.Connnection = lsGdb.Gdb;
                    frm31.FormName = AddressDistrict.FormName1.FormSubDistrict;
                    frm31.Show(this);
                    break;
                case "serviceip":
                    ServiceIP frm32 = new ServiceIP();
                    //frm15.lsReportName = e.Node.Name;
                    frm32.Show(this);
                    break;
                case "rptmemberstatus":
                    {
                        ReportCriteria frm33 = new ReportCriteria();
                        frm33.Connnection = lsGdb.Gdb;
                        frm33.lsReportName = e.Node.Name;
                        frm33.Show(this);
                        break;
                    }
                case "rptdailypayinrecordsu":
                    ReportCriteria frm34 = new ReportCriteria();
                    frm34.Connnection = lsGdb.Gdb;
                    frm34.lsReportName = e.Node.Name;
                    frm34.Show(this);
                    break;
                case "rptdailypayinrecordpayment":
                    ReportCriteria frm35 = new ReportCriteria();
                    frm35.Connnection = lsGdb.Gdb;
                    frm35.lsReportName = e.Node.Name;
                    frm35.Show(this);
                    break;
                case "membermeetingview":
                    MeetingView frm36 = new MeetingView();
                    frm36.Connnection = lsGdb.Gdb;
                    frm36.Show(this);
                    break;
                case "membersendemail":
                    MemberSendEmail frm371 = new MemberSendEmail();
                    //frm37.Connnection = lsGdb.Gdb;
                    frm371.Show(this);
                    break;
                case "meetingsendmail":
                    //MeetingSendMail frm37 = new MeetingSendMail();
                    //frm37.Connnection = lsGdb.Gdb;
                    //frm37.Show(this);membersendemail
                    break;
            }
            Cursor.Current = System.Windows.Forms.Cursors.Default;
            Cursor.Show();
        }
        private void Main_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    {
                        if (MessageBox.Show("Do you exit Program", "Exit Program", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            Application.Exit();
                        }
                        break;
                    }
            }
        }
        private void CloseForm()
        {
            this.Close();
        }
        private void Main_Load(object sender, EventArgs e)
        {
            string lsLoginOn = lsIni.GetString("thahr30", "loginon", "0");
            string lsPrivileges = lsIni.GetString("thahr30", "privilegeson", "0");
            Boolean lbCancel = false;
            if (lsLoginOn == "1")
            {
                StaffLogin frm = new StaffLogin();
                frm.ShowDialog(this);
                if (frm.StaffName == "loginfail" || frm .StaffName == "")
                {
                    CloseForm();
                    lbCancel = true;
                }
                else
                {
                    lsStaffID = frm.StaffID;
                    lsGdb.Gdb = frm.Connnection;
                    if (lsPrivileges == "1")
                    {
                        SelectStaffPrivileges(lsStaffID);
                    }
                    SL1.Items[0].Text = "Database " + lsGdb.Gdb.Database + " Version " + lsGdb.Gdb.ServerVersion + " ";
                }
                lsStaffName = frm.StaffName;
                this.Text = "Staff name " + frm.StaffName + lsLastUpdate;
                frm.Dispose();
            }
            //this.Text = "Staff name " + frm.StaffName + lsLastUpdate;
            if (lbCancel == false)
            {
                //CreateGraph(zg1);
            }
        }
        private void exit_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            SelectStaffPrivileges(lsStaffID);
        }

        private void logoff_Click(object sender, EventArgs e)
        {
            this.Hide();
            lsGdb.Gdb.Close();
            StaffLogin frm = new StaffLogin();
            frm.ShowDialog(this);
            if (frm.StaffName == "loginfail")
            {
                CloseForm();
            }
            else
            {
                string lsPrivileges = lsIni.GetString("thahr30", "privilegeson", "0");
                if (lsPrivileges == "1")
                {
                    lsStaffID = frm.StaffID;
                    lsGdb.Gdb = frm.Connnection;
                    SelectStaffPrivileges(lsStaffID);
                }
                this.Show();
            }
            lsStaffName = frm.StaffName;
            this.Text = "Staff name " + frm.StaffName + lsLastUpdate;
            frm.Dispose();
        }
        private void splitContainer1_Resize(object sender, EventArgs e)
        {
            //SetSize();
        }
        private void SetSize()
        {
            zg1.Location = new Point(3, 3);
            // Leave a small margin around the outside of the control
            //zg1.Size = new Size(this.ClientRectangle.Width - 20, this.ClientRectangle.Height - 20);
            zg1.Size = new Size(splitContainer1.Panel2.Width - 3, splitContainer1.Panel2.Height - 3);
            TvwMain.Size = new Size(splitContainer1.Panel1.Width - 3, splitContainer1.Panel1.Height - 3);
        }
        private void zg1_Resize(object sender, EventArgs e)
        {
            //SetSize();
        }
        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            SetSize();
        }

        private void Main_Resize(object sender, EventArgs e)
        {
            splitContainer1.Width = this.Width - 40;
            splitContainer1.Height = this.Height - SL1.Height - 80;
            //splitContainer1.Panel1.Width = this.Width - 300;
            //splitContainer1.Panel1.Height = this.Height - 10;
            //splitContainer1.Panel2.Width = this.Width - 10;
            //splitContainer1.Panel2.Height = this.Height - 10;
            SetSize();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            SendEmail Send = new SendEmail();
            Send.Show();
        }
    }
}