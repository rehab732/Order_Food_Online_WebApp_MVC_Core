using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Order_Food_Online.Areas.Resturant.Models;
using Order_Food_Online.Data;
using Order_Food_Online.Models;
using Order_Food_Online.Repository;
using Order_Food_Online.Services;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("myConn") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentity<ApplicationUser,IdentityRole>(options=>options.SignIn.RequireConfirmedAccount=true)
   .AddEntityFrameworkStores<ApplicationDbContext>()
   .AddDefaultUI()
   .AddDefaultTokenProviders();
builder.Services.AddTransient<IEmailSender, EmailSender>();
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ICRUDRepository<Items>, ItemRepoService>();
builder.Services.AddScoped<ICRUDRepository<Resturants>, ResturantRepoService>();
builder.Services.AddScoped<ICRUDRepository<Orders>, OrderRepoService>();
builder.Services.AddScoped<ICRUDRepository<OrderItems>, OrderItemsRepoService>();



builder.Services.AddAuthentication()
   .AddGoogle(options =>
   {
       IConfigurationSection googleAuthNSection =
       config.GetSection("Authentication:Google");
       options.ClientId = googleAuthNSection["ClientId"];
       options.ClientSecret = googleAuthNSection["ClientSecret"];
   })
   .AddFacebook(options =>
   {
       IConfigurationSection FBAuthNSection =
       config.GetSection("Authentication:FB");
       options.ClientId = FBAuthNSection["ClientId"];
       options.ClientSecret = FBAuthNSection["ClientSecret"];
   })
    .AddMicrosoftAccount(options =>
    {
        IConfigurationSection Microsoft =
        config.GetSection("Authentication:Micro");
        options.ClientId = Microsoft["ClientId"];
        options.ClientSecret = Microsoft["ClientSecret"];
    });

   




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "MyArea",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
