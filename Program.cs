using Microsoft.EntityFrameworkCore;
using Actividad4LengProg3.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BdMdoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexionDB")));

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configuración del middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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



