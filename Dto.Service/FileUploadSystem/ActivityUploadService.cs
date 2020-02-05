using AutoMapper;
using Dto.IRepository.FileUploadSystem;
using Dto.IService.FileUploadSystem;
using Dtol.Dtol;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ViewModel.ActivitySystem.MiddleViewModel;

namespace Dto.Service.FileUploadSystem
{
    public class ActivityUploadService :IActivityUploadService
    {
        private readonly IActivityUploadRepository _activityUploadRepository;
        private readonly IMapper _IMapper;
        public ActivityUploadService(IActivityUploadRepository activityUploadRepository, IMapper mapper)
        {

            _activityUploadRepository = activityUploadRepository;
            _IMapper = mapper;
        }



        //改文件名
        public string fileRandomName(string fileRealname)
        {
            string RandName = "";
            string[] fileTail = fileRealname.Split('.');
            RandName = Guid.NewGuid() + "." + fileTail[fileTail.Length-1];
            return RandName;
        }

        //保存文件信息
        public FileUpload saveAttachInfo(string filename, string randomName)
        {
            Guid id = Guid.NewGuid();
            var file = new FileUpload
            {
                Id = id,
                FileName = filename,
                //FormId = new Guid(fileinfo["FormId"]),
                PhysicsName = randomName,
                AddTime = DateTime.Now,
                Status = "1",
                FilePath = @"../files/" + randomName,
            };
            _activityUploadRepository.Add(file);
            _activityUploadRepository.SaveChanges();
            return file;
        }

        //根据Id 查询附件
        public List<ActivityUploadSearchMiddle> getAttachInfo(Guid Id)
        {
            return _activityUploadRepository.getAttachInfo(Id);
        }
        //更新附件
        public int UpdateFile(FileUpload fileUpload)
        {
            _activityUploadRepository.Update(fileUpload);
            return _activityUploadRepository.SaveChanges();
        }
        //根据FormId 查询附件
        public List<ActivityUploadSearchMiddle> getAttachInfoByFormId(Guid FormId)
        {
            return _activityUploadRepository.getAttachInfoByFormId(FormId);
        }



    }
}
