using Dto.IRepository.MaintainSystem;
using Dtol;
using Dtol.Dtol;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dto.Repository.MaintainSystem
{
    public class PoliticalRepository : IPoliticalRepository
    {
        protected readonly DtolContext Db;
        protected readonly DbSet<Political> DbSet;
        public PoliticalRepository(DtolContext context)
        {
            Db = context;
            DbSet = Db.Set<Political>();
        }


        public void Add(Political obj)
        {
            DbSet.Add(obj);
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

        public IQueryable<Political> GetAll()
        {
            return DbSet.OrderBy(a=>a.code);
        }

        public Political GetById(Guid id)
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

        public void Update(Political obj)
        {
            DbSet.Update(obj);
        }
    }
}
