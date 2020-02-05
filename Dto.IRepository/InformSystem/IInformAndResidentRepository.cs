using Dtol.Dtol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.InformSystem.RequestViewModel;

namespace Dto.IRepository.InformSystem
{
    public interface IInformAndResidentRepository : IRepository<InformAndResident>
    {
        void AddInformAndResident(List<InformAndResident> obj);

        List<InformAndResident> InformAndResidentSerachByIdWhere(InformSearchByIdViewModel informSearchByIdViewModel);
    }
}

