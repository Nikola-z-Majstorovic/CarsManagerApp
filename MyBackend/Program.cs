using Microsoft.EntityFrameworkCore;
using MyBackend.Context;
using MyBackend.Repositores;
using MyBackend.Repositores.Interfaces;
using MyBackend.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registruj ICarRepository na osnovu podešavanja
var repoType = builder.Configuration["RepositoryType"];

if (repoType == "Database")
{
    builder.Services.AddScoped<ICarRepository, CarRepository>();
}
else
{
    builder.Services.AddSingleton<ICarRepository, InMemoryCarRepository>();
}

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSingleton<CarService>();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("_myAllowSpecificOrigins",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200") 
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});
var app = builder.Build();
app.UseCors("_myAllowSpecificOrigins");
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
