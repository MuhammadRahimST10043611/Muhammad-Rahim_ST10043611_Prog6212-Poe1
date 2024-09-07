namespace ProgPoe1.Models
{
    public class Claim
    {
        public int Id { get; set; }
        public string LecturerName { get; set; }
        public decimal HourlyRate { get; set; }
        public int HoursWorked { get; set; }
        public decimal TotalAmount => HourlyRate * HoursWorked;  // Automatically calculated
        public string Status { get; set; }  // Submitted, Approved, Rejected
        public string SupportingDocumentsPath { get; set; }
    }
}
