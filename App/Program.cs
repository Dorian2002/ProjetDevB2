using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Microsoft.AspNetCore.Identity;
using App.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using App.Models;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Server=localhost;Database=test_db;Port=5432;User Id=root;Password=root");;

builder.Services.AddDbContext<ApplicationDbContext>(options => options
    .UseNpgsql("Server=localhost;Database=test_db;Port=5432;User Id=root;Password=root"));

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

using (var scope = app.Services.CreateScope()){
    var result = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>().Database.EnsureCreated();
    //scope.ServiceProvider.GetRequiredService<ApplicationDbContext>().Seed();
}
app.UseAuthentication();

app.Run();
