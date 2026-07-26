using Microsoft.AspNetCore.Mvc;
using TinViet.Services;

namespace TinViet.Controllers;

public sealed class HomeController(NewsRepository news) : Controller
{
    public IActionResult Index() => View(news);
    public IActionResult Search(string? q) => View(news.Search(q).ToList());
    public IActionResult Login() => View();
}
