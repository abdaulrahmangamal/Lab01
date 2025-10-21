using ASP_.NET_MVC_lab.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP_.NET_MVC_lab.Repos
{
    public interface ISchoolGenericRepository
    {

        public void Add<T>(T obj);


        public void Edit<T>(T obj);


        public void Delete<T>(int id) where T : class;


        public ICollection<T> getAll<T>() where T : class;


        public T getById<T>(int id) where T : class;


        public Department getByName(int id, string name);//department/getbyname/1?name=dept1


        public void Save();
        
    }
}
