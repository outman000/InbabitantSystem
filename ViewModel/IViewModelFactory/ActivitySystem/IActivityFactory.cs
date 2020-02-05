using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.ActivitySystem.ResponseViewModel;

namespace ViewModel.IViewModelFactory.ActivitySystem
{
    public interface IActivityFactory
    {
        ActivityAddResViewModel GetActivityAddResViewModel();

        ActivitySearchResViewModel GetActivitySearchResViewModel();

        ActivityUpdateResViewModel GetActivityUpdateResViewModel();

        ActivitySearchByIdResViewModel GetActivitySearchByIdResViewModel();
    }
}
