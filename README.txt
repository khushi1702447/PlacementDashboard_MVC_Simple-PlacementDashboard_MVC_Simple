PLACEMENT DASHBOARD - ASP.NET MVC 5 (.NET Framework 4.8)
========================================================
A simplified MVC practical project with Controller, Model, Views, ADO.NET, SQL Server and Crystal Reports.

PAGES
1. Placement/Index - displays placement summary and student placement records.
2. Placement/Report - opens the Crystal Reports viewer.

SETUP
1. In Visual Studio create ASP.NET Web Application (.NET Framework), choose MVC, target .NET Framework 4.8.
2. Copy the supplied files into matching folders.
3. Run SQL/PlacementDB.sql in SQL Server Management Studio.
4. Check the PlacementDB connection string in Web.config.
5. Install SAP Crystal Reports for Visual Studio and add references to CrystalDecisions.CrystalReports.Engine,
   CrystalDecisions.Shared and CrystalDecisions.Web.
6. Create Reports/PlacementSummary.rpt using Reports/REPORT_SETUP.txt.
7. Run the project. The default route opens Placement/Index.

NOTE
The .rpt file is a Crystal Reports designer file and must be created using the installed Crystal Reports
designer. It is not possible to supply a genuine designed .rpt binary without that designer.
