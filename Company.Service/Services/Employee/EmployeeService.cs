using Company.Repositry.Interfaces;
using Company.Service.Interfaces;
using Company.Service.Interfaces.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Service.Interfaces.Employee.DTO;
using AutoMapper;
using Company.Data;
using Company.Service;
using Company.Data.Models;
using Company.Service.Helper;



namespace Company.Service.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public void Add(EmployeeDto employeeDto)
        {
            //Manual MApping
            //Data.Models.Employee employee = new Data.Models.Employee
            //{
            //    Address = employeeDto.Address,
            //    Age = employeeDto.Age,
            //    DepartmentId = employeeDto.DepartmentId,
            //    Email = employeeDto.Email,
            //    HiringDate = employeeDto.HiringDate,
            //    Name = employeeDto.Name,
            //   Phone = employeeDto.Phone,
            //   Salary = employeeDto.Salary,
            //   ImageUrl = employeeDto.ImageUrl

            //};
            employeeDto.ImageUrl = DocumentSettings.UploadFile(employeeDto.Image, "Images");
            Employee employee = _mapper.Map<Employee>(employeeDto);
            
            _unitOfWork.EmployeeRepositry.Add(employee);
            _unitOfWork.Complete();
            
        }

        public void Delete(EmployeeDto employeeDto)
        {
            //Data.Models.Employee employee = new Data.Models.Employee
            //{
            //    Address = employeeDto.Address,
            //    Age = employeeDto.Age,
            //    DepartmentId = employeeDto.DepartmentId,
            //    Email = employeeDto.Email,
            //    HiringDate = employeeDto.HiringDate,
            //    Name = employeeDto.Name,
            //    Phone = employeeDto.Phone,
            //    Salary = employeeDto.Salary,
            //    ImageUrl = employeeDto.ImageUrl

            //};
            Employee employee = _mapper.Map<Employee>(employeeDto);
            _unitOfWork.EmployeeRepositry.Delete(employee);
            _unitOfWork.Complete();
        }

        public IEnumerable<EmployeeDto> GetAll()
        {
            var emp= _unitOfWork.EmployeeRepositry.GetAll();
            //var mappedEmp = emp.Select(x => new EmployeeDto
            //{
            //    Address = x.Address,
            //    Age = x.Age,
            //    DepartmentId = x.DepartmentId,
            //    Email = x.Email,
            //    HiringDate = x.HiringDate,
            //    Name = x.Name,
            //    Phone = x.Phone,
            //    Salary = x.Salary,
            //    ImageUrl = x.ImageUrl,
            //    CreateAt = x.CreateAt

            //});
           var employee = _mapper.Map<IEnumerable<EmployeeDto>>(emp);
            return employee;
        }

        public EmployeeDto GetBYId(int? id)
        {
            if (id is null)
                return null;
            var emp = _unitOfWork.EmployeeRepositry.GetBYId(id.Value);

            if (emp is null)
                return null;

            //EmployeeDto empDto = new EmployeeDto
            //{
            //    Address = emp.Address,
            //    Age = emp.Age,
            //    DepartmentId = emp.DepartmentId,
            //    Email = emp.Email,
            //    HiringDate = emp.HiringDate,
            //    Name = emp.Name,
            //    Phone = emp.Phone,
            //    Salary = emp.Salary,
            //    ImageUrl = emp.ImageUrl,
            //    Id = emp.id,
            //    CreateAt = emp.CreateAt

            //};
            EmployeeDto empDto = _mapper.Map<EmployeeDto>(emp);
            return empDto;
        }

        public void Update(EmployeeDto entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EmployeeDto> GetEmpoyeeByName(string empyeeName)
        {
            
            var emp = _unitOfWork.EmployeeRepositry.GetEmpoyeeByName(empyeeName);


            //var mappedEmp = emp.Select(x => new EmployeeDto
            //{
            //    Address = x.Address,
            //    Age = x.Age,
            //    DepartmentId = x.DepartmentId,
            //    Email = x.Email,
            //    HiringDate = x.HiringDate,
            //    Name = x.Name,
            //    Phone = x.Phone,
            //    Salary = x.Salary,
            //    ImageUrl = x.ImageUrl,
            //    CreateAt = x.CreateAt

            //});

            IEnumerable<EmployeeDto> mappedEmp = _mapper.Map<IEnumerable<EmployeeDto>>(emp);
            return mappedEmp;
           
            
        }
    }
}
