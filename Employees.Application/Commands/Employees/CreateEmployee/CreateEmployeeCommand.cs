using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Application.Commands.Employees.CreateEmployee
{
    public record CreateEmployeeCommand 
        (string Name, int Age, string Department, string ContractType, string EmployeeGrade) : IRequest<int>;

}
