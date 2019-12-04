using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalifornianHealth.Models
{
    public class BookingModel
    {
        public PatientDetails patient { get; set; }
        public ConsultantDetails consultant { get; set; }
        public FacilityDetails facility { get; set; }
        public PaymentDetails payment { get; set; }
        public AppointmentDetails appointment { get; set; }
    }


}