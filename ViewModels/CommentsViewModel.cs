using CommunityToolkit.Mvvm.ComponentModel;
using SmartCSLBlog.Interfaces;
using SmartCSLBlog.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCSLBlog.ViewModels
{
    [QueryProperty(nameof(Posts), "p1")]
    public partial class CommentsViewModel : BaseViewModel
    {
        private readonly ICommentsService _commentsService;

        [ObservableProperty] private ObservableCollection<Comments> comments;
        [ObservableProperty] private Posts posts;

        public CommentsViewModel(ICommentsService commentsService)
        {
            _commentsService = commentsService;
            Posts = posts;
        }

        public override async void CurrentPageOnAppearing(object sender, EventArgs e)
        {
            // Use the generated property 'Post' instead of directly referencing the field 'post'
            var _comments = await _commentsService.GetCommentsAsync(Posts?.Id ?? 1);
            Comments = new ObservableCollection<Comments>(_comments);
        }
    }
}
