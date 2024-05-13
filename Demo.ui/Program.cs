using Microsoft.EntityFrameworkCore;
using Demo.database;
using Demo.application.UserAdmin;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{

}).AddEntityFrameworkStores<Appdbcontext>();

builder.Services.AddTransient<Register>();
builder.Services.AddDbContext<Appdbcontext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    options.EnableSensitiveDataLogging();
});
builder.Services.AddControllersWithViews();   
builder.Services.AddControllersWithViews().AddRazorPagesOptions(
    options => {
        //options.Conventions.AuthorizeFolder("/Actions");
        options.Conventions.AuthorizePage("/Actions/ActionIndex");

    }
);
builder.Services.AddHttpClient();
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

app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();

app.Run();
