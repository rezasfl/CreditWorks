using CreditWorks.VehicleManagement.Core.Managers;
using CreditWorks.VehicleManagement.Data;
using CreditWorks.VehicleManagement.Vehicles;
using CreditWorks.VehicleManagement.Categories;
using Fluxor;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<VehicleManager>();
builder.Services.AddVehicles();
builder.Services.AddCategories();

builder.Services.AddFluxor(o =>
{
    o.ScanAssemblies(typeof(Program).Assembly);
});

//Getting the connection string from appsettings
//IMPORTANT: Make sure you have set the connection string in appsettings.json
var connectionString = builder.Configuration.GetConnectionString("Default") ?? throw new NullReferenceException("No connection string in appsettings.json");

//Registring DbContextFactory so that we can inject this factory to access our DB when needed.
builder.Services.AddDbContextFactory<VehiclesDbContext>(options => options.UseSqlServer(connectionString));

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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
