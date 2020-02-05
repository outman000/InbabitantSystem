using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.MaintainSystem.MiddleViewModel;

namespace Dto.IService.MaintainSystem
{
    public interface IPoliticalService
    {
        List<PoliticalSearchMiddle> GetAll();
    }
}
