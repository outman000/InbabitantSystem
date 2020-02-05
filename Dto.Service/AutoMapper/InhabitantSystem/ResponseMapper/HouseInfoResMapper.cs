using AutoMapper;
using Dtol.Dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.InhabitantSystem.MiddleViewModel;

namespace Dto.Service.AutoMapper.InhabitantSystem.ResponseMapper
{
    public class HouseInfoResMapper : Profile
    {
        public HouseInfoResMapper()
        {
            CreateMap<HouseInfo, HouseInfoSearchMiddle>();
        }
    }
}
