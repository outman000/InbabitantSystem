using Dto.IRepository.ActivitySystem;
using Dtol;
using Dtol.Dtol;
using Dtol.EfCoreExtion;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using ViewModel.ActivitySystem.RequestViewModel;

namespace Dto.Repository.ActivitySystem
{
    public class ActivityRepository : IActivityRepository
    {
        protected readonly DtolContext Db;
        protected readonly DbSet<Activity> DbSet;
        public ActivityRepository(DtolContext context)
        {
            Db = context;
            DbSet = Db.Set<Activity>();
        }
        public List<Activity> ActivitySerachByWhere(ActivitySearchViewModel activitySearchViewModel)
        {
            //查询条件
            int SkipNum = activitySearchViewModel.pageViewModel.CurrentPageNum * activitySearchViewModel.pageViewModel.PageSize;
            var predicate = SearchActivityWhere(activitySearchViewModel);
            var result = DbSet.Where(predicate).ToList()
            .Skip(SkipNum)
            .Take(activitySearchViewModel.pageViewModel.PageSize)
            .OrderBy(o => o.AddTime).ToList();

            return result;
        }
        public int ActivitySerachByWhereCount(ActivitySearchViewModel activitySearchViewModel)
        {
            var predicate = SearchActivityWhere(activitySearchViewModel);
            var result = DbSet.Where(predicate).Count();
            return result;
        }

        public IQueryable<Activity> ActivitySerachByIdWhere(ActivitySearchByIdViewModel activitySearchByIdViewModel)
        {
            var predicate = SearchByIdActivityWhere(activitySearchByIdViewModel);
            var result = DbSet.Where(predicate);
            
            return result;
        }

        public void Add(Activity obj)
        {
            DbSet.Add(obj);
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

        public IQueryable<Activity> GetAll()
        {
            return DbSet;
        }

        public Activity GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public void Remove(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Update(Activity obj)
        {
            DbSet.Update(obj);
        }

        //根据条件活动
        private Expression<Func<Activity, bool>> SearchActivityWhere(ActivitySearchViewModel activitySearchViewModel)
        {
            var predicate = WhereExtension.True<Activity>();//初始化where表达式
            //predicate = predicate.And(p => p.Name.ToString().Contains(buildingSearchViewModel.Name.ToString()));
            
            if (activitySearchViewModel.Title != "")
            {
                predicate = predicate.And(p => p.Title.Contains(activitySearchViewModel.Title));
            }
            if (activitySearchViewModel.StartTime != null )
            {
                predicate = predicate.And(p=> activitySearchViewModel.StartTime<p.StartTime  );
            }
            if (activitySearchViewModel.EndTime != null)
            {
                predicate = predicate.And(p =>   p.StartTime < activitySearchViewModel.EndTime);
            }
            if (activitySearchViewModel.Recorder != "")
            {
                predicate = predicate.And(p => p.Recorder.Contains(activitySearchViewModel.Recorder));
            }
            //predicate = predicate.And(p => p.ConstructionTime.ToString().c);

            predicate = predicate.And(p => p.Status == "1");
            return predicate;
        }

        private Expression<Func<Activity, bool>> SearchByIdActivityWhere(ActivitySearchByIdViewModel activitySearchByIdViewModel)
        {
            var predicate = WhereExtension.True<Activity>();//初始化where表达式
                                                           

            if (activitySearchByIdViewModel.Id != null)
            {
                predicate = predicate.And(p => p.Id.Equals(activitySearchByIdViewModel.Id));
            }

            predicate = predicate.And(p => p.Status == "1");

            return predicate;
        }




    }
}
