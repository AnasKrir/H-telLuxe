using System.ComponentModel.DataAnnotations;
namespace HotelManagement.Models;

public class Service
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Ce champ est obligatoire.")]
    [StringLength(10, ErrorMessage = "La valeur ne doit pas dépasser 10 caractères.")]
    public  string NomService { get; set; }

    [Required]
    public float Tarif { get; set; }
 
    public  string Description { get; set; }

    // Constructeur d'initialisation
    public Service(int id, string nomService, float tarif, string description)
    {
        Id = id;
        NomService = nomService;
        Tarif = tarif;
        Description = description;
    }
}
