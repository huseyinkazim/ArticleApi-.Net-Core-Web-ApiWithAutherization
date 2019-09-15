using Core.DtoLayer.Dto;
using Core.EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ServiceLayer.Interfaces
{
   public interface IUserService
    {
         UserDto FindByName(string username);
         bool CheckPassword(UserDto user, string password);
    }
}
