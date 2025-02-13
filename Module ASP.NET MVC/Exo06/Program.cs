using Exo06.Data;
using Exo06.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Ajout de services.
// Des classes qui donnent des fonctionnalités réutilisables dans l'application
// Ex : pour la BDD, pour EfCore, Repositories, Logique Métier, ...

builder.Services.AddControllersWithViews(); // Obligatoire en MVC

// Le cycle de vie Transient, le plus court, sert à rendre les dépendances disponibles lors du traitement de e la requête par un contrôleur. Elle sont libérées par la suite
//builder.Services.AddTransient();

// Le cycle de vie Scope va être utile pour rendre les dépendances communes entre plusieurs contrôleurs, de sorte à ce que celles-ci puissent partager au besoin des informations durant la requête.
//builder.Services.AddScoped();

// Le cycle de vie Singleton va permettre de rendre disponible une dépendance entre les requêtes. Celle-ci va être partagée, une fois créée, par tous les éléments de notre application jusqu'à son arret
//builder.Services.AddSingleton();


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("default"))
);

builder.Services.AddScoped<IRepository<Movie>, MovieRepository>();

builder.Services.AddRouting(option => option.LowercaseQueryStrings=true);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Movie}/{action=Index}/{id?}");

app.Run();
