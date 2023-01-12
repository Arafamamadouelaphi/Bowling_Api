using AutoMapper;
using BowlingLib.Model;
using BowlingRepository;
using BowlingRepository.Interface;
using BowlingService;
using BowlingService.Interfaces;
using Business;
using Mapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(JoueurProfile));
builder.Services.AddScoped<IJoueurService, JoueurService>();
builder.Services.AddScoped<IJoueurRepository, JoueurRepository>();

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