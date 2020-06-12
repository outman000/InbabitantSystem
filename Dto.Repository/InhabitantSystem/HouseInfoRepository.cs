using Dto.IRepository.InhabitantSystem;
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
using ViewModel.InhabitantSystem.MiddleViewModel;
using ViewModel.InhabitantSystem.RequestViewModel;

namespace Dto.Repository.InhabitantSystem
{
    public class HouseInfoRepository : IHouseInfoRepository
    {
        protected readonly DtolContext Db;
        protected readonly DbSet<HouseInfo> DbSet;
        public HouseInfoRepository(DtolContext context)
        {
            Db = context;
            DbSet = Db.Set<HouseInfo>();
        }

        public void Add(HouseInfo obj)
        {
            DbSet.Add(obj);
        }

        

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

        public IQueryable<HouseInfo> GetAll()
        {
            return DbSet;
        }

        public HouseInfo GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public IQueryable<HouseInfo> HouseInfoSerachByWhere(HouseInfoSearchViewModel houseInfoSearchViewModel)
        {
            //查询条件
            var predicate = SearchHouseInfoWhere(houseInfoSearchViewModel);
            var result = DbSet
                         //.Include(a => a.ResidentIdentity)
                         //.Include(a=>a.ResidentInfo)
                         .Where(predicate);
            //.Skip(SkipNum)
            //.Take(foodInfoSearchViewModel.pageViewModel.PageSize)
            //.OrderBy(o => o.AddDate).ToList();

            return result;
        }

        public IQueryable<HouseInfo> HouseInfoSerachByWhere3(InhabitantUpdateMiddle inhabitantUpdateMiddle)
        {
            //查询条件
            var predicate = SearchHouseInfoWhere3(inhabitantUpdateMiddle);
            var result = DbSet
                         .Where(predicate);

            return result;
        }
        public IQueryable<HouseInfo> HouseInfoSerachByWhere2(InhabitantAndHouseInfoAddMiddle inhabitantAndHouseInfoAddMiddle)
        {
            //查询条件
            var predicate = SearchHouseInfoWhere2(inhabitantAndHouseInfoAddMiddle);
            var result = DbSet
                         .Where(predicate);

            return result;
        }
        public void Remove(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Update(HouseInfo obj)
        {
            DbSet.Update(obj);
        }

        public void UpdateHouseInfo(List<HouseInfo> obj)
        {
            foreach (HouseInfo houseInfo in obj)
            {
                DbSet.Update(houseInfo);
            }
        }
        public void AddHouseInfo(List<HouseInfo> obj)
        {
            foreach (HouseInfo houseInfo in obj)
            {
                DbSet.Add(houseInfo);
            }
        }
        private Expression<Func<HouseInfo, bool>> SearchHouseInfoWhere2(InhabitantAndHouseInfoAddMiddle inhabitantAndHouseInfoAddMiddle)
        {
            var predicate = WhereExtension.True<HouseInfo>();//初始化where表达式

        
                predicate = predicate.And(p => p.Area==inhabitantAndHouseInfoAddMiddle.Area);
            predicate = predicate.And(p => p.UnitNo==inhabitantAndHouseInfoAddMiddle.UnitNo);
            predicate = predicate.And(p => p.BuildingNo==inhabitantAndHouseInfoAddMiddle.BuildingNo);
            predicate = predicate.And(p => p.HouseNo==inhabitantAndHouseInfoAddMiddle.HouseNo);
            //predicate = predicate.And(p => p.Status == "1");

            return predicate;
        }
        private Expression<Func<HouseInfo, bool>> SearchHouseInfoWhere3(InhabitantUpdateMiddle  inhabitantUpdateMiddle)
        {
            var predicate = WhereExtension.True<HouseInfo>();//初始化where表达式


            predicate = predicate.And(p => p.Area == inhabitantUpdateMiddle.Area);
            predicate = predicate.And(p => p.UnitNo == inhabitantUpdateMiddle.UnitNo);
            predicate = predicate.And(p => p.BuildingNo == inhabitantUpdateMiddle.BuildingNo);
            predicate = predicate.And(p => p.HouseNo == inhabitantUpdateMiddle.HouseNo);
            //predicate = predicate.And(p => p.Status == "1");

            return predicate;
        }

        private Expression<Func<HouseInfo, bool>> SearchHouseInfoWhere(HouseInfoSearchViewModel houseInfoSearchViewModel)
        {
            var predicate = WhereExtension.True<HouseInfo>();//初始化where表达式

            if (houseInfoSearchViewModel.Id != null)
            {
                predicate = predicate.And(p => p.Id.Equals(houseInfoSearchViewModel.Id));
            }
            //predicate = predicate.And(p => p.Status == "1");

            return predicate;
        }

        /// <summary>
        /// 查询住户数
        /// </summary>
        /// <param name="buildingSearchViewModel"></param>
        /// <returns></returns>
        public int HouseCountByWhere(BuildingSearchViewModel buildingSearchViewModel)
        {
            //查询条件
            var predicate = SearchHouseCountWhere(buildingSearchViewModel);
            var result = DbSet
                         .Where(predicate).ToList().Count();

            return result;
        }

        private Expression<Func<HouseInfo, bool>> SearchHouseCountWhere(BuildingSearchViewModel buildingSearchViewModel)
        {
            var predicate = WhereExtension.True<HouseInfo>();//初始化where表达式

            if (buildingSearchViewModel.Name !="")
            {
                predicate = predicate.And(p => p.Area.Equals(buildingSearchViewModel.Name));
            }


            return predicate;
        }

        public List<HouseInfo> GetByHouseHolderIdNo(string HouseHolderIdNo)
        {
          return   DbSet.Where(b => b.HouseHolderIdNo == HouseHolderIdNo).ToList();
        }
    }
}
