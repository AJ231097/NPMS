using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NPMS.Models;
using System;
using System.Drawing.Text;
using Microsoft.AspNetCore.Identity;
using NuGet.Packaging.Signing;
using System.Configuration;
using WebGoatCore.Utils;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<NPMSContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("NPMSContext") ?? throw new InvalidOperationException("Connection string 'NPMSContext' not found.")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
        .AddEntityFrameworkStores<NPMSContext>().AddDefaultTokenProviders();
builder.Services.AddSession();
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Lockout.MaxFailedAccessAttempts = 3;
    options.Lockout.AllowedForNewUsers = true;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromHours(24);
    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
});

//builder.Services.AddScoped<IPasswordHasher<IdentityUser>, Argon2Hasher<IdentityUser>>();
builder.Services.Configure<PasswordHasherOptions>(option =>
{
    option.IterationCount = 160000;
});

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
app.UseSession();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
