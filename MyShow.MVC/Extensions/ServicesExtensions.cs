using MyShow.Data;
using MyShow.Data.Entities;
using MyShow.Data.Services.Interfaces;
using MyShow.Data.Services.Maze;
using MyShow.MVC.Policies;
using System.Net.Http.Headers;
using static System.Net.Mime.MediaTypeNames;

namespace MyShow.MVC.Extensions;

public static class ServicesExtensions
{
    public static void AddHttpClients(this IServiceCollection services)
    {
        services.AddHttpClient<ITvShowService, MazeTvShowService>(client =>
        {
            client.BaseAddress = new Uri("https://api.tvmaze.com/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Application.Json));
        })
            .AddPolicyHandler(PolicyHandler.WaitAndRetry())
            .AddPolicyHandler(PolicyHandler.Timeout())
            .SetHandlerLifetime(TimeSpan.FromMinutes(5));
    }

    public static void AddIdentity(this IServiceCollection services)
    {
        services.AddDefaultIdentity<User>(options =>
        {
            options.SignIn.RequireConfirmedAccount = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireDigit = false;
            options.Password.RequiredLength = 6;
        }).AddEntityFrameworkStores<AppDbContext>();
    }
}
