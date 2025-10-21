using ASP_.NET_MVC_lab.Context;
using ASP_.NET_MVC_lab.Models;
using ASP_.NET_MVC_lab.Repos;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace ASP_.NET_MVC_lab.Controllers
{
    public class InstructorController : Controller
    {
        //SchoolContext scontext = new SchoolContext();
        ISchoolGenericRepository schoolgenericrepo;
        public InstructorController(ISchoolGenericRepository _ischoolrepo)
        {
            schoolgenericrepo = _ischoolrepo;
        }
        public IActionResult getAll()
        {
            //throw new Exception("An error from student controller");

            var instructors = schoolgenericrepo.getAll<Instructor>();
            return View(instructors);
        }
        public IActionResult getById(int id)
        {
            var inst = schoolgenericrepo.getById<Instructor>(id);
            return View(inst);
        }
        public IActionResult addInstructor()
        {
            var dept = schoolgenericrepo.getAll<Department>();
            ViewBag.depts = dept;
            return View("AddInstructor");
        }
        [HttpPost]
        public IActionResult addNewInstructor(Instructor ins)
        {
            if (ModelState.IsValid)
            {
                schoolgenericrepo.Add<Instructor>(ins);
                schoolgenericrepo.Save();
                return RedirectToAction("getAll");
            }
            else
            {
                var dept = schoolgenericrepo.getAll<Department>();
                ViewBag.depts = dept;
                return View("addInstructor",ins);
            }
        }
        [HttpGet]
        public IActionResult EditInstructor(int id)
        {
            var instruct = schoolgenericrepo.getById<Instructor>(id);
            var dept = schoolgenericrepo.getAll<Department>();
            ViewBag.depts = dept;
            return View(instruct);
        }
        [HttpPost]
        public IActionResult EditInstructor(Instructor inst)
        {
            if (ModelState.IsValid)
            {
                schoolgenericrepo.Edit(inst);
                schoolgenericrepo.Save();
                return RedirectToAction("getall");
            }
            else
                return View(inst);
          
        }
        public IActionResult Delete(int id)
        {
            //scontext.instructors.Remove(scontext.instructors.Find(id));
            schoolgenericrepo.Delete<Instructor>(id);
            schoolgenericrepo.Save();
                return RedirectToAction("getall");
        }






    }
}
