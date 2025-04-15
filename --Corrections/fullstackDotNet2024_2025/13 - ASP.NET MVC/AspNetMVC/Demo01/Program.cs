// builder => sert à construire et configurer l'application
using Demo01.Data;
using Demo01.Models;
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

builder.Services.AddDbContext<ApplicationDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("default")));


builder.Services.AddScoped<IRepository<Cat>, CatRepository>();
//builder.Services.AddScoped<IRepository<Dog>, DogRepository>();

//méthode qui passe d'une application "en construction" à une application prête
var app = builder.Build();

// Configure the HTTP request pipeline.
//Configuration des Middleware

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    //app.UseHsts(); // utilisé pour le https
}

//app.UseHttpsRedirection(); // utilisé pour le https
app.UseStaticFiles(); // => wwwroot (css, js, images, favicon, ...)

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    //pattern: "{action=Index}/{controller=Home}/{id?}"); // change l'ordre dans la route
    pattern: "{controller=Home}/{action=Index}/{id?}");

// ajout d'une 2e configuration avec une route "/test" qui redirige vers Privacy
//app.MapControllerRoute(
//    name: "customRoute",
//    pattern: "test",
//    new
//    {
//        Controller = "Home",
//        Action = "Privacy"
//    });

// lancer l'application une fois configurée
app.Run();
