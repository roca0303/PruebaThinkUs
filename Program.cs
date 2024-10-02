using Microsoft.EntityFrameworkCore;
using PruebaThinkUs.Datos;
using PruebaThinkUs.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Configuramos la conexión a sql ser local db MSSQLLOCAL
builder.Services.AddDbContext<ApplicationDbContext>(opciones =>
            opciones.UseSqlServer(builder.Configuration.GetConnectionString("ConexionSql")));

// Registrar el servicio EmpleadoService para inyección de dependencias
builder.Services.AddScoped<IEmpleadoService, EmpleadoService>();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
