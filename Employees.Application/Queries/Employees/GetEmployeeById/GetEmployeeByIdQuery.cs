using Employees.Contract.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Application.Queries.Employees.GetEmployeeById
{
    public record GetEmployeeByIdQuery(int Id) : IRequest<GetEmployeeByIdResponse>;

}
