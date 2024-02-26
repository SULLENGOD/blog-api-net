using MongoDB.Entities;

namespace SearchService.Models;

public class Post : Entity
{
    public string Title { get; set; }
    public string Content { get; set; }
    public string Excerp { get; set; }
    public string FeaturedImage { get; set; }
    public List<string> Tags { get; set; }
    public List<string> Categories { get; set; }
    public string Author { get; set; }
    public List<string> CoAuthors { get; set; }
    public string Status { get; set; }
    public List<string> Likes { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime PublishedAt { get; set; }
}
