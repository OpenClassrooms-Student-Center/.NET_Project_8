using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace CalifornianHealth.Models
{
    public class FacilityDetails
    {
        public int facilityId { get; set; }
        public string facilityName { get; set; }
        public string facilityAddressLine1 { get; set; }

        public string facilityAddressLine2 { get; set; }

        public string facilityRegion { get; set; }

        public string facilityCity { get; set; }

        public string facilityPostcode { get; set; }

        public string facilityContactNumber { get; set; }
    }
}