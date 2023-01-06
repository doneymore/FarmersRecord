using FarmersRecord.Dtos;
using FarmersRecord.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmersRecord.FarmersRepository
{
    public class FarmersRepo : IFarmersRepo
    {
        private readonly AppDbContext _db;
        public FarmersRepo(AppDbContext db)
        {
            _db = db;
        }

        public bool CreateFarmer(FarmerModel farms)
        {
            try
            {
                var farm = new FarmerModel()
                {
                    FirstName = farms.FirstName,
                    LastName = farms.LastName,
                    PhoneNumber = farms.PhoneNumber,
                    Comments = farms.Comments,
                    Age = farms.Age,
                    MaritalStatus = farms.MaritalStatus

                };
                _db.farmerModels.Add(farm);
                return Save();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public class AppResponse
        {
            public object Data { get; set; }
            public object Data2 { get; set; }
            public DateTime Date { get; set; }
            public string ResponseCode { get; set; }
            public string ResponseMessage { get; set; }
        }



        public async Task<AppResponse> CreateManyFarmer(List<FarmerModel> farms)
        {
            try
            {
                int failedCount = 0;
                foreach (var item in farms)
                {
                    var rex = _db.farmerModels.Where(a => a.PhoneNumber == item.PhoneNumber).FirstOrDefault();

                    if (rex == null)
                    {
                        //add record into db
                        _db.farmerModels.Add(new FarmerModel()
                        {
                            FirstName = item.FirstName.ToUpper(),
                            Age = item.Age,
                            Comments = item.Comments,
                            PhoneNumber = item.PhoneNumber,
                            LastName = item.LastName.ToUpper(),
                            MaritalStatus = item.MaritalStatus
                        });
                         await _db.SaveChangesAsync();
                                            }
                    else
                    {
                        failedCount += 1;
                    }
                }

                return new AppResponse
                {
                    ResponseCode = "00",
                    ResponseMessage = $"{farms.Count()} record(s) initiated, {farms.Count() - failedCount} Created Successfully and {failedCount} was omitted"
                }; 
                //lambda foreach
                //farms.ForEach(h =>
                //{

                //});
            }
            catch (Exception ex)
            {
                return new AppResponse
                {
                    ResponseCode = "99",
                    ResponseMessage = $"An error occured, reason: {ex.Message}"
                };
            }
        }
        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }
        public FarmerModel getFarmersById(int farmId)
        {
            return _db.farmerModels.FirstOrDefault(a => a.Id == farmId);
           
        }

        public ICollection<FarmerModel> getAllFarmRecord()
        {
            var getAll = _db.farmerModels.OrderBy(a => a.FirstName).ToList();
            return getAll;
        }

        public bool UpdateFarmerRecord(FarmerModel farm)
        {
            _db.farmerModels.Update(farm);
            return Save();

        }

        public bool DeleteFarmerRecord(int farmId)
        {
            var farms = new FarmerModel()
            {
                Id = farmId
            };
            _db.farmerModels.Remove(farms);
            return Save();

        }

        public bool FarmerExist(int farmId)
        {
            return _db.farmerModels.Any(a => a.Id == farmId);
        }

        public bool FarmExist(string firstName)
        {
            return _db.farmerModels.Any(a => a.FirstName == firstName);
        }




    }
}
