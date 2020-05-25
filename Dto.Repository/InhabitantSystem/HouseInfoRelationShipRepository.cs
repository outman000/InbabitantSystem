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
using ViewModel.InhabitantSystem.MiddleViewModel;
using ViewModel.InhabitantSystem.RequestViewModel;

namespace Dto.Repository.InhabitantSystem
{
    public class HouseInfoRelationShipRepository : IHouseInfoRelationShipRepository
    {

        protected readonly DtolContext Db;
        protected readonly DbSet<InfoRelationShip> DbSet;
        public HouseInfoRelationShipRepository(DtolContext context)
        {
            Db = context;
            DbSet = Db.Set<InfoRelationShip>();
        }


        public void Add(InfoRelationShip obj)
        {
            DbSet.Add(obj);
        }

        

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

        public IQueryable<InfoRelationShip> GetAll()
        {
            return DbSet;
        }

        public InfoRelationShip GetById(Guid id)
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

        public void Update(InfoRelationShip obj)
        {
            DbSet.Update(obj);
        }


        public void AddHouseInfoRelationShip(List<InfoRelationShip> obj)
        {
            foreach (InfoRelationShip infoRelationShip in obj)
            {
                DbSet.Add(infoRelationShip);
            }
        }

        public void DeleteHouseInfoRelationShip(List<HouseInfoRelationShipDeleteMiddle> obj)
        {
            foreach (HouseInfoRelationShipDeleteMiddle houseInfoRelationShipDeleteMiddle in obj)
            {
                Remove(houseInfoRelationShipDeleteMiddle.Id);
            }
        }

        public List<InfoRelationShip> InfoRelationShipSerachByIdNoWhere(string IdNo)
        {

            var predicate = SearchInfoRelationShipByIdNoWhere(IdNo);
            var result = DbSet
                         //.Include(a=>a.HouseInfo)
                         //.Include(a=>a.ResidentInfo)
                         .Where(predicate);
            if (result.Count() != 0)
            {
                return result.ToList();
            }
            else
            {
                return null;
            }
        }

        private Expression<Func<InfoRelationShip, bool>> SearchInfoRelationShipByIdNoWhere(string IdNo)
        {
            var predicate = WhereExtension.True<InfoRelationShip>();//初始化where表达式
            if (IdNo != null)
            {
                predicate = predicate.And(p => p.ResidentInfoId.Value.ToString() ==IdNo);
            }
       
            return predicate;
        }
    }
}
