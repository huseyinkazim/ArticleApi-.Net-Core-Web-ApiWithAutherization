using Core.EntityLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.EntityLayer.Context.Seed
{
    public class SeedDatabase
    {
        public static void Initialize(IConfiguration configuration, IServiceProvider provider)
        {
            var context = provider.GetRequiredService<AppDbContext>();
            var usermanager = provider.GetRequiredService<UserManager<ApplicationUser>>();

            var isCreated=context.Database.EnsureCreated();

            if (!context.Users.Any())
            {
                ApplicationUser defaultUser = new ApplicationUser
                {
                    Email="default@contoso.com",
                    SecurityStamp=Guid.NewGuid().ToString(),
                    UserName= configuration["Contoso:DefaultUserName"]
                };
                 usermanager.CreateAsync(defaultUser, configuration["Contoso:DefaultPassword"]);
            }
            if (!context.Articles.Any())
            {
                Article defaultArticle = new Article
                {
                    IsActive = true,
                    Content = "Bu bir test makalesidir.Contoso için yapılmıştır.",
                    Title = "Contoso Web Api .Net Core",
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now
                };
                context.Articles.Add(defaultArticle);
                context.SaveChangesAsync();
            }

        }
    }
}
