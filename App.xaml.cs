
using SmartCSLBlog.Models;

namespace SmartCSLBlog
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            CarregarVariavesSessao();
        }

        private void CarregarVariavesSessao()
        {
            Session.BaseUrl = "https://jsonplaceholder.typicode.com/";
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}