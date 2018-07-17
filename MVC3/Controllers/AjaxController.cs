using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC3.Controllers
{
    public class AjaxController : Controller
    {
        // GET: Ajax
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult GoHome()
        {
            string url = Url.Action("Index", "Home");

            return Json(url);
        }


        public ActionResult GetVillage(int id = -1)
        {
            List<Village> list = new List<Village>()
            {
                new Village() { VillageId = 1, VillageName = "First" },
                new Village() { VillageId = 2, VillageName = "Second" },
            };


            if (id > -1)
                list = list.Where(obj => obj.VillageId == id).ToList();


            string result = "";
            if (list.Count <= 0)
            {
                //讀取資料庫錯誤
                result = JsonConvert.SerializeObject(new List<Village>());
                return Json(result);
            }
            else
            {
                result = JsonConvert.SerializeObject(list);
                return Json(result);
            }
        }
    }


    internal class Village
    {
        public int VillageId { get; set; }

        public string VillageName { get; set; }
    }
}