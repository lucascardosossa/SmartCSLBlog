using Refit;
using SmartCSLBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCSLBlog.Interfaces
{
    public interface IRestAPI
    {
        [Get("/posts")]
        Task<List<Posts>> GetPostsAsync();
    }
}
