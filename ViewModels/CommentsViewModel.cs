using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SmartCSLBlog.Interfaces;
using SmartCSLBlog.Models;
using SmartCSLBlog.Services;
using System.Collections.ObjectModel;

namespace SmartCSLBlog.ViewModels
{
    [QueryProperty(nameof(Posts), "p1")]
    public partial class CommentsViewModel : BaseViewModel
    {
        private readonly ICommentsService _commentsService;
        private readonly IDialogService _dialogService;
        private readonly IConnectivityService _connectivityService;

        [ObservableProperty] private ObservableCollection<Comments> comments;
        [ObservableProperty] private Posts posts;
        [ObservableProperty] private int count;

        public CommentsViewModel(
            ICommentsService commentsService,
            IDialogService dialogService,
            IConnectivityService connectivityService)
        {
            _commentsService = commentsService;
            _dialogService = dialogService;
            _connectivityService = connectivityService;
        }

        public override async void CurrentPageOnAppearing(object sender, EventArgs e)
        {
            await LoadCommentsAsync();
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
                await LoadCommentsAsync();
            }
            catch (Exception)
            {
                await _dialogService.ShowErrorAsync("Erro", "Ocorreu um erro ao atualizar os dados.", "ok");
            }
        }

        private async Task LoadCommentsAsync()
        {
            try
            {
                var comments = await _commentsService.GetCommentsAsync(Posts?.Id ?? 1);
                Comments = [.. comments];
                Count = Comments.Count;
            }
            catch (Exception)
            {
                await _dialogService.ShowErrorAsync("Erro", "Ocorreu um erro ao atualizar os dados.", "ok");
            }
        }
    }
}
