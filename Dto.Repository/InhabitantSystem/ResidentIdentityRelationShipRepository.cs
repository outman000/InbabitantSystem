using Dto.IRepository.InhabitantSystem;
using Dtol;
using Dtol.Dtol;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.InhabitantSystem.MiddleViewModel;

namespace Dto.Repository.InhabitantSystem
{
    public class ResidentIdentityRelationShipRepository : IResidentIdentityRelationShipRepository
    {
        protected readonly DtolContext Db;
        protected readonly DbSet<ResidentRelationShip> DbSet;
        public ResidentIdentityRelationShipRepository(DtolContext context)
        {
            Db = context;
            DbSet = Db.Set<ResidentRelationShip>();
        }




        public void Add(ResidentRelationShip obj)
        {
            DbSet.Add(obj);
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

        public IQueryable<ResidentRelationShip> GetAll()
        {
            return DbSet;
        }

        public ResidentRelationShip GetById(Guid id)
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

        public void Update(ResidentRelationShip obj)
        {
            DbSet.Update(obj);
        }



        public void AddResidentIdentityRelationShip(List<ResidentRelationShip> obj)
        {
            foreach (ResidentRelationShip residentRelationShip in obj)
            {
                DbSet.Add(residentRelationShip);
            }
        }

        public void DeleteResidentIdentityRelationShip(List<ResidentIdentityRelationShipDeleteMiddle> obj)
        {
            foreach (ResidentIdentityRelationShipDeleteMiddle residentIdentityRelationShipDeleteMiddle in obj)
            {
                Remove(residentIdentityRelationShipDeleteMiddle.Id);
            }
        }
    }
}
