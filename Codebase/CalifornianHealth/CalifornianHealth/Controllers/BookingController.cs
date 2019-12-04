using CalifornianHealth.Models;
using CalifornianHealth.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CalifornianHealth.Controllers
{
    public class BookingController : Controller
    {
        CFRepository _cfRepository;

        public BookingController(CFRepository cfRepository)
        {
            _cfRepository = cfRepository;
        }

        // GET: Booking
        public ActionResult Index()
        {
            return View();
        }

        //TODO: Change this method to ensure that members do not have to wait endlessly. 
        public ActionResult BookAppointment(BookingModel bookingModel)
        {
            bool createdBooking = _cfRepository.CreateBooking(bookingModel);

            if (createdBooking)
                return View();

            return View("Error");
        }

        //TODO: Change this method to display the consultant calendar. Ensure that the user can have a real time view of 
        //the consultant's availability;
        public ActionResult GetConsultantCalendar(int consultantId, DateTime requestedDate, DateTime requestedTime)
        {
            ConsultantCalendar consultant = _cfRepository.GetConsultantCalendar(consultantId);

            if (consultant.availableDates.Any(a => a.Date == requestedDate.Date))
            {
                if (consultant.availableDates.Any(a => a.TimeOfDay == requestedTime.TimeOfDay))
                {
                    //set availability and return view. Can the user have a real time view?
                }
                else
                {
                    //no availability; what do we do?
                }
            }

            //No availability; what do we do?

            return View();
        }
    }
}