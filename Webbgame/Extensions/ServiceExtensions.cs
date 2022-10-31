﻿using Contracts;
using LoggerService;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Repository;
using Service;
using Service.Contracts;

namespace Webbgame.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureCors(this IServiceCollection services) =>
     services.AddCors(options =>
     {
         options.AddPolicy("CorsPolicy", builder =>
         builder.AllowAnyOrigin()
         .AllowAnyMethod()
         .AllowAnyHeader());
     });

    public static void ConfigureIISIntegration(this IServiceCollection services) =>
         services.Configure<IISOptions>(options =>
         {
         });

    public static void ConfigureLoggerService(this IServiceCollection services) =>
     services.AddSingleton<ILoggerManager, LoggerManager>();

    public static void ConfigureRepositoryManager(this IServiceCollection services) =>
     services.AddScoped<IRepositoryManager, RepositoryManager>();

    public static void ConfigureServiceManager(this IServiceCollection services) =>
    services.AddScoped<IServiceManager, ServiceManager>();

    public static void ConfigureSqlContext(this IServiceCollection services,
    IConfiguration configuration) =>
         services.AddDbContext<RepositoryContext>(opts =>
             opts.UseSqlServer(configuration.GetConnectionString("sqlConnection")));

    public static void ConfigureSwaggerGen(this IServiceCollection services)
    {
        services.AddSwaggerGen(s =>
        {
            s.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Code Maze API",
                Version = "v1"
            });
            s.SwaggerDoc("v2", new OpenApiInfo
            {
                Title = "Code Maze API",
                Version = "v2"
            });
        });
    }




}
