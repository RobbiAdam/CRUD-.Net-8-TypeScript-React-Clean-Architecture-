using Employees.Contract.Exceptions;
using Employees.Domain.Entities;
using Employees.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Application.Commands.Employees.UpdateEmployee
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, Unit>
    {
        private readonly EmployeesDBContext _employeesDBContext;

        public UpdateEmployeeCommandHandler(EmployeesDBContext employeesDBContext)
        {
            _employeesDBContext = employeesDBContext;
        }
        public async Task<Unit> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employeeToUpdate = await _employeesDBContext.Employees.FirstOrDefaultAsync
                (x => x.Id == request.Id, cancellationToken);

            if (employeeToUpdate == null)
            {
                throw new NotFoundException($"{nameof(Employee)} with {nameof(Employee.Id)}: " +
                        $"{request.Id}" + $"not found in database");
            }

            employeeToUpdate.Name = request.Name;
            employeeToUpdate.Age = request.Age;
            employeeToUpdate.Department = request.Department;
            employeeToUpdate.ContractType = request.ContractType;
            employeeToUpdate.EmployeeGrade = request.EmployeeGrade;

            _employeesDBContext.Employees.Update(employeeToUpdate);
            await _employeesDBContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
