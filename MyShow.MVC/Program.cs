using Microsoft.EntityFrameworkCore;
using MyShow.Data;
using MyShow.Data.Entities;
using MyShow.Data.Extensions;
using MyShow.Data.Services.Interfaces;
using MyShow.Data.Services.Maze;
using MyShow.MVC.Policies;
using System.Net.Http.Headers;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDataServices(builder.Configuration);
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<User>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 6;
}).AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddHttpClient<ITvShowService, MazeTvShowService>(client =>
{
    client.BaseAddress = new Uri("https://api.tvmaze.com/");
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Application.Json));
}).AddPolicyHandler(PolicyHandler.WaitAndRetry())
  .AddPolicyHandler(PolicyHandler.Timeout())
  .SetHandlerLifetime(TimeSpan.FromMinutes(5));

builder.Services.AddControllersWithViews();

builder.Services.AddAutoMapper(typeof(MazeProfile).Assembly, Assembly.GetExecutingAssembly());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
  name: "areas",
  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
