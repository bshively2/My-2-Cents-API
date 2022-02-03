using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My2Cents.DataInfrastructure.Models
{
  public class UserProfileDto
  {
    public int UserId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? SecondaryEmail { get; set; }
    public string? MailingAddress { get; set; }
    public int? Phone { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? Employer { get; set; }
    public string? WorkAddress { get; set; }
    public int? WorkPhone { get; set; }

  }
}
