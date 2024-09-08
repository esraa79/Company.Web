using Company.Data.Context;
using Company.Data.Models;
using Company.Repositry.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Repositry.Repositries
{
    internal class EmployeeRepositry :GenericRepositry<Employee>, IEmployeeRepositry
    {
        private readonly CompanyDbContext _context;

        public EmployeeRepositry(CompanyDbContext context):base(context) 
        {
            this._context = context;
        }

        public IEnumerable<Employee> GetEmpoyeeByAddress(string Address)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetEmpoyeeByName(string empyeeName)
        =>_context.Employees.Where(x=>x.Name.Trim().ToLower().Contains(empyeeName.Trim().ToLower())).ToList();
    }
}
