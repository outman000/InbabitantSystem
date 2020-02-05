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
using ViewModel.InhabitantSystem.RequestViewModel;

namespace Dto.Repository.InhabitantSystem
{
    public class IdentityRepository : IIdentityRepository
    {
        protected readonly DtolContext Db;
        protected readonly DbSet<ResidentIdentity> DbSet;
        public IdentityRepository(DtolContext context)
        {
            Db = context;
            DbSet = Db.Set<ResidentIdentity>();
        }
        public void Add(ResidentIdentity obj)
        {
            DbSet.Add(obj);
        }

        

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

        public IQueryable<ResidentIdentity> GetAll()
        {
            return DbSet;
        }

        public ResidentIdentity GetById(Guid id)
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

        public void Update(ResidentIdentity obj)
        {
            DbSet.Update(obj);
        }
        public List<ResidentIdentity> IdentitySerachByWhere(IdentitySearchViewModel identitySearchViewModel)
        {
            int SkipNum = identitySearchViewModel.pageViewModel.CurrentPageNum * identitySearchViewModel.pageViewModel.PageSize;
            //查询条件
            var predicate = SearchIdentityWhere(identitySearchViewModel);
            var result = DbSet
                         //.Include(a => a.ResidentIdentity)
                         //.Include(a=>a.ResidentInfo)
                         .Where(predicate).ToList()
            .Skip(SkipNum)
            .Take(identitySearchViewModel.pageViewModel.PageSize)
            .OrderBy(o => o.AddTime).ToList();

            return result;
        }
        public int IdentitySerachByWhereCount(IdentitySearchViewModel identitySearchViewModel)
        {
            var predicate = SearchIdentityWhere(identitySearchViewModel);
            var result = DbSet
                         //.Include(a => a.ResidentIdentity)
                         //.Include(a=>a.ResidentInfo)
                         .Where(predicate).Count();
            return result;
        }



        public void UpdateIdentity(List<ResidentIdentity> obj)
        {
            foreach (ResidentIdentity residentRelationShip in obj)
            {
                DbSet.Update(residentRelationShip);
            }
        }
        public void AddIdentity(List<ResidentIdentity> obj)
        {
            foreach (ResidentIdentity residentRelationShip in obj)
            {
                DbSet.Add(residentRelationShip);
            }
        }

        private Expression<Func<ResidentIdentity, bool>> SearchIdentityWhere(IdentitySearchViewModel identitySearchViewModel)
        {
            var predicate = WhereExtension.True<ResidentIdentity>();//初始化where表达式

            if (identitySearchViewModel.Id != null)
            {
                predicate = predicate.And(p => p.Id.Equals(identitySearchViewModel.Id));
            }
            if (identitySearchViewModel.IdentityName!="")
            {
                predicate = predicate.And(p => p.IdentityName.Equals(identitySearchViewModel.IdentityName));
            }
            predicate = predicate.And(p => p.Status == "1");

            return predicate;
        }
    }
}
