﻿using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicVIewModel;

namespace ViewModel.InhabitantSystem.ResponseViewModel
{
    public class HouseInfoRelationShipDeleteResViewModel
    {
        /// <summary>
        /// 基础返回结果构造方法
        /// </summary>
        public HouseInfoRelationShipDeleteResViewModel()
        {
            baseViewModel = new BaseViewModel();

        }
        /// <summary>
        /// 删除成功的行数
        /// </summary>
        public int AddCount;
        /// <summary>
        /// 基础返回结果
        /// </summary>
        public BaseViewModel baseViewModel;
    }
}
