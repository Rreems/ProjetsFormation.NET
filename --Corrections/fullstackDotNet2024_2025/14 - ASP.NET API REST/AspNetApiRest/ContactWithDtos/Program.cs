using ContactWithDtos.Helpers;

var builder = WebApplication.CreateBuilder(args);

builder.InjectDepencies();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(options =>
{
    options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
});

app.UseAuthentication(); // /!\ ne pas oublier

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();
