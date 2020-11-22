using l2g.Entities.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l2g.DL.Interfaces
{
    public interface IQuoteDL
    {
        bool AddQuote(GetQuote quote, int userId);
    }
}
