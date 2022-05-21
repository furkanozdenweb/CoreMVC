using AdonetCoreMVC.Services;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


// builder.Services.AddSingleton<IHesapMakinesi, HesapMakinesiKdv8>(); // AddSingleton Dependency Injection kullanýmý çok sýk kullanýlan ama sadece iþlem yapan insert,update,insert,delete methodlarý için kullanýlabilir.



//builder.Services.AddTransient<IHesapMakinesi, HesapMakinesiKdv8>(); //AddTransient  eðer 2 taným yapýlýrsa 2side ayný referans tipi alýr.  Dependency Injection kullanýmý sadece bu interface çaðýrýldýðýnda newlenir ve nesne örneði oluþturulur. sonra bellekten kaldýrýlýr.  Default olarak servislerdeki iterface tanýmlamasýnda Hangi Servis classýn çalýþacaðýný belirtir. 

builder.Services.AddScoped<IHesapMakinesi, HesapMakinesiKdv8>(); //AddScoped Dependency Injection kullanýmý sadece bu interface çaðýrýldýðýnda newlenir ve nesne örneði oluþturulur. sonra bellekten kaldýrýlýr.  Default olarak servislerdeki iterface tanýmlamasýnda Hangi Servis classýn çalýþacaðýný belirtir.



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
/*
app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "@npm")),
    RequestPath = new PathString("/vendor")
});*/

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "/{controller=Home}/{action=Index}/{id?}");


app.MapControllerRoute(
    name: "admin",
    pattern: "/{controller=Home}/{action=Index2}/{id?}");

app.MapControllerRoute(
    name: "myRoute",
    pattern: "/{controller=Home}/{action=Index3}/{id?}");


app.Run();
