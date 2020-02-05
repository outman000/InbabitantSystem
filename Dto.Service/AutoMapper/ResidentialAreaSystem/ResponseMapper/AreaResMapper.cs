using AutoMapper;
using Dtol.Dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.InhabitantSystem.RequestViewModel;
using ViewModel.ResidentialAreaSystem.MiddleViewModel;

namespace Dto.Service.AutoMapper.ResidentialAreaSystem.ResponseMapper
{
    public class AreaResMapper : Profile
    {
        public AreaResMapper()
        {
            //添加匹配
            CreateMap<ResidentialArea, AreaSearchMiddle>();

            CreateMap<ResidentialArea, StatisticsViewModel>()
                .ForMember(dest=>dest.Name, options => options.MapFrom(a=>a.Name));

        }
    }
}
