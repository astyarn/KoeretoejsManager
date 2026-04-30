using KoeretoejsManager.Components;
using KoeretoejsManager.Interfaces;
using KoeretoejsManager.Services;

namespace KoeretoejsManager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddHttpClient<IUserAuthApiService, UserAuthApiService>();
            builder.Services.AddScoped<IUserTokenStore, UserTokenStore>();
            builder.Services.AddHttpClient<IVehicleApiService, VehicleApiService>(client =>
            {
                var baseUrl = builder.Configuration["Api:BaseUrl"];

                if (string.IsNullOrWhiteSpace(baseUrl))
                    throw new InvalidOperationException("Api:BaseUrl is not configured.");

                client.BaseAddress = new Uri(baseUrl);
            });

            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
            app.UseHttpsRedirection();

            app.UseAntiforgery();

            app.MapStaticAssets();
            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
