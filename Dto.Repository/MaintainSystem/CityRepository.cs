using Dto.IRepository.MaintainSystem;
using Dtol;
using Dtol.Dtol;
using Dtol.EfCoreExtion;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Dto.Repository.MaintainSystem
{
    public class CityRepository : ICityRepository
    {
        protected readonly DtolContext Db;
        protected readonly DbSet<City> DbSet;
        public CityRepository(DtolContext context)
        {
            Db = context;
            DbSet = Db.Set<City>();
        }

        public void Add(City obj)
        {
            DbSet.Add(obj);
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

        public IQueryable<City> GetAll()
        {
            return DbSet;
        }

        public City GetById(Guid id)
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

        public void Update(City obj)
        {
            DbSet.Update(obj);
        }

        /// <summary>
        /// 查询子城市
        /// </summary>
        /// <param name="FormId"></param>
        /// <returns></returns>
        #region
        public List<City> CitySerachByFormId(Guid FormId)
        {
            var predicate = SearchCityWhere(FormId);
            var result = DbSet.Where(predicate).OrderBy(a => a.Code).ToList();

            return result;

        }
        private Expression<Func<City, bool>> SearchCityWhere(Guid FormId)
        {
            var predicate = WhereExtension.True<City>();//初始化where表达式

            predicate = predicate.And(p => p.FormId.Equals(FormId));

            return predicate;
        }
        #endregion


        /// <summary>
        /// 查询省级城市
        /// </summary>
        /// <returns></returns>
        #region
        public List<City> GetAllCity()
        {
            var predicate = SearchAllCityWhere();
            var result = DbSet.Where(predicate).OrderBy(a=>a.Code).ToList();

            return result;
        }

        private Expression<Func<City, bool>> SearchAllCityWhere()
        {
            var predicate = WhereExtension.True<City>();//初始化where表达式

            predicate = predicate.And(p => p.FormId==null);

            return predicate;
        }
        #endregion

    }
}
