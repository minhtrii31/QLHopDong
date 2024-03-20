using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QLHopDong.ViewModels
{
    public class BaseViewModel : BindableBase
    {
        private string _title = "Contract Manager";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        public BaseViewModel()
        {

        }
    }
}
