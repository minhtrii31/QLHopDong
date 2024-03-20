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
            return Container.Resolve<Login>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

            containerRegistry.RegisterForNavigation<Login, LoginViewModel>();
        }
    }
}
