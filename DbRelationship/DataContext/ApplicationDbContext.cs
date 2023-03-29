using DbRelationship.Entity;
using Microsoft.EntityFrameworkCore;

namespace DbRelationship.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<PostImage> PostImages { get; set; }    
        public DbSet<Tag> Tags { get; set; }    
    }
}
