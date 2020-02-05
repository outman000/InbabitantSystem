using AutoMapper;
using Dtol.Dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.BuildingSystem.RequestViewModel;

namespace Dto.Service.AutoMapper.BuildingSystem.RequestMapper
{
   public  class BuildingMapper : Profile
    {
        public BuildingMapper()
        {
            //添加匹配
            CreateMap<BuildingAddViewModel, Building>();
            //更新
            CreateMap<BuildingUpdateViewModel, Building>();
        }

    }
}
