using Microsoft.EntityFrameworkCore;
using PostsService.Entities;

namespace PostsService.Data;

public class PostDbContext : DbContext
{
    public PostDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Post> Posts { get; set; }
}
