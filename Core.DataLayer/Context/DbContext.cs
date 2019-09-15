using Core.EntityLayer.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.EntityLayer.Context
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Log> Logs { set; get; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //builder.Entity<ApplicationUser>().ToTable("user");
            //builder.Entity<IdentityRole>().ToTable("role");
            //builder.Entity<IdentityUserRole>().ToTable("userrole");
            //builder.Entity<IdentityUserClaim>().ToTable("userclaim");
            //builder.Entity<IdentityUserLogin>().ToTable("userlogin");
        }
    }
}
