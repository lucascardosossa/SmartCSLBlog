using SmartCSLBlog.Interfaces;
using SmartCSLBlog.Models;
using SmartCSLBlog.Repository;

namespace SmartCSLBlog.Services
{
    public class CommentsService : BaseService<IRestAPI>, ICommentsService
    {
        public async Task<Comments> GetCommentAsync(int commentId)
        {
            var comments = await Service().GetCommentsAsync();
            return comments.FirstOrDefault(c => c.Id == commentId) ?? throw new Exception($"Comentário com  ID {commentId} não encontrado");
        }

        public async Task<List<Comments>> GetCommentsAsync(int postId)
        { 
        
            List<Comments> commentsPost = new List<Comments>();
            if (ConexaoService.TemConexaoInternet())
            {
                var comments = await Service().GetCommentsAsync();
                commentsPost = comments.Where(c => c.PostId == postId).ToList();
                SaveCommentsDB(commentsPost);
            }
            else
            {
                var repository = new CommentsRepository();
                commentsPost = repository.GetCommentsByPostId(postId);
            }

            return commentsPost;

        }

        public void SaveCommentsDB(List<Comments> comments)
        {
            foreach (var comment in comments)
            {
                try
                {
                    var repository = new CommentsRepository();
                    repository.AddComment(comment);
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao salvar comentário localmente: " + ex.Message);
                }
            }
        }
    }
}
