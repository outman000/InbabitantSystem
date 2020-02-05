using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.MaintainSystem.MiddleViewModel;

namespace Dto.IService.MaintainSystem
{
    public interface ICityService
    {
        List<CitySearchMiddle> GetAllProvince();

        List<CitySearchMiddle> GetCityChildren(Guid FormId);
    }
}
