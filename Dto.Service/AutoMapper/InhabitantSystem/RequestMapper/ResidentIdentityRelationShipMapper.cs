﻿using AutoMapper;
using Dtol.Dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.InhabitantSystem.MiddleViewModel;

namespace Dto.Service.AutoMapper.InhabitantSystem.RequestMapper
{
    public class ResidentIdentityRelationShipMapper : Profile
    {
        public ResidentIdentityRelationShipMapper()
        {
            //添加匹配
            CreateMap<ResidentIdentityRelationShipAddMiddle, ResidentRelationShip>();
            //更新
            //CreateMap<IdentityUpdateMiddle, ResidentIdentity>();
        }
    }
}
