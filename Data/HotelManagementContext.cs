using Microsoft.EntityFrameworkCore;
using HotelManagement.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


#pragma warning disable CA1050 // Déclarer les types dans des espaces de noms
public class HotelManagementContext : IdentityDbContext<Receptionniste>
#pragma warning restore CA1050 // Déclarer les types dans des espaces de noms
{
    public HotelManagementContext(DbContextOptions<HotelManagementContext> options) : base(options) { }

    public DbSet<Client> Clients { get; set; }
    public DbSet<Chambre> Chambres { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<ProgrammeFidelite> ProgrammesFidelite { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<ReservationService> ReservationServices { get; set; }
    public DbSet<Paiement> Paiements { get; set; }
    public DbSet<Receptionniste> Receptionnistes { get; set; }
}
