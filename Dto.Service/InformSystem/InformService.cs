using AutoMapper;
using Dto.IRepository.InformSystem;
using Dto.IService.InformSystem;
using Dtol.Dtol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.InformSystem.MiddleViewModel;
using ViewModel.InformSystem.RequestViewModel;
using ViewModel.InformSystem.ResponseViewModel;

namespace Dto.Service.InformSystem
{
    public class InformService : IInformService
    {
        private readonly IInformRepository _informRepository;
        private readonly IInformAndResidentRepository _informAndResidentRepository;
        private readonly IMapper _IMapper;
        public InformService(IInformRepository informRepository, IMapper mapper, IInformAndResidentRepository informAndResidentRepository)
        {
            _informAndResidentRepository = informAndResidentRepository;
            _informRepository = informRepository;
            _IMapper = mapper;
        }

        public InformAddResViewModel AddInform(InformAddViewModel informAddViewModel)
        {
            var aAddInsertModel = _IMapper.Map<InformAddViewModel, Inform>(informAddViewModel);
            //var a = new InfoRelationShip();
            aAddInsertModel.AddTime = DateTime.Now;
            _informRepository.Add(aAddInsertModel);
            InformAddResViewModel aa = new InformAddResViewModel();
            aa.Id = aAddInsertModel.Id;
            aa.AddCount= _informRepository.SaveChanges();
            return aa;
        }

        public int AddInformAndResident(InformAndResidentViewModel informAndResidentViewModel)
        {
            var tempAddViewMiddle = informAndResidentViewModel.informAndResidentMiddles; ;
            var aAddInsertModel = _IMapper.Map<List<InformAndResidentMiddle>, List<InformAndResident>>(tempAddViewMiddle);
            _informAndResidentRepository.AddInformAndResident(aAddInsertModel);
            return _informAndResidentRepository.SaveChanges();
        }

        public List<InformSearchMiddle> Inform_Search(InformSearchViewModel informSearchViewModel)
        {
            var InformSearchResult = _informRepository.InformSerachByWhere(informSearchViewModel);
            var InformSearchResultModel = _IMapper.Map<List<Inform>, List<InformSearchMiddle>>(InformSearchResult);
            return InformSearchResultModel;
        }
        public int Inform_SearchCount(InformSearchViewModel informSearchViewModel)
        {
            return _informRepository.InformSerachByWhereCount(informSearchViewModel);
        }
        public List<InformSearchByIdMiddle> Inform_Search_ById(InformSearchByIdViewModel informSearchByIdViewModel)
        {
            var InformSearchByIdResult = _informAndResidentRepository.InformAndResidentSerachByIdWhere(informSearchByIdViewModel);
            var InformSearchByIdResultModel = _IMapper.Map<List<InformAndResident>, List<InformSearchByIdMiddle>>(InformSearchByIdResult);
            return InformSearchByIdResultModel;
        }



        public int UpdateInform(InformUpdateViewModel informUpdateViewModel)
        {
            var updateModel= _IMapper.Map<InformUpdateViewModel, Inform>(informUpdateViewModel);
            _informRepository.Update(updateModel);
            return _informRepository.SaveChanges();
        }
    }
}
