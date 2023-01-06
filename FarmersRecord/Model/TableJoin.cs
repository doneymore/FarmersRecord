using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmersRecord.Model
{
    public class TableJoin
    {
        public int Id { get; set; }
        public List<FarmerModel> FarmModel { get; set; }
        public List<UserModel> UserModel { get; set; }
    }
}
