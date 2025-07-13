using SmartCSLBlog.Interfaces;
using SmartCSLBlog.Models;
using SmartCSLBlog.Repository;

namespace SmartCSLBlog.Services
{
    public class PostsService : BaseService<IRestAPI>, IPostsService
    {
        public PostsService() : base()
        {
        }
        public async Task<List<Posts>> GetPostsAsync()
        {
            List<Posts> posts;
            if (NetworkService.HasInternetConnection())
            {
                posts = await Service().GetPostsAsync();
                SavePostsDB(posts);
            }
            else
            {
                var repository = new PostsRepository();
                posts = repository.GetAllPosts();
            }

            return posts;
        }
        public async Task<Posts> GetPostAsync(int id)
        {
            var posts = Service().GetPostsAsync();
            return posts.Result.FirstOrDefault(p => p.Id == id) ?? throw new Exception($"Post with ID {id} not found.");

        }

        private void SavePostsDB(List<Posts> posts)
        {
            foreach (var post in posts)
            {
                try
                {
                    var repository = new PostsRepository();
                    repository.AddPost(post);
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao salvar posts localmente: " + ex.Message);
                }
            }
        }
    }
}
