using Company.Data.Models;
using Company.Service.Interfaces.Department;
using Company.Service.Interfaces.Department.DTO;
using Company.Service.Interfaces.Employee;
using Company.Service.Interfaces.Employee.DTO;
using Company.Service.Services;
using Company.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Company.Web.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        private readonly IDepartmentService _departmentService;
     
      

        public EmployeeController(IEmployeeService employeeService,IDepartmentService departmentService)
        {
           _employeeService = employeeService;
            _departmentService = departmentService;

            
        }
       
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
        public IActionResult Create(EmployeeDto employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _employeeService.Add(employee);

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
