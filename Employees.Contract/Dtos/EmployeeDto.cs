using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Contract.Dtos
{
    public record EmployeeDto(int id, string name, int age, string department, string contractType, string employeeGrade ,DateTime createdDate);

}
