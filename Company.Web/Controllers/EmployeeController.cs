using Company.Data.Models;
using Company.Service.Interfaces.Department;
using Company.Service.Interfaces.Department.DTO;
using Company.Service.Interfaces.Employee;
using Company.Service.Interfaces.Employee.DTO;
using Company.Service.Services;
using Company.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Company.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        private readonly IDepartmentService _departmentService;
        private readonly EmployeeDto _employeeDto;
      

        public EmployeeController(IEmployeeService employeeService,IDepartmentService departmentService,EmployeeDto employeeDto)
        {
           _employeeService = employeeService;
            _departmentService = departmentService;
           _employeeDto = employeeDto;
            
        }
        [HttpGet]
        public IActionResult Index(string searchInp)
        {
            IEnumerable<EmployeeDto> emp;
            if(string.IsNullOrEmpty(searchInp))
             emp = _employeeService.GetAll();
               

            
            else
             emp = _employeeService.GetEmpoyeeByName(searchInp);
        
            return View(emp);


        }
        [HttpGet]
        public IActionResult Create()
        {
          ViewBag.DepartmentDto = _departmentService.GetAll();
           
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _employeeService.Add(_employeeDto);

                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("EmployeeError", "Validation Error");

                return View(employee);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("DepartmntError", ex.Message);

                return View(employee);
            }
        }

    }
}
