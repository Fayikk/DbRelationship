using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DbRelationship.Entity
{
    public class Tag
    {
        [Key]
        public int TagId { get; set; }  
        public string TagName { get; set; }
        [JsonIgnore]
        public ICollection<Post> Posts { get; set; }
    }
}
