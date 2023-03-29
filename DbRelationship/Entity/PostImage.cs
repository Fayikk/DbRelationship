using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DbRelationship.Entity
{
    public class PostImage
    {
        [Key]
        public int PostImageId { get; set; }
        public string Caption { get; set; }

        public int PostId { get; set; }
        [JsonIgnore]
        public Post Post { get; set; }
    }
}
