using SmartCSLBlog.ViewModels;
namespace SmartCSLBlog.Views;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class CommentsView : BaseContentPage<CommentsViewModel>
{
	public CommentsView(CommentsViewModel viewModel) : base(viewModel)
    {
		InitializeComponent();
	}
}