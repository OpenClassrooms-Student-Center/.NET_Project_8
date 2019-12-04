using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace CalifornianHealth.Models
{
    public class AppointmentDetails
    {
        public int appointmentId { get; set; }
        public DateTime appointmentDate { get; set; }
        public DateTime appointmentTime { get; set; }


    }
}