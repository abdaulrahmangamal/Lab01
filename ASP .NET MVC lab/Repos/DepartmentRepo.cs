using ASP_.NET_MVC_lab.Context;
using ASP_.NET_MVC_lab.Models;

namespace ASP_.NET_MVC_lab.Repos
{
    public class DepartmentRepo
    {
        SchoolContext scontext;
        public DepartmentRepo()
        {
            scontext = new();
        }
        public void Add(Department dpt)
        {
            scontext.Add(dpt);
        }
        public void Edit(Department dpt)
        {
            scontext.Update(dpt);
        }
        public void Delete(int id)
        {
            Department dpt = getById(id);
            scontext.Remove(dpt);
        }
        public ICollection<Department> getAll()
        {
            return scontext.departments.ToList();
        }
        public Department getById(int id)
        {
            return getAll().FirstOrDefault(c => c.deptid == id);
        }
        public void Save()
        {
            scontext.SaveChanges();
        }
    }
}
