using SmartCSLBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCSLBlog.Interfaces
{
    public interface IPostsService
    {
        Task<List<Posts>> GetPostsAsync();
    }
}
