using Dto.IRepository.BuildingSystem;
using Dtol;
using Dtol.Dtol;
using Dtol.EfCoreExtion;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using ViewModel.BuildingSystem.RequestViewModel;

namespace Dto.Repository.BuildingSystem
{
    public class BuildingRepository : IBuildingRepository
    {
        protected readonly DtolContext Db;
        protected readonly DbSet<Building> DbSet;
        public BuildingRepository(DtolContext context)
        {
            Db = context;
            DbSet = Db.Set<Building>();
        }




        public void Add(Building obj)
        {
            DbSet.Add(obj);
        }

        public List<Building> BuildingSerachByWhere(BuildingSearchViewModel buildingSearchViewModel)
        {
            int SkipNum = buildingSearchViewModel.pageViewModel.CurrentPageNum * buildingSearchViewModel.pageViewModel.PageSize;
            //查询条件
            var predicate = SearchBuildingWhere(buildingSearchViewModel);
            var result = DbSet.Where(predicate).ToList()
            .Skip(SkipNum)
            .Take(buildingSearchViewModel.pageViewModel.PageSize)
            .OrderBy(a=>a.AddTime).ToList();

            return result;
        }
        public int BuildingSerachByWhereCount(BuildingSearchViewModel buildingSearchViewModel)
        {
            var predicate = SearchBuildingWhere(buildingSearchViewModel);
            var result = DbSet.Where(predicate).ToList().Count();
            return result;
        }
        //根据检索条件  统计有多少栋楼
        public int BuildingSerachByWhereBuildingNoCount(BuildingSearchViewModel buildingSearchViewModel)
        {
            var predicate = SearchBuildingWhere(buildingSearchViewModel);
            var result = DbSet.Where(predicate).ToList()
                .GroupBy(a => a.BuildingNo).Select(a => a.First()).ToList()
                .Count();
            return result;
        }
        //根据检索条件 统计有多少个单元
        public int BuildingSerachByWhereUnitNoCount(BuildingSearchViewModel buildingSearchViewModel)
        {
            var predicate = SearchBuildingWhere(buildingSearchViewModel);
            var result = DbSet.Where(predicate)
                .GroupBy(a => new { a.BuildingNo,a.UnitNo} )
                .Select(a => a.First()).ToList()
                .Count();
            return result;
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

        public IQueryable<Building> GetAll()
        {
            return DbSet;
        }

        public Building GetById(Guid id)
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

        public void Update(Building obj)
        {
            DbSet.Update(obj);
        }


        #region 查询条件
        //根据条件查询部门
        private Expression<Func<Building, bool>> SearchBuildingWhere(BuildingSearchViewModel buildingSearchViewModel)
        {
            var predicate = WhereExtension.True<Building>();//初始化where表达式
            //predicate = predicate.And(p => p.Name.ToString().Contains(buildingSearchViewModel.Name.ToString()));
            if (buildingSearchViewModel.Name != "")
            {
                predicate = predicate.And(p => p.Name.Contains(buildingSearchViewModel.Name));
            }
            if (buildingSearchViewModel.Id !=null)
            {
                predicate = predicate.And(p => p.Id.Equals(buildingSearchViewModel.Id));
            }

            predicate = predicate.And(p => p.Status == "1");

            return predicate;
        }
        #endregion


    }
}
