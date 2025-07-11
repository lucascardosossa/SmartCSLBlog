using SmartCSLBlog.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartCSLBlog.Models;

namespace SmartCSLBlog.Services
{
    public class PostsService : BaseService<IRestAPI>, IPostsService
    {
        public PostsService() : base()
        {
        }
        public async Task<List<Posts>> GetPostsAsync()
        {
            return await Service().GetPostsAsync();
        }
        public async Task<Posts> GetPostAsync(int id)
        {
            var posts = Service().GetPostsAsync();
            return posts.Result.FirstOrDefault(p => p.Id == id) ?? throw new Exception($"Post with ID {id} not found.");
        }
    }
}
