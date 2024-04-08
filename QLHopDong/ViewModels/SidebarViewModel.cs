using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System.Windows.Input;

namespace QLHopDong.ViewModels
{
    public class SidebarViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;
        public ICommand NavigationCommand { get; }

        public SidebarViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            NavigationCommand = new DelegateCommand<string>(Navigate);
        }

        private void Navigate(string selectedItem)
        {
            if (selectedItem != null)
            {
                switch (selectedItem)
                {
                    case "Trang chính":
                        _regionManager.RequestNavigate("ContentRegion", "Home");
                        break;
                    case "Hợp đồng":
                        _regionManager.RequestNavigate("ContentRegion", "ContractPageView");
                        break;
                    case "Các loại hợp đồng":
                        _regionManager.RequestNavigate("ContentRegion", "ContractType");
                        break;
                    case "Thống kê":
                        _regionManager.RequestNavigate("ContentRegion", "Report");
                        break;
                    case "Người dùng":
                        _regionManager.RequestNavigate("ContentRegion", "Users");
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
