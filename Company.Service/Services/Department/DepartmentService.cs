using Company.Repositry.Interfaces;
using Company.Service;
using Company.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Repositry.Repositries;
using Company.Service.Interfaces.Department;
using Company.Service.Interfaces.Department.DTO;
using Company.Service.Interfaces.Employee.DTO;
using System.Runtime.Intrinsics.Arm;
using AutoMapper;


namespace Company.Service.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DepartmentService(IUnitOfWork unitOfWork,IMapper mapper)
        {
           _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

       
        public void Add(DepartmentDto departmentDto)
        {
            //var mappedDepartment = new Data.Models.Department
            //{
            //    Code = entity.Code,
            //    Name = entity.Name,
            //    CreateAt = DateTime.Now

            //};
            Department Dep = _mapper.Map<Department>(departmentDto);
            _unitOfWork.DepartmentRepositry.Add(Dep);
            _unitOfWork.Complete();
            
        }

        public void Delete(DepartmentDto department)
        {
            //Department dep = new Data.Models.Department
            //{
            //  Code= department.Code,
            //  Name = department.Name,
            //  CreateAt =department.CreateAt,
            //  id = department.Id



            //};
            Department dep = _mapper.Map<Department>(department);
            _unitOfWork.DepartmentRepositry.Delete(dep);
            _unitOfWork.Complete();
        }

        public IEnumerable<DepartmentDto> GetAll()
        {
            var dep = _unitOfWork.DepartmentRepositry.GetAll();
            //var mappeddep = emp.Select(x => new DepartmentDto
            //{
            //   Code=x.Code,
            //   Name=x.Name,
            //   CreateAt=x.CreateAt,
            //   Id = x.id

            //});
            var mappeddep = _mapper.Map<IEnumerable<DepartmentDto>>(dep);

            return mappeddep;
        }

        public DepartmentDto GetBYId(int? id)
        {
            if (id is null)
                return null;
            var dep = _unitOfWork.DepartmentRepositry.GetBYId(id.Value);

            if (dep is null)
                return null;

            //DepartmentDto depDto = new DepartmentDto
            //{
            //   Code = dep.Code,
            //   Name = dep.Name,
            //   CreateAt = dep.CreateAt,
            //   Id = dep.id


            //};
            DepartmentDto depDto = _mapper.Map<DepartmentDto>(dep);
            return depDto;

        }

        public void Update(DepartmentDto department)
        {
           // _unitOfWork.DepartmentRepositry.Update(department); 
            _unitOfWork.Complete();
        }
    }
}
