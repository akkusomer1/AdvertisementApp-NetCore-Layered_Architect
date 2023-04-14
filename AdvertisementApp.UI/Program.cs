using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Security.Claims;
using Udemy.AdvertisementApp.Core.UnitOfWork;
using Udemy.AdvertisementApp.Data.Context;
using Udemy.AdvertisementApp.Data.UnitofWork;
using Udemy.AdvertisementApp.Service.Extantion;
using Udemy.AdvertisementApp.Service.Mapping;
using Udemy.AdvertisementApp.UI.Models;
using Udemy.AdvertisementApp.UI.ValidationRules;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AdvertisementContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("LocalDb"), opt =>
    {
        opt.MigrationsAssembly(Assembly.GetAssembly(typeof(AdvertisementContext)).GetName().Name);
    });
});



builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(opt =>
{
    opt.Cookie.Name = "MyCookie";
    opt.ExpireTimeSpan = TimeSpan.FromDays(20);
    opt.Cookie.HttpOnly = true;
    opt.Cookie.SameSite = SameSiteMode.Strict;
    opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
    opt.LoginPath = new PathString("/Account/SignIn");
    opt.LogoutPath = new PathString("/Account/LogOut");
    opt.AccessDeniedPath = new PathString("/Account/AccessDeniedPath");
});


//builder.Services.AddAuthorization(opt =>
//{
//    opt.AddPolicy("Admin", policy => policy.RequireRole(ClaimTypes.Role,"Admin"));
//    opt.AddPolicy("Member", policy => policy.RequireRole(ClaimTypes.Role,"Member"));
//});
builder.Services.AddDependencies();

builder.Services.AddFluentValidation();
builder.Services.AddValidatorsFromAssembly(typeof(UserCreateVmValidator).Assembly);

//builder.Services.AddTransient<IValidator<UserCreateVm>, UserCreateVmValidator>();

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStatusCodePagesWithReExecute("/Home/NotFound", "?code={0}");
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
