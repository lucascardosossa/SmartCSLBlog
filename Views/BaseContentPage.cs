using CommunityToolkit.Mvvm.ComponentModel;
using SmartCSLBlog.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCSLBlog.Views
{
    public abstract class BaseContentPage<TViewModel> : ContentPage where TViewModel : ObservableObject
    {
        protected BaseContentPage(TViewModel viewModel)
        {
            base.BindingContext = viewModel;
        
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (BindingContext is BaseViewModel baseViewModel)
            {
                baseViewModel.CurrentPageOnAppearing(this, EventArgs.Empty);
            }
        }

        protected new TViewModel BindingContext => (TViewModel)base.BindingContext;
    }
}
