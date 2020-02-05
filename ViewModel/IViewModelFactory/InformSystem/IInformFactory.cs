using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.InformSystem.ResponseViewModel;

namespace ViewModel.IViewModelFactory.InformSystem
{
    public interface IInformFactory
    {
        InformAddResViewModel GetInformAddResViewModel();
        InformSearchResViewModel GetInformSearchResViewModel();
        InformUpdateResViewModel GetInformUpdateResViewModel();
        InformAndResidentResViewModel GetInformAndResidentResViewModel();
        InformSearchByIdResViewModel GetInformSearchByIdResViewModel();
    }
}
