var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

//OBLIGATORIO PARA ARCHIVOS STATICOS DE CSS O JS
app.UseStaticFiles();

//PARA LAS RUTAS USAR MAPControllerRoute
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
    