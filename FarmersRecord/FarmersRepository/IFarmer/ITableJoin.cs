using FarmersRecord.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmersRecord.FarmersRepository.IFarmer
{
   public interface ITableJoin
    {
        ICollection<TableJoin> GetAllDbContent();
        Task<dynamic> GetDashBoardItems();
    }
}
