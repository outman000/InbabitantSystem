using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.BuildingSystem.ReponseViewModel;
using ViewModel.IViewModelFactory.IBuildingSystem;

namespace ViewModel.ViewModelFactory.BuildingSystem
{
    public class BuildingFactory : IBuildingFactory
    {
        public BuildingAddResViewModel GetBuildingAddResViewModel()
        {
            return new BuildingAddResViewModel();
        }

        public BuildingSearchResViewModel GetBuildingSearchResViewModel()
        {
            return new BuildingSearchResViewModel();
        }

        public BuildingUpdateResViewModel GetBuildingUpdateResViewModel()
        {
            return new BuildingUpdateResViewModel();
        }
    }
}
