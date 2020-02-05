using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.InhabitantSystem.RequestViewModel
{
    public class StatisticsViewModel
    {
        /// <summary>
        /// 小区名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string Gender { get; set; }
        /// <summary>
        /// 起始年龄
        /// </summary>
        public int StartAge { get; set; }
        /// <summary>
        /// 结束年龄
        /// </summary>
        public int EndAge { get; set; }

        public StatisticsViewModel(int startAge, int endAge) {
            StartAge = startAge;
            EndAge = endAge;
        }
        public StatisticsViewModel(string gender) {
            Gender = gender;
        }

        public StatisticsViewModel()
        {
           
        }
    }
}
