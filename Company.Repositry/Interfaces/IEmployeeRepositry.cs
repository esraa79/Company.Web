using Company.Data.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Repositry.Interfaces
{
    public interface IEmployeeRepositry:IGenericRepositry<Employee>
    {
        Employee GetEmpoyeeByName(string empyeeName);

        IEnumerable<Employee> GetEmpoyeeByAddress(string Address);
        

    }
}
