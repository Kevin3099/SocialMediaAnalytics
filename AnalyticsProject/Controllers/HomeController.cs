﻿using AnalyticsProject.Services;
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
    [Route("api/Home")]
    [ApiController]
   // [Authorize]
    public class HomeController : ControllerBaseX
    {
        public IHomePageService Svc { get; }
        public HomeController(IHomePageService homePageService)
        {
            Svc = homePageService;
        }

        [HttpGet()]
       // [ResponseCache(Duration = 1)]
        [Route("Get")]
        public string Get()
        {
            return "Hello";
        }

    /*    [HttpGet()]
        [Route("Get1")]
        public ActionResult<List<HomePageVM>> Get1()
        {
            var result = Execute(Svc.GetNames);
            return result;
        }

          [HttpPost]
          [Route("Add")]
          public ActionResult<VM> Add([FromBody] VM add)
          {
              var result = Execute(Svc.Add, add);
              return result;
          }*/
    }
}
