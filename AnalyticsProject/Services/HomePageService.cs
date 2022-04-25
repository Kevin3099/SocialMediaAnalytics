using AnalyticsProject.DataModels;
using AnalyticsProject.ViewModels;
using AnalyticsProject.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnalyticsProject.Services
{
    public interface IHomePageService
    {
        void GetNames();
    }
    public class HomePageService : ServiceBase, IHomePageService
    {
        public HomePageService(SMAContext ctx) : base(ctx)
        {
        }

        public void GetNames()
        {
        } 
    }
}
