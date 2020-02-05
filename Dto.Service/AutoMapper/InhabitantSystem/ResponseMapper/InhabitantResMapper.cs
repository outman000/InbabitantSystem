using AutoMapper;
using Dtol.Dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.InhabitantSystem.MiddleViewModel;

namespace Dto.Service.AutoMapper.InhabitantSystem.ResponseMapper
{
    public class InhabitantResMapper : Profile
    {
        public InhabitantResMapper()
        {
            CreateMap<ResidentInfo, InhabitantSearchMiddle>();

            
            CreateMap<InfoRelationShip, HouseInfo>();
            CreateMap<ResidentRelationShip, ResidentIdentity>();

            CreateMap<ResidentIdentity, ResidentIdentityMiddle>();
            CreateMap<HouseInfo, HouseInfoMiddle>();

            CreateMap<ResidentInfo, ResidentMiddle>()
                
                //.ConstructUsing(s => new ResidentMiddle
                //{
                //    Id =s.Id,
                //    HouseInfo = new HouseInfoMiddle
                //    {
                //        Id = s.InfoRelationShips.HouseInfo.Id,
                //        Area= s.InfoRelationShips.HouseInfo.Area

                //    },
                //    ResidentIdentity =new ResidentIdentityMiddle {
                //        Id = s.ResidentRelationShips.ResidentIdentity.Id,
                //        IdentityName = s.ResidentRelationShips.ResidentIdentity.IdentityName
                //    }

                //});
                .ForMember(dest => dest.HouseInfo, options => options.MapFrom(a => a.InfoRelationShips.HouseInfo))
                .ForMember(dest => dest.ResidentIdentity, options => options.MapFrom(a => a.ResidentRelationShips.ResidentIdentity));
            CreateMap<ResidentMiddle, BaseInfoInhabitantMiddle>();
        }
    }
}
