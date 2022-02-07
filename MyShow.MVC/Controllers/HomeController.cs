using Microsoft.AspNetCore.Mvc;
using MyShow.MVC.Models;
using MyShow.Shared.ResponseModels;
using System.Diagnostics;

namespace MyShow.MVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult SearchTvShow(string title)
    {
        // TODO: Call Search Tv Show action
        var tvShow = new TvShowResponse
        {
            Id = 1,
            ImageUri = "https://m.media-amazon.com/images/M/MV5BNGY3MmUzNjktZWEzNi00ODdiLTk4ZDItZjBhMjZlYzI0NTJjXkEyXkFqcGdeQXVyMTEyMjM2NDc2._V1_.jpg",
            Name = title
        };

        return Ok(tvShow);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
