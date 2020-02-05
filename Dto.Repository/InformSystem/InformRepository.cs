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
    public class InformRepository : IInformRepository
    {
        protected readonly DtolContext Db;
        protected readonly DbSet<Inform> DbSet;
        public InformRepository(DtolContext context)
        {
            Db = context;
            DbSet = Db.Set<Inform>();
        }

        public void Add(Inform obj)
        {
            DbSet.Add(obj);
        }

        

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

        public IQueryable<Inform> GetAll()
        {
            return DbSet;
        }

        public Inform GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public List<Inform> InformSerachByWhere(InformSearchViewModel informSearchViewModel)
        {
            int SkipNum = informSearchViewModel.pageViewModel.CurrentPageNum * informSearchViewModel.pageViewModel.PageSize;
            var predicate = SearchInformWhere(informSearchViewModel);
            var result = DbSet.Where(predicate).ToList().OrderBy(a=>a.AddTime)
            .Skip(SkipNum)
            .Take(informSearchViewModel.pageViewModel.PageSize).ToList();
            //.OrderBy(o => o.AddDate).ToList();

            return result;
        }
        public int InformSerachByWhereCount(InformSearchViewModel informSearchViewModel)
        {
            var predicate = SearchInformWhere(informSearchViewModel);
            var result = DbSet.Where(predicate).ToList()
                        .Count();

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

        

        public void Update(Inform obj)
        {
            DbSet.Update(obj);
        }

        private Expression<Func<Inform, bool>> SearchInformWhere(InformSearchViewModel informSearchViewModel)
        {
            var predicate = WhereExtension.True<Inform>();//初始化where表达式
            
            if (informSearchViewModel.StartTime != null)
            {
                predicate = predicate.And(p => p.SendTime> informSearchViewModel.StartTime);
            }
            if (informSearchViewModel.EndTime != null)
            {
                predicate = predicate.And(p => p.SendTime < informSearchViewModel.EndTime);
            }
            if (informSearchViewModel.Sender != "")
            {
                predicate = predicate.And(p => p.Sender.Contains(informSearchViewModel.Sender));
            }
            if (informSearchViewModel.Title != "")
            {
                predicate = predicate.And(p => p.InformTitle.Contains(informSearchViewModel.Title));
            }
            if (informSearchViewModel.Status == "1")
            {
                predicate = predicate.And(p => p.Status == "1");
            }
            if (informSearchViewModel.Status == "2")
            {
                predicate = predicate.And(p => p.Status == "2");
            }
            if (informSearchViewModel.Status == "3")
            {
                predicate = predicate.And(p => p.Status != "0");
            }

            return predicate;
        }
    }
}
