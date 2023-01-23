using AutoMapper;
using BowlingEF.Context;
using BowlingLib.Model;
using BowlingRepository;
using BowlingRepository.Interface;
using BowlingService;
using BowlingService.Interfaces;
using Business;
using Mapper;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(JoueurProfile));
builder.Services.AddScoped<IJoueurService, JoueurService>();

//Configurer la connexion à la base de données SQLite du projet BowlingEF
builder.Services.AddDbContext<BowlingContext>(options =>
{
    options.UseSqlite("Data Source=bowling.db");
});

builder.Services.AddScoped<IJoueurRepository, JoueurRepository>();

//configure Logger
builder.Services.AddLogging(configure =>
{
    configure.AddConsole();
    configure.AddDebug();
});

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