using Intro.Models;
using Microsoft.AspNetCore.Mvc;

namespace Intro.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Details(int id)
        {
            Student studentModel = StudentList.Students.FirstOrDefault(e => e.Id == id);
            //return View();//Model ==> null
            return View(studentModel);//Model ==> null
        }

        public IActionResult GetAllStudents()
        {
            List<Student> students = StudentList.Students;
            return View(students);

        }

    }
}
