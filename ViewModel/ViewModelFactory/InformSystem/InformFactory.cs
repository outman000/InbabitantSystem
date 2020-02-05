using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.InformSystem.ResponseViewModel;
using ViewModel.IViewModelFactory.InformSystem;

namespace ViewModel.ViewModelFactory.InformSystem
{
    public class InformFactory : IInformFactory
    {
        public InformAddResViewModel GetInformAddResViewModel()
        {
            return new InformAddResViewModel();
        }

        public InformAndResidentResViewModel GetInformAndResidentResViewModel()
        {
            return new InformAndResidentResViewModel();
        }

        public InformSearchByIdResViewModel GetInformSearchByIdResViewModel()
        {
            return new InformSearchByIdResViewModel();
        }

        public InformSearchResViewModel GetInformSearchResViewModel()
        {
            return new InformSearchResViewModel();
        }

        public InformUpdateResViewModel GetInformUpdateResViewModel()
        {
            return new InformUpdateResViewModel();
        }


    }
}
