using Microsoft.Extensions.Logging;
using SmartCSLBlog.Behaviors;
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

            ModelLocator.RegisterSingleton(typeof(IPostsService), typeof(PostsService));
            ModelLocator.RegisterSingleton(typeof(ICommentsService), typeof(CommentsService));
            ModelLocator.RegisterSingleton(typeof(IDialogService), typeof(DialogService));
            ModelLocator.RegisterSingleton(typeof(IConnectivityService), typeof(ConnectivityService));


#if DEBUG
            builder.Logging.AddDebug();
#endif


            return builder.Build();
        }
    }
}
