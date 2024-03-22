using Prism.DryIoc;
using Prism.Ioc;
using QLHopDong.ViewModels;
using QLHopDong.Views;
using System.Windows;

namespace QLHopDong
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App 
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<BaseView>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<Login, LoginViewModel>();
            containerRegistry.RegisterForNavigation<BaseView, BaseViewModel>();
            containerRegistry.RegisterForNavigation<ContractPageView, ContractPageViewModel>();
        }

        protected override void OnInitialized()
        {
            var login = Container.Resolve<Login>();
            var result = login.ShowDialog();

            if (result == true)
            {
                base.OnInitialized();
            }
            else
            {
                Application.Current.Shutdown();
            }
        }

    }
}