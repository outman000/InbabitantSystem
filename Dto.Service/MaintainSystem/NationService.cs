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
    public class NationService : INationService
    {
        private readonly INationRepository _nationRepository;
        private readonly IMapper _IMapper;

        public NationService(INationRepository nationRepository, IMapper mapper)
        {

            _nationRepository = nationRepository;
            _IMapper = mapper;
        }

        public List<NationSearchMiddle> GetAll()
        {
            var SearchResult = _nationRepository.GetAll().ToList();
            var SearchResultModel = _IMapper.Map<List<Nation>, List<NationSearchMiddle>>(SearchResult);
            return SearchResultModel;
        }
    }
}
