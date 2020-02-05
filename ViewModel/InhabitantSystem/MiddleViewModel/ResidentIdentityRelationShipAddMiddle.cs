using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ViewModel.InhabitantSystem.MiddleViewModel
{
    public class ResidentIdentityRelationShipAddMiddle
    {
        /// <summary>
        /// id
        /// </summary>
        
        //public Guid Id { get; set; }
        /// <summary>
        /// 人员信息Id
        /// </summary>
        public Guid? ResidentInfoId { get; set; }

        /// <summary>
        /// 身份Id
        /// </summary>
        public Guid? ResidentIdentityId { get; set; }
    }
}
