using Company.Repositry.Interfaces;
using Company.Repositry.Repositries;
using Microsoft.AspNetCore.Mvc;

namespace Company.Web.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepositry _departmentRepositry;
        public DepartmentController(IDepartmentRepositry departmentRepositry)
        {
            _departmentRepositry = departmentRepositry;
        }

       

        public IActionResult Index()
        {
            var department = _departmentRepositry.GetAll();
            return View(department);
        }
    }
}
