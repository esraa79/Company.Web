using Company.Data.Models;
using Company.Service.Interfaces.Department.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Service.Interfaces.Department
{
    public interface IDepartmentService
    {
        DepartmentDto GetBYId(int? id);
        IEnumerable<DepartmentDto> GetAll();
        void Add(DepartmentDto entity);
        void Delete(DepartmentDto entity);
        void Update(DepartmentDto entity);
    }
}
