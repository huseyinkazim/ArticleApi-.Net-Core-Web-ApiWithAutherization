using Core.DtoLayer.Dto;
using Core.EntityLayer.Models;
using Core.Repository.Interfaces;
using Core.ServiceLayer.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using Core.ServiceLayer.Core;
namespace Core.ServiceLayer.Services
{
    public class UserService : IUserService
    { 
        private IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }
        public bool CheckPassword(UserDto user, string password)
        {
            var model = _userRepository.FindByName(user.UserName);
            return _userRepository.CheckPassword(model, password);
        }

        public UserDto FindByName(string username)
        {
            var model = _userRepository.FindByName(username);
            return Converter.MapTo<ApplicationUser, UserDto>(model);
        }
    }
}
