using AdonetCoreMVC.Services;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


// builder.Services.AddSingleton<IHesapMakinesi, HesapMakinesiKdv8>(); // AddSingleton Dependency Injection kullan�m� �ok s�k kullan�lan ama sadece i�lem yapan insert,update,insert,delete methodlar� i�in kullan�labilir.



//builder.Services.AddTransient<IHesapMakinesi, HesapMakinesiKdv8>(); //AddTransient  e�er 2 tan�m yap�l�rsa 2side ayn� referans tipi al�r.  Dependency Injection kullan�m� sadece bu interface �a��r�ld���nda newlenir ve nesne �rne�i olu�turulur. sonra bellekten kald�r�l�r.  Default olarak servislerdeki iterface tan�mlamas�nda Hangi Servis class�n �al��aca��n� belirtir. 

builder.Services.AddScoped<IHesapMakinesi, HesapMakinesiKdv8>(); //AddScoped Dependency Injection kullan�m� sadece bu interface �a��r�ld���nda newlenir ve nesne �rne�i olu�turulur. sonra bellekten kald�r�l�r.  Default olarak servislerdeki iterface tan�mlamas�nda Hangi Servis class�n �al��aca��n� belirtir.



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
