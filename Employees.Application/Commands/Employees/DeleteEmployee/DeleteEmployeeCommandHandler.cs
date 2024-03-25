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

namespace Employees.Application.Commands.Employees.DeleteEmployee
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, Unit>
    {
        private readonly EmployeesDBContext _employeesDBContext;

        public DeleteEmployeeCommandHandler(EmployeesDBContext employeesDBContext)
        {
            _employeesDBContext = employeesDBContext;
        }
        public async Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employeeToDelete = await _employeesDBContext.Employees.
                FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (employeeToDelete == null)
            {
                throw new NotFoundException($"{nameof(Employee)} with {nameof(Employee.Id)}: " +
                    $"{request.Id}" + $"not found in database");
            }

            _employeesDBContext.Employees.Remove(employeeToDelete);
            await _employeesDBContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
