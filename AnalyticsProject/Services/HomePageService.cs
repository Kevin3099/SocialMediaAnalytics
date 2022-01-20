using AnalyticsProject.DataModels;
using AnalyticsProject.ViewModels;
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
    public class HomePageService : ServiceBase,IHomePageService
    {
        public HomePageService(SMAContext ctx) : base(ctx)
        {
        }

        public void GetNames()
        {
            var db = Ctx.HomePages.ToList();
            var vm = new List<HomePageVM>();

            foreach (var homePage in db)
            {
                var homeVM = new HomePageVM(homePage);
                vm.Add(homeVM);
            }
          //  return vm;
        }
    }
}
