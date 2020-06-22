using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Dto.IService.ActivitySystem;
using Dto.IService.FileUploadSystem;
using Dtol.Dtol;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using ViewModel.ActivitySystem.MiddleViewModel;
using ViewModel.ActivitySystem.RequestViewModel;
using ViewModel.ActivitySystem.ResponseViewModel;
using ViewModel.IViewModelFactory.ActivitySystem;

namespace Service.ActivitySystem.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityService _activityService;
        private readonly IActivityUploadService _activityUploadService;
        private readonly ILogger _ILogger;
        private readonly IActivityFactory _activityFactory;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="activityService"></param>
        /// <param name="logger"></param>
        /// <param name="activityFactory"></param>
        /// <param name="activityUploadService"></param>
        public ActivityController(IActivityService activityService, ILogger logger, IActivityFactory activityFactory, IActivityUploadService activityUploadService)
        {
            _activityService = activityService;
            _activityUploadService = activityUploadService;
            _ILogger = logger;
            _activityFactory = activityFactory;
        }
        /// <summary>
        /// 添加活动信息
        /// </summary>
        /// <param name="activityAddViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult<ActivityAddResViewModel> Manage_OpinionInfo_Add(ActivityAddViewModel activityAddViewModel)
        {
            activityAddViewModel.Id = Guid.NewGuid();
            int Activity_add_Count;
            Activity_add_Count = _activityService.AddActivity(activityAddViewModel);
            var opinionInfoAddResModel = _activityFactory.GetActivityAddResViewModel();

            //添加附件中的FormId
            foreach (FileUpload fileUpload in activityAddViewModel.Files)
            {
                fileUpload.FormId = activityAddViewModel.Id;
                _activityUploadService.UpdateFile(fileUpload);

            }

            if (Activity_add_Count > 0)
            {
                opinionInfoAddResModel.baseViewModel.IsSuccess = true;
                opinionInfoAddResModel.AddCount = Activity_add_Count;
                opinionInfoAddResModel.baseViewModel.Message = "添加成功";
                opinionInfoAddResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("增添活动信息成功");
                return Ok(opinionInfoAddResModel);
            }
            else
            {
                opinionInfoAddResModel.baseViewModel.IsSuccess = false;
                opinionInfoAddResModel.AddCount = 0;
                opinionInfoAddResModel.baseViewModel.Message = "添加失败";
                opinionInfoAddResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("增添活动信息失败");
                return BadRequest(opinionInfoAddResModel);
            }


        }

        /// <summary>
        /// 查询活动信息
        /// </summary>
        /// <param name="activitySearchViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult<ActivitySearchResViewModel> Manage_OpinionInfo_Search(ActivitySearchViewModel activitySearchViewModel)
        {
            var SearchResult = _activityService.Activity_Search(activitySearchViewModel);
            int total = _activityService.Activity_SearchCount(activitySearchViewModel);
            var Actionresult = _activityFactory.GetActivitySearchResViewModel();
            Actionresult.baseViewModel.IsSuccess = true;
            Actionresult.Data = SearchResult;
            Actionresult.TotalCount = total;
            Actionresult.baseViewModel.Message = "查询信息成功";
            Actionresult.baseViewModel.ResponseCode = 200;
            _ILogger.Information("查询信息成功");

            return Ok(Actionresult);

        }
        /// <summary>
        /// 根据Id查询活动信息
        /// </summary>
        /// <param name="activitySearchByIdViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult<ActivitySearchMiddle> Manage_OpinionInfo_SearchById(ActivitySearchByIdViewModel activitySearchByIdViewModel)
        {
            var SearchResult = _activityService.Activity_SearchById(activitySearchByIdViewModel);
            var Actionresult = _activityFactory.GetActivitySearchByIdResViewModel();
            Actionresult.baseViewModel.IsSuccess = true;
            Actionresult.Data = SearchResult;
            Actionresult.baseViewModel.Message = "查询信息成功";
            Actionresult.baseViewModel.ResponseCode = 200;
            _ILogger.Information("查询信息成功");

            return Ok(Actionresult);

        }


        /// <summary>
        /// 更新活动信息
        /// </summary>
        /// <param name="activityUpdateViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult<ActivityUpdateResViewModel> Manage_OpinionInfo_Update(ActivityUpdateViewModel activityUpdateViewModel)
        {
            int Activity_Update_Count;
            Activity_Update_Count = _activityService.Activity_Update(activityUpdateViewModel);
            var opinionInfoUpdateResModel = _activityFactory.GetActivityUpdateResViewModel();

            //添加附件中的FormId
            foreach (FileUpload fileUpload in activityUpdateViewModel.Files)
            {
                fileUpload.FormId = activityUpdateViewModel.Id;
                _activityUploadService.UpdateFile(fileUpload);

            }


            if (Activity_Update_Count > 0)
            {
                opinionInfoUpdateResModel.baseViewModel.IsSuccess = true;
                opinionInfoUpdateResModel.AddCount = Activity_Update_Count;
                opinionInfoUpdateResModel.baseViewModel.Message = "更改成功";
                opinionInfoUpdateResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("更改活动信息成功");
                return Ok(opinionInfoUpdateResModel);
            }
            else
            {
                opinionInfoUpdateResModel.baseViewModel.IsSuccess = false;
                opinionInfoUpdateResModel.AddCount = 0;
                opinionInfoUpdateResModel.baseViewModel.Message = "更改失败";
                opinionInfoUpdateResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("更改活动信息失败");
                return BadRequest(opinionInfoUpdateResModel);
            }
        }

        /// <summary>
        /// 上传附件
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult<FileUpload> Uploadfile(IFormFile files)
        {
            //var files = Request.Form.Files;

            if (files != null)
            {
                string filename = files.FileName;
                string [] a =filename.Split("\\");
                string name = a.Length>0 ? a[a.Length-1] : filename;


                string filePath = "";//上传文件的路径

                //if (files.Length == 0)
                //{
                //    throw new ArgumentException("找不到上传的文件");
                //}
                // full path to file in temp location

                string randomname = _activityUploadService.fileRandomName(name);
                filePath = @Directory.GetCurrentDirectory() + "\\files\\" + @randomname;
                if (files.Length > 0)
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        files.CopyTo(stream);
                    }
                }
                FileUpload fileUpload = _activityUploadService.saveAttachInfo(name, randomname);
                _ILogger.Information("图片上传成功");
                return Ok(fileUpload);

            }
            else {
                _ILogger.Information("图片上传失败");
                return BadRequest("请选择要上传的图片");
            }


            

        }
        /// <summary>
        /// 删除附件
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public string DeletefileById(FileUpload fileUpload)
        {
            //删除附件（更新附件状态）
            int a=_activityUploadService.UpdateFile(fileUpload);
            string kio = a > 0 ? "success" : "false";


            return kio;

            //查询附件
            //var SearchResult = new ActivityUploadSearchResViewModel();
            //var data = _activityUploadService.getAttachInfo(fileUpload.FormId);
            //SearchResult.Data = data;
            //return Ok(SearchResult);
        }


        /// <summary>
        /// 根据Id查询附件
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult<ActivityUploadSearchResViewModel> SearchfileById(Guid Id)
        {

            //改成根据id 查询一个附件


            var SearchResult = new ActivityUploadSearchResViewModel();
            var data = _activityUploadService.getAttachInfo(Id);
            SearchResult.Data=data;
            return Ok(SearchResult);
        }
        /// <summary>
        /// 根据FormId查询附件
        /// </summary>
        /// <param name="FormId"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult<ActivityUploadSearchResViewModel> SearchfileByActivityId(Guid FormId)
        {
            var SearchResult = new ActivityUploadSearchResViewModel();
            var data = _activityUploadService.getAttachInfoByFormId(FormId);
            SearchResult.Data = data;
            return Ok(SearchResult);
        }

    }
}