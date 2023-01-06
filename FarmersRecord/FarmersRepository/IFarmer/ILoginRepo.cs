using FarmersRecord.Dtos;
using System.Threading.Tasks;

namespace FarmersRecord.FarmersRepository
{
    public interface ILoginRepo
    {
        Task<LoginRepo.AppResponse> LoginUser(LoginDto login);
    }
}