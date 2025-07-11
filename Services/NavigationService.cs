using SmartCSLBlog.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCSLBlog.Services
{
    public class NavigationService
    {
        public static async Task Voltar()
        {
            try
            {
                await Shell.Current.GoToAsync("..");
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Erro", ex.Message, "Ok");
            }
        }
        public static async Task NavigationPushAsync<T>(bool modal = false)
        {
            try
            {
                //Cria o Type da página
                Type pageType = Type.GetType(typeof(T).FullName); // GetPageTypeForViewModel(typeof(T));
                if (pageType == null)
                {
                    throw new Exception($"Não foi possível criar o tipo da página {typeof(T)}");
                }
                //Cria a instância da página
                Page page = Activator.CreateInstance(pageType) as Page;
                //Cria a instância da ViewModel da Página
                var viewModel = Activator.CreateInstance<T>();
                //atribui o BindingContext da página
                page.BindingContext = viewModel;
                //Inicializa os eventos CurrentPageOnAppearing e CurrentPageOnDisappearing
                if (page?.BindingContext is BaseViewModel a)
                {
                    Shell.Current.CurrentPage.Appearing += a.CurrentPageOnAppearing;
                    Shell.Current.CurrentPage.Disappearing += a.CurrentPageOnDisappearing;
                    //a.CurrentPageOnAppearing(Shell.Current.CurrentPage, new EventArgs());
                }

                //Chama a página no Navigation do Shell.
                if (modal)
                {
                    await Shell.Current.Navigation.PushModalAsync(page, true);
                }
                else
                {
                    await Shell.Current.Navigation.PushAsync(page, true);
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Erro", ex.Message, "Ok");
            }
        }
        public static async Task NavigationBackAsync(bool modal = false)
        {
            try
            {
                if (modal)
                {
                    await Shell.Current.Navigation.PopModalAsync(true);
                }
                else
                {
                    await Shell.Current.Navigation.PopAsync(true);
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Erro", ex.Message, "Ok");
            }
        }

        public static async Task NavigationGoTo<T>()
        {
            try
            {
                Routing.RegisterRoute($"{typeof(T).Name}", typeof(T));
                await Shell.Current.GoToAsync($"{typeof(T).Name}", true);

                if (Shell.Current.CurrentPage?.BindingContext is BaseViewModel a)
                {
                    Shell.Current.CurrentPage.Appearing += a.CurrentPageOnAppearing;
                    Shell.Current.CurrentPage.Disappearing += a.CurrentPageOnDisappearing;
                    a.CurrentPageOnAppearing(Shell.Current.CurrentPage, new EventArgs());
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Erro", ex.Message, "Ok");
            }
        }

        public static async Task NavigationGoTo<T>(Dictionary<string, object> parametro)
        {
            try
            {
                Routing.RegisterRoute($"{typeof(T).Name}", typeof(T));
                await Shell.Current.GoToAsync($"{typeof(T).Name}", true, parametro);

                if (Shell.Current.CurrentPage?.BindingContext is BaseViewModel a)
                {
                    Shell.Current.CurrentPage.Appearing += a.CurrentPageOnAppearing;
                    Shell.Current.CurrentPage.Disappearing += a.CurrentPageOnDisappearing;
                    a.CurrentPageOnAppearing(Shell.Current.CurrentPage, new EventArgs());
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Erro", ex.Message, "Ok");
            }
        }

        public static async Task NavigationGoTo<T>(params object[] parametro)
        {
            try
            {
                int count = 1;
                Dictionary<string, object> dic = new Dictionary<string, object>();
                foreach (var param in parametro)
                {
                    dic.Add($"p{count}", param);
                    count++;
                }

                Routing.RegisterRoute($"{typeof(T).Name}", typeof(T));
                await Shell.Current.GoToAsync($"{typeof(T).Name}", true, dic);

                if (Shell.Current.CurrentPage?.BindingContext is BaseViewModel a)
                {
                    Shell.Current.CurrentPage.Appearing += a.CurrentPageOnAppearing;
                    Shell.Current.CurrentPage.Disappearing += a.CurrentPageOnDisappearing;
                    a.CurrentPageOnAppearing(Shell.Current.CurrentPage, new EventArgs());
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Erro", ex.Message, "Ok");
            }
        }

        public static async void PopUntil<T>()
        {
            try
            {
                StringBuilder st = new StringBuilder();
                var itens = Shell.Current.Navigation.NavigationStack.ToList();
                itens.Reverse();
                foreach (Page p in itens)
                {
                    if (p != null)
                    {
                        if (p.GetType().Name.Equals(typeof(T).Name)) break;
                        else
                            st.Append("../");
                    }
                }

                await Shell.Current.GoToAsync(st.ToString(), true);
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Erro", ex.Message, "Ok");
            }
        }

        private static Type GetPageTypeForViewModel(Type viewModelType)
        {
            string viewName = viewModelType.FullName.Replace("Model", string.Empty);

            var viewType = Type.GetType(viewName);
            return viewType;
        }
        public static async Task Voltar(params object[] parametro)
        {
            try
            {
                int count = 1;
                Dictionary<string, object> dic = new Dictionary<string, object>();
                foreach (var param in parametro)
                {
                    dic.Add($"p{count}", param);
                    count++;
                }

                await Shell.Current.GoToAsync($"..", dic);
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Erro", ex.Message, "Ok");
            }
        }
        public static async Task Voltar(Dictionary<string, object> parametro)
        {
            try
            {
                await Shell.Current.GoToAsync($"..", parametro);
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Erro", ex.Message, "Ok");
            }
        }


        public static async void PopUntil<T>(params object[] parametro)
        {
            try
            {
                int count = 1;
                Dictionary<string, object> dic = new Dictionary<string, object>();
                foreach (var param in parametro)
                {
                    dic.Add($"p{count}", param);
                    count++;
                }

                StringBuilder st = new StringBuilder();
                var itens = Shell.Current.Navigation.NavigationStack.ToList();
                itens.Reverse();
                foreach (Page p in itens)
                {
                    if (p != null)
                    {
                        if (p.GetType().Name.Equals(typeof(T).Name)) break;
                        else
                            st.Append("../");
                    }
                }

                await Shell.Current.GoToAsync(st.ToString(), dic);
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Erro", ex.Message, "Ok");
            }
        }
        public static async void PopUntil<T>(Dictionary<string, object> parametro)
        {
            try
            {
                StringBuilder st = new StringBuilder();
                var itens = Shell.Current.Navigation.NavigationStack.ToList();
                itens.Reverse();
                foreach (Page p in itens)
                {
                    if (p != null)
                    {
                        if (p.GetType().Name.Equals(typeof(T).Name)) break;
                        else
                            st.Append("../");
                    }
                }

                await Shell.Current.GoToAsync(st.ToString(), parametro);
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Erro", ex.Message, "Ok");
            }
        }
        public static async Task NavigationPopToRootAsync()
        {
            try
            {
                await Shell.Current.Navigation.PopToRootAsync(true);
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Erro", ex.Message, "Ok");
            }
        }
    }

}
