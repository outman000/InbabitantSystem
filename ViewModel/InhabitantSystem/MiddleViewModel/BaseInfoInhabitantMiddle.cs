using Dtol.Dtol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.PublicVIewModel;

namespace ViewModel.InhabitantSystem.MiddleViewModel
{
    public class BaseInfoInhabitantMiddle
    {
        ///// <summary>
        ///// 分页
        ///// </summary>
        //public PageViewModel pageViewModel { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //public BaseInfoInhabitantMiddle()
        //{
        //    pageViewModel = new PageViewModel();
        //}
        /// <summary>
        /// 居民信息id
        /// </summary>
        public Guid? Id { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string Gender { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; set; }
        /// <summary>
        /// 小区名称
        /// </summary>
        public string Area { get; set; }
        /// <summary>
        /// 联系方式
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string IdNumber { get; set; }

    }
}
