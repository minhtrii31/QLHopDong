using System.Windows;
using System.Windows.Input;

namespace QLHopDong.Views
{
    public partial class BaseView : Window
    {
        public BaseView()
        {
            InitializeComponent();
            this.Loaded += BaseView_Loaded;
        }

        private void BaseView_Loaded(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
