using NewsApplication.DTO;
using NewsApplication.Models;

namespace NewsApplication.Services;

public interface INewsItemService
{
    Task<NewsItem> GetNewsItemByTitle(string title);
    Task<IEnumerable<NewsItem>> GetNewsItems();
    Task<NewsItem> CreateNewsItem(CreateNewsItemRequestDto request);
    Task<NewsItem> EditNewsItem(EditNewsItemRequestDto request);
    Task<NewsItem> DeleteNewsItem(string title);
}
