using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l2g.Entities.BusinessEntities
{
    public class Error
    {
        public string ErrorMessage { get; set; }
        public string Property { get; set; }
    }
    public class ErrorResponseVM
    {
        public List<Error> Errors { get; set; } = new List<Error>();
        public bool IsValid { get { return Errors.Count == 0; } }
    }
}
