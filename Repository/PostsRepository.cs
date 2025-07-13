using SmartCSLBlog.Models;

namespace SmartCSLBlog.Repository
{
    public class PostsRepository : CrudRepository<Posts>
    {
       public void AddPost(Posts post)
        {
            try
            {
                if(!context.database.Table<Posts>().Any(p => p.Id == post.Id))
                    context.database.Insert(post);
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding post: " + ex.Message);
            }
        }
        public List<Posts> GetAllPosts()
        {
            try
            {
                return context.database.Table<Posts>().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving posts: " + ex.Message);
            }
        }
        
    }
}
