using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor.Services;
using WebbGame.Ui;
using WebbGame.Ui.Data;
using WebbGame.Ui.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddHttpClient();
builder.Services.AddServerSideBlazor();

builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthService>();
builder.Services.AddScoped<ICharacterService, CharacterService>();
builder.Services.AddMudServices();

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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();