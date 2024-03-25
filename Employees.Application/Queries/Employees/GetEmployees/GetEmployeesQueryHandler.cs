using Employees.Contract.Responses;
using Employees.Infrastructure;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Employees.Application.Queries.Employees.GetEmployees
{
    public class GetEmployeesQueryHandler : IRequestHandler<GetEmployeesQuery, GetEmployeesResponse>
    {
        private readonly EmployeesDBContext _employeesDBContext;

        public GetEmployeesQueryHandler(EmployeesDBContext employeesDBContext)
        {
            _employeesDBContext = employeesDBContext;
        }
        public async Task<GetEmployeesResponse> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
        {
            var employees = await _employeesDBContext.Employees.ToListAsync(cancellationToken);

            return employees.Adapt<GetEmployeesResponse>();
        }
    }
}
