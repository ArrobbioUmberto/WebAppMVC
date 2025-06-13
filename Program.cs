using Microsoft.EntityFrameworkCore;
using WebAppMVC.Data;
using WebAppMVC.Models.Services.Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IItemServices, ItemServices>();
builder.Services.AddTransient<ICategoryServices, CategoryServices>();
builder.Services.AddDbContext<ShopContext>(options =>
{
    options.UseSqlServer("QUI DEVE ESSERE INSERITO IL CONNECTION STRING");
});

builder.Services.AddControllersWithViews();
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5193); // HTTP su tutte le interfacce
    // options.ListenAnyIP(7274, listenOptions =>
    // {
    //     listenOptions.UseHttps(); // HTTPS su tutte le interfacce
    // });
    options.Listen(System.Net.IPAddress.Parse("192.168.1.2"), 7275); // HTTP sull'IP locale
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseStaticFiles();

app.UseRouting();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
name: "detail",
pattern: "{controller=Item}/{action=Detail}/{id?}");

app.Run();
