using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Contract.Requests.Employees
{
    public record UpdateEmployeeRequest(string Name, int Age, string Department, string ContractType, string EmployeeGrade);
    
}
