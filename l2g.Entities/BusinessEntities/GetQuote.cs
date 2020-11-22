using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l2g.Entities.BusinessEntities
{
    public class GetQuote
    {
        [Required(ErrorMessage = "CarId is required")]
        public int CarId { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public float Price { get; set; }

        [Required(ErrorMessage = "MileageId is required")]
        public int MileageId { get; set; }

        [Required(ErrorMessage = "MonthId is required")]
        public int MonthId { get; set; }
    }
}
