using FarmersRecord.Dtos;
using FarmersRecord.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using static FarmersRecord.FarmersRepository.FarmersRepo;

namespace FarmersRecord.FarmersRepository
{
    public interface IFarmersRepo
    {
        bool CreateFarmer(FarmerModel farms);
        Task<AppResponse> CreateManyFarmer(List<FarmerModel> farms);
        bool DeleteFarmerRecord(int farmId);
        bool FarmerExist(int farmId);
        bool FarmExist(string firstName);
        ICollection<FarmerModel> getAllFarmRecord();
        FarmerModel getFarmersById(int farmId);
        bool Save();
        bool UpdateFarmerRecord(FarmerModel farm);
        //bool CreateManyFarmer(List<FarmerDto> farms);
    }
}