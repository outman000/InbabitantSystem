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
    public class PoliticalService : IPoliticalService
    {
        private readonly IPoliticalRepository _politicalRepository;
        private readonly IMapper _IMapper;

        public PoliticalService(IPoliticalRepository politicalRepository, IMapper mapper)
        {

            _politicalRepository = politicalRepository;
            _IMapper = mapper;
        }

        public List<PoliticalSearchMiddle> GetAll()
        {
            var SearchResult= _politicalRepository.GetAll().ToList();
            var SearchResultModel = _IMapper.Map<List<Political>, List<PoliticalSearchMiddle>>(SearchResult);
            return SearchResultModel;


        }


    }
}
