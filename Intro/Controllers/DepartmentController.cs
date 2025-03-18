using Intro.Models;
using Intro.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Intro.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IGenericRepository<Department> _deptRepository;
        public DepartmentController(IGenericRepository<Department> iDepartmentRepository)
        {
            _deptRepository = iDepartmentRepository;
        }

        public IActionResult Index()
        {
            //var depts = context.Department.ToList();
            var depts = _deptRepository.GetAll();
            return View(depts);
        }

        public IActionResult New()
        {

            return View();
        }

        public IActionResult SaveNewDepartment(Department department)
        {
            if (department.Name != null && department.ManagerName != null)
            {
                _deptRepository.Add(department);
                //_deptRepository.Save();


                return RedirectToAction("Index");
            }

            return View("New", department);
        }
    }
}
