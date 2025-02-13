using Exo06.Data;
using Exo06.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Ajout de services.
// Des classes qui donnent des fonctionnalit�s r�utilisables dans l'application
// Ex : pour la BDD, pour EfCore, Repositories, Logique M�tier, ...

builder.Services.AddControllersWithViews(); // Obligatoire en MVC

// Le cycle de vie Transient, le plus court, sert � rendre les d�pendances disponibles lors du traitement de e la requ�te par un contr�leur. Elle sont lib�r�es par la suite
//builder.Services.AddTransient();

// Le cycle de vie Scope va �tre utile pour rendre les d�pendances communes entre plusieurs contr�leurs, de sorte � ce que celles-ci puissent partager au besoin des informations durant la requ�te.
//builder.Services.AddScoped();

// Le cycle de vie Singleton va permettre de rendre disponible une d�pendance entre les requ�tes. Celle-ci va �tre partag�e, une fois cr��e, par tous les �l�ments de notre application jusqu'� son arret
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
