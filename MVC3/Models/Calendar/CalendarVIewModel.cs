using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC3.Models.Calendar
{
    public class CalendarVIewModel
    {
        public int CalendarID { get; set; }
        public string CalendarName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}