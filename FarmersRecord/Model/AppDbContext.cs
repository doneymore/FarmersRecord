using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmersRecord.Model
{
    public class AppDbContext: IdentityDbContext<UserDetailsModel>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }
        public DbSet<FarmerModel> farmerModels { get; set; }
        public DbSet<LoginModel> LoginModel { get; set; }
        public DbSet<TableJoin> TableJoin { get; set; }
        public DbSet<UserModel> UserModel { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserModel>().HasData(
                new UserModel
                {
                    Id = 1,
                    FirstName = "Nigeria",
                    LastName = "NG",
                    Email = "doneymore@123.com",
                    Password = "12345",
                    ConfirmPassword = "12345"

                },
                  new UserModel
                  {
                      Id = 2,
                      FirstName = "Nigeria!",
                      LastName = "NG!",
                      Email = "doneymore@123.com!",
                      Password = "12345!",
                      ConfirmPassword = "12345!"

                  }
                   

                );

            
        }
    }
}
