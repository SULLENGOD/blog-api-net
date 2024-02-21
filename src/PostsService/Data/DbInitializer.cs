
using Microsoft.EntityFrameworkCore;
using PostsService.Entities;

namespace PostsService.Data;

public class DbInitializer
{
    public static void InitDB(WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        SeedData(scope.ServiceProvider.GetService<PostDbContext>());
    }

    private static void SeedData(PostDbContext context)
    {
        context.Database.Migrate();
        if (context.Posts.Any())
        {
            Console.WriteLine("Erorr");
            return;
        }

        var posts = new List<Post>()
        {
            //Posts
            new Post
            {
                Id = Guid.Parse("efe2f108-dc1b-4538-b38f-74d73befd3f3"),
                Title = "First Test Post",
                Content = "Auto-Generated content: Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.",
                Excerp = "Auto-Generated content: Lorem Ipsum is simply dummy text ...",
                FeaturedImage = "https://i.pinimg.com/564x/cf/d7/76/cfd7760f15894715d78ffe562e0b0026.jpg",
                Tags = new List<string> {
                    "auto",
                    "test",
                    "post"
                },
                Categories = new List<string> {
                    "Test",
                    "Auto-Generated",
                },
                Author = "Auto-Gen 1",
                CoAuthors = new List<string> {
                    "Sullen"
                },
                Status = Status.Published,
                Likes = new List<string> {
                    "Sullen",
                    "Auto-like"
                },
                CreatedAt = DateTime.UtcNow,
                PublishedAt = DateTime.UtcNow
            },

            new Post 
            {
                Id = Guid.Parse("7490a8d4-aee1-4c93-b543-ab056782a6e9"),
                Title = "2th Test Post",
                Content = "Auto-Generated content: Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.",
                Excerp = "Auto-Generated content: Lorem Ipsum is simply dummy text ...",
                FeaturedImage = "https://i.pinimg.com/564x/cf/d7/76/cfd7760f15894715d78ffe562e0b0026.jpg",
                Tags = new List<string> {
                    "auto",
                    "test",
                    "post"
                },
                Categories = new List<string> {
                    "Test",
                    "Auto-Generated",
                },
                Author = "Auto-Gen 1",
                CoAuthors = new List<string> {
                    "Sullen"
                },
                Status = Status.Published,
                Likes = new List<string> {
                    "Sullen",
                    "Auto-like"
                },
                CreatedAt = DateTime.UtcNow,
                PublishedAt = DateTime.UtcNow
            },

            new Post 
            {
                Id = Guid.Parse("52c1f781-ea8a-4df7-829a-7745dcaec29f"),
                Title = "3th Test Post",
                Content = "Auto-Generated content: Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.",
                Excerp = "Auto-Generated content: Lorem Ipsum is simply dummy text ...",
                FeaturedImage = "https://i.pinimg.com/564x/cf/d7/76/cfd7760f15894715d78ffe562e0b0026.jpg",
                Tags = new List<string> {
                    "auto",
                    "test",
                    "post"
                },
                Categories = new List<string> {
                    "Test",
                    "Auto-Generated",
                },
                Author = "Auto-Gen 1",
                CoAuthors = new List<string> {
                    "Sullen"
                },
                Status = Status.Published,
                Likes = new List<string> {
                    "Sullen",
                    "Auto-like"
                },
                CreatedAt = DateTime.UtcNow,
                PublishedAt = DateTime.UtcNow
            },

            new Post 
            {
                Id = Guid.Parse("509f0c33-9a7a-4036-b71f-20729665a142"),
                Title = "4th Test Post",
                Content = "Auto-Generated content: Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.",
                Excerp = "Auto-Generated content: Lorem Ipsum is simply dummy text ...",
                FeaturedImage = "https://i.pinimg.com/564x/cf/d7/76/cfd7760f15894715d78ffe562e0b0026.jpg",
                Tags = new List<string> {
                    "auto",
                    "test",
                    "post"
                },
                Categories = new List<string> {
                    "Test",
                    "Auto-Generated",
                },
                Author = "Auto-Gen 1",
                CoAuthors = new List<string> {
                    "Sullen"
                },
                Status = Status.Published,
                Likes = new List<string> {
                    "Sullen",
                    "Auto-like"
                },
                CreatedAt = DateTime.UtcNow,
                PublishedAt = DateTime.UtcNow
            },

            new Post 
            {
                Id = Guid.Parse("1e93e725-7e5c-49a0-b953-9b03689f2bd0"),
                Title = "5th Test Post",
                Content = "Auto-Generated content: Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.",
                Excerp = "Auto-Generated content: Lorem Ipsum is simply dummy text ...",
                FeaturedImage = "https://i.pinimg.com/564x/cf/d7/76/cfd7760f15894715d78ffe562e0b0026.jpg",
                Tags = new List<string> {
                    "auto",
                    "test",
                    "post"
                },
                Categories = new List<string> {
                    "Test",
                    "Auto-Generated",
                },
                Author = "Auto-Gen 1",
                CoAuthors = new List<string> {
                    "Sullen"
                },
                Status = Status.Published,
                Likes = new List<string> {
                    "Sullen",
                    "Auto-like"
                },
                CreatedAt = DateTime.UtcNow,
                PublishedAt = DateTime.UtcNow
            },

            new Post 
            {
                Id = Guid.Parse("15c1bf95-bd2b-4c54-8716-5e308c6b37c5"),
                Title = "6th Test Post",
                Content = "Auto-Generated content: Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.",
                Excerp = "Auto-Generated content: Lorem Ipsum is simply dummy text ...",
                FeaturedImage = "https://i.pinimg.com/564x/cf/d7/76/cfd7760f15894715d78ffe562e0b0026.jpg",
                Tags = new List<string> {
                    "auto",
                    "test",
                    "post"
                },
                Categories = new List<string> {
                    "Test",
                    "Auto-Generated",
                },
                Author = "Auto-Gen 1",
                CoAuthors = new List<string> {
                    "Sullen"
                },
                Status = Status.Published,
                Likes = new List<string> {
                    "Sullen",
                    "Auto-like"
                },
                CreatedAt = DateTime.UtcNow,
                PublishedAt = DateTime.UtcNow
            },

            new Post 
            {
                Id = Guid.Parse("fb4ac23a-dd16-4f19-9687-d16b7a929e83"),
                Title = "7th Test Post",
                Content = "Auto-Generated content: Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.",
                Excerp = "Auto-Generated content: Lorem Ipsum is simply dummy text ...",
                FeaturedImage = "https://i.pinimg.com/564x/cf/d7/76/cfd7760f15894715d78ffe562e0b0026.jpg",
                Tags = new List<string> {
                    "auto",
                    "test",
                    "post"
                },
                Categories = new List<string> {
                    "Test",
                    "Auto-Generated",
                },
                Author = "Auto-Gen 1",
                CoAuthors = new List<string> {
                    "Sullen"
                },
                Status = Status.Published,
                Likes = new List<string> {
                    "Sullen",
                    "Auto-like"
                },
                CreatedAt = DateTime.UtcNow,
                PublishedAt = DateTime.UtcNow
            },

            new Post 
            {
                Id = Guid.Parse("a35cef39-8252-4f15-8335-b952973a19dd"),
                Title = "8th Test Post",
                Content = "Auto-Generated content: Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.",
                Excerp = "Auto-Generated content: Lorem Ipsum is simply dummy text ...",
                FeaturedImage = "https://i.pinimg.com/564x/cf/d7/76/cfd7760f15894715d78ffe562e0b0026.jpg",
                Tags = new List<string> {
                    "auto",
                    "test",
                    "post"
                },
                Categories = new List<string> {
                    "Test",
                    "Auto-Generated",
                },
                Author = "Auto-Gen 1",
                CoAuthors = new List<string> {
                    "Sullen"
                },
                Status = Status.Published,
                Likes = new List<string> {
                    "Sullen",
                    "Auto-like"
                },
                CreatedAt = DateTime.UtcNow,
                PublishedAt = DateTime.UtcNow
            },

            new Post 
            {
                Id = Guid.Parse("28e5c8a9-07a5-4362-b49d-31b0679dd656"),
                Title = "9th Test Post",
                Content = "Auto-Generated content: Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.",
                Excerp = "Auto-Generated content: Lorem Ipsum is simply dummy text ...",
                FeaturedImage = "https://i.pinimg.com/564x/cf/d7/76/cfd7760f15894715d78ffe562e0b0026.jpg",
                Tags = new List<string> {
                    "auto",
                    "test",
                    "post"
                },
                Categories = new List<string> {
                    "Test",
                    "Auto-Generated",
                },
                Author = "Auto-Gen 1",
                CoAuthors = new List<string> {
                    "Sullen"
                },
                Status = Status.Published,
                Likes = new List<string> {
                    "Sullen",
                    "Auto-like"
                },
                CreatedAt = DateTime.UtcNow,
                PublishedAt = DateTime.UtcNow
            },

            new Post 
            {
                Id = Guid.Parse("31ab4d41-d020-4c66-b8dc-f15f5224682c"),
                Title = "10th Test Post",
                Content = "Auto-Generated content: Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.",
                Excerp = "Auto-Generated content: Lorem Ipsum is simply dummy text ...",
                FeaturedImage = "https://i.pinimg.com/564x/cf/d7/76/cfd7760f15894715d78ffe562e0b0026.jpg",
                Tags = new List<string> {
                    "auto",
                    "test",
                    "post"
                },
                Categories = new List<string> {
                    "Test",
                    "Auto-Generated",
                },
                Author = "Auto-Gen 1",
                CoAuthors = new List<string> {
                    "Sullen"
                },
                Status = Status.Published,
                Likes = new List<string> {
                    "Sullen",
                    "Auto-like"
                },
                CreatedAt = DateTime.UtcNow,
                PublishedAt = DateTime.UtcNow
            }
        };

        context.AddRange(posts);
        context.SaveChanges();
    }
}
