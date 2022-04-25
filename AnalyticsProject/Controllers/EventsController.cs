using AnalyticsProject.Services;
using AnalyticsProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nancy.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AnalyticsProject.Controllers
{
    [Route("api/Event")]
    [ApiController]
  //  [Authorize]
  // Setting up Events Controller
    public class EventsController : ControllerBaseX
    {
        // Defining services to be used
        public IEventsService Svc { get; }
        public EventsController(IEventsService eventsService)
        {
            Svc = eventsService;
        }

        //Method to Call Service and use Search Event Method
        [HttpGet]
        [Route("SearchEvent")]
        public ActionResult<EventsVM> SearchEvent(DateTime toDate, DateTime fromDate, string platform, string hashtag)
        {
            FilterVM filter = new FilterVM()
            {
                DateTo = toDate,
                DateFrom = fromDate,
                Platform = platform
            };

            EventsVM newEvent = new EventsVM() { 
            Hashtag = hashtag,
            DateFrom = filter.DateFrom,
            DateTo = filter.DateTo
            };

            var result = Execute(Svc.SearchEvent, newEvent);
            return result;
        }
        // Calls MyEvents when API is called
        [HttpGet]
        [Route("MyEvents")]
        public ActionResult<List<EventsVM>> MyEvents()
        {
            var result = Execute(Svc.MyEvents);
            return result;
        }
        // Calls Filtered My Events when API is Called
        [HttpGet]
        [Route("FilteredMyEvents")]
        public ActionResult<List<EventsVM>> FilteredMyEvents(FilterVM filter, string hashtag)
        {

            var result = Execute(Svc.FilteredMyEvents,filter,hashtag);
            return result;
        }

        // Calls Compare Events when API is Called
        [HttpGet]
        [Route("CompareEvents")]
        public ActionResult<ComparedStatsVM> CompareEvents(string platform, string hashtag0, string hashtag1, string hashtag2, string hashtag3) {
            List<EventsVM> myEventsList = new List<EventsVM>();

            // Can compare up to 5 different events from the JQuery String
            EventsVM myEvent = new EventsVM();
            EventsVM myEvent1 = new EventsVM();
            EventsVM myEvent2 = new EventsVM();
            EventsVM myEvent3 = new EventsVM();
            EventsVM myEvent4 = new EventsVM();

            myEvent.Hashtag = hashtag0;
            myEventsList.Add(myEvent);

            myEvent2.Hashtag = hashtag1;
            myEventsList.Add(myEvent2);

            myEvent3.Hashtag = hashtag2;
            myEventsList.Add(myEvent3);

            myEvent4.Hashtag = hashtag3;
            myEventsList.Add(myEvent4);

            var result = Execute(Svc.CompareEvents, myEventsList, platform);
            return result;
        }
    }
}
