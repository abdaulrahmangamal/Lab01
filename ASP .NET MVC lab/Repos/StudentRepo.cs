using ASP_.NET_MVC_lab.Context;
using ASP_.NET_MVC_lab.Models;

namespace ASP_.NET_MVC_lab.Repos
{
    public class StudentRepo
    {
        SchoolContext scontext;
        public StudentRepo()
        {
            scontext = new();
        }
        public void Add(Student std)
        {
            scontext.Add(std);
        }
        public void Edit(Student std)
        {
            scontext.Update(std);
        }
        public void Delete (int id)
        {
            Student std = getById(id);
            scontext.Remove(std);
        }
        public ICollection<Student> getAll()
        {
            return scontext.Students.ToList();
        }
        public Student getById(int id)
        {
            return getAll().FirstOrDefault(c=>c.ssn==id);
        }
        public void Save()
        {
            scontext.SaveChanges();
        }

    }
}
