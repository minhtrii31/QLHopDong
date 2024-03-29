using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QLHopDong.ViewModels
{
    public class ContractTypeViewModel : BindableBase
    {
        private string _selectedContractType;
        public string SelectedContractType
        {
            get { return _selectedContractType; }
            set { SetProperty(ref _selectedContractType, value); }
        }
        private List<string> _contractTypes;
        public List<string> ContractTypes
        {
            get { return _contractTypes; }
            set { SetProperty(ref _contractTypes, value); }
        }

        public ContractTypeViewModel()
        {
            ContractTypes = new List<string>
            {
                "Hợp đồng",
                "Thương thảo",
                "Báo giá",
                "Nghiệm thu"
            };

            SelectedContractType = ContractTypes.FirstOrDefault();
        }
    }
}
