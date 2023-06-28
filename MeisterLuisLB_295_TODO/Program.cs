using MeisterLuisLB_295_TODO.Model;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add the database context as a service with the connection string
builder.Services.AddDbContext<TODODB>(options => options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TODODB;Trusted_Connection=True"));

// Add other services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
