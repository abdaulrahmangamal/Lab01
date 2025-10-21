using ASP_.NET_MVC_lab.Context;
using ASP_.NET_MVC_lab.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP_.NET_MVC_lab.Repos
{
    public class SchoolGenericRepository:ISchoolGenericRepository
    {
        SchoolContext scontext;
        public SchoolGenericRepository(SchoolContext _schoolcontext)
        {
            scontext = _schoolcontext;

        }
        public void Add<T>(T obj)
        {
            scontext.Add(obj);
        }
        public void Edit<T>(T obj)
        {
            scontext.Update(obj);
        }
        public void Delete<T>(int id)where T:class
        {
            
            scontext.Remove(getById<T>(id));
        }
        public ICollection<T> getAll<T>() where T : class
        {
            return scontext.Set<T>().ToList();
        }
        public T getById<T>(int id) where T: class
        {
            return scontext.Set<T>().Find(id);
        }
       public Department getByName(int id, string name) //department/getbyname/1?name=dept1
        {
            return scontext.departments.FirstOrDefault(c => c.Name == name);
        }
        public void Save()
        {
            scontext.SaveChanges();
        }
    }
}
