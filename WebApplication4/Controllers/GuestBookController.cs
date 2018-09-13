using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4.DataModels;
using WebApplication4.Manager;

namespace WebApplication4.Controllers
{
    public class GuestBookController : Controller
    {
        // GET: GuestBook
        public ActionResult Index(int ModuleInstanceID = 0, int? MasterGBID = null)
        {
            int PageModuleID = 0;


            List<GuestBookData> source =
                new GuestBookManager().GetGuestBookRootList(PageModuleID, MasterGBID);


            return View();
        }


        public ActionResult Create(GuestBookData data)
        {
            new GuestBookManager().CreateGuestBook(data);

            
            return View("Index");
        }
    }
}