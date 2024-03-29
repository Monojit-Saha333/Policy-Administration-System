using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Consumer.API.Models;

public class Customer
{
    [Key]
    public Guid CustomerID { get; set; }
    public string CustomerName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Pan { get; set; }
}