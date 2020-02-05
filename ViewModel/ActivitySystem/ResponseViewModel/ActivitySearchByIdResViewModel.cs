using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.ActivitySystem.MiddleViewModel;
using ViewModel.PublicVIewModel;

namespace ViewModel.ActivitySystem.ResponseViewModel
{
    public class ActivitySearchByIdResViewModel
    {
        public ActivitySearchByIdResViewModel()
        {
            baseViewModel = new BaseViewModel();

        }
        public BaseViewModel baseViewModel;

        public ActivitySearchByIdMiddle Data;
    }
}
