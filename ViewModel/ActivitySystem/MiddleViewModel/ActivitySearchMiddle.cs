using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.ActivitySystem.MiddleViewModel
{
    public class ActivitySearchMiddle
    {
        /// <summary>
        /// id
        /// </summary>
        public Guid Id { get; set; }
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 活动主题
        /// </summary>
        public string Theme { get; set; }
        /// <summary>
        /// 活动形式
        /// </summary>
        public string ActivityForm { get; set; }
        /// <summary>
        /// 起始时间
        /// </summary>
        public DateTime? StartTime { get; set; }
        /// <summary>
        /// 活动地点
        /// </summary>
        public string Place { get; set; }
        /// <summary>
        /// 目标人群
        /// </summary>
        public string TargetPeople { get; set; }
        /// <summary>
        /// 录入人
        /// </summary>
        public string Recorder { get; set; }
        /// <summary>
        /// 参与人数
        /// </summary>
        public int? participantsNumber { get; set; }
        /// <summary>
        /// 受益人数
        /// </summary>
        public int? BeneficiaryNumber { get; set; }
        /// <summary>
        /// 活动记录
        /// </summary>
        public string ActivityRecord { get; set; }
        /// <summary>
        /// 状态  0-删除 1-有效
        /// </summary>
        public string Status { get; set; }
    }
}
