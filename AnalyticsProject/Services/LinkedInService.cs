using AnalyticsProject.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnalyticsProject.Services
{
    public interface ILinkedInService
    {
        void GetNames();
    }
    public class LinkedInService : ServiceBase, ILinkedInService
    {
        public LinkedInService(SMAContext ctx) : base(ctx)
        {
        }

        public void GetNames()
        {

            //  return vm;
        }
    }
}
