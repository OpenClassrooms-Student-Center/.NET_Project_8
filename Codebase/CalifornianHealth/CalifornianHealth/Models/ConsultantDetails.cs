using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;


namespace CalifornianHealth.Models
{
    public class ConsultantDetails
    {
        public int consultantId { get; set; }
        public string consultantName { get; set; }
        public string consultantSpeciality { get; set; }
        public int facilityId { get; set; }
    }
}