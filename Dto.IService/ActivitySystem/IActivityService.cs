using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.ActivitySystem.MiddleViewModel;
using ViewModel.ActivitySystem.RequestViewModel;

namespace Dto.IService.ActivitySystem
{
    public interface IActivityService
    {
        int AddActivity(ActivityAddViewModel activityAddViewModel);

        List<ActivitySearchMiddle> Activity_Search(ActivitySearchViewModel activitySearchViewModel);
        int Activity_SearchCount(ActivitySearchViewModel activitySearchViewModel);
        ActivitySearchByIdMiddle Activity_SearchById(ActivitySearchByIdViewModel activitySearchByIdViewModel);

        int Activity_Update(ActivityUpdateViewModel activityUpdateViewModel);
    }
}
