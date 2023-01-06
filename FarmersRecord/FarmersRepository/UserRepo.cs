using FarmersRecord.FarmersRepository.IFarmer;
using FarmersRecord.Model;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmersRecord.FarmersRepository
{
    public class UserRepo : IUserRepo
    {
        private readonly UserManager<UserDetailsModel> _userManager;
        public UserRepo(UserManager<UserDetailsModel> usermanager)
        {
            _userManager = usermanager;
        }

        public async Task<IdentityResult> userLoginDe(UserModel usermodel)
        {
            var addUser = new UserDetailsModel()
            {
                FirstName = usermodel.FirstName,
                LastName = usermodel.LastName,
                Email = usermodel.Email,
                UserName = usermodel.Email
            };

           return await _userManager.CreateAsync(addUser, usermodel.Password);
        }
    }
}
