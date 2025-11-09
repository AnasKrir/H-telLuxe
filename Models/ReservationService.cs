using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace HotelManagement.Models;

public class ReservationService
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("Service")]
    public int ServiceId { get; set; }
    public Service Service { get; set; }

    [ForeignKey("Client")]
    public int ClientId { get; set; }
    public Client Client { get; set; }

    [Required]
    public DateTime DateReservation { get; set; }

    // Constructeur par défaut pour Entity Framework
    public ReservationService() { }

    // Constructeur avec des paramètres simples (sans objets liés)
    public ReservationService(int id, int serviceId, int clientId, DateTime dateReservation)
    {
        Id = id;
        ServiceId = serviceId;
        ClientId = clientId;
        DateReservation = dateReservation;
    }
}
