using Dtol.Dtol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.ActivitySystem.RequestViewModel;

namespace Dto.IRepository.ActivitySystem
{
    public interface IActivityRepository : IRepository<Activity>
    {
        List<Activity> ActivitySerachByWhere(ActivitySearchViewModel activitySearchViewModel);
        int ActivitySerachByWhereCount(ActivitySearchViewModel activitySearchViewModel);
        IQueryable<Activity> ActivitySerachByIdWhere(ActivitySearchByIdViewModel activitySearchByIdViewModel);
    }
}
