using AutoMapper;
using Dtol.Dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.InhabitantSystem.MiddleViewModel;
using ViewModel.InhabitantSystem.RequestViewModel;
using ViewModel.InhabitantSystem.ResponseViewModel;

namespace Dto.Service.AutoMapper.InhabitantSystem.RequestMapper
{
    public class InhabitantMapper : Profile
    {
        public InhabitantMapper()
        {
            //添加匹配
            CreateMap<InhabitantAddMiddle, ResidentInfo>();
            //更新
            CreateMap<InhabitantUpdateMiddle, ResidentInfo>();
            //   .ForMember(dest => dest.InfoRelationShips.RelationWithHousehold, op => op.MapFrom(a => a.RelationWithHousehold));
            CreateMap<InhabitantUpdateMiddle, InfoRelationShip>();

            CreateMap<InhabitantUpdateMiddle, InhabitantAndHouseInfoAddMiddle>();

            CreateMap < ResidentInfo, ResidentInfoMiddleId>();

            CreateMap<InhabitantAndHouseInfoAddMiddle, ResidentInfo>()
                .ForMember(dest => dest.Id, op => op.MapFrom(a => a.InhabitantId))
                .ForMember(dest => dest.Name, op => op.MapFrom(a => a.Name))
                .ForMember(dest => dest.Minority, op => op.MapFrom(a => a.Minority))
                .ForMember(dest => dest.Gender, op => op.MapFrom(a => a.Gender))
                .ForMember(dest => dest.Married, op => op.MapFrom(a => a.Married))
                .ForMember(dest => dest.Politics, op => op.MapFrom(a => a.Politics))
                .ForMember(dest => dest.Phone, op => op.MapFrom(a => a.Phone))
                .ForMember(dest => dest.IdNumber, op => op.MapFrom(a => a.IdNumber))
                .ForMember(dest => dest.Company, op => op.MapFrom(a => a.Company))
                .ForMember(dest => dest.Address, op => op.MapFrom(a => a.Address))
                .ForMember(dest => dest.Register, op => op.MapFrom(a => a.Register))
                .ForMember(dest => dest.Education, op => op.MapFrom(a => a.Education))
                .ForMember(dest => dest.ReligiousBelief, op => op.MapFrom(a => a.ReligiousBelief))
                .ForMember(dest => dest.Job, op => op.MapFrom(a => a.Job))
                .ForMember(dest => dest.PhotoId, op => op.MapFrom(a => a.PhotoId))
                .ForMember(dest => dest.Status, op => op.MapFrom(a => a.Status));

            CreateMap<PartyInfoAddViewModel, PartyInfo>();

            CreateMap<PartyInfoUpdateViewModel, PartyInfo>();
                
        }
    }
}
