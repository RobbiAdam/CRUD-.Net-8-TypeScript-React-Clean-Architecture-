using Employees.Infrastructure;
using Employees.Application;
using Microsoft.EntityFrameworkCore;
using dotNet.React.Modules;
using dotNet.React.Handlers;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<EmployeesDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeManagement"));
});

builder.Services.AddApplication();
builder.Services.AddExceptionHandler<ExceptionHandler>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policyBuilder =>
    {
        policyBuilder.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:5173");
    });
});

var app = builder.Build();

if(app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
}
// Configure the HTTP request pipeline.

app.UseExceptionHandler(_ => { });
app.UseCors("CorsPolicy");
app.UseHttpsRedirection();
app.AddEmployeesEndpoint();
app.Run();

