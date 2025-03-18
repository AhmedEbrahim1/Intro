using Intro.Models;

namespace Intro.ViewModel
{
    public class EmployeeAdditionalData
    {
        public string Message { get; set; }
        public List<string> Branches { get; set; }
        public DateTime Date { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
