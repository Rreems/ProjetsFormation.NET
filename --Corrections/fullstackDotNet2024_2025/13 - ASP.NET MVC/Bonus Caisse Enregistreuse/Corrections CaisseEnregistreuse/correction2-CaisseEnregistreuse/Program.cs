using Microsoft.EntityFrameworkCore;
using TpCaisseEnregistreuse.Data;
using TpCaisseEnregistreuse.Models;
using TpCaisseEnregistreuse.Repositories;
using TpCaisseEnregistreuse.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IRepository<Categorie>, CategoriesRepository>();
builder.Services.AddScoped<IRepository<Produit>, ProduitsRepository>();

builder.Services.AddSession();

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<CaisseEnregistreuseContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<IUploadService, UploadService>();



var app = builder.Build();


app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Categories}/{action=Index}/{id?}");

app.Run();
