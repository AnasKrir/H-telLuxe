using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace HotelManagement.Models;

public class ProgrammeFidelite
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int Points { get; set; }

    [ForeignKey("Client")]
    public int ClientId { get; set; }
    public Client Client { get; set; }

    // Constructeur par défaut pour EF
    public ProgrammeFidelite() { }

    // Vous pouvez ajouter un autre constructeur sans client lié ici si nécessaire
    public ProgrammeFidelite(int points, int clientId)
    {
        Points = points;
        ClientId = clientId;
    }
}
