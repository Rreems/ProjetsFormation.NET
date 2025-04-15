using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer("Data Source=(localdb)\\ContactApiDb;Integrated Security=True"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Migration automatique
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    await db.Database.MigrateAsync();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


// Endpoints CRUD
app.MapGet("/contacts", async (AppDbContext db) => await db.Contacts.ToListAsync())
   .WithOpenApi();

app.MapGet("/contacts/{id}", async ([FromRoute]int id, [FromServices] AppDbContext db) =>
    await db.Contacts.FindAsync(id) is Contact contact ? Results.Ok(contact) : Results.NotFound())
   .WithOpenApi();

app.MapGet("/contacts/search", async ([FromQuery] string? name, AppDbContext db) =>
{
    var query = db.Contacts.AsQueryable();
    if (!string.IsNullOrEmpty(name))
        query = query.Where(c => c.FirstName.Contains(name) || c.LastName.Contains(name));
    return Results.Ok(await query.ToListAsync());
})
   .WithOpenApi();

app.MapPost("/contacts", async ([FromBody] Contact contact, AppDbContext db) =>
{
    if (contact.BirthDate.Year <= 1910)
        return Results.BadRequest("La date de naissance doit être après 1910");

    contact.FirstName = char.ToUpper(contact.FirstName[0]) + contact.FirstName[1..].ToLower();
    contact.LastName = contact.LastName.ToUpper();

    db.Contacts.Add(contact);
    await db.SaveChangesAsync();
    return Results.Created($"/contacts/{contact.Id}", contact);
})
   .WithOpenApi();

app.MapPut("/contacts/{id}", async (int id, [FromBody] Contact contact, AppDbContext db) =>
{
    var existing = await db.Contacts.FindAsync(id);
    if (existing is null) return Results.NotFound();

    if (contact.BirthDate.Year <= 1910)
        return Results.BadRequest("La date de naissance doit être après 1910");

    existing.FirstName = char.ToUpper(contact.FirstName[0]) + contact.FirstName[1..].ToLower();
    existing.LastName = contact.LastName.ToUpper();
    existing.Gender = contact.Gender;
    existing.BirthDate = contact.BirthDate;
    existing.Email = contact.Email;
    existing.PhoneNumber = contact.PhoneNumber;

    await db.SaveChangesAsync();
    return Results.NoContent();
})
   .WithOpenApi();

app.MapDelete("/contacts/{id}", async (int id, AppDbContext db) =>
{
    var contact = await db.Contacts.FindAsync(id);
    if (contact is null) return Results.NotFound();
    db.Contacts.Remove(contact);
    await db.SaveChangesAsync();
    return Results.NoContent();
})
   .WithOpenApi();

await app.RunAsync();
