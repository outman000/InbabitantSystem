using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.ActivitySystem.ResponseViewModel;
using ViewModel.IViewModelFactory.ActivitySystem;

namespace ViewModel.ViewModelFactory.ActivitySystem
{
    public class ActivityFactory : IActivityFactory
    {
        public ActivityAddResViewModel GetActivityAddResViewModel()
        {
            return new ActivityAddResViewModel();
        }

        public ActivitySearchByIdResViewModel GetActivitySearchByIdResViewModel()
        {
            return new ActivitySearchByIdResViewModel();
        }

        public ActivitySearchResViewModel GetActivitySearchResViewModel()
        {
            return new ActivitySearchResViewModel();
        }

        public ActivityUpdateResViewModel GetActivityUpdateResViewModel()
        {
            return new ActivityUpdateResViewModel();
        }
    }
}
