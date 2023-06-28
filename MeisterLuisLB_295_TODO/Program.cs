using MeisterLuisLB_295_TODO.Model;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Details zur Datenbank-Verbindung aus der Konfiguration holen
var connectionString = builder.Configuration.GetConnectionString("TODODB");
// Verbindung zur Datenbank als Service (für Dependency-Injection) hinzufügen
builder.Services.AddDbContext<TODODB>(options => options.UseSqlServer(connectionString));
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
