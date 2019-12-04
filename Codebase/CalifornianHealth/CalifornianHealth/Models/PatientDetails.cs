using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace CalifornianHealth.Models
{
    public class PatientDetails
    {
        public int patientId { get; set; }
        public string patientName { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string Region { get; set; }

        public string City { get; set; }

        public string Postcode { get; set; }

        public string contactNumber { get; set; }
    }
}