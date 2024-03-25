using Employees.Contract.Exceptions;
using Employees.Contract.Responses;
using Employees.Domain.Entities;
using Employees.Infrastructure;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Application.Queries.Employees.GetEmployeeById
{
    public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, GetEmployeeByIdResponse>
    {
        private readonly EmployeesDBContext _employeesDBContext;

        public GetEmployeeByIdQueryHandler(EmployeesDBContext employeesDBContext)
        {
            _employeesDBContext = employeesDBContext;
        }
        public async Task<GetEmployeeByIdResponse> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            var employee = await _employeesDBContext.Employees.
                FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (employee == null)
            {
                throw new NotFoundException($"{nameof(Employee)} with {nameof(Employee.Id)}: " +
                    $"{request.Id}" + $"not found in database");
            }

            return employee.Adapt<GetEmployeeByIdResponse>();
        }
    }
}
