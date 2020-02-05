using AutoMapper;
using Dtol.Dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.InhabitantSystem.MiddleViewModel;

namespace Dto.Service.AutoMapper.InhabitantSystem.RequestMapper
{
    public class HouseInfoMapper :Profile
    {
        public HouseInfoMapper()
        {
            //添加匹配
            CreateMap<HouseInfoAddMiddle, HouseInfo>();
            //更新
            CreateMap<HouseInfoUpdateMiddle, HouseInfo>();

            CreateMap<InhabitantAndHouseInfoAddMiddle, HouseInfo>()
                .ForMember(dest => dest.Id, op => op.MapFrom(a => a.HouseId))
                .ForMember(dest => dest.Area, op => op.MapFrom(a => a.Area))
                .ForMember(dest => dest.BuildingNo, op => op.MapFrom(a => a.BuildingNo))
                .ForMember(dest => dest.UnitNo, op => op.MapFrom(a => a.UnitNo))
                .ForMember(dest => dest.HouseNo, op => op.MapFrom(a => a.HouseNo))
                .ForMember(dest => dest.HouseHolder, op => op.MapFrom(a => a.HouseHolder))
                .ForMember(dest => dest.HouseHolderIdNo, op => op.MapFrom(a => a.HouseHolderIdNo));
        }

    }
}
