using Microsoft.AspNetCore.Mvc;
using Route.C41.G03.BLL.Interfaces;
using Route.C41.G03.DAL.Models;

namespace Route.C41.G03.PL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public IActionResult Index()
        {   
            var employees = _employeeRepository.GetAll();
            return View(employees);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _employeeRepository.Add(employee);
                    return RedirectToAction(nameof(Index));
                }
                catch (System.Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return View(employee);
        }

        [HttpGet]
        public IActionResult Details(int? id, string viewName = "Edit")
        {
            if (!id.HasValue)
                return BadRequest();
            var employee = _employeeRepository.GetById(id.Value);
            if (employee == null)
                return NotFound();
            return View(employee);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            //if (!id.HasValue)
            //    return BadRequest();
            //var employee =_employeeRepository.Get(id.Value);
            //if(employee is null)
            //    return NotFound();
            //return View(employee);

            return Details(id, "Edit");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Employee employee, [FromRoute] int id)
        {
            if (id != employee.Id)
                return BadRequest();
            if (ModelState.IsValid)
            {
                try
                {
                    _employeeRepository.Update(employee);
                    return RedirectToAction(nameof(Index));
                }
                catch (System.Exception ex)
                {
                    //1. log Exception
                    //2.form

                    ModelState.AddModelError(string.Empty, ex.Message);

                }
            }
            return View(employee);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            return Details(id, "Delete");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Employee employee, [FromRoute] int id)
        {
            if (id != employee.Id)
                return BadRequest();
            try
            {
                _employeeRepository.Delete(employee);
                return RedirectToAction(nameof(Index));
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(employee);
        }

    }
}