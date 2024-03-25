using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Domain.Entities
{
    public class Employee : BaseEntity
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Department { get; set; }
        public string ContractType { get; set; }
        public string EmployeeGrade { get; set; }

        
    }
}
