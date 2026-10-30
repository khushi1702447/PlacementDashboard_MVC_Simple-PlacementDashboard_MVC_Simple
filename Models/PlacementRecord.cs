using System;

namespace PlacementDashboard.Models
{
    public class PlacementRecord
    {
        public string EnrollmentNo { get; set; }
        public string StudentName { get; set; }
        public string Department { get; set; }
        public string CompanyName { get; set; }
        public string JobRole { get; set; }
        public decimal PackageLPA { get; set; }
        public string PlacementStatus { get; set; }
        public DateTime? OfferDate { get; set; }
    }
}
