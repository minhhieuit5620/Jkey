using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Middleware;
using WebApplication2.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication("AuthenticationDemo").AddCookie("AuthenticationDemo", options =>
{
    options.AccessDeniedPath = new PathString("/AccessDenied/Index");
    options.Cookie = new CookieBuilder
    {
        //Domain = "",
        HttpOnly = true,
        Name = ".aspNetCoreDemo.Security.Cookie",
        Path = "/",
        SameSite = SameSiteMode.Lax,
        SecurePolicy = CookieSecurePolicy.SameAsRequest,
    };
    options.Events = new CookieAuthenticationEvents
    {
        OnSignedIn = context =>
        {
            Console.WriteLine("{0} - {1}: {2}", DateTime.Now,
                "OnSignedIn", context.Principal.Identity.Name);
            return Task.CompletedTask;
        },
        OnSigningOut = context =>
        {
            Console.WriteLine("{0} - {1}: {2}", DateTime.Now,
                "OnSigningOut", context.HttpContext.User.Identity.Name);
            return Task.CompletedTask;
        },
        OnValidatePrincipal = context =>
        {
            Console.WriteLine("{0} - {1}: {2}", DateTime.Now,
                "OnValidatePrincipal", context.Principal.Identity.Name);
            return Task.CompletedTask;
        }
    };
    options.ExpireTimeSpan = TimeSpan.FromDays(1);
    options.LoginPath = new PathString("/User/Login");
    options.ReturnUrlParameter = "RequestPath";
    options.SlidingExpiration = true;
});

//builder.Services.AddScoped<IAuthenticationLogin, CustomAuthenticateLogin>();

//Connect DB
var connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<JkeyInternalContext>(x => x.UseSqlServer(connection));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/User/Login");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=Login}/{id?}");

app.Run();
