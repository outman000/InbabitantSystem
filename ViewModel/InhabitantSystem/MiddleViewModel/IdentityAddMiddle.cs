using Dtol.Dtol;
using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.InhabitantSystem.MiddleViewModel
{
    public class IdentityAddMiddle
    {
        /// <summary>
        /// 身份id
        /// </summary>
        
        //public Guid Id { get; set; } 
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
        ///// <summary>
        ///// 入党时间
        ///// </summary>
        //public DateTime? JoinPartyTime { get; set; }
        ///// <summary>
        ///// 党内职务
        ///// </summary>
        //public string PartyJob { get; set; }
        ///// <summary>
        ///// 党的备注
        ///// </summary>
        //public string PartyRemarks { get; set; }

    }
}
