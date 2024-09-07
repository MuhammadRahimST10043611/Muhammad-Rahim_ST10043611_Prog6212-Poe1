namespace ProgPoe1.Models
{
    public class Claim
    {
        public int Id { get; set; }  // Unique identifier for the claim
        public string LecturerName { get; set; }  // Name of the lecturer submitting the claim
        public decimal HourlyRate { get; set; }  // Hourly rate of the lecturer
        public int HoursWorked { get; set; }  // Total hours worked by the lecturer
        public decimal TotalAmount => HourlyRate * HoursWorked;  // Total amount calculated based on hourly rate and hours worked
        public string Status { get; set; }  // Status of the claim (Submitted, Approved, Rejected)
        public string SupportingDocumentsPath { get; set; }  // Path to the supporting documents uploaded
    }
}

//------------------------------------------...ooo000 END OF FILE 000ooo...----------------------------------------------------------------------------------------------------------------------//
