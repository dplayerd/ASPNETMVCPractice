using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class StaticController : Controller
    {
        // GET: StaticPage
        public ActionResult Index()
        {
            return View();
        }



        //其他成员
        public ActionResult Page(string id)
        {
            if (id == "S1")
                id = "Static1.html";
            else
                id = "Static2.html";


            string filePath =
                "~/StaticPage/" + id;


            string IOPath = Server.MapPath(filePath);


            if (!System.IO.File.Exists(IOPath))
                return Redirect("~/");


            string htmlContent =
                System.IO.File.ReadAllText(IOPath);


            return Content(htmlContent, "text/html");
        }
    }
}