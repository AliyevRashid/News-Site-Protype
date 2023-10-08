using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NewsApplication.Models;

namespace NewsApplication.Data
{
    public class NewsDbContext : IdentityDbContext
    {
        public NewsDbContext(DbContextOptions<NewsDbContext> options) : base(options)
        {

        }
        public DbSet<NewsItem> Items =>Set<NewsItem>();


    }
}
