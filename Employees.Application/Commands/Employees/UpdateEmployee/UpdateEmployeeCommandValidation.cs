using Employees.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Application.Commands.Employees.UpdateEmployee
{
    public class UpdateEmployeeCommandValidation : AbstractValidator<UpdateEmployeeCommand>
    {
        public UpdateEmployeeCommandValidation()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage($"{nameof(Employee.Id)} cannot be empty")
                .GreaterThan(0).WithMessage($"{nameof(Employee.Id)} Id is invalid");
            ;

            RuleFor(x => x.Name).NotEmpty()
                .WithMessage($"{nameof(Employee.Name)} is required")
                .MaximumLength(60)
                .WithMessage($"{nameof(Employee.Name)} cannot exceed 60 characters");

            RuleFor(x => x.Age).NotEmpty()
                .WithMessage($"{nameof(Employee.Age)} is required")
                .GreaterThanOrEqualTo(18)
                .WithMessage($"{nameof(Employee.Age)} should be greater than or equal to 18");

            RuleFor(x => x.Department).NotEmpty()
                .WithMessage($"{nameof(Employee.Department)} is required");

            RuleFor(x => x.ContractType).NotEmpty()
                .WithMessage($"{nameof(Employee.ContractType)} is required");

        }
    }
}
