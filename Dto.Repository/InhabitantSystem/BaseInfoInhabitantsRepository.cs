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

namespace Dto.Repository.InhabitantSystem
{
    public  class BaseInfoInhabitantsRepository : IBaseInfoInhabitantsRepository
    {
        protected readonly DtolContext Db;
        protected readonly DbSet<ResidentInfo> DbSet;
        public BaseInfoInhabitantsRepository(DtolContext context)
        {
            Db = context;
            DbSet = Db.Set<ResidentInfo>();
        }

        public void Add(ResidentInfo obj)
        {
            DbSet.Add(obj);
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

        public ResidentInfo GetById2(Guid id)
        {
            return DbSet.Single(a => a.Id == id);
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
        /// <summary>
        /// 发送通知时 根据房子 身份 居民 查询所有信息
        /// </summary>
        /// <param name="baseInfoInhabitantViewModel"></param>
        /// <returns></returns>
        #region
        public List<BaseInfoInhabitantMiddle> getResidentByAllInfo(BaseInfoInhabitantViewModel baseInfoInhabitantViewModel)    //Include(a => a.ResidentRelationShips).Select(b=>b.ResidentIdentity) //.Include(a => a.InfoRelationShips.Select(b => b.HouseInfo))
        {
            int SkipNum = baseInfoInhabitantViewModel.pageViewModel.CurrentPageNum * baseInfoInhabitantViewModel.pageViewModel.PageSize;
            var predicate = SearchAllWhere(baseInfoInhabitantViewModel);
            var result = DbSet.Include(a => a.InfoRelationShips).ThenInclude(b => b.HouseInfo)
                           .Include(a => a.ResidentRelationShips).ThenInclude(b => b.ResidentIdentity)
                           .Where(predicate)
                           
                           .OrderBy(a => a.AddTime)
                           .Select(
                                p => new BaseInfoInhabitantMiddle()
                                {
                                    Id = p.Id,
                                    Name = p.Name,
                                    Gender = p.Gender,
                                    Age = Convert.ToInt32(DateTime.Now.Year.ToString()) - Convert.ToInt32(p.IdNumber.Substring(6, 4)),
                                    //Area=p.InfoRelationShips.HouseInfo.Area,
                                    Phone=p.Phone,
                                    IdNumber=p.IdNumber
                                }
                            )
                           
                           
                           
                           .ToList();

            var aaaa = result.AsEnumerable()
                       .Skip(SkipNum)
                       .Take(baseInfoInhabitantViewModel.pageViewModel.PageSize).ToList();

            //.Select(p => new ResidentMiddle()
            // {
            //    Id =p.Id,
            //    Address = p.Address,
            //    Company = p.Company,
            //    Education = p.Education,
            //    HouseInfo = p.InfoRelationShips.HouseInfo,
            //    ResidentIdentity = p.ResidentRelationShips.ResidentIdentity
            // }

            //).ToList();
            return aaaa;
                
            //    DbSet.Include(a => a.ResidentRelationShips).ThenInclude(a=>a.Select(b=>b.ResidentIdentity))
            //.Include(a => a.InfoRelationShips).ThenInclude(a => a.Select(b => b.HouseInfo));
        }
        public int getResidentByAllInfoCount(BaseInfoInhabitantViewModel baseInfoInhabitantViewModel)
        {
            var predicate = SearchAllWhere(baseInfoInhabitantViewModel);
            var result = DbSet.Include(a => a.InfoRelationShips).ThenInclude(b => b.HouseInfo)
                           .Include(a => a.ResidentRelationShips).ThenInclude(b => b.ResidentIdentity)
                           .Where(predicate)
                           .Select(
                            p => new BaseInfoInhabitantMiddle()
                            {
                                Id = p.Id,
                                Name = p.Name,
                                Gender = p.Gender,
                                Age = Convert.ToInt32(DateTime.Now.Year.ToString()) - Convert.ToInt32(p.IdNumber.Substring(6, 4)),
                                Area = p.InfoRelationShips.HouseInfo.Area,
                                Phone = p.Phone
                            }
                            )
                           .Count();
            return result;
        }



        private Expression<Func<ResidentInfo, bool>> SearchAllWhere(BaseInfoInhabitantViewModel baseInfoInhabitantViewModel)
        {
            var predicate = WhereExtension.True<ResidentInfo>();//初始化where表达式
            //id
            if (baseInfoInhabitantViewModel.Id != null)
            {
                predicate = predicate.And(p => p.Id.Equals(baseInfoInhabitantViewModel.Id));
            }
            //身份
            if (baseInfoInhabitantViewModel.IdentityName != "")
            {
                predicate = predicate.And(p => p.ResidentRelationShips.ResidentIdentity.IdentityName.Contains(baseInfoInhabitantViewModel.IdentityName));
            }
            //姓名
            if (baseInfoInhabitantViewModel.Name != "")
            {
                predicate = predicate.And(p => p.Name.Contains(baseInfoInhabitantViewModel.Name));
            }
            //性别
            if (baseInfoInhabitantViewModel.Gender != "")
            {
                predicate = predicate.And(p => p.Gender.Contains(baseInfoInhabitantViewModel.Gender));
            }
            //身份证号
            if (baseInfoInhabitantViewModel.IdNumber != "")
            {
                predicate = predicate.And(p => p.IdNumber.Contains(baseInfoInhabitantViewModel.IdNumber));
            }
            //小区名
            if (baseInfoInhabitantViewModel.Area != "")
            {
                predicate = predicate.And(p => p.InfoRelationShips.HouseInfo.Area.Contains(baseInfoInhabitantViewModel.Area));
            }
            //楼号
            if (baseInfoInhabitantViewModel.BuildingNo != 0)
            {
                predicate = predicate.And(p => p.InfoRelationShips.HouseInfo.BuildingNo.Equals(baseInfoInhabitantViewModel.BuildingNo));
            }
            //单元号
            if (baseInfoInhabitantViewModel.UnitNo != 0)
            {
                predicate = predicate.And(p => p.InfoRelationShips.HouseInfo.UnitNo.Equals(baseInfoInhabitantViewModel.UnitNo));

            }
            //门牌号
            if (baseInfoInhabitantViewModel.HouseNo != "")
            {
                predicate = predicate.And(p => p.InfoRelationShips.HouseInfo.HouseNo.Equals(baseInfoInhabitantViewModel.HouseNo));
            }
            //起始年龄
            if (baseInfoInhabitantViewModel.StartAge != 0)
            {
                
                predicate = predicate.And(p => Convert.ToInt32(DateTime.Now.Year.ToString())- Convert.ToInt32(p.IdNumber.Substring(6, 4)) >= (baseInfoInhabitantViewModel.StartAge));
            }
            //结束年龄
            if (baseInfoInhabitantViewModel.EndAge != 0)
            {
                predicate = predicate.And(p => Convert.ToInt32(DateTime.Now.Year.ToString()) - Convert.ToInt32(p.IdNumber.Substring(6, 4)) <= (baseInfoInhabitantViewModel.EndAge));
            }
            predicate = predicate.And(p => p.Status == "1");
            return predicate;
        }
        #endregion





        /// <summary>
        /// 查询添加身份时 查询不是该身份的居民信息
        /// </summary>
        /// <param name="addIdentitySearchResidentViewModel"></param>
        /// <returns></returns>
        #region
        public List<AddIdentitySearchResidentMiddle> getAddIdentitySearchResident(AddIdentitySearchResidentViewModel addIdentitySearchResidentViewModel)    //Include(a => a.ResidentRelationShips).Select(b=>b.ResidentIdentity) //.Include(a => a.InfoRelationShips.Select(b => b.HouseInfo))
        {
            int SkipNum = addIdentitySearchResidentViewModel.pageViewModel.CurrentPageNum * addIdentitySearchResidentViewModel.pageViewModel.PageSize;
            var predicate = SearchIdentityResidentWhere(addIdentitySearchResidentViewModel);
            var predicate1 = SearchIdentityResidentWhere1(addIdentitySearchResidentViewModel);
            var result1= DbSet.Include(a => a.InfoRelationShips).ThenInclude(b => b.HouseInfo)
                           .Include(a => a.ResidentRelationShips).ThenInclude(b => b.ResidentIdentity)
                           .Where(predicate1)
                           .Select(
                                p => new AddIdentitySearchResidentMiddle()
                                {
                                    Id = p.Id
                                }
                                    )
                           .ToList()
                           .GroupBy(a => a.Id).Select(a => a.First()).ToList();

            var result = DbSet.Include(a => a.InfoRelationShips).ThenInclude(b => b.HouseInfo)
                           .Include(a => a.ResidentRelationShips).ThenInclude(b => b.ResidentIdentity)
                           .Where(predicate)
                           .OrderBy(a => a.AddTime)

                           //.FromSql("", addIdentitySearchResidentViewModel.IdentityName)
                           .Select(
                            p => new AddIdentitySearchResidentMiddle()
                            {
                                Id = p.Id,
                                Name = p.Name,
                                Phone = p.Phone,
                                IdNumber = p.IdNumber

                                //Area = p.InfoRelationShips.HouseInfo.Area,
                                //BuildingNo=p.InfoRelationShips.HouseInfo.BuildingNo,
                                //UnitNo= p.InfoRelationShips.HouseInfo.UnitNo,
                                //HouseNo = p.InfoRelationShips.HouseInfo.HouseNo,
                            }
                            ).ToList()
                            .Except(result1,new ScoreFormIDComparer())

            //var jk = (from a in result select a.Id).Except(from a in result1 select a.Id);
                           .ToList()
                           .GroupBy(a=>a.Id).Select(a=>a.First());//根据居民id去重
            //将结果放入内存中
            var aaaa = result.AsEnumerable()
                       .Skip(SkipNum)
                       .Take(addIdentitySearchResidentViewModel.pageViewModel.PageSize).ToList();

            //.Select(p => new ResidentMiddle()
            // {
            //    Id =p.Id,
            //    Address = p.Address,
            //    Company = p.Company,
            //    Education = p.Education,
            //    HouseInfo = p.InfoRelationShips.HouseInfo,
            //    ResidentIdentity = p.ResidentRelationShips.ResidentIdentity
            // }

            //).ToList();
            return aaaa;

            //    DbSet.Include(a => a.ResidentRelationShips).ThenInclude(a=>a.Select(b=>b.ResidentIdentity))
            //.Include(a => a.InfoRelationShips).ThenInclude(a => a.Select(b => b.HouseInfo));
        }

        private Expression<Func<ResidentInfo, bool>> SearchIdentityResidentWhere(AddIdentitySearchResidentViewModel addIdentitySearchResidentViewModel)
        {
            var predicate = WhereExtension.True<ResidentInfo>();//初始化where表达式
            //id
            if (addIdentitySearchResidentViewModel.Area != "")
            {
                predicate = predicate.And(p => p.InfoRelationShips.HouseInfo.Area.Contains(addIdentitySearchResidentViewModel.Area));
            }
            if (addIdentitySearchResidentViewModel.Name!="")
            {
                predicate = predicate.And(p => p.Name.Contains(addIdentitySearchResidentViewModel.Name));
            }
            //if (addIdentitySearchResidentViewModel.IdentityName != "")
            //{
            //    predicate = predicate.And(p => p.ResidentRelationShips.ResidentIdentity.IdentityName != (addIdentitySearchResidentViewModel.IdentityName));
            //}

            //predicate = predicate.And(p=>p.Id in from(select id from residentRelationShip where ResidentIdentityId != 'da6df0ea-ec42-47db-9eb3-5713f9f2c50b'));
            predicate = predicate.And(p => p.Status == "1");

            return predicate;
        }

        private Expression<Func<ResidentInfo, bool>> SearchIdentityResidentWhere1(AddIdentitySearchResidentViewModel addIdentitySearchResidentViewModel)
        {
            var predicate = WhereExtension.True<ResidentInfo>();//初始化where表达式
            
            if (addIdentitySearchResidentViewModel.IdentityName != "")
            {
                predicate = predicate.And(p => p.ResidentRelationShips.ResidentIdentity.IdentityName == (addIdentitySearchResidentViewModel.IdentityName));
            }

            //predicate = predicate.And(p=>p.Id in from(select id from residentRelationShip where ResidentIdentityId != 'da6df0ea-ec42-47db-9eb3-5713f9f2c50b'));
            predicate = predicate.And(p => p.Status == "1");

            return predicate;
        }

        public int getAddIdentitySearchResidentCount(AddIdentitySearchResidentViewModel addIdentitySearchResidentViewModel)
        {
            var predicate = SearchIdentityResidentWhere(addIdentitySearchResidentViewModel);
            var predicate1 = SearchIdentityResidentWhere1(addIdentitySearchResidentViewModel);
            var result1 = DbSet.Include(a => a.InfoRelationShips).ThenInclude(b => b.HouseInfo)
                           .Include(a => a.ResidentRelationShips).ThenInclude(b => b.ResidentIdentity)
                           .Where(predicate1)
                           .Select(
                                p => new AddIdentitySearchResidentMiddle()
                                {
                                    Id = p.Id
                                }
                                    )
                           .ToList()
                           .GroupBy(a => a.Id).Select(a => a.First()).ToList();

            var result = DbSet.Include(a => a.InfoRelationShips).ThenInclude(b => b.HouseInfo)
                           .Include(a => a.ResidentRelationShips).ThenInclude(b => b.ResidentIdentity)
                           .Where(predicate)
                           .Select(
                            p => new AddIdentitySearchResidentMiddle()
                            {
                                Id = p.Id,
                                Name = p.Name,
                                Phone = p.Phone,
                                IdNumber = p.IdNumber

                                
                            }
                            ).ToList()
                            .Except(result1, new ScoreFormIDComparer())

                           .ToList()
                           .GroupBy(a => a.Id).Select(a => a.First())//根据居民id去重
                           .Count();
            return result;
        }


        #endregion


        //查询身份时 查是该身份的居民

        #region
        public List<IdentitySearchResidentMiddle> getIdentitySearchResident(IdentitySearchResidentViewModel identitySearchResidentViewModel)
        {
            int SkipNum = identitySearchResidentViewModel.pageViewModel.CurrentPageNum * identitySearchResidentViewModel.pageViewModel.PageSize;
            var predicate = IdentitySearchResidentWhere(identitySearchResidentViewModel);
            var result = DbSet.Include(a => a.InfoRelationShips).ThenInclude(b => b.HouseInfo)
                           .Include(a => a.ResidentRelationShips).ThenInclude(b => b.ResidentIdentity)
                           .Where(predicate)
                           .OrderBy(a => a.AddTime)
                           .Select(
                                p => new IdentitySearchResidentMiddle()
                                {
                                    Id = p.Id,
                                    Name = p.Name,
                                    Phone = p.Phone,
                                    IdNumber = p.IdNumber,
                                    ResidentRelationShipId = p.ResidentRelationShips.Id
                                }
                                    )
                           .ToList()
                           .GroupBy(a => a.Id).Select(a => a.First()).ToList()
                           .Skip(SkipNum)
                           .Take(identitySearchResidentViewModel.pageViewModel.PageSize).ToList();
            return result;
        }

        private Expression<Func<ResidentInfo, bool>> IdentitySearchResidentWhere(IdentitySearchResidentViewModel identitySearchResidentViewModel)
        {
            var predicate = WhereExtension.True<ResidentInfo>();//初始化where表达式

            if (identitySearchResidentViewModel.IdentityName != "")
            {
                predicate = predicate.And(p => p.ResidentRelationShips.ResidentIdentity.IdentityName.Equals(identitySearchResidentViewModel.IdentityName));
            }
            if (identitySearchResidentViewModel.Area != "")
            {
                predicate = predicate.And(p => p.InfoRelationShips.HouseInfo.Area.Equals(identitySearchResidentViewModel.Area));
            }
            if (identitySearchResidentViewModel.Name != "")
            {
                predicate = predicate.And(p => p.Name.Equals(identitySearchResidentViewModel.Name));
            }



            return predicate;
        }
        public int getIdentitySearchResidentCount(IdentitySearchResidentViewModel identitySearchResidentViewModel)
        {
            var predicate = IdentitySearchResidentWhere(identitySearchResidentViewModel);
            var result = DbSet.Include(a => a.InfoRelationShips).ThenInclude(b => b.HouseInfo)
                           .Include(a => a.ResidentRelationShips).ThenInclude(b => b.ResidentIdentity)
                           .Where(predicate)
                           .Select(
                                p => new IdentitySearchResidentMiddle()
                                {
                                    Id = p.Id,
                                    Name = p.Name,
                                    Phone = p.Phone,
                                    IdNumber = p.IdNumber,
                                    ResidentRelationShipId = p.ResidentRelationShips.Id
                                }
                                    )
                           .ToList()
                           .GroupBy(a => a.Id).Select(a => a.First()).ToList()
                           .Count();
            return result;
        }
        #endregion

        /// <summary>
        /// 居民信息查询时  查询的信息
        /// </summary>
        /// <param name="addIdentitySearchResidentViewModel"></param>
        /// <returns></returns>
        #region
        public List<ResidentInfoSearchMiddle> getResidentInfoSearchResident(ResidentInfoSearchViewModel residentInfoSearchViewModel)
        {
            int SkipNum = residentInfoSearchViewModel.pageViewModel.CurrentPageNum * residentInfoSearchViewModel.pageViewModel.PageSize;
            var predicate = SearchResidentInfoWhere(residentInfoSearchViewModel);

            var result = DbSet.Include(a => a.InfoRelationShips).ThenInclude(b => b.HouseInfo)
                           .Include(a => a.ResidentRelationShips).ThenInclude(b => b.ResidentIdentity)
                           .Where(predicate)
                           .OrderBy(a => a.AddTime)

                           //.FromSql("", addIdentitySearchResidentViewModel.IdentityName)
                           .Select(
                            p => new ResidentInfoSearchMiddle()
                            {
                                Id = p.Id,
                                Name = p.Name,
                                Phone = p.Phone,
                                Area = p.InfoRelationShips.HouseInfo.Area,
                                BuildingNo = p.InfoRelationShips.HouseInfo.BuildingNo,
                                UnitNo = p.InfoRelationShips.HouseInfo.UnitNo,
                                HouseNo = p.InfoRelationShips.HouseInfo.HouseNo


                            }
                            )

                           .ToList();
                           //.GroupBy(a => a.Id).Select(a => a.First());//根据居民id去重

            //将结果放入内存中
            var aaaa = result
                       .Skip(SkipNum)
                       .Take(residentInfoSearchViewModel.pageViewModel.PageSize).ToList();

            
            return aaaa;

        }

        private Expression<Func<ResidentInfo, bool>> SearchResidentInfoWhere(ResidentInfoSearchViewModel residentInfoSearchViewModel)
        {
            var predicate = WhereExtension.True<ResidentInfo>();//初始化where表达式
            //姓名
            if (residentInfoSearchViewModel.Name !="")
            {
                predicate = predicate.And(p => p.Name.Contains(residentInfoSearchViewModel.Name));
            }
            //身份证号
            if (residentInfoSearchViewModel.IdNumber != "")
            {
                predicate = predicate.And(p => p.IdNumber.Equals(residentInfoSearchViewModel.IdNumber));
            }
            //性别
            if (residentInfoSearchViewModel.Gender != "")
            {
                predicate = predicate.And(p => p.Gender.Equals(residentInfoSearchViewModel.Gender));
            }
            //文化程度
            if (residentInfoSearchViewModel.Education != "")
            {
                predicate = predicate.And(p => p.Education.Equals(residentInfoSearchViewModel.Education));
            }
            //小区
            if (residentInfoSearchViewModel.Area != "")
            {
                predicate = predicate.And(p => p.InfoRelationShips.HouseInfo.Area.Equals (residentInfoSearchViewModel.Area));
            }
            //楼号
            if (residentInfoSearchViewModel.BuildingNo != 0)
            {
                predicate = predicate.And(p => p.InfoRelationShips.HouseInfo.BuildingNo.Equals(residentInfoSearchViewModel.BuildingNo));
            }
            //单元号
            if (residentInfoSearchViewModel.UnitNo != 0)
            {
                predicate = predicate.And(p => p.InfoRelationShips.HouseInfo.UnitNo.Equals(residentInfoSearchViewModel.UnitNo));

            }
            //门牌号
            if (residentInfoSearchViewModel.HouseNo != "")
            {
                predicate = predicate.And(p => p.InfoRelationShips.HouseInfo.HouseNo.Equals(residentInfoSearchViewModel.HouseNo));
            }
            //起始年龄
            if (residentInfoSearchViewModel.StartAge != 0)
            {

                predicate = predicate.And(p => Convert.ToInt32(DateTime.Now.Year.ToString()) - Convert.ToInt32(p.IdNumber.Substring(6, 4)) >= (residentInfoSearchViewModel.StartAge));
            }
            //结束年龄
            if (residentInfoSearchViewModel.EndAge != 0)
            {
                predicate = predicate.And(p => Convert.ToInt32(DateTime.Now.Year.ToString()) - Convert.ToInt32(p.IdNumber.Substring(6, 4)) <= (residentInfoSearchViewModel.EndAge));
            }
            //身份
            if (residentInfoSearchViewModel.IdentityName != "")
            {
                predicate = predicate.And(p => p.ResidentRelationShips.ResidentIdentity.IdentityName.Contains(residentInfoSearchViewModel.IdentityName));
            }
            //政治面貌
            if (residentInfoSearchViewModel.Politics != "")
            {
                predicate = predicate.And(p => p.Politics.Contains(residentInfoSearchViewModel.Politics));
            }

            if (residentInfoSearchViewModel.RelationWithHousehold == "租户")
            {
                predicate = predicate.And(p => p.InfoRelationShips.RelationWithHousehold == "租户");
            }
            if (residentInfoSearchViewModel.RelationWithHousehold == "居民")
            {
                predicate = predicate.And(p => p.InfoRelationShips.RelationWithHousehold != "租户");
            }

            return predicate;
        }

        public int getResidentInfoSearchResidentCount(ResidentInfoSearchViewModel residentInfoSearchViewModel)
        {
            var predicate = SearchResidentInfoWhere(residentInfoSearchViewModel);

            var result = DbSet.Include(a => a.InfoRelationShips).ThenInclude(b => b.HouseInfo)
                           .Include(a => a.ResidentRelationShips).ThenInclude(b => b.ResidentIdentity)
                           .Where(predicate)


                           //.FromSql("", addIdentitySearchResidentViewModel.IdentityName)
                           .Select(
                            p => new ResidentInfoSearchMiddle()
                            {
                                Id = p.Id,
                                Name = p.Name,
                                Phone = p.Phone,
                                Area = p.InfoRelationShips.HouseInfo.Area,
                                BuildingNo = p.InfoRelationShips.HouseInfo.BuildingNo,
                                UnitNo = p.InfoRelationShips.HouseInfo.UnitNo,
                                HouseNo = p.InfoRelationShips.HouseInfo.HouseNo


                            }
                            )

                           .ToList().Count();
            return result;
        }
        #endregion


        /// <summary>
        /// 根据具体房子信息查询
        /// </summary>
        /// <param name="byHouseInfoSearchResidentViewModel"></param>
        /// <returns></returns>
        #region
        public List<ByHouseInfoSearchResidentMiddle> getByHouseInfoSearchResident(ByHouseInfoSearchResidentViewModel byHouseInfoSearchResidentViewModel)
        {
            var predicate = ByHouseInfoSearchResidentWhere(byHouseInfoSearchResidentViewModel);
            var result = DbSet.Include(a => a.InfoRelationShips).ThenInclude(b => b.HouseInfo)
                           .Include(a => a.ResidentRelationShips).ThenInclude(b => b.ResidentIdentity)
                           .Where(predicate)


                           //.FromSql("", addIdentitySearchResidentViewModel.IdentityName)
                           .Select(
                            p => new ByHouseInfoSearchResidentMiddle()
                            {
                                Id = p.Id,
                                Name = p.Name,
                                Phone = p.Phone,
                                Minority=p.Minority,
                                Gender=p.Gender,
                                Married=p.Married,
                                Politics=p.Politics,
                                IdNumber=p.IdNumber,
                                Company=p.Company,
                                Address=p.Address,
                                Province=p.Province,
                                City=p.City,
                                County=p.County,
                                Register =p.Register,
                                Education=p.Education,
                                ReligiousBelief=p.ReligiousBelief,
                                Job=p.Job,
                                PhotoId=p.PhotoId,

                                InfoRelationShipId =p.InfoRelationShips.Id,
                                RelationWithHousehold =p.InfoRelationShips.RelationWithHousehold,
                               // HouseHolderIdNo = p.InfoRelationShips.ResidentInfo.IdNumber,
                                HouseHolderIdNo =p.InfoRelationShips.HouseInfo.HouseHolderIdNo,
                                Area = p.InfoRelationShips.HouseInfo.Area,
                                BuildingNo = p.InfoRelationShips.HouseInfo.BuildingNo,
                                UnitNo = p.InfoRelationShips.HouseInfo.UnitNo,
                                HouseNo = p.InfoRelationShips.HouseInfo.HouseNo


                            }
                            )

                           .ToList();

            return result;
        }
        private Expression<Func<ResidentInfo, bool>> ByHouseInfoSearchResidentWhere(ByHouseInfoSearchResidentViewModel byHouseInfoSearchResidentViewModel)
        {
            var predicate = WhereExtension.True<ResidentInfo>();//初始化where表达式
            //小区
            predicate = predicate.And(p => p.InfoRelationShips.HouseInfo.Area.Equals(byHouseInfoSearchResidentViewModel.Area));
            
            //楼号
            predicate = predicate.And(p => p.InfoRelationShips.HouseInfo.BuildingNo.Equals(byHouseInfoSearchResidentViewModel.BuildingNo));
            
            //单元号
            predicate = predicate.And(p => p.InfoRelationShips.HouseInfo.UnitNo.Equals(byHouseInfoSearchResidentViewModel.UnitNo));

            //门牌号
            predicate = predicate.And(p => p.InfoRelationShips.HouseInfo.HouseNo.Equals(byHouseInfoSearchResidentViewModel.HouseNo));

            predicate = predicate.And(p => p.Status == "1");

            return predicate;
        }
        

        #endregion





        /// <summary>
        /// 获取统计信息
        /// </summary>
        /// <param name="statisticsViewModel"></param>
        /// <returns></returns>
        #region
        public int getStatistics(StatisticsViewModel statisticsViewModel)
        {
            var predicate = SearchStatisticsWhere(statisticsViewModel);
            var result = DbSet.Include(a => a.InfoRelationShips).ThenInclude(b => b.HouseInfo)

                           .Where(predicate)

                           .ToList()
                           .GroupBy(a => a.Id).Select(a => a.First());
                           
            var aaa= result.Count();

            return aaa;


        }
     


        private Expression<Func<ResidentInfo, bool>> SearchStatisticsWhere(StatisticsViewModel statisticsViewModel)
        {
            var predicate = WhereExtension.True<ResidentInfo>();//初始化where表达式
           
            //小区名字
            if (statisticsViewModel.Name != null)
            {
                predicate = predicate.And(p => p.InfoRelationShips.HouseInfo.Area.Equals(statisticsViewModel.Name));
            }
            //性别
            if (statisticsViewModel.Gender != null)
            {
                predicate = predicate.And(p => p.Gender.Equals(statisticsViewModel.Gender));
            }
           
            //起始年龄
            if (statisticsViewModel.StartAge != 0)
            {

                predicate = predicate.And(p => Convert.ToInt32(DateTime.Now.Year.ToString()) - Convert.ToInt32(p.IdNumber.Substring(6, 4)) > (statisticsViewModel.StartAge));
            }
            //结束年龄
            if (statisticsViewModel.EndAge != 0)
            {
                predicate = predicate.And(p => Convert.ToInt32(DateTime.Now.Year.ToString()) - Convert.ToInt32(p.IdNumber.Substring(6, 4)) <= (statisticsViewModel.EndAge));
            }

            return predicate;
        }

    
        #endregion




    }
}
