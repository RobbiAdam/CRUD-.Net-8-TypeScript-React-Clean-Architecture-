using Employees.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Infrastructure
{
    public class EmployeesDBContext : DbContext
    {
        public EmployeesDBContext(DbContextOptions options) : base(options) 
        {

        }

        public DbSet<Employee> Employees { get; set; }
    }
}
