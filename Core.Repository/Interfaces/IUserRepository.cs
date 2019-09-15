using Core.EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repository.Interfaces
{
    public interface IUserRepository
    {
        ApplicationUser FindByName(string username);
        bool CheckPassword(ApplicationUser user, string password);
    }
}
