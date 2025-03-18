using Intro.Models;

namespace Intro.Repositories
{
    public interface IDepartmentRepository
    {
        public void Add(Department obj);
        public void Update(Department obj);
        public void Delete(int id);
        public Department GetById(int id);
        public List<Department> GetAll();
        public void Save();
    }
}
