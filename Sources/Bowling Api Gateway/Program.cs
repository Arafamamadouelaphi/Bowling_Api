using System.Net;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("ocelot.json", false, true);
builder.Services.AddOcelot(builder.Configuration);


var app = builder.Build();


app.UseRouting();
app.UseOcelot();

//Désactiver la validation du certificat SSL
//ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };



app.MapGet("/", () => "Hello World!");

app.Run();