using Microsoft.EntityFrameworkCore;
using LibraryProject.Models;

var builder = WebApplication.CreateBuilder(args);

// получаем строку подключения из файла конфигурации
string connection = builder.Configuration.GetConnectionString("DefaultConnection");

// добавляем контекст ApplicationContext в качестве сервиса в приложение
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));


// добавляем поддержку контроллеров с представлениями
builder.Services.AddControllersWithViews();
var app = builder.Build();

app.UseStaticFiles();

// устанавливаем сопоставление маршрутов с контроллерами
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


    