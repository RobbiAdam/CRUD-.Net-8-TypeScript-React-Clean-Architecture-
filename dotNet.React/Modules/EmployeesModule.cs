using Employees.Application.Commands.Employees.CreateEmployee;
using Employees.Application.Commands.Employees.DeleteEmployee;
using Employees.Application.Commands.Employees.UpdateEmployee;
using Employees.Application.Queries.Employees.GetEmployeeById;
using Employees.Application.Queries.Employees.GetEmployees;
using Employees.Contract.Requests.Employees;
using MediatR;

namespace dotNet.React.Modules
{
    public static class EmployeesModule
    {
        public static void AddEmployeesEndpoint(this IEndpointRouteBuilder app)
        {
            app.MapGet("api/employees", async (IMediator mediator, CancellationToken ct) =>
            {
                var employees = await mediator.Send(new GetEmployeesQuery(), ct);
                return Results.Ok(employees);
            }).WithTags("Employees");

            app.MapGet("api/employees/{id}", async (IMediator mediator, int id, CancellationToken ct) =>
            {
                var employee = await mediator.Send(new GetEmployeeByIdQuery(id), ct);
                return Results.Ok(employee);
            }).WithTags("Employees");

            app.MapPost("api/employees", async (IMediator mediator,
                CreateEmployeeRequest createEmployeeRequest, CancellationToken ct) =>
            {
                var command = new CreateEmployeeCommand(
                    createEmployeeRequest.Name,
                    createEmployeeRequest.Age,
                    createEmployeeRequest.Department,
                    createEmployeeRequest.ContractType,
                    createEmployeeRequest.EmployeeGrade
                    );

                var result = await mediator.Send(command, ct);

                return Results.Ok(result);

            }).WithTags("Employees");

            app.MapPut("api/employees/{id}", async (IMediator mediator, int id,
                UpdateEmployeeRequest updateEmployeeRequest, CancellationToken ct) =>
            {
                var command = new UpdateEmployeeCommand(
                    id,
                    updateEmployeeRequest.Name,
                    updateEmployeeRequest.Age,
                    updateEmployeeRequest.Department,
                    updateEmployeeRequest.ContractType,
                    updateEmployeeRequest.EmployeeGrade
                     );

                var result = await mediator.Send(command, ct);

                return Results.Ok(result);
            }).WithTags("Employees");

            app.MapDelete("api/employees/{id}", async(IMediator mediator, int id, CancellationToken ct) =>
            {
                var command = new DeleteEmployeeCommand(id);
                var result = await mediator.Send(command, ct);
                return Results.Ok(result);

            }).WithTags("Employees");

        }
    }
}
