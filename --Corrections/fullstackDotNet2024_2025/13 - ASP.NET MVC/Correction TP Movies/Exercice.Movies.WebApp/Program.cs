using Exercice.Movies.Data.Data;
using Exercice.Movies.Data.Entities;
using Exercice.Movies.Data.Interfaces;
using Exercice.Movies.Data.Repositories;
using Exercice.Movies.WebApp.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddRouting(options =>
{
    options.LowercaseUrls = true;
});

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("LocalDB"));
});

builder.Services.AddScoped<IRepository<Movie>, MovieRepository>();
//builder.Services.AddScoped<IRepository<Movie>, MovieFakeDb>();
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IUploadPictureService, UploadPictureService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    //app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Movie}/{action=Index}/{id?}");

await app.RunAsync();