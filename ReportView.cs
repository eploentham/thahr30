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
using System.Collections;
namespace ThaHr30
{
    public partial class ReportView : Form
    {
        public string lsReportName = ""; 
        private ReportDocument custReport = new ReportDocument ();
        IniFile lsIni = new IniFile("thahr30.ini");
        CrystalReportViewer Rpt = new CrystalReportViewer();
        string lsHLine3 = "", lsHLine2="", lsHLine1="", lsHLeft2="";
        public string  HLine3
        {
            get
            {
                return lsHLine3;
            }
            set
            {
                lsHLine3 = value.Trim();
                lsHLine3 = lsHLine3.Replace("\r", "");
                lsHLine3 = lsHLine3.Replace("\n", "");
            }
        }
        public string HLine2
        {
            get
            {
                return lsHLine2;
            }
            set
            {
                lsHLine2 = value.Trim();
                lsHLine2 = lsHLine2.Replace("\r", "");
                lsHLine2 = lsHLine2.Replace("\n", "");
            }
        }
        public string HLine1
        {
            get
            {
                return lsHLine1;
            }
            set
            {
                lsHLine1 = value.Trim();
                lsHLine1 = lsHLine1.Replace("\r", "");
                lsHLine1 = lsHLine1.Replace("\n", "");
            }
        }
        public string HLeft2
        {
            get
            {
                return lsHLeft2;
            }
            set
            {
                lsHLeft2 = value.Trim();

            }
        }
        public string ReportFileName
        {
            get
            {
                return lsReportName;
            }
            set
            {
                lsReportName = value.Trim();
            }
        }
        private void ConfigureCrystalReports(string aReportName)
        {
            try
            {
                Rpt.Height = this.Height ;
                Rpt.Width = this.Width ;
                Rpt.Top = this.Top;
                Rpt.Left = this.Left;
                Rpt.Visible = true;
                //Rpt.ReportSource = "D:\\ThaHr30\\ThaHr30\\Voucher.rpt";
                Rpt.DisplayGroupTree = false;
                //Rpt.DisplayStatusBar = true;
                Rpt.DisplayToolbar = true;
                //Rpt.SelectionFormula = "";
                Rpt.ShowPrintButton = true;
                
                custReport = new ReportDocument();
                string reportPath = Application.StartupPath + "\\" + aReportName + ".rpt";
                //custReport.SetParameterValue("line1", lsPara);
                //reportPath = "d:\\thahr30\\" + "voucher1.rpt";

                
                Controls.Add(Rpt);
                //rdOrders.RecordSelectionFormula = "{Orders.Ship Via} = 'UPS'";

                custReport.Load(reportPath);

                //foreach (CrystalDecisions.CrystalReports.Engine.Table tblLogon in custReport.Database.Tables){
                //    CrystalDecisions.Shared.TableLogOnInfo rptLogon = tblLogon.LogOnInfo;
                    
                //    //rptLogon.ConnectionInfo.ServerName = "ชื่อ Server ของคุณ";
                //    //rptLogon.ConnectionInfo.UserID = "ชื่อผู้ใช้งานของคุณ";
                //    //rptLogon.ConnectionInfo.Password = "รหัสผ่านของคุณ";
                //    rptLogon.ConnectionInfo.DatabaseName = "C:\\ThaHr30\\thahr30.mdb";
                //    //rptLogon.ConnectionInfo.IntegratedSecurity = False;
                    
                //    tblLogon.ApplyLogOnInfo(rptLogon);
                //}
                
                //custReport.DataDefinition.FormulaFields["line1"].Text = "\"" + lsHLine1 + "\"";
                
                
                
                switch (lsReportName)
                {
                    case "rptsalereport":
                        {
                            custReport.DataDefinition.FormulaFields["hline1"].Text = "\"" + lsHLine1 + "\"";
                            custReport.DataDefinition.FormulaFields["hline2"].Text = "\"" + lsHLine2 + "\"";
                            custReport.DataDefinition.FormulaFields["hline3"].Text = "\"" + lsHLine3 + "\"";
                            break;
                        }
                    case "rptsalereportcounter":
                        {
                            custReport.DataDefinition.FormulaFields["hline1"].Text = "\"" + lsHLine1 + "\"";
                            custReport.DataDefinition.FormulaFields["hline2"].Text = "\"" + lsHLine2 + "\"";
                            custReport.DataDefinition.FormulaFields["hline3"].Text = "\"" + lsHLine3 + "\"";
                            break;
                        }
                    case "rptmeetingsign":
                        {
                            string a = "ใบลงชื่อ";
                            
                            custReport.DataDefinition.FormulaFields["hline1"].Text = "\"" + lsHLine1 + "\"";
                            custReport.DataDefinition.FormulaFields["hline2"].Text = "\"" + lsHLine2 + "\"";
                            custReport.DataDefinition.FormulaFields["hline3"].Text = "\"" + lsHLine3 + "\"";
                            break;
                        }
                    case "rptdailypayinrecordpayment":
                        {
                            custReport.DataDefinition.FormulaFields["line1"].Text = "\"" + lsHLine1 + "\"";
                            custReport.DataDefinition.FormulaFields["line2"].Text = "\"" + lsHLine2 + "\"";
                            custReport.DataDefinition.FormulaFields["line3"].Text = "\"" + lsHLine3 + "\"";
                            break;
                        }
                    case "rptdailypayinrecordsu":
                        {
                            custReport.DataDefinition.FormulaFields["line1"].Text = "\"" + lsHLine1 + "\"";
                            custReport.DataDefinition.FormulaFields["line2"].Text = "\"" + lsHLine2 + "\"";
                            custReport.DataDefinition.FormulaFields["line3"].Text = "\"" + lsHLine3 + "\"";
                            custReport.DataDefinition.FormulaFields["hleft2"].Text = "\"" + lsHLeft2 + "\"";
                            break;
                        }
                    case "rptsumtypememberregion":
                        {
                            custReport.DataDefinition.FormulaFields["line2"].Text = "\"" + lsHLine2 + "\"";
                            custReport.DataDefinition.FormulaFields["line3"].Text = "\"" + lsHLine3 + "\"";
                            break;
                        }
                    case "rptsumtypememberregion1":
                        {
                            custReport.DataDefinition.FormulaFields["line2"].Text = "\"" + lsHLine2 + "\"";
                            custReport.DataDefinition.FormulaFields["line3"].Text = "\"" + lsHLine3 + "\"";
                            break;
                        }
                    case "rptmonthlysalereport":
                        {
                            custReport.DataDefinition.FormulaFields["line3"].Text = "\"" + lsHLine3 + "\"";
                            break;
                        }
                    case "rptmonthlysummarydeposit01_11":
                        {
                            custReport.DataDefinition.FormulaFields["hline1"].Text = "\"" + lsHLine1 + "\"";
                            string lsHLine2 = lsIni.GetString("report", "rptmonthlysummarydeposi", "DAILY SUMMARY DEPOSIT REPORT ");
                            custReport.DataDefinition.FormulaFields["hline2"].Text = "\"" + lsHLine2 + "\"";
                            custReport.DataDefinition.FormulaFields["hline3"].Text = "\"" + lsHLine3 + "\"";
                            break;
                        }
                    case "rptmonthlysummarydeposit12_22":
                        {
                            custReport.DataDefinition.FormulaFields["hline1"].Text = "\"" + lsHLine1 + "\"";
                            string lsHLine2 = lsIni.GetString("report", "rptmonthlysummarydeposi", "DAILY SUMMARY DEPOSIT REPORT ");
                            custReport.DataDefinition.FormulaFields["hline2"].Text = "\"" + lsHLine2 + "\"";
                            custReport.DataDefinition.FormulaFields["hline3"].Text = "\"" + lsHLine3 + "\"";
                            break;
                        }
                    case "rptmonthlysummarydeposit23_28":
                        {
                            custReport.DataDefinition.FormulaFields["hline1"].Text = "\"" + lsHLine1 + "\"";
                            string lsHLine2 = lsIni.GetString("report", "rptmonthlysummarydeposi", "DAILY SUMMARY DEPOSIT REPORT ");
                            custReport.DataDefinition.FormulaFields["hline2"].Text = "\"" + lsHLine2 + "\"";
                            custReport.DataDefinition.FormulaFields["hline3"].Text = "\"" + lsHLine3 + "\"";
                            break;
                        }
                    case "rptmonthlysummarydeposit23_29":
                        {
                            custReport.DataDefinition.FormulaFields["hline1"].Text = "\"" + lsHLine1 + "\"";
                            string lsHLine2 = lsIni.GetString("report", "rptmonthlysummarydeposi", "DAILY SUMMARY DEPOSIT REPORT ");
                            custReport.DataDefinition.FormulaFields["hline2"].Text = "\"" + lsHLine2 + "\"";
                            custReport.DataDefinition.FormulaFields["hline3"].Text = "\"" + lsHLine3 + "\"";
                            break;
                        }
                    case "rptmonthlysummarydeposit23_30":
                        {
                            custReport.DataDefinition.FormulaFields["hline1"].Text = "\"" + lsHLine1 + "\"";
                            string lsHLine2 = lsIni.GetString("report", "rptmonthlysummarydeposi", "DAILY SUMMARY DEPOSIT REPORT ");
                            custReport.DataDefinition.FormulaFields["hline2"].Text = "\"" + lsHLine2 + "\"";
                            custReport.DataDefinition.FormulaFields["hline3"].Text = "\"" + lsHLine3 + "\"";
                            break;
                        }
                    case "rptmonthlysummarydeposit23_31":
                        {
                            custReport.DataDefinition.FormulaFields["hline1"].Text = "\"" + lsHLine1 + "\"";
                            string lsHLine2 = lsIni.GetString("report", "rptmonthlysummarydeposi", "DAILY SUMMARY DEPOSIT REPORT ");
                            custReport.DataDefinition.FormulaFields["hline2"].Text = "\"" + lsHLine2 + "\"";
                            custReport.DataDefinition.FormulaFields["hline3"].Text = "\"" + lsHLine3 + "\"";
                            break;
                        }
                    case "rptskk9":
                        {
                            string lsrptskk9HLine1 = "", lsrptskk9HLine2 = "", lsrptskk9HLine3 = "", lsrptskk9FLine1 = "", lsrptskk9FLine2 = "", lsrptskk9FLine3 = "";
                            lsrptskk9HLine1 = lsIni.GetString("report", "skk9hline1", " ");
                            lsrptskk9HLine2 = lsIni.GetString("report", "skk9hline2", " ");
                            lsrptskk9HLine3 = lsIni.GetString("report", "skk9hline3", " ");
                            lsrptskk9FLine1 = lsIni.GetString("report", "skk9fline1", " ");
                            lsrptskk9FLine2 = lsIni.GetString("report", "skk9fline2", " ");
                            lsrptskk9FLine3 = lsIni.GetString("report", "skk9fline3", " ");
                            custReport.DataDefinition.FormulaFields["hline1"].Text = "\"" + lsrptskk9HLine1 + "\"";
                            custReport.DataDefinition.FormulaFields["hline2"].Text = "\"" + lsrptskk9HLine2 + "\"";
                            custReport.DataDefinition.FormulaFields["hline3"].Text = "\"" + lsrptskk9HLine3 + "\"";
                            custReport.DataDefinition.FormulaFields["fline1"].Text = "\"" + lsrptskk9FLine1 + "\"";
                            custReport.DataDefinition.FormulaFields["fline2"].Text = "\"" + lsrptskk9FLine2 + "\"";
                            custReport.DataDefinition.FormulaFields["fline3"].Text = "\"" + lsrptskk9FLine3 + "\"";
                            break;
                        }
                }
                Rpt.ReportSource = custReport;
                //Rpt.ParameterFieldInfo = paramFields;
                custReport.Refresh();
                Rpt.ShowCloseButton = true;
                Rpt.Show();
                //Application.DoEvents();
                //Rpt.Refresh();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Report could not be created", MessageBoxButtons.OK);
            }
            //SetCurrentValuesForParameterField(customersByCityReport, arrayList);
        }
        public ReportView()
        {
            InitializeComponent();
        }

        private void Report_Load(object sender, EventArgs e)
        {
            if (lsReportName == "")
            {
                lsReportName = "rptvoucher";
            }
            ConfigureCrystalReports(lsReportName);
        }

        private void ReportView_FormClosing(object sender, FormClosingEventArgs e)
        {
            Rpt.Dispose();
        }
    }
}