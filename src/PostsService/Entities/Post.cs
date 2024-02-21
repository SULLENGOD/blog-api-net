namespace PostsService.Entities;

public class Post
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string Excerp { get; set; }
    public string FeaturedImage { get; set; }
    public List<string> Tags { get; set; }
    public List<string> Categories { get; set; }
    public string Author { get; set; }
    public List<string> CoAuthors { get; set; }
    public Status Status { get; set; }
    public List<string> Likes { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public DateTime PublishedAt { get; set; } = DateTime.UtcNow;
}
