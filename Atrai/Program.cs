using Atrai.Data.Context.AppDataContext;
using Atrai.Dependency;
using Atrai.Model;
using Atrai.Model.Core.Entity;
using Atrai.Services;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using System;
using System.IO;



var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.LoginPath = "/Home/login/";
                options.ExpireTimeSpan = TimeSpan.FromHours(1000);
            });

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromHours(60 * 10000);
});
string conString = builder.Configuration.GetConnectionString("DefaultConnection");


AppData.DefaultConnectionString = conString;

builder.Services.AddControllersWithViews()
    .AddSessionStateTempDataProvider()
    .AddRazorRuntimeCompilation()
    .AddNewtonsoftJson(x =>
    {
        x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        x.SerializerSettings.ContractResolver = new DefaultContractResolver();

    })
    .AddJsonOptions(options =>
    {

        // Use the default property (Pascal) casing.
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
    });

builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<IFileProvider>(new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images")));

builder.Services
    .Configure<FormOptions>(x => x.ValueCountLimit = 100000)
    .Configure<SecurityStampValidatorOptions>(options => options.ValidationInterval = TimeSpan.FromSeconds(30));
builder.Services.AddAntiforgery(options =>
{
    // Set Cookie properties using CookieBuilder properties†.
    options.FormFieldName = "Dominate_ANTIFORZERY";
    options.HeaderName = "X-CSRF-TOKEN-Dominate_ANTIFORZERY";
    options.SuppressXFrameOptionsHeader = false;
});
builder.Services.AddMvcCore(options =>
{
    options.RequireHttpsPermanent = true;
    options.RespectBrowserAcceptHeader = true;

}).AddFormatterMappings();
builder.Services.AddDbContext<InvoiceDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.Configure<SMTPConfigModel>(builder.Configuration.GetSection("SMTPConfig"));
builder.Services.AddScoped<IUserService, UserService>();
//all repository Service Move to this function
builder.Services.RegisterReporsitory();

FirebaseApp.Create(new AppOptions()
{
    Credential = GoogleCredential.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "atrai-2a996-8d25b2c6f311.json")),
});
builder.Services.AddTransient<INotificationSender, NotificationSender>();

//builder.Services
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());


app.UseMiddleware<GTMiddleware>();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();