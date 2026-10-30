using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using PlacementDashboard.Models;

namespace PlacementDashboard.Data
{
    public class PlacementRepository
    {
        private readonly string cs = ConfigurationManager.ConnectionStrings["PlacementDB"].ConnectionString;

        public DashboardViewModel GetDashboard()
        {
            DashboardViewModel model = new DashboardViewModel();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Students", con))
                    model.TotalStudents = Convert.ToInt32(cmd.ExecuteScalar());

                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(DISTINCT StudentID) FROM PlacementRecords WHERE PlacementStatus='Placed'", con))
                    model.PlacedStudents = Convert.ToInt32(cmd.ExecuteScalar());

                using (SqlCommand cmd = new SqlCommand("SELECT ISNULL(AVG(PackageLPA),0) FROM PlacementRecords WHERE PlacementStatus='Placed'", con))
                    model.AveragePackage = Convert.ToDecimal(cmd.ExecuteScalar());

                using (SqlCommand cmd = new SqlCommand(@"
                    SELECT s.EnrollmentNo, s.StudentName, s.Department, p.CompanyName,
                           p.JobRole, p.PackageLPA, p.PlacementStatus, p.OfferDate
                    FROM Students s INNER JOIN PlacementRecords p ON s.StudentID=p.StudentID
                    ORDER BY s.StudentName", con))
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    model.Records = new List<PlacementRecord>();
                    while (dr.Read())
                    {
                        model.Records.Add(new PlacementRecord {
                            EnrollmentNo = Convert.ToString(dr["EnrollmentNo"]),
                            StudentName = Convert.ToString(dr["StudentName"]),
                            Department = Convert.ToString(dr["Department"]),
                            CompanyName = Convert.ToString(dr["CompanyName"]),
                            JobRole = Convert.ToString(dr["JobRole"]),
                            PackageLPA = Convert.ToDecimal(dr["PackageLPA"]),
                            PlacementStatus = Convert.ToString(dr["PlacementStatus"]),
                            OfferDate = dr["OfferDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["OfferDate"])
                        });
                    }
                }
            }
            return model;
        }

        public DataTable GetReportData()
        {
            using (SqlConnection con = new SqlConnection(cs))
            using (SqlCommand cmd = new SqlCommand(@"
                SELECT s.EnrollmentNo, s.StudentName, s.Department, s.GraduationYear, s.CGPA,
                       p.CompanyName, p.JobRole, p.PackageLPA, p.PlacementStatus, p.OfferDate
                FROM Students s INNER JOIN PlacementRecords p ON s.StudentID=p.StudentID
                ORDER BY s.Department, s.StudentName", con))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable("PlacementReportData");
                da.Fill(dt);
                return dt;
            }
        }
    }
}
