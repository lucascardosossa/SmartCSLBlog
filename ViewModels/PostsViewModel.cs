using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SmartCSLBlog.Interfaces;
using SmartCSLBlog.Models;
using SmartCSLBlog.Services;
using SmartCSLBlog.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCSLBlog.ViewModels
{
    public partial class PostsViewModel : BaseViewModel
    {
        private readonly IPostsService _service;

        [ObservableProperty] private ObservableCollection<Posts> itens;

        public PostsViewModel(IPostsService service)
        {
            _service = service;
        }

        public override async void CurrentPageOnAppearing(object sender, EventArgs e)
        {
            var _posts = await _service.GetPostsAsync();

            Itens = [.._posts];
        }

        [RelayCommand]
        private async Task ItemSelecionadoAsync(object obj)
        {
            try
            {
                var posts = obj as Posts;
                await NavigationService.NavigationGoTo<CommentsView>(posts);
            }
            catch (Exception ex)
            {
                _ = Shell.Current.DisplayAlert("Erro", "Ocorreu um erro ao selecionar o item.", "ok");
            }
        }
    }
}
