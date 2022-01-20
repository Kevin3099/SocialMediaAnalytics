
using AnalyticsProject.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnalyticsProject.Services
{
    public class ServiceBase
    {
        protected SMAContext Ctx { get; set; }

        public ServiceBase(SMAContext ctx)
        {
            Ctx = ctx;
        }

    }
}
