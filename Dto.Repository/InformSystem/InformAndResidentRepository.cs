using Dto.IRepository.InformSystem;
using Dtol;
using Dtol.Dtol;
using Dtol.EfCoreExtion;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using ViewModel.InformSystem.RequestViewModel;

namespace Dto.Repository.InformSystem
{
    public class InformAndResidentRepository : IInformAndResidentRepository
    {
        protected readonly DtolContext Db;
        protected readonly DbSet<InformAndResident> DbSet;
        public InformAndResidentRepository(DtolContext context)
        {
            Db = context;
            
            DbSet = Db.Set<InformAndResident>();
        }
        public void Add(InformAndResident obj)
        {
            DbSet.Add(obj);
        }

        public void AddInformAndResident(List<InformAndResident> obj)
        {
            foreach (InformAndResident informAndResident in obj)
            {
                DbSet.Add(informAndResident);

            }
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

        public IQueryable<InformAndResident> GetAll()
        {
            return DbSet;
        }

        public InformAndResident GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public List<InformAndResident> InformAndResidentSerachByIdWhere(InformSearchByIdViewModel informSearchByIdViewModel)
        {
            int SkipNum = informSearchByIdViewModel.pageViewModel.CurrentPageNum * informSearchByIdViewModel.pageViewModel.PageSize;
            var predicate = SearchInformAndResidentWhere(informSearchByIdViewModel);
            var result = DbSet
                .Include(a => a.Inform)
                .Include(a => a.residentInfo)
                .Where(predicate);
            var aaaa = result.ToList()
                       .Skip(SkipNum)
                       .Take(informSearchByIdViewModel.pageViewModel.PageSize).ToList();
            
            //.OrderBy(o => o.AddTime).ToList();

            return aaaa;
        }

        public void Remove(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Update(InformAndResident obj)
        {
            DbSet.Update(obj);
        }

        private Expression<Func<InformAndResident, bool>> SearchInformAndResidentWhere(InformSearchByIdViewModel informSearchByIdViewModel)
        {
            var predicate = WhereExtension.True<InformAndResident>();//初始化where表达式

            if (informSearchByIdViewModel.Id != null)
            {
                predicate = predicate.And(p => p.InformId.Equals(informSearchByIdViewModel.Id) );
            }
            

            return predicate;
        }
    }
}
