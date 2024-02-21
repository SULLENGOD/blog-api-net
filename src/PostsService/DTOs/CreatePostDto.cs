using System.ComponentModel.DataAnnotations;

namespace PostsService.DTOs;

public class CreatePostDto
{
    [Required]
    public string Title { get; set; }

    [Required]
    public string Content { get; set; }

    [Required]
    public string Author { get; set; }

    [Required]
    public List<string> CoAuthors { get; set; }

    [Required]
    public string Status { get; set; }

    [Required]
    public string FeaturedImage { get; set; }

    [Required]
    public List<string> Tags { get; set; }

    [Required]
    public List<string> Categories { get; set; }

}
