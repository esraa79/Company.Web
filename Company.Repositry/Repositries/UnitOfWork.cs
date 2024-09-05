using Company.Data.Context;
using Company.Repositry.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Repositry.Repositries
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CompanyDbContext _context;

        public UnitOfWork(CompanyDbContext context)
        {
            _context = context;
            DepartmentRepositry = new DepartmentRepositry(context);
            EmployeeRepositry = new EmployeeRepositry(context);
        }
        public IDepartmentRepositry DepartmentRepositry { get ; set ; }
        public IEmployeeRepositry EmployeeRepositry { get; set ; }

        public int Complete()
        =>_context.SaveChanges();
    }
}
