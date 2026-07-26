using TinViet.Models;

namespace TinViet.Services;

public sealed class NewsRepository
{
    public IReadOnlyList<string> Categories { get; } = ["Thời sự", "Thế giới", "Kinh tế", "Đời sống", "Sức khỏe", "Giới trẻ", "Giáo dục", "Văn hóa", "Giải trí", "Thể thao", "Công nghệ", "Xe"];

    public IReadOnlyList<Article> Articles { get; } =
    [
        new(1, "Thời sự", "Thành phố mở thêm những không gian xanh bên dòng sông", "Những khoảng thở mới giữa đô thị đang dần hoàn thiện, mang lại nơi gặp gỡ và vận động cho cộng đồng.", "https://images.unsplash.com/photo-1583416750470-965b2707b355?auto=format&fit=crop&w=1200&q=85", "Minh An", "Hôm nay, 08:10", true),
        new(2, "Kinh tế", "Doanh nghiệp Việt tìm nhịp tăng trưởng mới trong nửa cuối năm", "Sự linh hoạt trong quản trị và đầu tư công nghệ đang tạo ra những cơ hội bền vững.", "https://images.unsplash.com/photo-1556761175-b413da4baf72?auto=format&fit=crop&w=900&q=85", "Hà Phương", "Hôm nay, 09:20"),
        new(3, "Giáo dục", "Mùa hè của những lớp học mở ra ngoài cánh cửa trường", "Từ thư viện cộng đồng đến bảo tàng, học sinh có thêm nhiều trải nghiệm đáng nhớ.", "https://images.unsplash.com/photo-1503676260728-1c00da094a0b?auto=format&fit=crop&w=900&q=85", "Ngọc Dung", "Hôm nay, 10:05"),
        new(4, "Công nghệ", "Những công cụ số giúp người trẻ sáng tạo theo cách riêng", "Công nghệ đang trở thành chất liệu tự nhiên trong các dự án cá nhân và cộng đồng.", "https://images.unsplash.com/photo-1518770660439-4636190af475?auto=format&fit=crop&w=900&q=85", "Thành Luân", "Hôm nay, 10:40"),
        new(5, "Đời sống", "Một buổi sáng chậm rãi ở những con hẻm cũ", "Nhịp sống thân thuộc vẫn được giữ lại qua gánh hàng, tiếng chào và những mái hiên đầy nắng.", "https://images.unsplash.com/photo-1528127269322-539801943592?auto=format&fit=crop&w=900&q=85", "Bảo Trân", "Hôm nay, 11:15"),
        new(6, "Thể thao", "Các vận động viên trẻ hướng đến mùa giải đầy kỳ vọng", "Sự chuẩn bị kỹ lưỡng và tinh thần đồng đội là hành trang cho chặng đường mới.", "https://images.unsplash.com/photo-1461896836934-ffe607ba8211?auto=format&fit=crop&w=900&q=85", "Quang Huy", "Hôm nay, 12:00"),
        new(7, "Văn hóa", "Triển lãm đánh thức ký ức về một thành phố ven sông", "Những bức ảnh tư liệu kể lại hành trình thay đổi của thành phố qua nhiều thập kỷ.", "https://images.unsplash.com/photo-1564399579883-451a5d44ec08?auto=format&fit=crop&w=900&q=85", "Diệu Linh", "Hôm qua, 19:30"),
        new(8, "Sức khỏe", "Thói quen nhỏ tạo nền tảng cho một ngày nhiều năng lượng", "Các chuyên gia khuyến khích những thay đổi vừa sức, đều đặn và phù hợp với từng người.", "https://images.unsplash.com/photo-1506126613408-eca07ce68773?auto=format&fit=crop&w=900&q=85", "Thùy Vy", "Hôm qua, 18:10"),
        new(9, "Thế giới", "Những thành phố ven biển chuẩn bị cho một mùa lễ hội mới", "Du khách tìm đến các không gian công cộng, âm nhạc đường phố và những chợ phiên đầy màu sắc.", "https://images.unsplash.com/photo-1500534314209-a25ddb2bd429?auto=format&fit=crop&w=900&q=85", "Hải Nam", "Hôm qua, 16:25"),
        new(10, "Thời sự", "Những tuyến xe buýt điện mang lại lựa chọn di chuyển mới", "Kết nối thuận tiện và không gian công cộng thân thiện đang góp phần thay đổi diện mạo đô thị.", "https://images.unsplash.com/photo-1544620347-c4fd4a3d5957?auto=format&fit=crop&w=900&q=85", "Gia Hân", "Hôm nay, 13:20"),
        new(11, "Thời sự", "Góc chợ nhỏ giữ lại hương vị của một khu phố lâu đời", "Những người bán hàng đã tạo nên một không gian sống động bằng sự thân quen mỗi ngày.", "https://images.unsplash.com/photo-1533900298318-6b8da08a523e?auto=format&fit=crop&w=900&q=85", "Khánh Vy", "Hôm nay, 14:15")
    ];

    public Article? Find(int id) => Articles.FirstOrDefault(article => article.Id == id);
    public IEnumerable<Article> ByCategory(string category)
    {
        var matching = Articles.Where(article => article.Category.Equals(category, StringComparison.OrdinalIgnoreCase)).ToList();
        var remaining = Articles
            .Where(article => !matching.Contains(article))
            .Take(6 - matching.Count)
            .Select(article => article with { Category = category });

        return matching.Concat(remaining).Take(6);
    }
    public IEnumerable<Article> Search(string? query) => string.IsNullOrWhiteSpace(query) ? Articles : Articles.Where(article => $"{article.Title} {article.Summary} {article.Category}".Contains(query, StringComparison.OrdinalIgnoreCase));
}
