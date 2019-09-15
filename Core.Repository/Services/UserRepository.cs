using Core.EntityLayer.Models;
using Core.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repository.Services
{
    public class UserRepository : IUserRepository
    {
        private UserManager<ApplicationUser> _userManager;
        public UserRepository(UserManager<ApplicationUser> userManager)
        {
            this._userManager = userManager;
        }
        public bool CheckPassword(ApplicationUser user, string password)
        {
            return _userManager.CheckPasswordAsync(user, password).Result;
        }

        public ApplicationUser FindByName(string username)
        {
            return _userManager.FindByNameAsync(username).Result;
        }
    }
}
