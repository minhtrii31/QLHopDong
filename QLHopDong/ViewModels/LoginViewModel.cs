using GalaSoft.MvvmLight.Command;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using QLHopDong.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Wpf.Ui.Input;

namespace QLHopDong.ViewModels
{
    public class LoginViewModel : BindableBase
    {
        private string _title = "Login";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        public LoginViewModel()
        {
        }
    }
}
