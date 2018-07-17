using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Created()
        {
            string Name = Request.Form["Name"];
            string Gender = Request.Form["Gender"];
            string Region = Request.Form["Region"];
            string Desc = Request.Form["Desc"];


            Models.RegisterViewModel model = new Models.RegisterViewModel()
            {
                Name = Name,
                Gender = Gender,
                Region = Region,
                Desc = Desc
            };

            
            return View(model);
        }



        public ActionResult AjaxGo()
        {
            return View();
        }
    }
}