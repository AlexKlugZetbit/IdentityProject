using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using IdentityProject.Data;
using IdentityProject.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = "server=localhost;database=test;uid=root;pwd=;";

builder.Services.AddDbContext<IdentityProjectContext>(options =>
    options.UseMySql(connectionString, new MySqlServerVersion(new Version(10,4,24))));

builder.Services.AddDefaultIdentity<IdentityProjectUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<IdentityProjectContext>();

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();

app.Run();
