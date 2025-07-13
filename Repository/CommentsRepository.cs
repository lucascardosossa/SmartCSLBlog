using SmartCSLBlog.Models;

namespace SmartCSLBlog.Repository
{
    public class CommentsRepository : CrudRepository<Comments>
    {
        public CommentsRepository() { }
        public void AddComment(Comments comment)
        {
            try
            {
                if (!context.database.Table<Comments>().Any(c => c.Id == comment.Id))
                    context.database.Insert(comment);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível guardar o comentário: " + ex.Message);
            }
        }

        public List<Comments> GetAllComments()
        {
            try
            {
                return context.database.Table<Comments>().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar os comentários: " + ex.Message);
            }
        }

        internal List<Comments> GetCommentsByPostId(int postId)
        {
            try
            {
                var comments = GetAllComments();
                return comments.Where(c => c.PostId == postId).ToList();
            }
            catch (Exception ex)
            {

                throw new Exception("Não foi possível buscar os comentários: " + ex.Message);
            }
        }
    }
}
