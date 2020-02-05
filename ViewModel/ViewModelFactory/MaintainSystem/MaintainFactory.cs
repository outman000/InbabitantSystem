using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.IViewModelFactory.MaintainSystem;
using ViewModel.MaintainSystem.ResponseViewModel;

namespace ViewModel.ViewModelFactory.MaintainSystem
{
    public class MaintainFactory : IMaintainFactory
    {
        public PoliticalSearchResViewModel GetPoliticalSearchResViewModel()
        {
            return new PoliticalSearchResViewModel();
        }

        public NationSearchResViewModel GetNationSearchResViewModel()
        {
            return new NationSearchResViewModel();
        }

        public CitySearchResViewModel GetCitySearchResViewModel()
        {
            return new CitySearchResViewModel();
        }


    }
}
