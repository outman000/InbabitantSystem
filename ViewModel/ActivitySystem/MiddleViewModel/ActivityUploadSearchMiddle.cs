using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.ActivitySystem.MiddleViewModel
{
    public class ActivityUploadSearchMiddle
    {
        /// <summary>
        /// 文件Id
        /// </summary>
        public Guid Id { get; set; } 
        /// <summary>
        /// 原始照片名称
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// 更改后照片名称
        /// </summary>
        public string PhysicsName { get; set; }
        /// <summary>
        /// 活动id -- 外键
        /// </summary>
        public Guid? FormId { get; set; }
        /// <summary>
        /// 状态 0-删除，1-有效
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddTime { get; set; }


        /// <summary>
        /// 路径
        /// </summary>
        public string FilePath { get; set; }
    }
}
