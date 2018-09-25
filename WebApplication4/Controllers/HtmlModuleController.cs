using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication4.Controllers
{
    public class HtmlModuleController : Controller
    {

        string FilePath = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/HTML/");

        public ActionResult ViewDetail(int ModuleInstanceID = 0)
        {
            if (ModuleInstanceID <= 0)
                return new EmptyResult();


            string IOPath = FilePath + "HTML_" + ModuleInstanceID + ".html";


            if (!System.IO.File.Exists(IOPath))
                return new EmptyResult();


            string htmlContent =
                System.IO.File.ReadAllText(IOPath);


            this.ViewData["Context"] = htmlContent;
            return PartialView();
        }


        public ActionResult ViewAdmin(int ModuleInstanceID = 0)
        {
             if (ModuleInstanceID <= 0)
                return new EmptyResult();


            string IOPath = FilePath + "HTML_" + ModuleInstanceID + ".html";


            if (!System.IO.File.Exists(IOPath))
                return new EmptyResult();


            string htmlContent =
                System.IO.File.ReadAllText(IOPath);


            this.ViewData["Context"] = htmlContent;
            return PartialView();
        }
    }
}