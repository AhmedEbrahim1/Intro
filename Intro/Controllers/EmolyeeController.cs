using Intro.Filters;
using Intro.Models;
using Intro.Repositories;
using Intro.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Data;

namespace Intro.Controllers
{
    public class EmolyeeController : Controller
    {
        private readonly IGenericRepository<Employee> _employeeRepository;
        private readonly IDepartmentRepository _deptRepository;
        //private readonly IEmployeeRepository _employeeRepository;

        //new DepartmentRepository()
        public EmolyeeController(IGenericRepository<Employee> genericRepository, IDepartmentRepository departmentRepository)//Ask 
        {
            this._employeeRepository = genericRepository;
            _deptRepository = departmentRepository;
            //_employeeRepository = employeeRepository;
        }

        public IActionResult ChekAgeAndName(int Age, string Nam)
        {
            if (Age > 40)
                return Json(true);
            else
                return Json(false);
        }

        //[HandleError]

        [HandleError]
        public IActionResult Index()
        {
            //throw new Exception();
            //var emps = context.Employees.ToList();
            var emps = _employeeRepository.GetAll();
            return View(emps);
        }

        [HttpGet]
        public IActionResult AddNewEmployee()
        {
            //ViewBag.depts = context.Department.ToList();
            ViewBag.depts = _deptRepository.GetAll();
            return View();
        }
        [HttpPost]
        public IActionResult AddNewEmployee(Employee newEmp)
        {
            if (ModelState.IsValid)
            {
                //context.Employees.Add(newEmp);
                _employeeRepository.Add(newEmp);
                //_employeeRepository.Save();
                return RedirectToAction("Index");
            }

            ViewBag.depts = _deptRepository.GetAll();
            return View(newEmp);//control + k + d 
        }

        [HttpGet]
        public IActionResult Edit(int Id)//Get
        {
            var emp = _employeeRepository.GetById(Id);
            var depts = _deptRepository.GetAll();
            if (emp != null)
            {
                ViewBag.depts = depts;
                return View(emp);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Edit(int Id, Employee newEmp)
        {
            if (newEmp.Nam != null)
            {
                //Auto Mapper ==> EmployeeViewModel , new Object of Employee
                var oldEmp = _employeeRepository.GetById(Id);
                oldEmp.Age = newEmp.Age;
                oldEmp.Address = newEmp.Address;
                oldEmp.Nam = newEmp.Nam;
                oldEmp.Dept_Id = newEmp.Dept_Id;

                _employeeRepository.Update(oldEmp);
                //_employeeRepository.Save();
                //context.SaveChanges();
                return RedirectToAction("Index");
            }
            //var depts = context.Department.ToList();
            var depts = _deptRepository.GetAll();
            ViewBag.depts = depts;
            return View(newEmp);
        }

        public IActionResult Details(int id)
        {
            //var emp = context.Employees.FirstOrDefault(e => e.Id == id);
            return View(_employeeRepository.GetById(id));
        }

        public IActionResult DetailsOfPartialView(int id)
        {
            var emp = _employeeRepository.GetById(id);
            //return View("_EmployeeCard", emp);//retrun view with layout
            return PartialView("_EmployeeCard", emp);//retrun view without layout
        }

        public IActionResult DeprtmentEmployee()
        {
            var depts = _deptRepository.GetAll();
            return View(depts);
        }

        //public IActionResult GetEmployeesByDeptId(int deptId)
        //{
        //    var emps = context.Employees.Where(e => e.Dept_Id == deptId).Select(x => new { x.Nam, x.Id }).ToList();
        //    return Json(emps);
        //}


        public IActionResult EmployeeAdditionalData()
        {
            //var emps = context.Employees.ToList();
            var emps = _employeeRepository.GetAll();
            var empViewModel = new EmployeeAdditionalData()
            {
                Date = DateTime.Now,
                Branches = new List<string>() { "B1", "B2", "B3" },
                //Employees = emps,
                Message = "TEST"
            };
            return View(empViewModel);
        }
    }
}
