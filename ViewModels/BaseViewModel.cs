using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCSLBlog.ViewModels
{
    public class BaseViewModel
    {
        public virtual Task InitializeAsync(object parameter)
        {
            return Task.FromResult(false);
        }
        public virtual void CurrentPageOnAppearing(object sender, EventArgs e) { }
        public virtual void CurrentPageOnDisappearing(object sender, EventArgs e) { }
    }
}
