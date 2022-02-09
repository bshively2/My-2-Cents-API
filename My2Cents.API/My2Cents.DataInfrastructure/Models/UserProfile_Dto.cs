namespace My2Cents.API.Models
{
    public class UserProfile_Dto
    {
        public int UserID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? SecondaryEmail { get; set; }
        public string? MailingAddress { get; set; }
        public decimal Phone { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Employer { get; set; }
        public string? WorkAddress { get; set; }
        public decimal WorkPhone { get; set; }
    }
}
