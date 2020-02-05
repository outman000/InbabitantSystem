using AutoMapper;
using Dtol.Dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.InformSystem.MiddleViewModel;

namespace Dto.Service.AutoMapper.InformSystem.ResponseMapper
{
    public class InformResMapper : Profile
    {
        public InformResMapper()
        {
            CreateMap<Inform, InformSearchMiddle>();

            CreateMap<InformAndResident, InformSearchByIdMiddle>();

        }
    }
}
