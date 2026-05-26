using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews().AddRazorOptions(options =>
{
    options.ViewLocationFormats.Clear();

    options.ViewLocationFormats.Add("/Modulo{1}/Apresentacao/Views/{0}.cshtml");

    options.ViewLocationFormats.Add("/Compartilhado/Apresentacao/Views/{0}.cshtml");
});

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();
app.MapDefaultControllerRoute();

app.Run();
