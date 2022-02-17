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
        [Route("AllDataLastWeek")]
        public ActionResult<List<SummaryInformationVM>> getAll()
        {
            var result = Execute(Svc.GetAll);
            return result;
        }

        [HttpGet]
        [Route("filteredDataByDateAndPlatform")]
        public ActionResult<List<SummaryInformationVM>> FilteredGet(DateTime toDate,DateTime fromDate,string platform)
        {
            var filter = new FilterVM
            {
                DateTo = toDate,
                DateFrom = fromDate,
                Platform = platform
            };

            var result = Execute(Svc.FilteredGet, filter);
            return result;
        }
    

    [HttpGet]
    [Route("DeleteData")]
    public void DeleteAll()
    {
        Execute(Svc.DeleteAll);
    }

    [HttpGet]
    [Route("GenerateData")]
    public ActionResult<List<SummaryInformationVM>> GenerateData(DateTime toDate, DateTime fromDate, string platform,string user)
    {
        var filter = new FilterVM
        {
                DateTo = toDate,
                DateFrom = fromDate,
                Platform = platform
        };

        var result = Execute(Svc.GenerateData, filter, user);
        return result;
    }
    }
}
//getall
//filteredGet
//deleteAll
//generate data