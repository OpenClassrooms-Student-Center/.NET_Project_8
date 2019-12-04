using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalifornianHealth.Models
{
    public class ConsultantCalendar
    {
        public int id { get; set; }
        public int consultantId { get; set; }
        public List<DateTime> availableDates { get; set; }
    }
}