using Refit;
using SmartCSLBlog.Interfaces;
using SmartCSLBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCSLBlog.Services
{
    public class BaseService<T> : IBaseService
    {
        protected static string Endpoint => Session.BaseUrl;

        protected static T Service()
        {
            return RestService.For<T>(new HttpClient
            {
                BaseAddress = new Uri(Endpoint),
                Timeout = TimeSpan.FromSeconds(120)
            });
        }
    }
}
