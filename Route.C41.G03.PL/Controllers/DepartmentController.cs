using Microsoft.AspNetCore.Mvc;
using Route.C41.G03.BLL.Interfaces;

namespace Route.C41.G03.PL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartment _departmentRepo;

        public DepartmentController(IDepartment departmentRepo)
        {
            _departmentRepo = departmentRepo;
        }

        // /Department/Index
        public IActionResult Index()
        {
            var departments = _departmentRepo.GetAll();
            return View(departments);
        }
    }
}