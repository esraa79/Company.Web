using Company.Data.Models;
using Company.Service.Interfaces.Employee.DTO;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Company.Service.Interfaces.Employee
{
    public interface IEmployeeService
    {
        EmployeeDto GetBYId(int? id);
        IEnumerable<EmployeeDto> GetAll();
        void Add(EmployeeDto entity);
        void Delete(EmployeeDto entity);
        void Update(EmployeeDto entity);
        IEnumerable<EmployeeDto> GetEmpoyeeByName(string empyeeName);
    }
}
