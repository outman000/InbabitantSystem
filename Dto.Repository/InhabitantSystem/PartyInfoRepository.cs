using Dto.IRepository.InhabitantSystem;
using Dtol;
using Dtol.Dtol;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dto.Repository.InhabitantSystem
{
    public class PartyInfoRepository : IPartyInfoRepository
    {
        protected readonly DtolContext Db;
        protected readonly DbSet<PartyInfo> DbSet;

        public PartyInfoRepository(DtolContext context)
        {
            Db = context;
            DbSet = Db.Set<PartyInfo>();
        }

        public void Add(PartyInfo obj)
        {
            DbSet.Add(obj);
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

        public IQueryable<PartyInfo> GetAll()
        {
            return DbSet;
        }

        public PartyInfo GetById(Guid id)
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

        public void Update(PartyInfo obj)
        {
            DbSet.Update(obj)
                .Property(a => a.JoinPartyTime).IsModified = true;
                
        }
    }
}
