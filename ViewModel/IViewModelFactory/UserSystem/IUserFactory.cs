using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.UserSystem.ResponseViewModel;

namespace ViewModel.IViewModelFactory.UserSystem
{
    public interface IUserFactory
    {

        UserSearchResViewModel GetUserSearchResViewModel();
    }
}
