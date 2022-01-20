﻿using AnalyticsProject.Services;
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
    public class HomeController : Controller
    {
        public IHomePageService Svc { get; }
        public HomeController(IHomePageService homePageService)
        {
            Svc = homePageService;
        }

     /*   [HttpGet()]
        [ResponseCache(Duration = 1)]
        [Route("Get")]
        public ActionResult<List<getVM>> Get()
        {
            var result = Execute(Svc.Get);
            return result;
        }

        [HttpPost]
        [Route("Add")]
        public ActionResult<VM> Add([FromBody] VM add)
        {
            var result = Execute(Svc.Add, add);
            return result;
        }
     */
    }
}
