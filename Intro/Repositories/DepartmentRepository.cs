using Intro.Models;

namespace Intro.Repositories
{
    public class DepartmentRepository: IDepartmentRepository
    {
        //CRUD 
        private readonly RwadMisrConext context;//null
        public DepartmentRepository(RwadMisrConext context)//ask ==> obj 
        {
            this.context = context;
        }

        public void Add(Department obj)
        {
            context.Department.Add(obj);
            //context.Add(obj);
        }
        public void Update(Department obj)
        {
            context.Department.Update(obj);
        }
        public void Delete(int id)
        {
            var dept = GetById(id);
            context.Department.Remove(dept);
        }
        public Department GetById(int id)
        {
            return context.Department.FirstOrDefault(d => d.Id == id);
        }
        public List<Department> GetAll()
        {
            return context.Department.ToList();
        }
        public void Save()
        {
            context.SaveChanges();
        }

    }
}
