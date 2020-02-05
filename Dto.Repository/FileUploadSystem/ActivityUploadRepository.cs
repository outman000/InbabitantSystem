using Dto.IRepository.FileUploadSystem;
using Dtol;
using Dtol.Dtol;
using Dtol.EfCoreExtion;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using ViewModel.ActivitySystem.MiddleViewModel;

namespace Dto.Repository.FileUploadSystem
{
    public class ActivityUploadRepository : IActivityUploadRepository
    {

        protected readonly DtolContext Db;
        protected readonly DbSet<FileUpload> DbSet;
        public ActivityUploadRepository(DtolContext context)
        {
            Db = context;
            DbSet = Db.Set<FileUpload>();
        }


        public void Add(FileUpload obj)
        {
            DbSet.Add(obj);
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

        public IQueryable<FileUpload> GetAll()
        {
            return DbSet;
        }

        public FileUpload GetById(Guid id)
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

        public void Update(FileUpload obj)
        {
            DbSet.Update(obj);
        }

        /// <summary>
        /// 根据Id查附件
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        #region
        public List<ActivityUploadSearchMiddle> getAttachInfo(Guid Id)
        {
            var predicate = Getwhere(Id);
            var result = DbSet.Where(predicate)
                            .Select(
                                        p=>new ActivityUploadSearchMiddle()
                                        {
                                            Id=p.Id,
                                            FileName=p.FileName,
                                            PhysicsName=p.PhysicsName, 
                                            FormId=p.FormId,
                                            Status=p.Status,
                                            AddTime=p.AddTime,
                                            FilePath = p.FilePath
                                        }
                                    )
                            .ToList();
            return result;
        }
        private Expression<Func<FileUpload, bool>> Getwhere(Guid Id)
        {
            var predicate = WhereExtension.True<FileUpload>();
            
            if (Id != null)
            {
                predicate = predicate.And(p => p.Id.Equals(Id));
            }
            
            predicate = predicate.And(p => p.Status == "1");
            return predicate;
        }
        #endregion



        /// <summary>
        /// 根据formId查附件
        /// </summary>
        /// <param name="FormId"></param>
        /// <returns></returns>
        #region
        public List<ActivityUploadSearchMiddle> getAttachInfoByFormId(Guid FormId)
        {
            var predicate = GetwhereByFormId(FormId);
            var result = DbSet.Where(predicate)
                            .Select(
                                        p => new ActivityUploadSearchMiddle()
                                        {
                                            Id = p.Id,
                                            FileName = p.FileName,
                                            PhysicsName = p.PhysicsName,
                                            FormId = p.FormId,
                                            Status = p.Status,
                                            AddTime = p.AddTime,
                                            FilePath = p.FilePath
                                        }
                                    )
                            .ToList();
            return result;
        }
        private Expression<Func<FileUpload, bool>> GetwhereByFormId(Guid FormId)
        {
            var predicate = WhereExtension.True<FileUpload>();
            
            if (FormId != null)
            {
                predicate = predicate.And(p => p.FormId.Equals(FormId));
            }

            predicate = predicate.And(p => p.Status == "1");
            return predicate;
        }




        #endregion
    }
}
