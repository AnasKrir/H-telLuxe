using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
namespace HotelManagement.Models;

public class Receptionniste
{
    

    [Key]
    public new int Id { get; set; }

    [Required(ErrorMessage = "Ce champ est obligatoire.")]
    [StringLength(10, ErrorMessage = "La valeur ne doit pas dépasser 10 caractères.")]
    public  string Nom { get; set; }

    [Required(ErrorMessage = "Ce champ est obligatoire.")]
    [StringLength(10, ErrorMessage = "La valeur ne doit pas dépasser 10 caractères.")]   
    public  string Prenom { get; set; }

    [Required]
    [RegularExpression(@"^\d{10}$", ErrorMessage = "Numéro de téléphone invalide.")]
    public  string Telephone { get; set; }

    [Required]
    [EmailAddress(ErrorMessage = "L'adresse e-mail est invalide.")]
    [StringLength(100)]
    public new required string Email { get; set; }
    public string Password { get; internal set; }
    public string Role { get; internal set; }

    // Constructeur d'initialisation
    public Receptionniste(int id, string nom, string prenom, string telephone, string email)
    {
        Id = id;
        Nom = nom;
        Prenom = prenom;
        Telephone = telephone;
        Email = email;
    }

    public Receptionniste(){}
}
