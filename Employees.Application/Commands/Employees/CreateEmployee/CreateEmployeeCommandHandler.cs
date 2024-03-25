using Employees.Domain.Entities;
using Employees.Infrastructure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Application.Commands.Employees.CreateEmployee
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, int>
    {
        private readonly EmployeesDBContext _employeesDBContext;

        public CreateEmployeeCommandHandler(EmployeesDBContext employeesDBContext)
        {
            _employeesDBContext = employeesDBContext;

        }
        public async Task<int> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = new Employee
            {
                Name = request.Name,
                Age = request.Age,
                Department = request.Department,
                ContractType = request.ContractType,
                EmployeeGrade = request.EmployeeGrade,
                
            };

            await _employeesDBContext.Employees.AddAsync(employee, cancellationToken);
            await _employeesDBContext.SaveChangesAsync(cancellationToken);

            return employee.Id;
        }
    }
}
