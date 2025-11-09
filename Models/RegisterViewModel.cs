using System.ComponentModel.DataAnnotations;
namespace HotelManagement.Models;

public class RegisterViewModel
{
    [Required]
    [StringLength(50)]
    public required string Nom { get; set; }

    [Required]
    [StringLength(50)]
    public required string Prenom { get; set; }

    [Required]
    [EmailAddress]
    public required string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public required string Password { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Les mots de passe ne correspondent pas.")]
    public required string ConfirmPassword { get; set; }
}
