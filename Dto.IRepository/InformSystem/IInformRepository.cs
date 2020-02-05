using Dtol.Dtol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.InformSystem.RequestViewModel;

namespace Dto.IRepository.InformSystem
{
    public interface IInformRepository : IRepository<Inform>
    {
        List<Inform> InformSerachByWhere(InformSearchViewModel informSearchViewModel);
        int InformSerachByWhereCount(InformSearchViewModel informSearchViewModel);

        

    }
}
