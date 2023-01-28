using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
//builder.Configuration.SetBasePath
builder.Configuration.AddJsonFile("ocelot.json", false, true);
builder.Services.AddOcelot(builder.Configuration);
    // .AddCacheManager(x =>
    // {
    //     x.WithDictionaryHandle();
    // });

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
app.UseOcelot();

app.UseAuthorization();

app.MapRazorPages();

app.Run();