using Dto.IRepository.InhabitantSystem;
using Dtol;
using Dtol.Dtol;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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


    }
}
