using Assignment_Task.Data;
using Assignment_Task.Models;
using Assignment_Task.Repositery;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
var Constring = builder.Configuration.GetConnectionString("DefaultConString");
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDBContext>(option => option.UseSqlServer(Constring));
builder.Services.AddScoped<ICustomerInfoService, CustomerInfoService>();
builder.Services.AddIdentity<AppUser, IdentityRole>(
    option =>
    {
        option.Password.RequiredUniqueChars = 1;
        option.Password.RequireUppercase = true;
        option.Password.RequireLowercase = true;
        option.Password.RequiredLength = 8;
        option.Password.RequireNonAlphanumeric = true;
    }
    ).AddEntityFrameworkStores<AppDBContext>().AddDefaultTokenProviders();


var app = builder.Build();

// Configure the HTTP request pipeline.
// Configure exception handling based on environment
if (app.Environment.IsDevelopment())
{
    // Show detailed error page in development
    app.UseDeveloperExceptionPage();
}
else
{
    // Use generic error handler in production
    app.UseExceptionHandler("/Error");
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
