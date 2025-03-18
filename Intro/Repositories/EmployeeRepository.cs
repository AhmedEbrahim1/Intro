using Intro.Models;

namespace Intro.Repositories
{
    public class EmployeeRepository: IEmployeeRepository
    {
        RwadMisrConext context; //==>null

        public EmployeeRepository()
        {
            context = new RwadMisrConext();
        }

        public void Add(Employee obj)
        {
            context.Employees.Add(obj);
            //context.Add(obj);
        }
        public void Update(Employee obj)
        {
            context.Employees.Update(obj);
        }
        public void Delete(int id)
        {
            var dept = GetById(id);
            context.Employees.Remove(dept);
        }
        public Employee GetById(int id)
        {
            return context.Employees.FirstOrDefault(d => d.Id == id);
        }
        public List<Employee> GetAll()
        {
            return context.Employees.ToList();
        }
        public void Save()
        {
            context.SaveChanges();
        }

    }
}
