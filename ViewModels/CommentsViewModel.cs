using CommunityToolkit.Mvvm.ComponentModel;
using SmartCSLBlog.Interfaces;
using SmartCSLBlog.Models;
using SmartCSLBlog.Services;
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
            var _comments = await _commentsService.GetCommentsAsync(Posts?.Id ?? 1);
            Comments = new ObservableCollection<Comments>(_comments);
            if (!ConexaoService.TemConexaoInternet() && !Comments.Any())
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Nenhum comentário encontrado",
                    "Você não está conectado à internet e não há comentários salvos localmente.",
                    "OK"
                );
            }
        }
    }
}
