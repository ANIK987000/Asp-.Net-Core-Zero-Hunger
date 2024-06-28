using Microsoft.EntityFrameworkCore;
using Zero_Hunger_Management.Data;
using Zero_Hunger_Management.Repo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ZeroHungerDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")));
var app = builder.Build();

// In Program.cs or Startup.cs, add the repository to the services collection
//builder.Services.AddTransient<RestaurantRepo>();

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
    pattern: "{controller=Login}/{action=Login}/{id?}");

app.Run();
