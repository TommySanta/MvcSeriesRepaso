using Microsoft.EntityFrameworkCore;
using MvcSeriesRepaso.Data;
using MvcSeriesRepaso.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
/****************************************************************************************************************************************************/
string connectionString = builder.Configuration.GetConnectionString("MySql");
builder.Services.AddTransient<RepositorySeries>();
builder.Services.AddDbContext<SeriesContext>(options =>
    options.UseMySQL(connectionString));
/***************/
// Add services to the container.
builder.Services.AddControllersWithViews();

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
app.MapStaticAssets();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
