﻿using Prism.Regions;
using System.Windows;
using System.Windows.Media;
using Wpf.Ui.Controls;

namespace QLHopDong.Views
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }
        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

            foreach (Window window in Application.Current.Windows)
            {
                if (window is BaseView)
                {
                    window.Close();
                    break;
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            tbUsername.Focus();
        }

        private void Button_Login(object sender, RoutedEventArgs e)
        {
            this.Close();

            foreach (Window window in Application.Current.Windows)
            {
                if (window is BaseView)
                {
                    window.Show();
                    break;
                }
            }
        }
    }
}
