using Exo01_.Data;
using Exo01_.Entities;
using Exo01_.Repository;
using Exo01_.Services;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// Deux lignes pour config Swagger
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

//builder.Services.AddSwaggerGen(c =>
//{
//    c.EnableAnnotations();
//});

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("LocalDB"));
});
builder.Services.AddScoped<IRepository<Hamster,int>, HamsterRepository>();
builder.Services.AddScoped<IHamsterService, HamsterService>();




var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


// -> Middlewares
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();
