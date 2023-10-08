namespace NewsApplication.Models;

public class NewsItem
{
   

    public int Id { get; set; }
    public string Description { get; set; }
    public string Title { get; set; }
    public DateTimeOffset CreatedDate { get; set; }
    public DateTimeOffset UpdatedDate { get; set; }
}
