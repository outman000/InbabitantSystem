using Dtol.Dtol;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dto.IRepository.MaintainSystem
{
    public interface ICityRepository : IRepository<City>
    {
        List<City> GetAllCity();
        List<City> CitySerachByFormId(Guid FormId);
    }
}
