using System.ComponentModel.DataAnnotations;

namespace DbRelationship.Entity
{
    public class Blog
    {
        [Key]
        public int BlogId { get; set; } 
        public string Url { get; set; } 
        public List<Post> Posts { get; set; }
    }
}
