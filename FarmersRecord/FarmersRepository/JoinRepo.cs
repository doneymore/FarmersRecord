using FarmersRecord.FarmersRepository.IFarmer;
using FarmersRecord.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmersRecord.FarmersRepository
{
    public class JoinRepo : ITableJoin
    {
        private readonly AppDbContext _db;

        public JoinRepo(AppDbContext db )
        {
            this._db = db;
        }

        public ICollection<TableJoin> GetAllDbContent()
        {
            return _db.TableJoin.Include(a => a.UserModel).Include(a => a.FarmModel).ToList();
            //return _db.farmerModels.Include();           

        }

        public async Task<dynamic> GetDashBoardItems()
        {
            try
            {
                using (_db)
                {
                    ////var response = from a in _db.farmerModels
                    ////               join b in _db.UserModel on a.Id equals b.Id
                    ////               select new
                    ////               {
                    ////                   a,
                    ////                   b
                    ////               };
                    //var reponse2 = _db.UserModel.ToList().Join(_db.farmerModels.ToList(), um => um.Id, fm => fm.Id, (um, fm) => new 
                    //{
                    //     um,
                    //     fm

                    //}).ToList();

                    //return reponse2;

                    return new
                    {
                        userCount = _db.UserModel.ToList().Count(),
                        userList = _db.UserModel.ToList(),
                        farmerCount = _db.farmerModels.ToList().Count(),
                        farmerList = _db.farmerModels.ToList()
                    };

                    //using var ctx = new SqlConnection(_connectionString);
                    //var loginCheck = await ctx.QueryMultipleAsync<Users, EligibilityLog, EligibilityLog, LoanRepayment, Tenant, Loan>
                    //    (m1 => m1.isAdmin == true && m1.EmailAddress.Contains("@sterling.ng"),
                    //    m2 => m2.CRSearchStatusCode == 200, //success eligibility check
                    //    m3 => m3.CRSearchStatusCode != 200, //failed eligibilitycheck
                    //    m4 => m4.RepaymentStatusId == Convert.ToInt32(Helper.Enum.RepaymentStatus.Pending) && m4.RepaymentStatusId == Convert.ToInt32(Helper.Enum.RepaymentStatus.Completed),
                    //    m5 => !m5.isDeleted,
                    //    m6 => m6.LoanStatusId != 0);

                    //return new Response
                    //{
                    //    Data = new
                    //    {
                    //        tenantCount = loginCheck.Item5.AsList().Count(),
                    //        loanApplicationCount = loginCheck.Item6.AsList().Count(),
                    //        totalEligibilityCheckCount = loginCheck.Item2.AsList().Count() + loginCheck.Item3.AsList().Count(),
                    //        totalRepaymentCount = loginCheck.Item4.AsList().Count(),
                    //        adminCount = loginCheck.Item1.AsList().Count(),
                    //        notification = 0  //count all the audit items
                    //    },
                    //    ResponseCode = "00",
                    //    ResponseMessage = "Command(s) Completed Successfully",
                    //    Date = DateTime.Now
                    //};


                }
            }
            catch (Exception ex)
            {

                return ex;
            }
        }
    }
}
