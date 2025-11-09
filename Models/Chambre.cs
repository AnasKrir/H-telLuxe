using System.ComponentModel.DataAnnotations;
namespace HotelManagement.Models;

public class Chambre
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(50, ErrorMessage = "Le type ne peut pas dépasser 50 caractères.")]
    public  string Type { get; set; }

    [Required]
    [Range(1, 10, ErrorMessage = "La capacité doit être entre 1 et 10.")]
    public int Capacite { get; set; }

    [Required]
    [Range(0.0, Double.MaxValue, ErrorMessage = "Le tarif doit être positif.")]
    public float TarifParNuit { get; set; }

    [Required]
    [StringLength(50)]
    public  string EtatMaintenance { get; set; }

    [Required]
    [StringLength(50)]
    public  string Disponibilite { get; set; }

    // Constructeur d'initialisation
    public Chambre(string type, int capacite, float tarifParNuit, string etatMaintenance, string disponibilite)
    {
        Type = type;
        Capacite = capacite;
        TarifParNuit = tarifParNuit;
        EtatMaintenance = etatMaintenance;
        Disponibilite = disponibilite;
    }

    
}
