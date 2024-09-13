using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication4.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        //typically for every view,we need to create an action method in controller, & for every controller action method we need to create a view.
        public ActionResult Index()  //Views of actionresult typically have the same name as the actionresult name, so we can just write return View.
        {
            return View();  //don't need to explicitly mention View name because it is same as action name.
        }

        public ActionResult Products()  //for this I created a view with a different name than the action name
        {
            return View("OurProducts");  //That is why we had to explicitly mention the name of the view ie OurProducts
        }
        public ActionResult Contact()
        {
            return View();
        }
        //ContentResult Example
        public ActionResult GetEmpName(int EmpId)
        {
            var employees = new[]
            {
                new { EmpId = 1, EmpName = "Scott", Salary = 9000},
                new { EmpId = 2, EmpName= "Allen" , Salary= 12000}
            };
            string matchEmpName = null;
            foreach(var item in employees)
            {
                if(item.EmpId == EmpId)
                {
                    matchEmpName = item.EmpName;
                }
            }
            return Content(matchEmpName, "text/plain"); //ContentResult() content= matchEmpName, ContentType = text/plain
        }

        //FileResult Example
        public ActionResult GetPaySlip(int EmpId)
        {
            string fileName = "~/PaySlip" + EmpId + ".pdf";
            return File(fileName, "application/pdf");
        }
        //RedirectResult Example
        public ActionResult EmpFacebookPage(int EmpId)
        {
            var employees = new[]
            {
                new { EmpId = 1, EmpName = "Scott", Salary = 9000},
                new { EmpId = 2, EmpName= "Allen" , Salary= 12000}
            };
            string fbUrl = null;
            foreach (var item in employees)
            {
                if(item.EmpId == EmpId)
                {
                    fbUrl = "http://www.facebook.com/emp" + EmpId;
                }
                
            }
            if(fbUrl == null)
            {
                return Content("invalid emp id");
            }
            else
            {
                return Redirect(fbUrl); 
            }

        }
        //to demonstrate razor
        public ActionResult StudentDetails()
        {
            ViewBag.StudentId = 101;
            ViewBag.StudentName = "Mike";
            ViewBag.Marks = 90;
            ViewBag.NoOfSemesters = 6;
            ViewBag.Subjects = new List<string>() { "Maths", "physics", "chemistry" };
            return View();
        }
        //for HTTP Request Object
        public ActionResult RequestExample()
        {
            ViewBag.Url = Request.Url;
            ViewBag.PhysicalApplicationPath = Request.PhysicalApplicationPath;
            ViewBag.Path = Request.Path;
            ViewBag.BrowserType = Request.Browser.Type;
            ViewBag.QueryString = Request.QueryString["n"];
            ViewBag.Headers = Request.Headers["Accept"];
            ViewBag.HttpMethod = Request.HttpMethod;
            return View();

        }
        public ActionResult ResponseExample()
        {
            Response.Write("Hello from ResponseExample");
            Response.ContentType = "text/html";
            Response.Headers["Server"] = "My Server";
            Response.StatusCode = 500;
            return View();
        } 


        }
}
