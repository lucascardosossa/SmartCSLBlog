using System;
using System.Text.Json.Serialization;

namespace SmartCSLBlog.Models
{
    public class Posts
    {
        [JsonPropertyName("userId")]
        public int UserId { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public required string Title { get; set; }
    }
}
