using FarmersRecord.Model;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmersRecord.FarmersRepository.IFarmer
{
    public interface IUserRepo
    {
        Task<IdentityResult> userLoginDe(UserModel usermodel);
    };
}
