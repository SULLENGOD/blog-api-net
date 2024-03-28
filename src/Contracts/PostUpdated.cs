namespace Contracts;

public class PostUpdated
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public List<string> CoAthors { get; set; }
    public List<string> Tags { get; set; }
    public List<string> Categories { get; set; }
}
