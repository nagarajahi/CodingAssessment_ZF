using CodingAssessment.AppDbContext;
using CodingAssessment.Middleware;
using CodingAssessment.Repository;
using CodingAssessment.Repository.IRepository;
using CodingAssessment.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Diagnostics.CodeAnalysis;
using System.Net.Mail;
using static CodingAssessment.Services.EmailService;

[ExcludeFromCodeCoverage]
public class Program
{
    public static void Main(string[] args)
    {
        var builder = CreateHostBuilder(args).Build();
        builder.Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
}
[ExcludeFromCodeCoverage]

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseInMemoryDatabase("FoodEnforcement");
        }, ServiceLifetime.Singleton);

        services.AddSingleton<IApplicationDbContext, ApplicationDbContext>();
        services.AddSingleton<IFoodAndDrugAdministrationRepository, FoodAndDrugAdministrationRepository>();
        services.AddSingleton<SmtpClient>(); // Assuming SmtpClient is provided by .NET Framework
        services.AddSingleton<ISmtpClient, SmtpClientWrapper>();
        services.AddSingleton<IEmailService, EmailService>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();

        app.UseMiddleware<ExceptionMiddleware>();

        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}

















//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
//Log.Logger = new LoggerConfiguration()
//    .ReadFrom.Configuration(builder.Configuration)
//    .Enrich.FromLogContext()
//    .WriteTo.Console()
//    .WriteTo.File("logs/AppLog.txt")
//    .CreateLogger();
//builder.Host.UseSerilog();
//builder.Services.AddDbContext<ApplicationDbContext>(
//    options => { options.UseInMemoryDatabase("FoodEnforcement"); },
//    ServiceLifetime.Singleton);

//builder.Services.AddSingleton<IApplicationDbContext, ApplicationDbContext>();
//builder.Services.AddSingleton<IFoodAndDrugAdministrationRepository, FoodAndDrugAdministrationRepository>();
//builder.Services.AddSingleton<SmtpClient>(); // Assuming SmtpClient is provided by .NET Framework
//builder.Services.AddSingleton<EmailService.ISmtpClient, EmailService.SmtpClientWrapper>();

//// Register EmailService
//builder.Services.AddSingleton<IEmailService, EmailService>();

//var app = builder.Build();
//app.UseMiddleware<ExceptionMiddleware>();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();
//app.UseAuthorization();

//app.MapControllers();

//app.Run();
