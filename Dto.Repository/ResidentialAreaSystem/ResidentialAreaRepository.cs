using Dto.IRepository.ResidentialAreaSystem;
using Dtol;
using Dtol.Dtol;
using Dtol.EfCoreExtion;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using ViewModel.ResidentialAreaSystem.MiddleViewModel;
using ViewModel.ResidentialAreaSystem.RequestViewModel;

namespace Dto.Repository.ResidentialAreaSystem
{
    public class ResidentialAreaRepository : IResidentialAreaRepository
    {
        protected readonly DtolContext Db;
        protected readonly DbSet<ResidentialArea> DbSet;
        public ResidentialAreaRepository(DtolContext context)
        {
            Db = context;
            DbSet = Db.Set<ResidentialArea>();
        }


        public void Add(ResidentialArea obj)
        {
            DbSet.Add(obj);
        }

        public List<ResidentialArea> AreaSerachByWhere(AreaSearchViewModel areaSearchViewModel)
        {
            int SkipNum = areaSearchViewModel.pageViewModel.CurrentPageNum * areaSearchViewModel.pageViewModel.PageSize;
            //查询条件
            var predicate = SearchAreaWhere(areaSearchViewModel);
            var result = DbSet.Where(predicate).ToList()
                .Skip(SkipNum)
                .Take(areaSearchViewModel.pageViewModel.PageSize)
                .OrderBy(a => a.AddTime).ToList();

            return result;
        }
        public int AreaSerachByWhereCount(AreaSearchViewModel areaSearchViewModel)
        {
            var predicate = SearchAreaWhere(areaSearchViewModel);
            var result = DbSet.Where(predicate).ToList().Count();
            return result;
        }
        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

        public IQueryable<ResidentialArea> GetAll()
        {
            return DbSet;
        }

        public ResidentialArea GetById(Guid id)
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

        public void Update(ResidentialArea obj)
        {
            DbSet.Update(obj);
        }


        //根据条件查小区
        #region 查询条件

        private Expression<Func<ResidentialArea, bool>> SearchAreaWhere(AreaSearchViewModel areaSearchViewModel)
        {
            var predicate = WhereExtension.True<ResidentialArea>();//初始化where表达式
            if (areaSearchViewModel.Id != null)
            {
                predicate = predicate.And(p => p.Id.Equals(areaSearchViewModel.Id));
            }
            if (areaSearchViewModel.Name!="")
            {
                predicate = predicate.And(p => p.Name.ToString().Contains(areaSearchViewModel.Name.ToString()));
            }
            
            if (areaSearchViewModel.Developers != "")
            {
                predicate = predicate.And(p => p.Developers.Contains(areaSearchViewModel.Developers));
            }
            if (areaSearchViewModel.ConstructionTimeStart != null)
            {
                predicate = predicate.And(p => p.ConstructionTime>(areaSearchViewModel.ConstructionTimeStart));
            }
            if (areaSearchViewModel.ConstructionTimeEnd != null)
            {
                predicate = predicate.And(p => p.ConstructionTime < (areaSearchViewModel.ConstructionTimeEnd));
            }
            predicate = predicate.And(p => p.Status=="1");

            return predicate;
        }
        #endregion

    }
}
