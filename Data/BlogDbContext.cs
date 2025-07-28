using Microsoft.EntityFrameworkCore;
using wweblog.Models;

namespace wweblog.Data
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options) { }

        public DbSet<Comment> Comments { get; set; }
        // public DbSet<Post> Posts { get; set; } // Nếu có model Post
    }
}
