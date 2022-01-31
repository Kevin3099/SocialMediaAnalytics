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
    [Route("api/SummaryInformation")]
    [ApiController]
   // [Authorize]
    public class SummaryInformationController : ControllerBaseX
    {
        public ISummaryInformationService Svc { get; }
        public SummaryInformationController(ISummaryInformationService summaryInformationService)
        {
            Svc = summaryInformationService;
        }

        [HttpGet]
        [Route("getAll")]
        public ActionResult<List<SummaryInformationVM>> getAll()
        {
            var result = Execute(Svc.GetAll);
            return result;
        }

        [HttpGet]
        [Route("filteredData")]
        public ActionResult<List<SummaryInformationVM>> filteredGet(DateTime toDate,DateTime fromDate,string platform)
        {
            var filter = new FilterVM
            {
                DateTo = toDate,
                DateFrom = fromDate,
                Platform = platform
            };

            var result = Execute(Svc.filteredGet, filter);
            return result;
        }
    }
}
