using AnalyticsProject.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnalyticsProject.Services
{
    public interface IFacebookService
    {
        void GetNames();
    }
    public class FacebookService : ServiceBase, IFacebookService
    {
        public FacebookService(SMAContext ctx) : base(ctx)
        {
        }

        public void GetNames()
        {

            //  return vm;
        }
    }
}
