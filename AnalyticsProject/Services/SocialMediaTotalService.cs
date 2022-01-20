using AnalyticsProject.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnalyticsProject.Services
{
    public interface ISocialMediaTotalService
    {
        void GetNames();
    }
    public class SocialMediaTotalService : ServiceBase, ISocialMediaTotalService
    {
        public SocialMediaTotalService(SMAContext ctx) : base(ctx)
        {
        }

        public void GetNames()
        {

            //  return vm;
        }
    }
}
