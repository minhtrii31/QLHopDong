using Prism.Commands;
using Prism.Regions;
using System.Windows;
using Wpf.Ui.Controls;

namespace QLHopDong.Views
{
    /// <summary>
    /// Interaction logic for BaseView.xaml
    /// </summary>
    public partial class BaseView : Window
    {

        public BaseView()
        {
            InitializeComponent();
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonMaximize_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
            {
                WindowState = WindowState.Maximized;
            }
            else
            {
                WindowState = WindowState.Normal;
            }
        }

    }
}
