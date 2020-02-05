using Dtol.Dtol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.ActivitySystem.MiddleViewModel;

namespace Dto.IRepository.FileUploadSystem
{
    public interface IActivityUploadRepository : IRepository<FileUpload>
    {
        /// <summary>
        /// 根据Id查附件
        /// </summary>
        /// <param name="FormId"></param>
        /// <returns></returns>
        List<ActivityUploadSearchMiddle> getAttachInfo(Guid Id);

        /// <summary>
        /// 根据FormId查附件
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        List<ActivityUploadSearchMiddle> getAttachInfoByFormId(Guid Id);

    }
}
