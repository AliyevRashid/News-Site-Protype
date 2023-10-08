using Microsoft.EntityFrameworkCore;
using NewsApplication.Data;
using NewsApplication.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<INewsItemService, NewsItemService>();
builder.Services.AddDbContext<NewsDbContext>(
    options=>
        options.UseSqlServer(
            builder.Configuration.GetConnectionString("NewsDbContext")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=News}/{action=Index}/{id?}");

app.Run();
