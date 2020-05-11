using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using l2g.DL.Mapping;
using l2g.Entities.BusinessEntities;
using l2g.Entities.DataEntities;

namespace l2g.DL
{
    public class QuoteDL
    {
        public bool AddQuote(GetQuote quote, int userId)
        {
            l2g_tbl_Quote quoteEntity = MappingConfig.GetQuoteToDataEntity(quote);
            quoteEntity.UserId = userId;
            quoteEntity.CreatedDate = DateTime.Now;
            using (var db = new Lead2OrderGenerateDbEntities())
            {
                try
                {
                    db.l2g_tbl_Quote.Add(quoteEntity);
                    db.SaveChanges();
                    return true;
                }
                catch(Exception)
                {
                    return false;
                }
            }
        }
    }
}
