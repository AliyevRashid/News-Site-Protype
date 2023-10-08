using Microsoft.EntityFrameworkCore;
using NewsApplication.Data;
using NewsApplication.DTO;
using NewsApplication.Models;

namespace NewsApplication.Services;

public class NewsItemService : INewsItemService
{

    private NewsDbContext _context;


    public NewsItemService(NewsDbContext context)
    {
        _context = context;
    
    }
    public Task<NewsItem> CreateNewsItem(CreateNewsItemRequestDto createRequest)
    {
       var item = GenerateNewsItemFromRequest(createRequest);
       var items = _context.Items.ToList();
        if(items.FirstOrDefault(i=>i.Title == item.Title) == null)
        {
          _context.Items.Add(item);
            _context.SaveChanges();
          return Task.FromResult(item);
        }
        return null;
    }

    public Task<NewsItem> DeleteNewsItem(string title)
    {
        var item = _context.Items.FirstOrDefault(i=>i.Title == title);
        _context.Items.Remove(item);
        _context.SaveChanges();
        return Task.FromResult(item);
    }

    public  Task<NewsItem> EditNewsItem(EditNewsItemRequestDto editRequest)
    {
        if (editRequest == null)
           {
               return null;
           }
       var item =  _context.Items.FirstOrDefault(i => i.Title == editRequest.OldTitle);
        if(item!=null) 
        {
            
            item.Title = editRequest.Title;
            item.Description = editRequest.Description;
            item.UpdatedDate= DateTime.Now;
             _context.Items.Update(item);
             _context.SaveChanges();
            return Task.FromResult(item);
        }
        return null;
    }

    public Task<NewsItem> GetNewsItemByTitle(string title)
    {
        var item = _context.Items.FirstOrDefault(i => i.Title == title);
        return Task.FromResult(item);
    }

    public async Task<IEnumerable<NewsItem>> GetNewsItems()
    {
       var items = await _context.Items.ToListAsync();

        return items != null ? items : null; ;
    }
    


    private NewsItem GenerateNewsItemFromRequest (CreateNewsItemRequestDto request)
    {
        var item = new NewsItem() 
        {
            Title=request.Title,
            Description=request.Description,
            CreatedDate=DateTimeOffset.UtcNow,
            UpdatedDate=DateTimeOffset.UtcNow
        };
        return item;
    }
}
