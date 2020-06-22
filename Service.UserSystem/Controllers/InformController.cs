using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Dto.IService.InformSystem;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using ViewModel.InformSystem.MiddleViewModel;
using ViewModel.InformSystem.RequestViewModel;
using ViewModel.InformSystem.ResponseViewModel;
using ViewModel.IViewModelFactory.InformSystem;

namespace Service.InformSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class InformController : ControllerBase
    {
        private readonly IInformService _informService;
        private readonly ILogger _ILogger;
        private readonly IInformFactory _informFactory;
        public InformController(IInformService informService, ILogger logger, IInformFactory informFactory)
        {
            _informService = informService;
            _ILogger = logger;
            _informFactory = informFactory;
        }

        /// <summary>
        /// 添加通知信息
        /// </summary>
        /// <param name="informAddViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult<InformAddResViewModel> Manage_OpinionInfo_Add(InformAddViewModel informAddViewModel)
        {
            //int Inform_add_Count;
            InformAddResViewModel  aa= _informService.AddInform(informAddViewModel);
            var opinionInfoAddResModel = _informFactory.GetInformAddResViewModel();
            if (aa.AddCount > 0)
            {
                opinionInfoAddResModel.Id = aa.Id;
                opinionInfoAddResModel.baseViewModel.IsSuccess = true;
                opinionInfoAddResModel.AddCount = aa.AddCount;
                opinionInfoAddResModel.baseViewModel.Message = "添加成功";
                opinionInfoAddResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("增添通知信息成功");
                return Ok(opinionInfoAddResModel);
            }
            else
            {
                opinionInfoAddResModel.baseViewModel.IsSuccess = false;
                opinionInfoAddResModel.AddCount = 0;
                opinionInfoAddResModel.baseViewModel.Message = "添加失败";
                opinionInfoAddResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("增添通知信息失败");
                return BadRequest(opinionInfoAddResModel);
            }
        }

        /// <summary>
        /// 添加通知和居民的关系信息
        /// </summary>
        /// <param name="informAndResidentViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult<InformAddResViewModel> Manage_OpinionInfo_AddInformAndResident(InformAndResidentViewModel informAndResidentViewModel)
        {
            int InformAndResident_add_Count;
            int Inform_Update_Count;
            InformAndResident_add_Count = _informService.AddInformAndResident(informAndResidentViewModel);
            Inform_Update_Count = _informService.UpdateInform(informAndResidentViewModel.informUpdateViewModel);
            //短信内容
            string content = informAndResidentViewModel.content;
            //发送短信
            foreach (InformAndResidentMiddle informAndResidentMiddle  in informAndResidentViewModel.informAndResidentMiddles)
            {
                string telphone = informAndResidentMiddle.phone;
                SendMessage(telphone, content);
            }

            var opinionInformAndResidentAddResModel = _informFactory.GetInformAndResidentResViewModel();
            if (InformAndResident_add_Count > 0)
            {
                opinionInformAndResidentAddResModel.baseViewModel.IsSuccess = true;
                opinionInformAndResidentAddResModel.AddCount = InformAndResident_add_Count;
                opinionInformAndResidentAddResModel.baseViewModel.Message = "添加成功";
                opinionInformAndResidentAddResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("增添关系信息成功");
                return Ok(opinionInformAndResidentAddResModel);
            }
            else
            {
                opinionInformAndResidentAddResModel.baseViewModel.IsSuccess = false;
                opinionInformAndResidentAddResModel.AddCount = 0;
                opinionInformAndResidentAddResModel.baseViewModel.Message = "添加失败";
                opinionInformAndResidentAddResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("增添关系信息失败");
                return BadRequest(opinionInformAndResidentAddResModel);
            }
        }

        /// <summary>
        /// 查询通知信息
        /// </summary>
        /// <param name="informSearchViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult<InformSearchResViewModel> Manage_OpinionInfo_Search(InformSearchViewModel informSearchViewModel)
        {
            var SearchResult = _informService.Inform_Search(informSearchViewModel);
            int total = _informService.Inform_SearchCount(informSearchViewModel);
            var Actionresult = _informFactory.GetInformSearchResViewModel();
            Actionresult.baseViewModel.IsSuccess = true;
            Actionresult.Data = SearchResult;
            Actionresult.TotalCount = total;
            Actionresult.baseViewModel.Message = "查询信息成功";
            Actionresult.baseViewModel.ResponseCode = 200;
            _ILogger.Information("查询信息成功");

            return Ok(Actionresult);

        }
        /// <summary>
        /// 根据ID查询通知信息
        /// </summary>
        /// <param name="informSearchByIdViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult<InformSearchByIdResViewModel> Manage_OpinionInfo_Search_ById(InformSearchByIdViewModel informSearchByIdViewModel)
        {
            var SearchResult = _informService.Inform_Search_ById(informSearchByIdViewModel);
            var Actionresult = _informFactory.GetInformSearchByIdResViewModel();
            Actionresult.baseViewModel.IsSuccess = true;
            Actionresult.Data = SearchResult;
            Actionresult.baseViewModel.Message = "查询信息成功";
            Actionresult.baseViewModel.ResponseCode = 200;
            _ILogger.Information("查询信息成功");

            return Ok(Actionresult);

        }
        /// <summary>
        /// 更新通知信息
        /// </summary>
        /// <param name="informUpdateViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult<InformUpdateResViewModel> Manage_OpinionInfo_Update(InformUpdateViewModel informUpdateViewModel)
        {
            int Inform_Update_Count;
            Inform_Update_Count = _informService.UpdateInform(informUpdateViewModel);
            var Actionresult = _informFactory.GetInformUpdateResViewModel();
            if (Inform_Update_Count > 0)
            {
                Actionresult.baseViewModel.IsSuccess = true;
                Actionresult.UpdateCount = Inform_Update_Count;
                Actionresult.baseViewModel.Message = "更改成功";
                Actionresult.baseViewModel.ResponseCode = 200;
                _ILogger.Information("更改通知信息成功");
                return Ok(Actionresult);
            }
            else
            {
                Actionresult.baseViewModel.IsSuccess = false;
                Actionresult.UpdateCount = 0;
                Actionresult.baseViewModel.Message = "更改失败";
                Actionresult.baseViewModel.ResponseCode = 400;
                _ILogger.Information("更改通知信息失败");
                return BadRequest(Actionresult);
            }

            

        }


        /// <summary>
        /// 短信
        /// </summary>
        /// <param name="telphone"></param>
        /// <param name="contcent"></param>
        [Authorize]
        private void SendMessage(string telphone,string contcent)
        {
            
            var url = "http://172.30.10.242/MessageService.asmx/SendMessage?op=SendMessage&telephone="+ telphone + "&context="+ contcent + "&unit=";
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.Method = "GET";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            string retString = reader.ReadToEnd();

        }

       

















    }
}