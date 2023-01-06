using FarmersRecord.Dtos;
using FarmersRecord.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmersRecord.FarmersRepository
{
    public class LoginRepo : ILoginRepo
    {
        public readonly AppDbContext _db;
        public LoginRepo(AppDbContext db)
        {
            _db = db;
        }
        public class AppResponse
        {
            public object Data { get; set; }
            public object Data2 { get; set; }
            public DateTime Date { get; set; }
            public string ResponseCode { get; set; }
            public string ResponseMessage { get; set; }
        }


        public async Task<AppResponse> LoginUser(LoginDto login)
        {
            var rex = await _db.LoginModel.Where(a => a.Email == login.Email && a.Password == login.Password).FirstOrDefaultAsync();
            if (rex == null)
            {
                return new AppResponse
                {
                    ResponseCode = "90",
                    ResponseMessage = "Get Your Email and Password Correctly"
                };
            }
            else
            {
                return new AppResponse
                {
                    ResponseCode = "",
                    ResponseMessage = "Login Successfully",
                    Data = new
                    {
                        token = "",
                        tokenLifeSpan = ""
                    }
                };
            }

        }
    }
}
