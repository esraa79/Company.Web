using Company.Repositry.Interfaces;
using Company.Service.Interfaces;
using Company.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Repositry.Repositries;


namespace Company.Service.Services.Department
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentService(IUnitOfWork unitOfWork)
        {
           _unitOfWork = unitOfWork;
        }

       
        public void Add(Data.Models.Department entity)
        {
            var mappedDepartment = new Data.Models.Department
            {
                Code = entity.Code,
                Name = entity.Name,
                CreateAt = DateTime.Now

            };
            _unitOfWork.DepartmentRepositry.Add(mappedDepartment);
            _unitOfWork.Complete();
            
        }

        public void Delete(Data.Models.Department department)
        {
            _unitOfWork.DepartmentRepositry.Delete(department);
            _unitOfWork.Complete();
        }

        public IEnumerable<Data.Models.Department> GetAll()
        {
            var departments = _unitOfWork.DepartmentRepositry.GetAll();
            return departments;
        }

        public Data.Models.Department GetBYId(int? id)
        {
            if (id is null)
                return null;
            var department = _unitOfWork.DepartmentRepositry.GetBYId(id.Value);

            if (department is null)
                return null;

            return department;

        }

        public void Update(Data.Models.Department department)
        {
            _unitOfWork.DepartmentRepositry.Update(department); 
            _unitOfWork.Complete();
        }
    }
}
