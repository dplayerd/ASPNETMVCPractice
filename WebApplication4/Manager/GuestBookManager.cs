using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using WebApplication4.DataModels;

namespace WebApplication4.Manager
{
    public class GuestBookManager
    {
        string FilePath =
                HttpContext.Current.Server.MapPath("~/App_Data/GuestBookData.json");

        private List<GuestBookData> readAll()
        {
            if (!File.Exists(FilePath))
                return new List<GuestBookData>();


            string jsonContent =
                File.ReadAllText(FilePath);


            var list =
                JsonConvert.DeserializeObject<List<GuestBookData>>(jsonContent);

            return list;
        }


        private void writeAll(List<GuestBookData> list)
        {
            if (!File.Exists(FilePath))
                return;


            string jsonContent =
                JsonConvert.SerializeObject(list);


            File.WriteAllText(FilePath, jsonContent);
        }



        public List<GuestBookData> GetGuestBookRootList(int PageModuleID, int? MasterGBID = null)
        {
            var sourceList = this.readAll();


            // 主貼文的 MasterGBID = null
            // 回文的 MasterGBID != null
            var result =
                from item in sourceList
                where 
                    PageModuleID == item.PageModuleID &&
                    MasterGBID == item.ReplyGBID 
                select item;


            return result.ToList();
        }


        public void CreateGuestBook(GuestBookData guestBook)
        {
            var sourceList = this.readAll();

            sourceList.Add(guestBook);

            this.writeAll(sourceList);
        }
    }
}