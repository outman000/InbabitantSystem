using Dtol.Dtol;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.ActivitySystem.MiddleViewModel;

namespace Dto.IService.FileUploadSystem
{
    public interface IActivityUploadService
    {
        //保存文件信息
        FileUpload saveAttachInfo(string filename, string randomName);
        //根据附件 Id获取文件信息
        List<ActivityUploadSearchMiddle> getAttachInfo(Guid Id);
        //根据FormId 查询附件
        List<ActivityUploadSearchMiddle> getAttachInfoByFormId(Guid FormId);
        //改文件名
        string fileRandomName(string fileRealname);
        //删除文件信息(更新文件状态)
        int UpdateFile(FileUpload fileUpload);
        




    }
}
