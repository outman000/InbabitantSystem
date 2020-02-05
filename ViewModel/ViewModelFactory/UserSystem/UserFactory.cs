using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.IViewModelFactory.UserSystem;
using ViewModel.UserSystem.ResponseViewModel;

namespace ViewModel.ViewModelFactory.UserSystem
{
    public class UserFactory : IUserFactory
    {
        public UserSearchResViewModel GetUserSearchResViewModel()
        {
            return new UserSearchResViewModel();
        }
    }
}
