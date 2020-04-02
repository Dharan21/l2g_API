using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l2g.Entities.BusinessEntities
{
    public class GearboxVM
    {
        [Key]
        public int GearboxId { get; set; }
        public string GearboxType { get; set; }
    }
}
