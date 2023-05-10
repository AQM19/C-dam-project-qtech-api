using AutoTerraAPI.VMs.Mappers;
using Business.DTOs.Mappers;
using Business.Interfaces;
using Business.Services;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEntityFrameworkMySQL()
    .AddDbContext<QtechContext>(options =>
    {
        options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection"));
    });

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(MapperDTO).Assembly, typeof(MapperVM).Assembly);

builder.Services.AddScoped<ILecturaService, LecturaService>();
builder.Services.AddScoped<IEspecieService, EspecieService>();
builder.Services.AddScoped<IEspecieTerrarioService, EspecieTerrarioService>();
builder.Services.AddScoped<ILogroService, LogroService>();
builder.Services.AddScoped<INotificacionService, NotificacionService>();
builder.Services.AddScoped<IObservacionService, ObservacionService>();
builder.Services.AddScoped<ITareaService, TareaService>();
builder.Services.AddScoped<ITerrarioService, TerrarioService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IUsuarioLogroService, UsuarioLogroService>();
builder.Services.AddScoped<IUsuarioUsuarioService, UsuarioUsuarioService>();
builder.Services.AddScoped<IVisitaService, VisitaService>();

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
