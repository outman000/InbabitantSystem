using AutoMapper;
using Dtol.Dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.ActivitySystem.RequestViewModel;

namespace Dto.Service.AutoMapper.ActivitySystem.RequestMapper
{
    public class ActivityMapper : Profile
    {
        public ActivityMapper()
        {
            //添加匹配
            CreateMap<ActivityAddViewModel, Activity>();
            //更新
            CreateMap<ActivityUpdateViewModel, Activity>();
        }
    }
}
