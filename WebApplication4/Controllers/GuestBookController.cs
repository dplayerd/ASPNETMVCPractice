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
        GuestBookManager gbMgr = new GuestBookManager();



        // GET: GuestBook
        public ActionResult Index(int ModuleInstanceID = 0, int? MasterGBID = null)
        {
            var act = this.RouteData.Values["action"] as string;
            var ctl = this.RouteData.Values["controller"] as string;
            var id = this.RouteData.Values["id"] as string;


            List<GuestBookData> source =
                this.gbMgr.GetGuestBookRootList(ModuleInstanceID, MasterGBID);


            return PartialView(source);
        }


        public ActionResult Create(int ModuleInstanceID = 0, int? MasterGBID = null)
        {
            var act = this.RouteData.Values["action"] as string;
            var ctl = this.RouteData.Values["controller"] as string;
            var id = this.RouteData.Values["id"] as string;


            List<GuestBookData> guestList =
                this.gbMgr.GetGuestBookRootList(ModuleInstanceID, MasterGBID);


            return PartialView(guestList);
        }
    }
}