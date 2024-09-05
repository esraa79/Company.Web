using Company.Data.Models;
using Company.Repositry.Interfaces;
using Company.Repositry.Repositries;
using Company.Service.Interfaces;
using Company.Service.Services.Department;
using Microsoft.AspNetCore.Mvc;

namespace Company.Web.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            this._departmentService = departmentService;
        }

       

        public IActionResult Index()
        {
            var department = _departmentService.GetAll();
            return View(department);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Department department)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _departmentService.Add(department);

                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("DepartmntError", "Validation Error");

                return View(department);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("DepartmntError", ex.Message);

                return View(department);
            }
        }

        public IActionResult Details(int? Id,string ViewName="Details")
        {
            var dept = _departmentService.GetBYId(Id);
            if (dept is null)
                return RedirectToAction("NotFoundPage",null,"Home");
            return View(ViewName,dept);
        }
        [HttpGet]
        public IActionResult Update(int? Id)
        {
         
            return Details(Id,"Update");
        }
        [HttpPost]
        public IActionResult Update(int? Id,Department department)
        {
            if(department.id != Id.Value)
                return RedirectToAction("NotFoundPage", null, "Home");

            _departmentService.Update(department);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int? Id)
        {
            var dept = _departmentService.GetBYId(Id);
            if (dept is null)
                return RedirectToAction("NotFoundPage", null, "Home");
            _departmentService.Delete(dept);

            return RedirectToAction(nameof(Index));
        }


    }
}
