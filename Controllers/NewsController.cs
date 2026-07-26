using Microsoft.AspNetCore.Mvc;
using TinViet.Services;

namespace TinViet.Controllers;

public sealed class NewsController(NewsRepository news) : Controller
{
    [HttpGet("chuyen-muc/{category}")]
    public IActionResult Category(string category)
    {
        ViewBag.Category = category;
        return View(news.ByCategory(category).ToList());
    }

    [HttpGet("bai-viet/{id:int}")]
    public IActionResult Article(int id)
    {
        var article = news.Find(id);
        return article is null ? NotFound() : View(article);
    }
}
