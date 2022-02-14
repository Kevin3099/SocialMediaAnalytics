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
    public class EventsController : ControllerBaseX
    {
        public IEventsService Svc { get; }
        public EventsController(IEventsService eventsService)
        {
            Svc = eventsService;
        }

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

        [HttpGet]
        [Route("MyEvents")]
        public ActionResult<List<EventsVM>> MyEvents()
        {
            var result = Execute(Svc.MyEvents);
            return result;
        }

        [HttpGet]
        [Route("FilteredMyEvents")]
        public ActionResult<List<EventsVM>> FilteredMyEvents(FilterVM filter, string hashtag)
        {

            var result = Execute(Svc.FilteredMyEvents,filter,hashtag);
            return result;
        }
        [HttpGet]
        [Route("CompareEvents")]
        public ActionResult<ComparedStatsVM> CompareEvents(List<EventsVM> eventsList, string platform)
        {
            var result = Execute(Svc.CompareEvents,eventsList,platform);
            return result;
        }
    }
}
