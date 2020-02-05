using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ViewModel.InhabitantSystem.MiddleViewModel
{
    public class ResidentIdentityMiddle
    {
        /// <summary>
        /// 身份id
        /// </summary>
        [Key]
        public Guid Id { get; set; } 
        /// <summary>
        /// 身份名称
        /// </summary>
        public string IdentityName { get; set; }
        /// <summary>
        /// 关系Id
        /// </summary>
        public Guid FormId { get; set; }
        /// <summary>
        /// 状态  0-删除 1-有效
        /// </summary>
        public string Status { get; set; }
    }
}
