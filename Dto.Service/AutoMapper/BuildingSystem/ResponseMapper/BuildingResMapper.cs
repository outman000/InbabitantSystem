using AutoMapper;
using Dtol.Dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.BuildingSystem.MiddleViewModel;

namespace Dto.Service.AutoMapper.BuildingSystem.ResponseMapper
{
    public class BuildingMapper : Profile
    {
        public BuildingMapper()
        {
            CreateMap<Building, BuildingSearchMiddleViewModel>();

        }
    }
}
