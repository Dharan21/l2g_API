using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l2g.Entities.BusinessEntities
{
    public class QuoteVM
    {
        [Key]
        public int QuoteId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int UserId { get; set; }
        public int CarId { get; set; }
        public string Carname { get; set; }
        public string Model { get; set; }
        public int Price { get; set; }
        public int MileageId { get; set; }
        public int MonthId { get; set; }
        public int Kilometer { get; set; }
        public int Months { get; set; }
    }
}
