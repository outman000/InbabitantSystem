using AutoMapper;
using Dtol.Dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.ResidentialAreaSystem.RequestViewModel;

namespace Dto.Service.AutoMapper.ResidentialAreaSystem.RequestMapper
{
   public  class AreaMapper : Profile
    {
        public AreaMapper()
        {
            //添加匹配
            CreateMap<AreaAddViewModel, ResidentialArea>();
            //更新
            CreateMap<AreaUpdateViewModel, ResidentialArea>();
        }

    }
}
