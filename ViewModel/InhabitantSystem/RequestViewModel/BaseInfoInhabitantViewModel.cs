﻿using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicVIewModel;

namespace ViewModel.InhabitantSystem.RequestViewModel
{
    public class BaseInfoInhabitantViewModel
    {
        /// <summary>
        /// 分页
        /// </summary>
        public PageViewModel pageViewModel { get; set; }
        BaseInfoInhabitantViewModel()
        {
            pageViewModel = new PageViewModel();
        }
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
        /// 身份证号
        /// </summary>
        public string IdNumber { get; set; }
        /// <summary>
        /// 小区名称
        /// </summary>
        public string Area { get; set; }
        /// <summary>
        /// 楼号
        /// </summary>
        public int? BuildingNo { get; set; }
        /// <summary>
        /// 单元号
        /// </summary>
        public int? UnitNo { get; set; }
        /// <summary>
        /// 门牌号
        /// </summary>
        public string HouseNo { get; set; }
        /// <summary>
        /// 身份名称
        /// </summary>
        public string IdentityName { get; set; }
        /// <summary>
        /// 起始年龄
        /// </summary>
        public int? StartAge { get; set; }
        /// <summary>
        /// 结束年龄
        /// </summary>
        public int? EndAge { get; set; }






    }
}
