using SmartCSLBlog.ViewModels;

namespace SmartCSLBlog.Views;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class PostsView : BaseContentPage<PostsViewModel>
{
    public PostsView(PostsViewModel viewModel) : base(viewModel)
    {
        InitializeComponent();
    }
}

