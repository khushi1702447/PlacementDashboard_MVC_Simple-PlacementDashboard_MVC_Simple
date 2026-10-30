using System;
using CrystalDecisions.CrystalReports.Engine;
using PlacementDashboard.Data;

namespace PlacementDashboard
{
    public partial class PlacementCrystalReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ReportDocument report = new ReportDocument();
                report.Load(Server.MapPath("~/Reports/PlacementSummary.rpt"));
                report.SetDataSource(new PlacementRepository().GetReportData());
                CrystalReportViewer1.ReportSource = report;
                Session["PlacementReport"] = report;
            }
            else if (Session["PlacementReport"] != null)
            {
                CrystalReportViewer1.ReportSource = (ReportDocument)Session["PlacementReport"];
            }
        }
    }
}
