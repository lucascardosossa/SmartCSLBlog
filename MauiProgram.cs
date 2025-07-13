using Microsoft.Extensions.Logging;
using SmartCSLBlog.Interfaces;
using SmartCSLBlog.Services;
using SmartCSLBlog.ViewModels;
using SmartCSLBlog.Views;

namespace SmartCSLBlog
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<IPostsService, PostsService>();
            builder.Services.AddSingleton<ICommentsService, CommentsService>();
            builder.Services.AddTransient<PostsView>();
            builder.Services.AddTransient<PostsViewModel>();
            builder.Services.AddTransient<CommentsViewModel>();
            builder.Services.AddTransient<CommentsView>();

#if DEBUG
            builder.Logging.AddDebug();
#endif


            return builder.Build();
        }
    }
}
