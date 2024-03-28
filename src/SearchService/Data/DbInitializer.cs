using System.Text.Json;
using MongoDB.Driver;
using MongoDB.Entities;
using SearchService.Models;

namespace SearchService;

public class DbInitializer
{
    public static async Task InitDb(WebApplication app)
    {
        await DB.InitAsync("SearchDb", MongoClientSettings
            .FromConnectionString(app.Configuration.GetConnectionString("MongoDbConnection")));

        await DB.Index<Post>()
            .Key(x => x.Title, KeyType.Text)
            .Key(x => x.Author, KeyType.Text)
            .CreateAsync();

        var count = await DB.CountAsync<Post>();

        using var scope = app.Services.CreateScope();
        var httpClient = scope.ServiceProvider.GetRequiredService<PostSvcHttpClient>();
        var posts = await httpClient.GetPostsForSearchDb();

        Console.WriteLine(posts.Count + " Posts found");

        if(posts.Count > 0) await DB.SaveAsync(posts);
    }    
}
