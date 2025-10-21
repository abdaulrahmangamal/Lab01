using ASP_.NET_MVC_lab.Context;
using ASP_.NET_MVC_lab.Models;
using ASP_.NET_MVC_lab.Repos;
using Microsoft.AspNetCore.Mvc;

namespace ASP_.NET_MVC_lab.Controllers
{
    public class CourseController : Controller
    {
        //SchoolContext scontext = new SchoolContext();
        ISchoolGenericRepository schoolgenericrepo;
        public CourseController(ISchoolGenericRepository _ischoolrepo)
        {
            schoolgenericrepo = _ischoolrepo;
        }
        public IActionResult getAll()
        {
            var courses = schoolgenericrepo.getAll<Course>();
            return View(courses);
        }
        public IActionResult getById(int Id)
        {
            return View(schoolgenericrepo.getById<Course>(Id));
        }
        [HttpGet]
        public IActionResult AddCourse(int Id)
        {
            return View("AddCourse");
        }
        [HttpPost]
        public IActionResult AddCourse(Course crs)
        {
            if (ModelState.IsValid)
            {
                schoolgenericrepo.Add<Course>(crs);
                schoolgenericrepo.Save();
                return RedirectToAction("getAll");
            }
            else
                return View(crs);
        }
        [HttpGet]
        public IActionResult EditCourse(int Id)
        {
            var crs = schoolgenericrepo.getById<Course>(Id);
            return View(crs);
        }
        [HttpPost]
        public IActionResult EditCourse(Course crs)
        {
            if (ModelState.IsValid)
            {
                schoolgenericrepo.Edit<Course>(crs);
                schoolgenericrepo.Save();
                return RedirectToAction("getAll");
            }
            else
                return View(crs); 
    
        }
        public IActionResult Delete(int id)
        {
            //scontext.courses.Remove(scontext.courses.Find(id));
            schoolgenericrepo.Delete<Course>(id);
            schoolgenericrepo.Save();
            return RedirectToAction("getall");
        }
    }
}
