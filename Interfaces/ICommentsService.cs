using SmartCSLBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCSLBlog.Interfaces
{
    public interface ICommentsService
    {
        // Define methods for the comments service here
        Task<List<Comments>> GetCommentsAsync(int postId);
        Task<Comments> GetCommentAsync(int commentId);
        //Task AddCommentAsync(Comments comment);
        //Task UpdateCommentAsync(Comments comment);
        //Task DeleteCommentAsync(int commentId);
    }
}
