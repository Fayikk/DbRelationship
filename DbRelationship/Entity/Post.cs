using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DbRelationship.Entity
{
    public class Post
    {
        [Key]
        public int PostId { get; set; } 
        public string Title { get; set; }
        public string Content { get; set; }
        public int BlogId { get; set; }
        [JsonIgnore]
        public Blog Blog { get; set; }
        public PostImage PostImage { get; set; }
        public ICollection<Tag> Tags { get; set; }

    }
}
