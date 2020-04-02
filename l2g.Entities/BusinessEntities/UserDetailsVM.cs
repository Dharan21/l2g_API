using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l2g.Entities.BusinessEntities
{
    public class UserDetailsVM
    {
        public int UserId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public System.DateTime DOB { get; set; }
        public string Contact { get; set; }
        public int HouseNo { get; set; }
        public string Street { get; set; }
        public string PIN { get; set; }
        public string Town { get; set; }
    }
}
