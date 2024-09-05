using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Repositry.Interfaces
{
    public interface IUnitOfWork
    {
        public IDepartmentRepositry DepartmentRepositry { get; set; }
        public IEmployeeRepositry EmployeeRepositry { get; set; }
        int Complete();
    }
}
