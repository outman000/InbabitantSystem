using AutoMapper;
using Dtol.Dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.InhabitantSystem.MiddleViewModel;

namespace Dto.Service.AutoMapper.InhabitantSystem.RequestMapper
{
    public class IdentityMapper : Profile
    {
        public IdentityMapper ()
        {
            //添加匹配
            CreateMap<IdentityAddMiddle, ResidentIdentity>();
            //更新
            CreateMap<IdentityUpdateMiddle, ResidentIdentity>();
        }
        
    }
}
