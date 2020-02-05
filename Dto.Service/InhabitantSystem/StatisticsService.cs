using AutoMapper;
using Dto.IRepository.InhabitantSystem;
using Dto.IService.InhabitantSystem;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.InhabitantSystem.MiddleViewModel;
using ViewModel.InhabitantSystem.RequestViewModel;

namespace Dto.Service.InhabitantSystem
{
    public class StatisticsService : IStatisticsService
    {

        private readonly IBaseInfoInhabitantsRepository _baseInfoInhabitantsRepository;
        private readonly IMapper _IMapper;

        public StatisticsService(IBaseInfoInhabitantsRepository baseInfoInhabitantsRepository, IMapper mapper)
        {
            _baseInfoInhabitantsRepository = baseInfoInhabitantsRepository;
            _IMapper = mapper;
        }

        /// <summary>
        /// 获取每个小区人数
        /// </summary>
        /// <returns></returns>
        public List<AreaPopulationStatisticsMiddle> GetAreaPopulation(List<StatisticsViewModel> statisticsViewModel)
        {
            List<AreaPopulationStatisticsMiddle> areaPopulationStatisticsMiddles = new List<AreaPopulationStatisticsMiddle>();
            foreach (StatisticsViewModel model in statisticsViewModel) {

                int count = _baseInfoInhabitantsRepository.getStatistics(model);
                var AreaPopulation = new AreaPopulationStatisticsMiddle();
                AreaPopulation.Name = model.Name;
                AreaPopulation.count = count;
                areaPopulationStatisticsMiddles.Add(AreaPopulation);


            }

            return areaPopulationStatisticsMiddles;
        }
        /// <summary>
        /// 获取年龄段人数
        /// </summary>
        /// <returns></returns>
        public List<AgeStatisticsMiddle> GetAgeCount()
        {
            List<AgeStatisticsMiddle> AgeStatisticsMiddles = new List<AgeStatisticsMiddle>();
            List<StatisticsViewModel> Age = new List<StatisticsViewModel>();
            Age.Add(new StatisticsViewModel(1,10)); Age.Add(new StatisticsViewModel(10, 20)); Age.Add(new StatisticsViewModel(20, 30)); Age.Add(new StatisticsViewModel(30, 40)); Age.Add(new StatisticsViewModel(40, 50));
            Age.Add(new StatisticsViewModel(50, 60)); Age.Add(new StatisticsViewModel(60, 70)); Age.Add(new StatisticsViewModel(70, 80)); Age.Add(new StatisticsViewModel(80, 90)); Age.Add(new StatisticsViewModel(90, 100));
            foreach (StatisticsViewModel model in Age) {
                int count = _baseInfoInhabitantsRepository.getStatistics(model);
                var AgeResult = new AgeStatisticsMiddle();
                AgeResult.Age = model.StartAge.ToString() + "-" + model.EndAge.ToString();
                AgeResult.count = count;
                AgeStatisticsMiddles.Add(AgeResult);
            }

            return AgeStatisticsMiddles;
        }
        /// <summary>
        /// 获取性别人数
        /// </summary>
        /// <returns></returns>
        public List<GenderStatisticsMiddle> GetGenderCount()
        {
            List<GenderStatisticsMiddle> GenderStatisticsMiddles = new List<GenderStatisticsMiddle>();
            List<StatisticsViewModel> Gender = new List<StatisticsViewModel>();
            Gender.Add(new StatisticsViewModel("男"));
            Gender.Add(new StatisticsViewModel("女"));
            foreach (StatisticsViewModel model in Gender) {
                int count = _baseInfoInhabitantsRepository.getStatistics(model);
                var GenderResult = new GenderStatisticsMiddle();
                GenderResult.Gender = model.Gender;
                GenderResult.Count = count;
                GenderStatisticsMiddles.Add(GenderResult);

            }

            return GenderStatisticsMiddles;
        }
    }
}
