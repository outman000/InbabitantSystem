using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.MaintainSystem.ResponseViewModel;

namespace ViewModel.IViewModelFactory.MaintainSystem
{
    public interface IMaintainFactory
    {

        PoliticalSearchResViewModel GetPoliticalSearchResViewModel();

        NationSearchResViewModel GetNationSearchResViewModel();

        CitySearchResViewModel GetCitySearchResViewModel();
    }
}
