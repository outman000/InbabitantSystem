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
using ViewModel.InhabitantSystem.MiddleViewModel;
using ViewModel.InhabitantSystem.RequestViewModel;
using ViewModel.InhabitantSystem.ResponseViewModel;

namespace Dto.Repository.InhabitantSystem
{
    public class InhabitantRepository : IInhabitantRepository
    {
        protected readonly DtolContext Db;
        protected readonly DbSet<ResidentInfo> DbSet;
        protected readonly DbSet<PartyInfo> DbSet1;
        public InhabitantRepository(DtolContext context)
        {
            Db = context;
            DbSet = Db.Set<ResidentInfo>();
            DbSet1 = Db.Set<PartyInfo>();
        }

        public void Add(ResidentInfo obj)
        {
            DbSet.Add(obj);
        }
        public void AddInfo(List<ResidentInfo> obj)
        {
            foreach (ResidentInfo infoRelationShip in obj) {
                DbSet.Add(infoRelationShip);
            }
            
        }
        public void UpdateInfo(List<ResidentInfo> obj)
        {
            foreach (ResidentInfo infoRelationShip in obj)
            {
                DbSet.Update(infoRelationShip);
            }
        }

        public IQueryable<ResidentInfo> InhabitantSerachByWhere(InhabitantSearchViewModel inhabitantSearchViewModel)
        {
            //查询条件
            var predicate = SearchInhabitantWhere(inhabitantSearchViewModel);
            var result = DbSet
                         //.Include(a=>a.HouseInfo)
                         //.Include(a=>a.ResidentInfo)
                         .Where(predicate);
            //.Skip(SkipNum)
            //.Take(foodInfoSearchViewModel.pageViewModel.PageSize)
            //.OrderBy(o => o.AddDate).ToList();

            return result;
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

        public IQueryable<ResidentInfo> GetAll()
        {
            return DbSet;
        }

        public ResidentInfo GetById(Guid id)
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

        public void Update(ResidentInfo obj)
        {
            DbSet.Update(obj);
        }
     


        #region 查询条件
        //根据条件查询
        private Expression<Func<ResidentInfo, bool>> SearchInhabitantWhere(InhabitantSearchViewModel inhabitantSearchViewModel)
        {
            var predicate = WhereExtension.True<ResidentInfo>();//初始化where表达式
            //predicate = predicate.And(p => p.Name.ToString().Contains(buildingSearchViewModel.Name.ToString()));
            if (inhabitantSearchViewModel.Id != null)
            {
                predicate = predicate.And(p => p.Id.Equals(inhabitantSearchViewModel.Id));
            }
            predicate = predicate.And(p => p.Status == "1");

            return predicate;
        }
        #endregion
        /// <summary>
        /// 根据身份证查询居民
        /// </summary>
        /// <param name="IdNo"></param>
        /// <returns></returns>
        public ResidentInfo InhabitantSerachByIdNoWhere(string IdNo)
        {
            var predicate = SearchInhabitantByIdNoWhere(IdNo);
            var result = DbSet
                         //.Include(a=>a.HouseInfo)
                         //.Include(a=>a.ResidentInfo)
                         .Where(predicate);
            if (result.Count() != 0)
            {
                return result.Single();
            }
            else
            {
                return null;
            }
           
            
        }
        private Expression<Func<ResidentInfo, bool>> SearchInhabitantByIdNoWhere(string IdNo)
        {
            var predicate = WhereExtension.True<ResidentInfo>();//初始化where表达式
            if (IdNo!= null)
            {
                predicate = predicate.And(p => p.IdNumber.Equals(IdNo));
            }
            predicate = predicate.And(p => p.Status == "1");
            return predicate;
        }



        /// <summary>
        /// 查询党员的居民信息
        /// </summary>
        /// <param name="partyResidentSearchViewModel"></param>
        /// <returns></returns>
        #region
        public List<PartyResidentSearchMiddle> getPartResidentSearch(PartyResidentSearchViewModel partyResidentSearchViewModel)
        {
            int SkipNum = partyResidentSearchViewModel.pageViewModel.CurrentPageNum * partyResidentSearchViewModel.pageViewModel.PageSize;
            var predicate = SearchPartResidentWhere(partyResidentSearchViewModel);
            var result = DbSet.Include(a => a.InfoRelationShips).ThenInclude(b => b.HouseInfo)
                           //.Include(a => a.ResidentRelationShips).ThenInclude(b => b.ResidentIdentity)
                           .Where(predicate)
                           .Join(DbSet1, a => a.Id, b => b.ResidentId, (a, b) => new PartyResidentSearchMiddle   //inner join
                           {
                               Id = a.Id,
                               Name = a.Name,
                               Gender = a.Gender,
                               IdNumber = a.IdNumber,
                               Education = a.Education,
                               Phone = a.Phone,
                               JoinPartyTime = b.JoinPartyTime,
                               PartyJob = b.PartyJob

                           })
                           
                           
                           .ToList()
                           .GroupBy(a => a.Id).Select(a => a.First()).ToList();
            var aaa= result
                        .Skip(SkipNum)
                       .Take(partyResidentSearchViewModel.pageViewModel.PageSize).ToList();

            return aaa;
        }

        private Expression<Func<ResidentInfo, bool>> SearchPartResidentWhere(PartyResidentSearchViewModel partyResidentSearchViewModel)
        {
            var predicate = WhereExtension.True<ResidentInfo>();//初始化where表达式

            if (partyResidentSearchViewModel.IdentityName != "")
            {
                predicate = predicate.And(p => p.Politics.Equals(partyResidentSearchViewModel.IdentityName));
            }
            if (partyResidentSearchViewModel.Area != "")
            {
                predicate = predicate.And(p => p.InfoRelationShips.HouseInfo.Area.Equals(partyResidentSearchViewModel.Area));
            }
            if (partyResidentSearchViewModel.Name != "")
            {
                predicate = predicate.And(p => p.Name.Equals(partyResidentSearchViewModel.Name));
            }
            //根据出生年月范围查询
            if (partyResidentSearchViewModel.StartTime != null)
            {
                predicate = predicate.And(p => DateTime.ParseExact(p.IdNumber.Substring(6, 8),"yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture)>= partyResidentSearchViewModel.StartTime);
            }
            if (partyResidentSearchViewModel.EndTime != null)
            {
                predicate = predicate.And(p => DateTime.ParseExact(p.IdNumber.Substring(6, 8), "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture) <= partyResidentSearchViewModel.EndTime);
            }

            predicate = predicate.And(p => p.Status == "1");


            return predicate;
        }

        public int getPartResidentSearchCount(PartyResidentSearchViewModel partyResidentSearchViewModel)
        {
            var predicate = SearchPartResidentWhere(partyResidentSearchViewModel);
            var result = DbSet.Include(a => a.InfoRelationShips).ThenInclude(b => b.HouseInfo)
                           //.Include(a => a.ResidentRelationShips).ThenInclude(b => b.ResidentIdentity)
                           .Where(predicate)
                           .Join(DbSet1, a => a.Id, b => b.ResidentId, (a, b) => new PartyResidentSearchMiddle   //inner join
                           {
                               Id = a.Id,
                               Name = a.Name,
                               Gender = a.Gender,
                               IdNumber = a.IdNumber,
                               Education = a.Education,
                               Phone = a.Phone,
                               JoinPartyTime = b.JoinPartyTime,
                               PartyJob = b.PartyJob

                           })


                           .ToList()
                           .GroupBy(a => a.Id).Select(a => a.First()).ToList().Count();
            return result;
        }
        #endregion


        /// <summary>
        /// 根据id查询党员的居民信息
        /// </summary>
        /// <param name="partyResidentByIdSearchViewModel"></param>
        /// <returns></returns>
        public PartyResidentByIdSearchMiddle getPartResidentByIdSearch(PartyResidentByIdSearchViewModel partyResidentByIdSearchViewModel)
        {
            var predicate = SearchPartResidentByIdWhere(partyResidentByIdSearchViewModel);
            var result = DbSet
                           //.Include(a => a.InfoRelationShips).ThenInclude(b => b.HouseInfo)
                           //.Include(a => a.ResidentRelationShips).ThenInclude(b => b.ResidentIdentity)
                           .Where(predicate)
                           .Join(DbSet1, a => a.Id, b => b.ResidentId, (a, b) => new PartyResidentByIdSearchMiddle   //inner join
                           {
                               Id = a.Id,
                               Name = a.Name,
                               Politics = a.Politics,
                               Gender = a.Gender,
                               IdNumber = a.IdNumber,
                               Education = a.Education,
                               Phone = a.Phone,
                               Minority=a.Minority,
                               PartId = b.Id,
                               JoinPartyTime = b.JoinPartyTime,
                               PartyJob = b.PartyJob,
                               Comment = b.Comment

                           })
                           .FirstOrDefault();


                           
            

            return result;
        }

        private Expression<Func<ResidentInfo, bool>> SearchPartResidentByIdWhere(PartyResidentByIdSearchViewModel partyResidentByIdSearchViewModel)
        {
            var predicate = WhereExtension.True<ResidentInfo>();//初始化where表达式

            if (partyResidentByIdSearchViewModel.Id != null)
            {
                predicate = predicate.And(p => p.Id.Equals(partyResidentByIdSearchViewModel.Id));
            }
            predicate = predicate.And(p => p.Status == "1");


            return predicate;
        }


        /// <summary>
        /// 查询未成年人
        /// </summary>
        /// <param name="underAgerSearchViewModel"></param>
        /// <returns></returns>
        public List<UnderAgeSearchMiddle> GetUnderAgeSearch(UnderAgerSearchViewModel underAgerSearchViewModel)
        {
            int SkipNum = underAgerSearchViewModel.pageViewModel.CurrentPageNum * underAgerSearchViewModel.pageViewModel.PageSize;
            var predicate = SearchUnderAgeWhere(underAgerSearchViewModel);
           

            var result = DbSet.Include(a => a.InfoRelationShips).ThenInclude(b => b.HouseInfo)
                           .Where(predicate)
                           
                           .Select(
                            p => new UnderAgeSearchMiddle()
                            {
                                Id = p.Id,
                                Name = p.Name,
                                IdNumber = p.IdNumber,
                                Age = Convert.ToInt32(DateTime.Now.Year.ToString()) - Convert.ToInt32(p.IdNumber.Substring(6, 4)),
                                Area = p.InfoRelationShips.HouseInfo.Area,
                                Phone = p.Phone,
                                Address = p.Address,
                                Province = p.Province,
                                City = p.City,
                                County = p.County
                            }
                            )
                            .ToList()
                            .Skip(SkipNum)
                       .Take(underAgerSearchViewModel.pageViewModel.PageSize).ToList();

            return result;
        }


        private Expression<Func<ResidentInfo, bool>> SearchUnderAgeWhere(UnderAgerSearchViewModel underAgerSearchViewModel)
        {
            var predicate = WhereExtension.True<ResidentInfo>();//初始化where表达式

            if (underAgerSearchViewModel.Area != "")
            {
                predicate = predicate.And(p => p.InfoRelationShips.HouseInfo.Area.Equals(underAgerSearchViewModel.Area));
            }
            if (underAgerSearchViewModel.Name != "")
            {
                predicate = predicate.And(p => p.Name.Equals(underAgerSearchViewModel.Name));
            }

            //根据出生年月范围查询
            if (underAgerSearchViewModel.StartTime != null)
            {
                predicate = predicate.And(p => DateTime.ParseExact(p.IdNumber.Substring(6, 8), "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture) >= underAgerSearchViewModel.StartTime);
            }
            if (underAgerSearchViewModel.EndTime != null)
            {
                predicate = predicate.And(p => DateTime.ParseExact(p.IdNumber.Substring(6, 8), "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture) <= underAgerSearchViewModel.EndTime);
            }

            predicate = predicate.And(p=> (Convert.ToInt32(DateTime.Now.Year.ToString()) - Convert.ToInt32(p.IdNumber.Substring(6, 4)))<18);
            predicate = predicate.And(p => p.Status == "1");


            return predicate;
        }
       

        /// <summary>
        ///查询适龄人员
        /// </summary>
        /// <param name="underAgerSearchViewModel"></param>
        /// <returns></returns>
        public List<RightAgeSearchMiddle> GetRightAgeSearch(RightAgeSearchViewModel rightAgeSearchViewModel)
        {
            int SkipNum = rightAgeSearchViewModel.pageViewModel.CurrentPageNum * rightAgeSearchViewModel.pageViewModel.PageSize;
            var predicate = SearchRightAgeWhere(rightAgeSearchViewModel);
            var predicate1= SearchRightAgeWhere1(rightAgeSearchViewModel);

            var result = DbSet.Include(a => a.InfoRelationShips).ThenInclude(b => b.HouseInfo)
                           .Where(predicate)
                           .Select(
                            p => new RightAgeSearchMiddle()
                            {
                                Id = p.Id,
                                Name = p.Name,
                                IdNumber = p.IdNumber,
                                Age = Convert.ToInt32(DateTime.Now.Year.ToString()) - Convert.ToInt32(p.IdNumber.Substring(6, 4)),
                                Phone = p.Phone,
                                Area = p.InfoRelationShips.HouseInfo.Area,
                                BuildingNo=p.InfoRelationShips.HouseInfo.BuildingNo,
                                UnitNo=p.InfoRelationShips.HouseInfo.UnitNo,
                                HouseNo=p.InfoRelationShips.HouseInfo.HouseNo
                            }
                            )
                            .ToList();
            var result1= DbSet.Include(a => a.InfoRelationShips).ThenInclude(b => b.HouseInfo)
                           .Where(predicate1)
                           .Select(
                            p => new RightAgeSearchMiddle()
                            {
                                Id = p.Id,
                                Name = p.Name,
                                IdNumber = p.IdNumber,
                                Age = Convert.ToInt32(DateTime.Now.Year.ToString()) - Convert.ToInt32(p.IdNumber.Substring(6, 4)),
                                Phone = p.Phone,
                                Area = p.InfoRelationShips.HouseInfo.Area,
                                BuildingNo = p.InfoRelationShips.HouseInfo.BuildingNo,
                                UnitNo = p.InfoRelationShips.HouseInfo.UnitNo,
                                HouseNo = p.InfoRelationShips.HouseInfo.HouseNo
                            }
                            )
                            .ToList();


            var eee = result.Union(result1).ToList()
                        .Skip(SkipNum)
                        .Take(rightAgeSearchViewModel.pageViewModel.PageSize).ToList();

            return eee;
        }


        private Expression<Func<ResidentInfo, bool>> SearchRightAgeWhere(RightAgeSearchViewModel rightAgeSearchViewModel)
        {
            var predicate = WhereExtension.True<ResidentInfo>();//初始化where表达式

            //(Convert.ToInt32(DateTime.Now.Year.ToString()) - Convert.ToInt32(p.IdNumber.Substring(6, 4)))== rightAgeSearchViewModel.Ruyuan

            if (rightAgeSearchViewModel.Area != "")
            {
                predicate = predicate.And(p => p.InfoRelationShips.HouseInfo.Area.Equals(rightAgeSearchViewModel.Area));
            }
            if (rightAgeSearchViewModel.Name != "")
            {
                predicate = predicate.And(p => p.Name.Equals(rightAgeSearchViewModel.Name));
            }
            //根据入园年龄查询
            
            predicate = predicate.And(p => (Convert.ToInt32(DateTime.Now.Year.ToString()) - Convert.ToInt32(p.IdNumber.Substring(6, 4))) == 4);
            
            predicate = predicate.And(p => p.Status == "1");



            return predicate;
        }
        private Expression<Func<ResidentInfo, bool>> SearchRightAgeWhere1(RightAgeSearchViewModel rightAgeSearchViewModel)
        {
            var predicate = WhereExtension.True<ResidentInfo>();//初始化where表达式

            if (rightAgeSearchViewModel.Area != "")
            {
                predicate = predicate.And(p => p.InfoRelationShips.HouseInfo.Area.Equals(rightAgeSearchViewModel.Area));
            }
            if (rightAgeSearchViewModel.Name != "")
            {
                predicate = predicate.And(p => p.Name.Equals(rightAgeSearchViewModel.Name));
            }
            ////根据入学年龄查询
            
            predicate = predicate.And(p =>(Convert.ToInt32(DateTime.Now.Year.ToString()) - Convert.ToInt32(p.IdNumber.Substring(6, 4)))==6);
            
            predicate = predicate.And(p => p.Status == "1");


            return predicate;
        }

    }
}
