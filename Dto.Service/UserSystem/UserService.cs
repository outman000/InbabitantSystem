using AutoMapper;
using Dto.IRepository.UserSystem;
using Dto.IService.UserSystem;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.UserSystem.RequestViewModel;

namespace Dto.Service.UserSystem
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _IMapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {

            _userRepository = userRepository;
            _IMapper = mapper;
        }

        /// <summary>
        /// 验证用户名和密码
        /// </summary>
        /// <param name="userSearchViewModel"></param>
        /// <returns></returns>
        public int User_Search(UserSearchViewModel userSearchViewModel)
        {
            return _userRepository.UserSerachByWhere(userSearchViewModel);
        }
    }
}
