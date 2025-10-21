using ASP_.NET_MVC_lab.Context;
using ASP_.NET_MVC_lab.Models;
using ASP_.NET_MVC_lab.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.EntityFrameworkCore;

namespace ASP_.NET_MVC_lab.Controllers
{
    public class StudentController : Controller
    {
        //SchoolContext stdcontext = new SchoolContext();
        ISchoolGenericRepository schoolgenericrepo;
        //StudentRepo studentrepo;
        //DepartmentRepo departmentrepo;
        public StudentController(ISchoolGenericRepository _ischoolrepo)
        {
            //studentrepo = new();
            //departmentrepo = new();
            schoolgenericrepo = _ischoolrepo;
        }
        public IActionResult getAll()
        {
            //var students = studentrepo.getAll();
            var student1 = schoolgenericrepo.getAll<Student>();
            return View(student1);
        }
        public IActionResult getById(int id)
        {
            var student = schoolgenericrepo.getById<Student>(id);
            //var student = stdcontext.Students.Include(m => m.StudentCourses)
            //.ThenInclude(m=>m.Course).FirstOrDefault(m=>m.ssn==id);
            return View(student);
        }
        [HttpGet]
        public IActionResult AddStudent()
        {
            var depts = schoolgenericrepo.getAll<Department>();
            ViewBag.depts = depts;
            return View("AddStudent");
        }
        [HttpPost]
        public IActionResult AddNewStudent(Student std)
        {
                if (ModelState.IsValid)
                {
                //stdcontext.Students.Add(std);
                schoolgenericrepo.Add(std);
                //stdcontext.SaveChanges();
                schoolgenericrepo.Save();
                    return RedirectToAction("getAll");
                }
                else
                {
                    var depts = schoolgenericrepo.getAll<Department>();
                    ViewBag.depts = depts;
                    return View("AddStudent", std);
                }
        }
        [HttpGet]
        public IActionResult EditStudent(int id)
        {
            //var student = stdcontext.Students.Find(id);
            var student = schoolgenericrepo.getById<Student>(id);
            //var dept = stdcontext.departments.ToList();
            var dept = schoolgenericrepo.getAll<Department>();
            ViewBag.depts = dept;
            return View(student);
        }
        [HttpPost]
        public IActionResult EditStudent(Student std)
        {
            if (ModelState.IsValid)
            {
                //stdcontext.Update(std);
                schoolgenericrepo.Edit(std);
                //stdcontext.SaveChanges();
                schoolgenericrepo.Save();
                return RedirectToAction("getall");
            }
            else
                return RedirectToAction("EditStudent");
        }
        public IActionResult Delete(int id)
        {
            //var std = stdcontext.Students.Find(id);
            //stdcontext.Students.Remove(stdcontext.Students.Find(id));
            schoolgenericrepo.Delete<Student>(id);
            //stdcontext.SaveChanges();
            schoolgenericrepo.Save();
            return RedirectToAction("getall");
        }




        //public ContentResult test()
        //{
        //    return Content("hello from student ctrl");
        //}
        //public ViewResult studentview()
        //{
        //    //ViewResult view = new ViewResult();
        //    //view.ViewName = "studentview";
        //    //return view;
        //    return View("studentview");
        //}
    }
}
