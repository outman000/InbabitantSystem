using AutoMapper;
using Dto.IRepository.MaintainSystem;
using Dto.IService.MaintainSystem;
using Dtol.Dtol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.MaintainSystem.MiddleViewModel;

namespace Dto.Service.MaintainSystem
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _IMapper;

        public CityService(ICityRepository cityRepository, IMapper mapper)
        {

            _cityRepository = cityRepository;
            _IMapper = mapper;
        }


        public List<CitySearchMiddle> GetAllProvince()
        {
            var SearchResult = _cityRepository.GetAllCity().ToList();
            var SearchResultModel = _IMapper.Map<List<City>, List<CitySearchMiddle>>(SearchResult);
            return SearchResultModel;
        }

        public List<CitySearchMiddle> GetCityChildren(Guid FormId)
        {
            var SearchResult = _cityRepository.CitySerachByFormId(FormId).ToList();
            var SearchResultModel = _IMapper.Map<List<City>, List<CitySearchMiddle>>(SearchResult);
            return SearchResultModel;
        }
    }
}
