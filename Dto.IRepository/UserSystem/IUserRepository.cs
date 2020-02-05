using Dtol.Dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.UserSystem.RequestViewModel;

namespace Dto.IRepository.UserSystem
{
    public interface IUserRepository : IRepository<UserInfo>
    {
        //查询
        int UserSerachByWhere(UserSearchViewModel userSearchViewModel);
    }
}
