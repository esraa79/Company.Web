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
    public class DepartmentRepositry :GenericRepositry<Department>, IDepartmentRepositry
    {
        private readonly CompanyDbContext _context;

        public DepartmentRepositry(CompanyDbContext context):base(context) 
        {
            this._context = context;
        }
    
    }
}
