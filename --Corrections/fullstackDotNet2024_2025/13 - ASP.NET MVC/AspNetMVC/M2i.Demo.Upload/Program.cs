using M2i.Demo.Upload.Data;
using M2i.Demo.Upload.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// On ajoute notre HashSet en singleton pour le rendre commun entre les requêtes et ainsi avoir la trace de nos images
builder.Services.AddSingleton<FakeDb>();

// On oublie pas de renseigner les dépendances sous peine d'avoir des erreurs
builder.Services.AddScoped<IUploadPictureService, UploadPictureService>();
builder.Services.AddScoped<IPictureService, PictureService>();

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
