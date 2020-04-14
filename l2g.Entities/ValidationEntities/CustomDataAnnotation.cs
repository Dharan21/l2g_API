using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l2g.Entities.ValidationEntities
{
    public class CustomDataAnnotation
    {
        public static EntityValidationResult ValidateEntity<T>(T entity)
        {
            return new EntityValidator<T>().Validate(entity);
        }
    }
}
