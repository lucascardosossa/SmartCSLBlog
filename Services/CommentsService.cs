using SmartCSLBlog.Interfaces;
using SmartCSLBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var comments = await Service().GetCommentsAsync();
            return comments.Where(c => c.PostId == postId).ToList();
        }
    }
}
