using BowlingRepository;
using BowlingRepository.Interface;
using BowlingService;
using BowlingService.Interfaces;
using GraphQL_Project;
using Mapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddGraphQLServer()
    .AddQueryType<Query>();
builder.Services.AddAutoMapper(typeof(JoueurProfile));
builder.Services.AddScoped<IJoueurService, JoueurService>();
builder.Services.AddScoped<IJoueurRepository, JoueurRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapGraphQL();

app.Run();