using Prism.DryIoc;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using QLHopDong.ViewModels;
using QLHopDong.Views;
using System.Windows;
using Wpf.Ui.Controls;

namespace QLHopDong
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
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
            containerRegistry.RegisterForNavigation<ContractType, ContractTypeViewModel>();
            containerRegistry.RegisterForNavigation<Report, ReportViewModel>();
            containerRegistry.RegisterForNavigation<Users, UsersViewModel>();
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            var region = ContainerLocator.Container.Resolve<IRegionManager>();
            region.RegisterViewWithRegion<Sidebar>("SidebarRegion");
            region.RegisterViewWithRegion<Home>("ContentRegion");
        }
    }
}