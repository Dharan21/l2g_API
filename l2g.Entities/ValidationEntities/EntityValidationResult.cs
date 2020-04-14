using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l2g.Entities.ValidationEntities
{
    public class EntityValidationResult
    {
        public IList<ValidationResult> ValidationErrors { get; private set; }
        public bool HasError
        {
            get { return ValidationErrors.Count > 0; }
        }

        public EntityValidationResult(IList<ValidationResult> violations = null)
        {
            ValidationErrors = violations ?? new List<ValidationResult>();
        }
    }
}
