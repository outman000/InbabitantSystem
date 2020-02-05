using AutoMapper;
using Dtol.Dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.InhabitantSystem.MiddleViewModel;

namespace Dto.Service.AutoMapper.InhabitantSystem.RequestMapper
{
    public class HouseInfoRelationShipMapper : Profile
    {
        public HouseInfoRelationShipMapper()
        {
            //添加匹配
            CreateMap<HouseInfoRelationShipAddMiddle, InfoRelationShip>();
            CreateMap<InhabitantAndHouseInfoAddMiddle, InfoRelationShip>()
                .ForMember(dest => dest.Id, op => op.MapFrom(a => a.RelationShipId))
                .ForMember(dest => dest.HouseInfoId, op => op.MapFrom(a => a.HouseId))
                .ForMember(dest => dest.ResidentInfoId, op => op.MapFrom(a => a.InhabitantId))
                .ForMember(dest => dest.RelationWithHousehold, op => op.MapFrom(a => a.RelationWithHousehold));
        }
    }
}
