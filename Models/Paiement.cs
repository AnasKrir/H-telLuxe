using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace HotelManagement.Models;

public class Paiement
{
    [Key]
    public int Id { get; set; }

    [Required]
    public float Montant { get; set; }

    [Required]
    public DateTime DatePaiement { get; set; }

    [Required]
    [StringLength(50)]
    public string ModePaiement { get; set; }

    [Required]
    [StringLength(50)]
    public string Status { get; set; }

    [ForeignKey("Client")]
    public int ClientId { get; set; }
    
    // Propriété de navigation pour Client
    public Client Client { get; set; }

    // Constructeur d'initialisation personnalisé
    public Paiement(int id, float montant, DateTime datePaiement, string modePaiement, string status, int clientId)
    {
        Id = id;
        Montant = montant;
        DatePaiement = datePaiement;
        ModePaiement = modePaiement;
        Status = status;
        ClientId = clientId;
    }

    // Constructeur par défaut utilisé par EF pour la persistance
    public Paiement() { }
}
