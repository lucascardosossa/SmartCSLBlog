using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SmartCSLBlog.Interfaces;
using SmartCSLBlog.Models;
using SmartCSLBlog.Services;
using SmartCSLBlog.Views;
using System.Collections.ObjectModel;

namespace SmartCSLBlog.ViewModels
{
    public partial class PostsViewModel : BaseViewModel
    {
        private readonly IPostsService _service;
        private readonly IDialogService _dialogService;
        private readonly IConnectivityService _connectivityService;

        [ObservableProperty] private ObservableCollection<Posts> itens;
        [ObservableProperty] private int count;

        public PostsViewModel(
            IPostsService service,
            IDialogService dialogService,
            IConnectivityService connectivityService)
        {
            _service = service;
            _dialogService = dialogService;
            _connectivityService = connectivityService;
        }

        public override async void CurrentPageOnAppearing(object sender, EventArgs e)
        {
            await LoadPostsAsync();
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
                await _dialogService.ShowErrorAsync("Erro", "Ocorreu um erro ao selecionar o item.", "ok");
            }
        }

        [RelayCommand]
        private async Task RefreshAsync()
        {
            if (!_connectivityService.HasInternetConnection())
            {
                await _dialogService.ShowWarningAsync("Atenção", "Você não está conectado à internet.", "ok");
                return;
            }

            try
            {
                await LoadPostsAsync();
            }
            catch (Exception)
            {
                await _dialogService.ShowErrorAsync("Erro", "Ocorreu um erro ao atualizar os dados.", "ok");
            }
        }

        private async Task LoadPostsAsync()
        {
            var posts = await _service.GetPostsAsync();
            Itens = [.. posts];
            Count = Itens.Count;
        }
    }
}
