using ASP_.NET_MVC_lab.Context;
using ASP_.NET_MVC_lab.Filters;
using ASP_.NET_MVC_lab.Models;
using ASP_.NET_MVC_lab.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ASP_.NET_MVC_lab.Controllers
{
    public class DepartmentController : Controller
    {
        //SchoolContext dptcontext = new SchoolContext();
        ISchoolGenericRepository schoolgenericrepo;
        public DepartmentController(ISchoolGenericRepository _ischoolrepo)
        {
            schoolgenericrepo = _ischoolrepo;
        }
        public IActionResult getAll()
        {
            HttpContext.Session.SetString("user","admin");
            Console.WriteLine($"User from Session ====>{HttpContext.Session.GetString("user")}");
            Response.Cookies.Append("user", "admin");
            Console.WriteLine($"User from Cookies =====>{Request.Cookies["user"]}");
            TempData["user"]="admin";
            var departments = schoolgenericrepo.getAll<Department>();
            return View(departments);
        }
        [AuthorizationFilter]
        public IActionResult getById(int id)
        {
            var departments = schoolgenericrepo.getById<Department>(id);

            return View(departments);
        }
        public IActionResult getByName(int id,string name) //department/getbyname/1?name=dept1
        {
            var departments = getByName(id, name);
            return View(departments);
            //return Content(name);
        }
    
        public IActionResult AddDepartment() 
        {
            return View("AddDepartment");
        }
        [LocationFilter]
        [HttpPost]
        public IActionResult AddNewDepartment(Department dept)
        {
            if (ModelState.IsValid)
            {
                schoolgenericrepo.Add<Department>(dept);
                schoolgenericrepo.Save();
                return RedirectToAction("getAll");
            }
            else
            {
                return View("AddDepartment",dept);
            }
        }
        [HttpGet]
        public IActionResult EditDepartment(int id)
        {
            var dept = schoolgenericrepo.getById<Department>(id);
            var branches = Enum.GetValues(typeof(branches));
            return View(dept);
        }
        [HttpPost]
        public IActionResult EditDepartment(Department dept)
        {
            if (ModelState.IsValid)
            {
                schoolgenericrepo.Edit(dept);
                schoolgenericrepo.Save();
                return RedirectToAction("getAll");
            }
            else
                return View(dept);
          
        }
        public IActionResult Delete(int id)
        {
            //dptcontext.departments.Remove(dptcontext.departments.Find(id));
            schoolgenericrepo.Delete<Department>(id);
            schoolgenericrepo.Save();
            return RedirectToAction("getall");
        }
    }
}
