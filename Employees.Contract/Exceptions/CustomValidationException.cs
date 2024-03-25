using Employees.Contract.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Contract.Exceptions
{
    public class CustomValidationException : Exception
    {
        public CustomValidationException(List<ValidationError> validationErrors)
        {
            ValidationErrors = validationErrors;
        
        }

        public List<ValidationError> ValidationErrors { get; set; }
    }
}
