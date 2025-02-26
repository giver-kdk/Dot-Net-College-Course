using Microsoft.EntityFrameworkCore;
using WebApp5ByGiver.Models;

var builder = WebApplication.CreateBuilder(args);
var myConStr = builder.Configuration.GetConnectionString("myConStr");

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DbFirstContext>(options => options.UseSqlServer(myConStr));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");




app.Run();
