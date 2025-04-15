using ExoCaisseEnregistreuse.Data;
using ExoCaisseEnregistreuse.Models;
using ExoCaisseEnregistreuse.Repositories;
using Microsoft.EntityFrameworkCore;
using ExoCaisseEnregistreuse.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddScoped<IRepository<Categorie>, CategorieRepository>();

builder.Services.AddScoped<IRepository<Produit>, ProduitRepository>();

string ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(ConnectionString));


builder.Services.AddScoped<IUploadService, UploadService>();


var app = builder.Build();


app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
