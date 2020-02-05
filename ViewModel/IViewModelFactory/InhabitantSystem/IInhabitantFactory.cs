using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.InhabitantSystem.RequestViewModel;
using ViewModel.InhabitantSystem.ResponseViewModel;

namespace ViewModel.IViewModelFactory.InhabitantSystem
{
    public interface IInhabitantFactory
    {
        /// <summary>
        /// 获取添加居民信息结果实例
        /// </summary>
        /// <returns></returns>
        InhabitantAddResViewModel GetInhabitantAddResViewModel();
        /// <summary>
        /// 获取查询居民结果
        /// </summary>
        /// <returns></returns>
        InhabitantSearchResModel GetInhabitantSearchResViewModel();
        /// <summary>
        /// 更新居民结果
        /// </summary>
        /// <returns></returns>
        InhabitantUpdateResViewModel GetInhabitantUpdateResViewModel();


        /// <summary>
        /// 获取添加身份结果实例
        /// </summary>
        /// <returns></returns>
        IdentityAddResViewModel GetIdentityAddResViewModel();
        /// <summary>
        /// 获取查询居民结果
        /// </summary>
        /// <returns></returns>
        IdentitySearchResViewModel GetIdentitySearchResViewModel();
        /// <summary>
        /// 更新居民结果
        /// </summary>
        /// <returns></returns>
        IdentityUpdateResViewModel GetIdentityUpdateResViewModel();

        /// <summary>
        /// 获取添加房子结果实例
        /// </summary>
        /// <returns></returns>
        HouseInfoAddResViewModel GetHouseInfoAddResViewModel();
        /// <summary>
        /// 获取查询房子结果
        /// </summary>
        /// <returns></returns>
        HouseInfoSearchResViewModel GetHouseInfoSearchResViewModel();
        /// <summary>
        /// 更新房子结果
        /// </summary>
        /// <returns></returns>
        HouseInfoUpdateResViewModel GetHouseInfoUpdateResViewModel();
        /// <summary>
        /// 添加居民和房子  关系信息 结果
        /// </summary>
        /// <returns></returns>
        HouseInfoRelationShipAddResViewModel GetHouseInfoRelationShipAddResViewModel();
        /// <summary>
        /// 删除居民和房子 关系结果
        /// </summary>
        /// <returns></returns>
        HouseInfoRelationShipDeleteResViewModel GetHouseInfoRelationShipDeleteResViewModel();
        /// <summary>
        /// 添加居民和身份  关系信息 结果
        /// </summary>
        /// <returns></returns>
        ResidentIdentityRelationShipAddResViewModel GetResidentIdentityRelationShipAddResViewModel();
        /// <summary>
        /// 删除居民和身份  关系信息 结果
        /// </summary>
        /// <returns></returns>
        ResidentIdentityRelationShipDeleteResViewModel GetResidentIdentityRelationShipDeleteResViewModel();
        /// <summary>
        /// 查询添加身份时 查询不是该身份的居民信息 结果
        /// </summary>
        /// <returns></returns>
        AddIdentitySearchResidentResViewModel GetAddIdentitySearchResidentResViewModel();
        /// <summary>
        /// 查询添加身份时 查询是该身份的居民信息 结果
        /// </summary>
        /// <returns></returns>
        IdentitySearchResidentResViewModel GetIdentitySearchResidentResViewModel();
        /// <summary>
        /// 统计每个小区人数 返回结果
        /// </summary>
        /// <returns></returns>
        AreaPopulationStatisticsResViewModel GetAreaPopulationStatisticsResViewModel();
        /// <summary>
        /// 统计不同年龄段人数 返回结果
        /// </summary>
        /// <returns></returns>
        AgeStatisticsResViewModel GetAgeStatisticsResViewModel();
        /// <summary>
        /// 统计不同性别人数 返回结果
        /// </summary>
        /// <returns></returns>
        GenderStatisticsResViewModel GetGenderStatisticsResViewModel();
        /// <summary>
        /// 添加居民和房子 结果 
        /// </summary>
        InhabitantAndHouseInfoAddResViewModel GetInhabitantAndHouseInfoAddResViewModel();

        /// <summary>
        /// 查询党员的居民信息
        /// </summary>
        /// <returns></returns>
        PartyResidentSearchResViewModel GetPartyResidentSearchResViewModel();
        /// <summary>
        /// 根据id查询党员的居民信息
        /// </summary>
        /// <returns></returns>
        PartyResidentByIdSearchResViewModel GetPartyResidentByIdSearchResViewModel();
        /// <summary>
        /// 添加党员信息
        /// </summary>
        /// <returns></returns>
        PartyInfoAddResViewModel GetPartyInfoAddResViewModel();
        /// <summary>
        /// 更新党员信息
        /// </summary>
        /// <returns></returns>
        PartyInfoUpdateResViewModel GetPartyInfoUpdateResViewModel();




        /// <summary>
        /// 根据 房屋 身份 居民信息 查询
        /// </summary>
        /// <returns></returns>
        BaseInfoInhabitantsResViewModel GetBaseInfoInhabitantsResViewModel();

        ResidentInfoSearchResViewModel GetResidentInfoSearchResViewModel();

        ByHouseInfoSearchResidentResViewModel GetByHouseInfoSearchResidentResViewModel();

        /// <summary>
        /// 查询未成年人信息
        /// </summary>
        /// <returns></returns>
        UnderAgeSearchResViewModel GetUnderAgeSearchResViewModel();
        /// <summary>
        /// 查询适龄人员信息
        /// </summary>
        /// <returns></returns>
        RightAgeSearchResViewModel GetRightAgeSearchResViewModel();

    }
}
