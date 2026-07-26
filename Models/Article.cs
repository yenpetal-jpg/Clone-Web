namespace TinViet.Models;

public sealed record Article(
    int Id,
    string Category,
    string Title,
    string Summary,
    string ImageUrl,
    string Author,
    string PublishedAt,
    bool IsFeatured = false);
