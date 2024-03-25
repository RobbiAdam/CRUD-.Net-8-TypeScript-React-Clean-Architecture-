using Employees.Contract.Responses;
using Employees.Domain.Entities;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Application.Mappings
{
    public class MappingConfig
    {
        public static void configure()
        {
            TypeAdapterConfig<List<Employee>, GetEmployeesResponse>.NewConfig()
                .Map(dest => dest.EmployeeDtos, src => src);

            TypeAdapterConfig<Employee, GetEmployeeByIdResponse>.NewConfig()
                .Map(dest => dest.EmployeeDto, src => src);
        }
    }
}
