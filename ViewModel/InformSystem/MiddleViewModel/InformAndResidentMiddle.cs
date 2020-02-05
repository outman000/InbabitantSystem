using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.InformSystem.MiddleViewModel
{
    public class InformAndResidentMiddle
    {
        /// <summary>
        /// id
        /// </summary>
        //public Guid Id { get; set; }
        /// <summary>
        /// 通知Id
        /// </summary>
        public Guid? InformId { get; set; }
        /// <summary>
        /// 居民Id
        /// </summary>
        public Guid? residentInfoId { get; set; }
        /// <summary>
        /// 居民电话
        /// </summary>
        public string phone { get; set; }
    }
}
