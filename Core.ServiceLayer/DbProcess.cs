using Core.EntityLayer.Context;
using Core.EntityLayer.Context.Seed;
using Core.EntityLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

using Microsoft.EntityFrameworkCore;
using System.Security;
namespace Core.ServiceLayer
{
    public class DbProcess
    {
        public static void CallSeed(IConfiguration configuration, IServiceProvider provider)
        { 
            SeedDatabase.Initialize(configuration,provider);
        }
      
    }
}
