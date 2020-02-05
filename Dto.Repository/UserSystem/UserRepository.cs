using Dto.IRepository.UserSystem;
using Dtol;
using Dtol.Dtol;
using Dtol.EfCoreExtion;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using ViewModel.UserSystem.RequestViewModel;

namespace Dto.Repository.UserSystem
{
    public class UserRepository : IUserRepository
    {
        protected readonly DtolContext Db;
        protected readonly DbSet<UserInfo> DbSet;
        public UserRepository(DtolContext context)
        {
            Db = context;
            DbSet = Db.Set<UserInfo>();
        }

        public void Add(UserInfo obj)
        {
            DbSet.Add(obj);
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

        public IQueryable<UserInfo> GetAll()
        {
            return DbSet;
        }

        public UserInfo GetById(Guid id)
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

        public void Update(UserInfo obj)
        {
            DbSet.Update(obj);
        }

        public int UserSerachByWhere(UserSearchViewModel userSearchViewModel)
        {
            var predicate = SearchUserWhere(userSearchViewModel);
            var result = DbSet.Where(predicate).Count();
            //.Skip(SkipNum)
            //.Take(foodInfoSearchViewModel.pageViewModel.PageSize)
            //.OrderBy(o => o.AddDate).ToList();

            return result;
        }

        private Expression<Func<UserInfo, bool>> SearchUserWhere(UserSearchViewModel userSearchViewModel)
        {
            var predicate = WhereExtension.True<UserInfo>();//初始化where表达式
            
                predicate = predicate.And(p => p.UserName.Equals(userSearchViewModel.UserName));
            
                predicate = predicate.And(p => p.PassWord.Equals(userSearchViewModel.PassWord));
            

            return predicate;
        }
    }
}
