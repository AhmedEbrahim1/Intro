using Intro.Models;

namespace Intro.Repositories
{
    public interface IEmployeeRepository
    {
        public void Add(Employee obj);
        public void Update(Employee obj);
        public void Delete(int id);
        public Employee GetById(int id);
        public List<Employee> GetAll();
        public void Save();
    }
}
