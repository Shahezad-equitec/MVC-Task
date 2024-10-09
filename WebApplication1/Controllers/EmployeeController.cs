using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeRepository empRep=new EmployeeRepository();
        // GET: Employee
        public ActionResult Index()
        {
            var data = empRep.GetAllEmp();
            return View(data);
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(EmployeeModel emp)
        {
            if(ModelState.IsValid)
            {
                int count = empRep.Add(emp);
                if (count > 0)
                {
                    var data = empRep.GetAllEmp();
                    return View("Index", data);
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View();
            }
            
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            EmployeeModel data= empRep.GetEmpById(id);
            return View(data);  
        }
        [HttpPost]
        public ActionResult Edit(EmployeeModel emp)
        {
            if(ModelState.IsValid)
            {
                int count=empRep.EditEmp(emp);
                if(count > 0)
                {
                    var data = empRep.GetAllEmp();
                    return View("Index", data);
                }
                else
                {
                    return View();
                }

            }
            else
            {
                return View();
            }
        }
        public ActionResult Delete(int id)
        {
            int count=empRep.UpdateEmp(id);
            if(count > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("index");
            }
        }
    }
}