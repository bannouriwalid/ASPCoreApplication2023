using System.ComponentModel.DataAnnotations;

namespace OnlineFoodOrderApp.ViewModels;

public class LoginViewModel
{
    [Required(ErrorMessage = "Username is required.")]
    [Display(Name = "User name")]
    public string UserName { get; set; }

    [Required(ErrorMessage = "Password is required.")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    
}