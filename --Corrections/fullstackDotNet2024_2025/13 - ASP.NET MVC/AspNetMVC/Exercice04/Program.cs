using Exercice04.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// On le créé en Singleton pour que toutes les requêtes travaillent sur la même instance de notre fausse base de données. De la sorte, elles pourront partager et manipuler la même 'Base de Données'
builder.Services.AddSingleton<FakeDb>();

// TODO: Ajouter la couche data avec une vraie base de données et le repository pattern

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
