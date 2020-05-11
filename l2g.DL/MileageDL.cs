using l2g.Entities.DataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l2g.DL
{
    public class MileageDL
    {
        public bool CheckMileageExists(int mileageId)
        {
            using (var db = new Lead2OrderGenerateDbEntities())
            {
                return db.l2g_tbl_Mileage.Any(x => x.MileageId == mileageId);
            }
        }
    }
}
