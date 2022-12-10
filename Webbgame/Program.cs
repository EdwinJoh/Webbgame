using Contracts;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.HttpOverrides;
using NLog;
using Service;
using Service.Contracts;
using Webbgame.Extensions;
using Webbgame.Presentation.ActionFilters;

var builder = WebApplication.CreateBuilder(args);

LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(),
"/nlog.config"));

// Add services to the container.

builder.Services.AddControllers()
    .AddApplicationPart(typeof(Webbgame.Presentation.AssemblyReference).Assembly);

builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();
builder.Services.ConfigureLoggerService();
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddAuthentication();
builder.Services.ConfigureSwaggerGen();



builder.Services.AddScoped<ValidationFilterAttribute>();

builder.Services.AddScoped<IAuthService, AuthService>();



var app = builder.Build();

var logger = app.Services.GetRequiredService<ILoggerManager>();
app.ConfigureExceptionHandler(logger);

if (app.Environment.IsProduction())
    app.UseHsts();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI(s =>
{
  
    s.SwaggerEndpoint("/swagger/v2/swagger.json", "Code Maze API v2");
    s.SwaggerEndpoint("/swagger/v3/swagger.json", "Code Maze API v3");
});

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});
app.UseCors("CorsPolicy");

app.UseAuthentication();
app.UseAuthorization();




app.MapControllers();

app.Run();
