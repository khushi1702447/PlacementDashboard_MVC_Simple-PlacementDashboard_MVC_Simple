<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PlacementCrystalReport.aspx.cs" Inherits="PlacementDashboard.PlacementCrystalReport" %>
<%@ Register Assembly="CrystalDecisions.Web" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<!DOCTYPE html>
<html>
<head runat="server"><title>Placement Report</title></head>
<body>
<form id="form1" runat="server">
    <h2>Placement Summary Report</h2>
    <a href="Placement/Index">Back to Dashboard</a>
    <hr />
    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server"
        AutoDataBind="true" HasExportButton="true" HasPrintButton="true" />
</form>
</body>
</html>
