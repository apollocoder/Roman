using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Roman.Web.Models;
using Roman.Web.Services;

var webBuilder = WebApplication.CreateBuilder(args);

webBuilder.Services
    .AddControllersWithViews()
    .AddJsonOptions(
        options =>
            options.JsonSerializerOptions.DefaultIgnoreCondition =
                JsonIgnoreCondition.WhenWritingNull
    );

webBuilder.Services.AddSwaggerGen();

webBuilder.Services.AddDbContext<Database>(
    options =>
        options.UseSqlServer(
            webBuilder.Configuration.GetConnectionString("DbContext"),
            providerOptions => providerOptions.EnableRetryOnFailure()
        )
);

webBuilder.Services.AddScoped<ISettings, AppSettings>();

var webApp = webBuilder.Build();

if (webApp.Environment.IsDevelopment())
{
    webApp.UseSwagger();
    webApp.UseSwaggerUI();
}
else
{
    webApp.UseHsts();
    webApp.UseHttpsRedirection();
}

webApp.UseStaticFiles();
webApp.UseRouting();

webApp.UsePathBase("/api");
webApp.MapControllerRoute(name: "default", pattern: "{controller}/{action=Index}/{id?}");

webApp.MapFallbackToFile("index.html");

webApp.Run();

public partial class Program { }
