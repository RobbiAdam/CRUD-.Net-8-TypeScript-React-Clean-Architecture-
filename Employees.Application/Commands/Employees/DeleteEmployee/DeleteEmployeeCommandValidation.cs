using Employees.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Application.Commands.Employees.DeleteEmployee
{
    public class DeleteEmployeeCommandValidation : AbstractValidator<DeleteEmployeeCommand>
    {
        public DeleteEmployeeCommandValidation()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage($"{nameof(Employee.Id)} cannot be empty")
                .GreaterThan(0).WithMessage($"{nameof(Employee.Id)} Id is invalid"); ;
        }
        }
    }

