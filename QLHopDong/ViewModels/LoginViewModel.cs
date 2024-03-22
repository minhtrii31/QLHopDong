using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

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
