using SQLite;
using System.Text.Json.Serialization;

namespace SmartCSLBlog.Models
{
    public class Posts
    {
        
        [PrimaryKey]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("userId")]
        public int UserId { get; set; }

        [JsonPropertyName("title")]
        public  string Title { get; set; }
    }
}
