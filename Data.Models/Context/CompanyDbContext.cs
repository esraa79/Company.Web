using Company.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Company.Data.Context
{
    public class CompanyDbContext:DbContext
    {
        public CompanyDbContext(DbContextOptions<CompanyDbContext> options):base(options)
        {

            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
          //   modelBuilder.Entity<BaseEntity>().HasQueryFilter(x => !x.IsDeleted);
               base.OnModelCreating(modelBuilder);
        }
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Department> Department { get; set; }

    }
}
