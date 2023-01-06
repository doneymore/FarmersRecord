using FarmersRecord.FarmersRepository.IFarmer;
using FarmersRecord.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmersRecord.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLoginController : ControllerBase
    {
        private readonly IUserRepo _uRepo;
        public UserLoginController(IUserRepo urepo)
        {
            _uRepo = urepo;
        }
        [HttpPost("UserLogin"), AllowAnonymous]

        public async Task<IActionResult> UserSignUp([FromBody] UserModel userModel)
        {
            var result = await _uRepo.userLoginDe(userModel);
            if (result.Succeeded)
            {
                return Ok(result.Succeeded);
            };
            return Unauthorized();
        }
        
    }
}
