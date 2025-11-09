using System.ComponentModel.DataAnnotations;
namespace HotelManagement.Models;


public class Client
{
    [Key]
    public  int Id { get; set; }

    [Required(ErrorMessage = "Ce champ est obligatoire.")]
    [StringLength(10, ErrorMessage = "La valeur ne doit pas dépasser 10 caractères.")]
    public  string Nom { get; set; }

    [Required]
    [StringLength(10, ErrorMessage = "La valeur ne doit pas dépasser 10 caractères.")]
    public  string Prenom { get; set; }

    [Required]
    [EmailAddress(ErrorMessage = "L'adresse e-mail est invalide.")]
    [StringLength(100)]
    public  string Email { get; set; }

    [Required]
    [RegularExpression(@"^\d{10}$", ErrorMessage = "Numéro de téléphone invalide.")]
    public  string Telephone { get; set; }

    public  string HistoriqueSejours { get; set; } // Stocké en JSON

    public  string Preferences { get; set; } // Stocké en JSON

    // Constructeur d'initialisation
    public Client(int id, string nom, string prenom, string email, string telephone, string historiqueSejours, string preferences)
    {
        Id = id;
        Nom = nom;
        Prenom = prenom;
        Email = email;
        Telephone = telephone;
        HistoriqueSejours = historiqueSejours;
        Preferences = preferences;
    }
}
