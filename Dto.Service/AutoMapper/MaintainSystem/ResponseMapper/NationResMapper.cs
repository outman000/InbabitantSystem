using AutoMapper;
using Dtol.Dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.MaintainSystem.MiddleViewModel;

namespace Dto.Service.AutoMapper.MaintainSystem.ResponseMapper
{
    public class NationResMapper : Profile
    {

        public NationResMapper()
        {
            CreateMap<Nation, NationSearchMiddle>();
        }
    }
}
