using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Data.Models;
using Company.Service.Interfaces.Department.DTO;
using Company.Service.Interfaces.Employee.DTO;

namespace Company.Service.Mapping
{
    public class DepartmetProfile:Profile
    {
        public DepartmetProfile()
        {
            CreateMap<Department, DepartmentDto>().ReverseMap();

        }
    }
}
