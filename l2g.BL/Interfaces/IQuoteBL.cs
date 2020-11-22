using l2g.Entities.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l2g.BL.Interfaces
{
    public interface IQuoteBL
    {
        ErrorResponseVM ValidateGetQuote(GetQuote quote);
        bool AddQuote(GetQuote quote, string username);
    }
}
