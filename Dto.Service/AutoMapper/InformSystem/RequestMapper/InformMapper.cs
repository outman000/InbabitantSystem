using AutoMapper;
using Dtol.Dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.InformSystem.MiddleViewModel;
using ViewModel.InformSystem.RequestViewModel;

namespace Dto.Service.AutoMapper.InformSystem.RequestMapper
{
    public class InformMapper : Profile
    {
        public InformMapper()
        {
            //添加匹配
            CreateMap<InformAddViewModel, Inform>();
            //更新
            CreateMap<InformUpdateViewModel, Inform>();

            CreateMap<InformAndResidentMiddle, InformAndResident>();
            //.ForMember(dest => dest.residentInfo, op => op.Ignore())
            //.ForMember(dest => dest.Id, options => options.MapFrom(a => a.Id))
            //.ForMember(dest => dest.InformId, options => options.MapFrom(a => a.InformId))
            //.ForMember(dest => dest.residentInfoId, options => options.MapFrom(a => a.residentInfoId))

            //.ForPath(dest => dest.residentInfo.Id, options => options.MapFrom(a => a.residentInfoId))
            //.ForPath(dest => dest.Inform.Id, options => options.MapFrom(a => a.InformId));
            //.PreserveReferences()
            //.ReverseMap();

            
        }
    }
}
