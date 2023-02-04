using BowlingEF.Context;
using BowlingRepository;
using BowlingRepository.Interface;
using BowlingService;
using BowlingService.Interfaces;
using Mapper;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c=>
{
    c.SwaggerDoc("v1", new() { Title = "APi Bowling APP", Version = "v1" });
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "BowlingApi.xml"));
});
builder.Services.AddAutoMapper(typeof(JoueurProfile));
builder.Services.AddScoped<IJoueurService, JoueurService>();

//Configurer la connexion à la base de données SQLite du projet BowlingEF
builder.Services.AddDbContext<BowlingContext>(options =>
{
    options.UseSqlite("Data Source=bowling.db");
});

builder.Services.AddScoped<IJoueurRepository, JoueurRepository>();
builder.Services.AddScoped<IpartieRepository, PartieRepository>();
builder.Services.AddScoped<IpartieService, PartieService>();

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
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API du projet Bowling APP v1");
        
    });
}

app.UseRouting();
app.UseEndpoints(endpoint=>
{
    endpoint.MapControllers();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();