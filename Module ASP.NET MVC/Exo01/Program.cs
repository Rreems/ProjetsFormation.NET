using Exo01.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();



// TRANSIENT: Quand appel M�thode d'un Controller -> cr�a de cette d�pendance. Transient cycle de vie le plus court
//builder.Services.AddTransient();

// SCOPE: va rendre d�pendances communes entre Controllers, qu'elles puissent partager donn�es
//builder.Services.AddScoped();
//builder.Services.AddScoped <     >;

// SINGLETON: Rendre dispo d�pendance entre les requ�tes. Elle va �tre partag�e, jusqu'� l'arr�t de l'appli
builder.Services.AddSingleton<FakeDb>();


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("default"))
);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    //app.UseHsts();  // Utilis� par le HTTPS
}

//app.UseHttpsRedirection();  // Utilis� par le HTTPS
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Contacts}/{action=Index}/{id?}");


app.Run();
