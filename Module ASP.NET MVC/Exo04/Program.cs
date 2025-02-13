using Exo04.Controllers;
using Exo04.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("default"))
);

builder.Services.AddScoped<MarsupilamiRepository>();

// SINGLETON: Rendre dispo d�pendance entre les requ�tes. Elle va �tre partag�e, jusqu'� l'arr�t de l'appli
//builder.Services.AddSingleton<AppDbContext>();

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
    pattern: "{controller=Marsupilami}/{action=Index}/{id?}");

app.Run();
