using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor.Services;
using BattleGameWeb.Configurations;
using BattleGameWeb.Clients;

namespace BattleGameWeb;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddMudServices();
        builder.Services.AddRazorPages();
        builder.Services.AddServerSideBlazor();

        builder.Services.Configure<ServiceUrlConfig>(
            builder.Configuration.GetSection(nameof(ServiceUrlConfig).Replace("Config", string.Empty)));
        builder.Services.AddHttpClient<GameClient>();           
        builder.Services.AddHttpClient<GameFieldClient>();

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
    }
}

