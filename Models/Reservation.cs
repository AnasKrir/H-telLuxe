using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace HotelManagement.Models;

public class Reservation
{
    [Key]
    public int Id { get; set; }

    [Required]
    public DateTime DateDebut { get; set; }

    [Required]
    public DateTime DateFin { get; set; }

    [Required(ErrorMessage = "Ce champ est obligatoire.")]
    [StringLength(10, ErrorMessage = "La valeur ne doit pas dépasser 10 caractères.")]
    public string Status { get; set; }

    [ForeignKey("Client")]
    public int ClientId { get; set; }
    public Client Client { get; set; }

    [ForeignKey("Chambre")]
    public int ChambreId { get; set; }
    public Chambre Chambre { get; set; }

    // Constructeur par défaut pour Entity Framework
    public Reservation() { }

    // Constructeur avec des paramètres simples (sans objets liés)
    public Reservation(int id, DateTime dateDebut, DateTime dateFin, string status, int clientId, int chambreId)
    {
        Id = id;
        DateDebut = dateDebut;
        DateFin = dateFin;
        Status = status;
        ClientId = clientId;
        ChambreId = chambreId;
    }
}
