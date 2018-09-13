using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.DataModels
{
    public class GuestBookData
    {
        public int GBID { get; set; }

        public int PageModuleID { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public int? ReplyGBID { get; set; }

        public int? Creator { get; set; }

        public DateTime? CreateDate { get; set; }

        public int? Updator { get; set; }

        public DateTime? UpdateDate { get; set; }
    }
}