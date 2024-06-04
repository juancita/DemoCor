using Microsoft.EntityFrameworkCore;
using ApiSiniestrosAxa.Infrastructure.Data.Models;
using ApiSiniestrosAxa.Core.Interfaces;
using ApiSiniestrosAxa.Infrastructure.Repositories;
using ApiSiniestrosAxa.Application.Services;
using ApiSiniestrosAxa.Application.External;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var urlAthento = builder.Configuration.GetSection("Athento:UrlAthento").Value;
var apiDocumentManagement = builder.Configuration.GetSection("Athento:ApiDocumentManagement").Value;
var apiToken = builder.Configuration.GetSection("Athento:ApiToken").Value;
var input = builder.Configuration.GetSection("Athento:Input").Value;

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configure repositories and services
builder.Services.AddScoped<IMovimientoRepository, MovimientoRepository>();
builder.Services.AddScoped<MovimientoService>();
builder.Services.AddScoped<IAnalistaRepository, AnalistaRepository>();
builder.Services.AddScoped<AnalistaService>();
builder.Services.AddScoped<ISiniestroRepository, SiniestroRepository>();
builder.Services.AddScoped<SiniestroService>();
builder.Services.AddScoped<IEstadoSiniestroRepository, EstadoSiniestroRepository>();
builder.Services.AddScoped<EstadoSiniestroService>();
builder.Services.AddScoped<AuthAthentoService>();
builder.Services.AddScoped<IMovilidadDeSiniestroRepository, MovilidadDeSiniestroRepository>();
builder.Services.AddScoped<MovilidadDeSiniestroService>();
builder.Services.AddScoped<IPersonaRepository, PersonaRepository>();
builder.Services.AddScoped<PersonaService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
if (app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
