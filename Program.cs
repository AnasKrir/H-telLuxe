using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using HotelManagement.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure the DbContext for Entity Framework Core
builder.Services.AddDbContext<HotelManagementContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("HotelManagementDB")));

// Ajouter Identity avec les paramètres par défaut
builder.Services.AddDefaultIdentity<Receptionniste>()
    .AddEntityFrameworkStores<HotelManagementContext>()
    .AddDefaultTokenProviders();  // Ceci est l'authentification par défaut




builder.Services.AddRazorPages();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.MapRazorPages();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
   name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
