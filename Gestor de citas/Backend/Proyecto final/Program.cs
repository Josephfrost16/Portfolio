using Business.Clases;
using Business.Interfaces;
using CapaDatos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Inyeccion de conexion:
var conn = builder.Configuration.GetConnectionString("SQLConnection");

builder.Services.AddDbContext<GestorGastosContext>(x => x.UseSqlServer(conn));

//Inyeccion de interfaces con acceso a las tablas:

builder.Services.AddScoped<IUsuario, LogicaUsuarios>();
builder.Services.AddScoped<ICategorias,LogicaCategorias>();
builder.Services.AddScoped<IGastos, LogicaGastos>();
builder.Services.AddScoped<IObservador, Notificador>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(a => a.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
