using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.UserSystem.RequestViewModel;

namespace Dto.IService.UserSystem
{
    public interface IUserService
    {
        int User_Search(UserSearchViewModel userSearchViewModel);
    }
}
