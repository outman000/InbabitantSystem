using AutoMapper;
using Dtol.Dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.ActivitySystem.MiddleViewModel;

namespace Dto.Service.AutoMapper.ActivitySystem.ResponseMapper
{
    public class ActivityResMapper : Profile
    {
        public ActivityResMapper()
        {
            CreateMap<Activity, ActivitySearchMiddle>();

            CreateMap<Activity, ActivitySearchByIdMiddle>();

        }
    }
}
