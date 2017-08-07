using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Windows.Forms;
namespace ThaHr30
{
    public partial class ReportCriteria : Form
    {
        public string lsReportName = "";
        Connection lsGdb = new Connection();
        public ReportCriteria()
        {
            InitializeComponent();
        }
        public Int32 PBMax
        {
            get
            {
                return Pb1 .Maximum;
            }
            set
            {
                Pb1.Maximum = value;
            }
        }
        public Int32 PBMin
        {
            get
            {
                return Pb1.Minimum;
            }
            set
            {
                Pb1.Minimum = value;
            }
        }
        public Boolean PBVisible
        {
            get
            {
                return Pb1.Visible;
            }
            set
            {
                Pb1.Visible = value;
            }
        }
        public Int32 PBValue
        {
            get
            {
                return Pb1.Value ;
            }
            set
            {
                Pb1.Value = value;
                Application.DoEvents();
            }
        }
        private void VisibleFalse()
        {
            lblFrHotel.Visible = false;
            lblToHotel.Visible = false;
            CboFromMember.Visible = false;
            CboToMember.Visible = false;
            Cbo1.Visible = false;
            Cbo2.Visible = false;
            TxtStartDate.Visible = false;
            TxtEndDate.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            CboMonth.Visible = false;
            CboYear.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            ChkSummary.Visible = false;
        }
        private void VisibleTrue(string aReportName)
        {
            switch (aReportName)
            {
                case "rptdailypayinrecord":
                    {
                        lsGdb.SelectCbo(Cbo1, "report", Connection.TableIniT.Counter);
                        lsGdb.SelectCbo(Cbo2, "", Connection.TableIniT.Shift);
                        label3.Visible = true;
                        label4.Visible = true;
                        Cbo1.Visible = true;
                        Cbo2.Visible = true;
                        label1.Visible = true;
                        label2.Visible = true;
                        TxtStartDate.Visible = true;
                        TxtEndDate.Visible = true;
                        ChkSummary.Visible = true;
                        label3.Text = "Counter :";
                        label4.Text = "Shift :";
                        break;
                    }
                case "rptrecordofdeposit":
                    {
                        lsGdb.SelectCbo(Cbo1, "", Connection.TableIniT.Counter);
                        lsGdb.SelectCbo(Cbo2, "", Connection.TableIniT.Shift);
                        label3.Visible = true;
                        label4.Visible = true;
                        Cbo1.Visible = true;
                        Cbo2.Visible = true;
                        label1.Visible = true;
                        label2.Visible = true;
                        TxtStartDate.Visible = true;
                        TxtEndDate.Visible = true;
                        ChkSummary.Visible = true;
                        label3.Text = "Counter :";
                        label4.Text = "Shift :";
                        break;
                    }
                case "rptrecordofdepositkingpower":
                    {
                        lsGdb.SelectCbo(Cbo1, "", Connection.TableIniT.Counter);
                        lsGdb.SelectCbo(Cbo2, "", Connection.TableIniT.Shift);
                        label3.Visible = true;
                        label4.Visible = true;
                        Cbo1.Visible = true;
                        Cbo2.Visible = true;
                        label1.Visible = true;
                        label2.Visible = true;
                        TxtStartDate.Visible = true;
                        TxtEndDate.Visible = true;
                        label3.Text = "Counter :";
                        label4.Text = "Shift :";
                        break;
                    }

                case "rptmonthlysalereport":
                    {
                        lsGdb.SelectCbo(Cbo1, "", Connection.TableIniT.Counter);
                        lsGdb.SelectCbo(CboMonth, "", Connection.TableIniT.MonthName);
                        lsGdb.SelectCbo(CboYear, "", Connection.TableIniT.YearName);
                        CboYear.Text = System.DateTime.Now.Year.ToString();
                        CboMonth.SelectedValue = System.DateTime.Now.Month.ToString();
                        CboMonth.Visible = true;
                        CboYear.Visible = true;
                        label5.Visible = true;
                        label6.Visible = true;
                        label5.Top = label1.Top;
                        label6.Top = label2.Top;
                        CboMonth.Top = TxtStartDate.Top;
                        CboYear.Top = TxtEndDate.Top;
                        lblFrHotel.Visible = true;
                        lblToHotel.Visible = true;
                        CboFromMember.Visible = true;
                        CboToMember.Visible = true;
                        lsGdb.SelectCbo(CboFromMember, "", Connection.TableIniT.Member);
                        lsGdb.SelectCbo(CboToMember, "", Connection.TableIniT.Member);
                        label3.Text = "Counter :";
                        break;
                    }
                case "rptmonthlysummarydeposit":
                    {
                        lsGdb.SelectCbo(Cbo1, "", Connection.TableIniT.Counter);
                        lsGdb.SelectCbo(CboMonth, "", Connection.TableIniT.MonthName);
                        lsGdb.SelectCbo(CboYear, "", Connection.TableIniT.YearName);
                        CboYear.Text = System.DateTime.Now.Year.ToString();
                        CboMonth.SelectedValue = System.DateTime.Now.Month.ToString();
                        CboMonth.Visible = true;
                        CboYear.Visible = true;
                        label5.Visible = true;
                        label6.Visible = true;
                        label5.Top = label1.Top;
                        label6.Top = label2.Top;
                        CboMonth.Top = TxtStartDate.Top;
                        CboYear.Top = TxtEndDate.Top;
                        lblFrHotel.Visible = true;
                        lblToHotel.Visible = true;
                        CboFromMember.Visible = true;
                        CboToMember.Visible = true;
                        lsGdb.SelectCbo(CboFromMember, "", Connection.TableIniT.Member);
                        lsGdb.SelectCbo(CboToMember, "", Connection.TableIniT.Member);
                        label3.Text = "Counter :";
                        break;
                    }
            }
        }
        private void ReportCriteria_Load(object sender, EventArgs e)
        {
            //Pb1.Visible = false;
            lsGdb.ConnectDatabase();
            VisibleFalse();
            VisibleTrue(lsReportName);
        }
        private void BtnOK_Click(object sender, EventArgs e)
        {
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Cursor.Show();
            lsGdb.ConnectDatabase();
            string lsStartDate = "", lsEndDate = "";
            switch (lsReportName)
            {
                case "rptmonthlysalereport":
                    {                        
                        Int32 li = Convert.ToInt32(CboMonth.SelectedValue);
                        DateTime ld = new DateTime();                        
                        lsStartDate = CboYear.Text + "-" + li.ToString("00") + "-01";
                        ld = lsGdb.LastDayofMonth(Convert.ToDateTime(lsStartDate));
                        lsEndDate = ld.Year.ToString("0000") + "-" + ld.Month.ToString("00") + "-" + ld.Day.ToString("00");
                        lsStartDate = (Convert.ToInt16(CboYear.Text) -543) + "-" + li.ToString("00") + "-01";
                        break;
                    }
                case "rptmonthlysummarydeposit":
                    {
                        Int32 li = Convert.ToInt32(CboMonth.SelectedValue);
                        DateTime ld = new DateTime();
                        lsStartDate = CboYear.Text + "-" + li.ToString("00") + "-01";
                        ld = lsGdb.LastDayofMonth(Convert.ToDateTime(lsStartDate));
                        lsEndDate = ld.Year.ToString("0000") + "-" + ld.Month.ToString("00") + "-" + ld.Day.ToString("00");
                        lsStartDate = (Convert.ToInt16(CboYear.Text) - 543) + "-" + li.ToString("00") + "-01";
                        break;
                    }
                default:
                    {
                        lsStartDate = TxtStartDate.Value.Year.ToString("0000") + "-" + TxtStartDate.Value.Month.ToString("00") + "-" + TxtStartDate.Value.Day.ToString("00");
                        lsEndDate = TxtEndDate.Value.Year.ToString("0000") + "-" + TxtEndDate.Value.Month.ToString("00") + "-" + TxtEndDate.Value.Day.ToString("00");
                        break;
                    }
            }
            //lsFromMember = CboFromMember.SelectedValue.ToString();
            //lsToMember = CboToMember.SelectedValue.ToString(); 
            Report lsRpt = new Report();
            switch (lsReportName)
            {
                case "rptmonthlysummarydeposit":
                    {
                        lsRpt.CreateMonthlySummaryDeposit(lsStartDate, lsEndDate, CboFromMember.Text, CboToMember.Text, Cbo1.Text, Cbo2.Text);
                        break;
                    }
                default:
                    {
                        lsRpt.CreateVoucherAcc(lsReportName, lsStartDate, lsEndDate, CboFromMember.Text, CboToMember.Text, Cbo1.Text, Cbo2.Text, true);
                        break;
                    }
            }
            Cursor.Current = System.Windows.Forms.Cursors.Default;
            Cursor.Show();
            ReportView frm = new ReportView();
            if (ChkSummary.Checked)
            {                
                frm.lsReportName = lsReportName + "summary";
            }
            else
            {
                frm.lsReportName = lsReportName;
            }
                 
            frm.Show(this);
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            ReportDocument RptExport = new ReportDocument();
            string reportPath = Application.StartupPath + "\\RptRecordofDeposit.rpt";
            RptExport.Load(reportPath);
            RptExport.ExportToDisk(ExportFormatType.PortableDocFormat, "d:\\thahr30\\aaaa.pdf");
            
        }
    }
}