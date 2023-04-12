using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

/**************************************************************************/
// Auth
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "auth";
        options.LoginPath = "/Auth/Login";
        options.LogoutPath = "/Auth/Logout";
        options.AccessDeniedPath = "/Auth/AccessDenied";
    })
    .AddMicrosoftAccount(microsoftOptions =>
    {
        microsoftOptions.ClientId = builder.Configuration["Authentication:Microsoft:ClientId"] ?? "";
        microsoftOptions.ClientSecret = builder.Configuration["Authentication:Microsoft:ClientSecret"] ?? "";
        microsoftOptions.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;

        //microsoftOptions.Events = new Microsoft.AspNetCore.Authentication.OAuth.OAuthEvents
        //{
        //    OnTicketReceived = ctx =>
        //    {
        //        var username = ctx.Principal.FindFirstValue(ClaimTypes.NameIdentifier);
        //        if (string.IsNullOrWhiteSpace(username))
        //        {
        //            ctx.HandleResponse();
        //            ctx.Response.Redirect("/");
        //            return Task.CompletedTask;
        //        }

        //        //if (!UserExists(username))
        //        //{
        //        //    CreateUser(username);
        //        //}

        //        return Task.CompletedTask;
        //    }
        //};
    });

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register HTTP Context
// builder.Services.AddHttpContextAccessor();


// Register services
FWAservices.Startup.ConfigureServices(builder.Services);

var app = builder.Build();

/**************************************************************************/
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
} else
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=Index}/{id?}");

app.Run();
