namespace PostsService.DTOs;

public class UpdatePostDto
{
    public string Title { get; set; }
    public string Content { get; set; }
    public List<string> CoAthors { get; set; }
    public List<string> Tags { get; set; }
    public List<string> Categories { get; set; }
}
