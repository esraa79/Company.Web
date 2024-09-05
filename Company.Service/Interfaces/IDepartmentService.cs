using Company.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Service.Interfaces
{
    public interface IDepartmentService
    {
        Department GetBYId(int? id);
        IEnumerable<Department> GetAll();
        void Add(Department entity);
        void Delete(Department entity);
        void Update(Department entity);
    }
}
