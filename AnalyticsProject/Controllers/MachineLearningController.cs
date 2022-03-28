using AnalyticsProject.Services;
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
    [Route("api/Home")]
    [ApiController]
    [Authorize]
    public class MachineLearningController : Controller
    {
        public IMachineLearningService Svc { get; }
        public MachineLearningController(IMachineLearningService machineLearningService)
        {
            Svc = machineLearningService;
        }
    }
}
