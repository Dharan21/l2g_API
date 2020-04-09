using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l2g.Entities.BusinessEntities
{
    public class Error
    {
        public string message { get; set; }
        public string property { get; set; }
    }
    public class ErrorResponseVM
    {
        public List<Error> errors { get; set; } = new List<Error>();
        public bool isValid { get; set; }
        public bool isSuccess { get; set; }
        public bool isInternalServerError { get; set; }
    }
}
