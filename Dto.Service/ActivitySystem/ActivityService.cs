using AutoMapper;
using Dto.IRepository.ActivitySystem;
using Dto.IService.ActivitySystem;
using Dtol.Dtol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.ActivitySystem.MiddleViewModel;
using ViewModel.ActivitySystem.RequestViewModel;
using ViewModel.ActivitySystem.ResponseViewModel;

namespace Dto.Service.ActivitySystem
{
    public class ActivityService : IActivityService
    {
        private readonly IActivityRepository _activityRepository;
        private readonly IMapper _IMapper;
        public ActivityService(IActivityRepository activityRepository, IMapper mapper)
        {

            _activityRepository = activityRepository;
            _IMapper = mapper;
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="activitySearchViewModel"></param>
        /// <returns></returns>
        public List<ActivitySearchMiddle> Activity_Search(ActivitySearchViewModel activitySearchViewModel)
        {
            var ActivitySearchResult = _activityRepository.ActivitySerachByWhere(activitySearchViewModel);
            var ActivitySearchResultModel = _IMapper.Map<List<Activity>, List<ActivitySearchMiddle>>(ActivitySearchResult);
            return ActivitySearchResultModel;
        }
        public int Activity_SearchCount(ActivitySearchViewModel activitySearchViewModel)
        {
            return _activityRepository.ActivitySerachByWhereCount(activitySearchViewModel);
        }

        public ActivitySearchByIdMiddle Activity_SearchById(ActivitySearchByIdViewModel activitySearchByIdViewModel)
        {
            var ActivitySearchByIdResult = _activityRepository.ActivitySerachByIdWhere(activitySearchByIdViewModel).First();
            var ActivitySearchByIdResultModel = _IMapper.Map<Activity, ActivitySearchByIdMiddle>(ActivitySearchByIdResult);

            return ActivitySearchByIdResultModel;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="activityUpdateViewModel"></param>
        /// <returns></returns>
        public int Activity_Update(ActivityUpdateViewModel activityUpdateViewModel)
        {
            var ActivityUpdateModel = _IMapper.Map<ActivityUpdateViewModel, Activity>(activityUpdateViewModel);
            _activityRepository.Update(ActivityUpdateModel);
            return _activityRepository.SaveChanges();
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="activityAddViewModel"></param>
        /// <returns></returns>
        public int AddActivity(ActivityAddViewModel activityAddViewModel)
        {
            var aAddInsertModel = _IMapper.Map<ActivityAddViewModel, Activity>(activityAddViewModel);
            //var a = new InfoRelationShip();
            _activityRepository.Add(aAddInsertModel);
            return _activityRepository.SaveChanges();
        }
    }
}
