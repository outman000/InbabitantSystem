using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dtol.Dtol
{
    public class FileUpload
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
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
