using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SmartCSLBlog.Behaviors
{
    public static class ModelLocator
    {
        private static List<Dictionary<Type, Type>> ServiceType = new List<Dictionary<Type, Type>>();
        private static List<Dictionary<Type, Type>> ServiceMockType = new List<Dictionary<Type, Type>>();
        public static void RegisterSingleton(Type serviceType, Type implementationType, bool Mock = false)
        {
            if (Mock)
            {
                ServiceMockType.Add(new Dictionary<Type, Type>()
                {
                     {serviceType, implementationType }
                });
            }
            else
            {
                ServiceType.Add(new Dictionary<Type, Type>()
                {
                     {serviceType, implementationType }
                });
            }

        }

        public static readonly BindableProperty AutoViewModelProperty =
        BindableProperty.CreateAttached("AutoViewModel", typeof(bool), typeof(ModelLocator), false,
            propertyChanged: (bin, old, newd) =>
            {
                if (bin != null)
                {
                    try
                    {
                        if ((bool)newd)
                        {
                            if (bin is Page page)
                            {
                                Type pageType = page.GetType();

                                if (!string.IsNullOrWhiteSpace(pageType.FullName))
                                {
                                    string fullNameViewModel = string.Empty;

                                    fullNameViewModel = pageType.Name.Contains("View") ? "Model" : "ViewModel";

                                    fullNameViewModel = $"{pageType.Name}{fullNameViewModel}";

                                    Type typeViewModel = ObterCaminhoViewModel(pageType.Assembly.GetName().FullName, fullNameViewModel);

                                    if (typeViewModel == null)
                                    {
                                        throw new Exception($"Não foi possível localizar a classe '{pageType.Name}{fullNameViewModel}'");
                                    }

                                    // Obtendo os construtores da classe
                                    ConstructorInfo construtor = typeViewModel.GetConstructors()[0];
                                    //Pegando o(s) parâmetro(s)
                                    ParameterInfo[] parametros = construtor.GetParameters();

                                    List<object> listParam = new List<object>();

                                    foreach (var param in parametros)
                                    {

                                        //Type typeParam = param.ParameterType;                                      
                                        //var service = Application.Current.Handler.MauiContext.Services.GetService(typeParam);


                                        //Pega o tipo do parâmetro referente a interface
                                        Type typeParam = GetImplementationType(param.ParameterType);

                                        if (typeParam != null)
                                        {
                                            //Cria a instância do service da ViewModel
                                            object service = Activator.CreateInstance(typeParam);

                                            if (service != null)
                                            {
                                                listParam.Add(service);
                                            }
                                        }
                                        else
                                        {
                                            //Se o Type do parâmetro for nulo, significa que não foi registrado a injeção
                                            throw new Exception("Serviço não registrado!");
                                        }

                                    }

                                    //Cria a instância da ViewModel da Página e passa os parâmetros
                                    object viewModel = listParam.Count == 0 ? Activator.CreateInstance(typeViewModel) : Activator.CreateInstance(typeViewModel, listParam.ToArray());

                                    page.BindingContext = viewModel;
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        //throw new Exception(ex.Message, new Exception(ex.StackTrace));
                        Application.Current.Windows[0].Page.DisplayAlert("", ex.Message, "OK");
                    }
                }
            });



        private static Type GetImplementationType(Type interfaceType)
        {
            List<Dictionary<Type, Type>> listServices = null;

            if (IsMock)
            {
                listServices = ServiceMockType;
            }
            else
            {
                listServices = ServiceType;
            }

            if (listServices == null) { return null; }

            foreach (var mapping in listServices)
            {
                // Tenta obter o valor (implementação) correspondente à interface Type
                if (mapping.TryGetValue(interfaceType, out Type implementationType))
                {
                    return implementationType;
                }
            }

            return null;
        }

        public static bool GetAutoViewModel(BindableObject view)
        {
            return (bool)view.GetValue(AutoViewModelProperty);
        }

        public static void SetAutoViewModel(BindableObject view, bool value)
        {
            view.SetValue(AutoViewModelProperty, value);
        }


        private static Type ObterCaminhoViewModel(string NomeAssembly, string ViewModel)
        {
            // Obtendo o nome do assembly onde a MainPageView está localizada
            // string nomeAssembly = tipoAlvo.Assembly.FullName;

            try
            {
                // Carregando o assembly dinamicamente
                Assembly assembly = Assembly.Load(NomeAssembly);

                // Obtendo todos os tipos no assembly carregado dinamicamente
                var tiposNoAssembly = assembly.GetTypes();

                // Procurando o tipo alvo (MainPageView)
                var tipoEncontrado = tiposNoAssembly.FirstOrDefault(t => t.Name.ToLower().Equals(ViewModel.ToLower()));

                if (tipoEncontrado != null)
                {
                    // Obtendo o caminho do tipo alvo
                    return tipoEncontrado;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao carregar o assembly: {ex.Message}\n{new Exception(ex.StackTrace)}");
            }
        }


        public static bool IsMock
        {
            get => Preferences.Default.Get("IsMock", false);
            set
            {
                Preferences.Default.Set("IsMock", value);
                //Application.Current?.MainPage.DisplayAlert("", "Reinicie o aplicativo para surtir efeito!", "OK");
            }
        }


        public static object CreateInstance(Type type)
        {
            //Pega o tipo do parâmetro referente a interface
            Type typeParam = GetImplementationType(type);

            return Activator.CreateInstance(typeParam);
        }

    }
}
