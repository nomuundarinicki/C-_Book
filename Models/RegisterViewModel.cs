using System.ComponentModel.DataAnnotations;

namespace Book.Models
{
  public class RegisterViewModel : BaseEntity
  {
    [Required]
    [MinLength(2)]
    [Display(Name = "FirstName")]
    public string FirstName { get; set; }

    [Required]
    [MinLength(2)]
    [Display(Name = "LastName")]
    public string LastName { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [MinLength(8)]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Compare("Password", ErrorMessage = "Password and confirmation must match.")]
    [DataType(DataType.Password)]
    [Display(Name = "Confirm Password")]
    public string Confirm { get; set; }
  }
}