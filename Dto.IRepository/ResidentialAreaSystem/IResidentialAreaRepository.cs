using Dtol.Dtol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.ResidentialAreaSystem.MiddleViewModel;
using ViewModel.ResidentialAreaSystem.RequestViewModel;
namespace Dto.IRepository.ResidentialAreaSystem
{
    public interface IResidentialAreaRepository : IRepository<ResidentialArea>
    {
        //属于实体自己 的方法
        List<ResidentialArea> AreaSerachByWhere(AreaSearchViewModel areaSearchViewModel);
        int AreaSerachByWhereCount(AreaSearchViewModel areaSearchViewModel);
    }


}
