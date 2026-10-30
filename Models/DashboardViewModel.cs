using System.Collections.Generic;

namespace PlacementDashboard.Models
{
    public class DashboardViewModel
    {
        public int TotalStudents { get; set; }
        public int PlacedStudents { get; set; }
        public decimal AveragePackage { get; set; }
        public List<PlacementRecord> Records { get; set; }
    }
}
