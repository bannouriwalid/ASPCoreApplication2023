using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace OnlineFoodOrderApp.Models;

public class Contact
{
    [Key]
    public int ContactId { get; set; }

    [Required(ErrorMessage = "Please enter your name")]
    [StringLength(50)]
    public string Name { get; set; }

    [Required(ErrorMessage = "Please enter your email address")]
    [StringLength(50)]
    [DataType(DataType.EmailAddress)]
    [RegularExpression(@"your_email_regex_pattern_here",
        ErrorMessage = "The email address is not entered in a correct format")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Please enter your phone number")]
    [StringLength(25)]
    [DataType(DataType.PhoneNumber)]
    public string Mobile { get; set; }

    [Required(ErrorMessage = "Please enter the subject")]
    [StringLength(30)]
    public string Subject { get; set; }

    [Required(ErrorMessage = "Please enter your message")]
    [StringLength(140)]
    public string Message { get; set; }
}


