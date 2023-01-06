using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmersRecord.Model
{
    public class FarmerModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; }
        public int MaritalStatus { get; set; }
        public string Comments { get; set; }
        public TableJoin Tablejoin { get; set; }
        //public ICollection<> { get; set; }
        //public DateTime DateCreated { get; set; }

    }
}
