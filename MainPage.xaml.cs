using SmartCSLBlog.Services;
using SmartCSLBlog.Views;

namespace SmartCSLBlog
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object? sender, EventArgs e)
        {
            IrPraPosts();
        }

        private async Task IrPraPosts()
        {
            await NavigationService.NavigationGoTo<PostsView>();
        }
    }
}
