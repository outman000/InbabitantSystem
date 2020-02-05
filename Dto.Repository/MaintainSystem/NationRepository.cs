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
    public class NationRepository : INationRepository
    {
        protected readonly DtolContext Db;
        protected readonly DbSet<Nation> DbSet;
        public NationRepository(DtolContext context)
        {
            Db = context;
            DbSet = Db.Set<Nation>();
        }

        public void Add(Nation obj)
        {
            DbSet.Add(obj);
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

        public IQueryable<Nation> GetAll()
        {
            return DbSet.OrderBy(a => a.code);
        }

        public Nation GetById(Guid id)
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

        public void Update(Nation obj)
        {
            DbSet.Update(obj);
        }
    }
}
