using AnalyticsProject.DataModels;
using AnalyticsProject.Helpers;
using AnalyticsProject.Properties;
using AnalyticsProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnalyticsProject.Services
{
    public interface ISummaryInformationService
    {
        public List<SummaryInformationVM> FilteredGet(FilterVM filter);
        public List<SummaryInformationVM> GetAll();
        public void DeleteAll();
        public void GenerateData(FilterVM filter, string user);

    }
    public class SummaryInformationService : ServiceBase, ISummaryInformationService
    {
        public SummaryInformationService(SMAContext ctx) : base(ctx)
        {
        }

        public List<SummaryInformationVM> GetAll()
        {
           // GenerateData()
            List<SummaryInformationVM> db = new List<SummaryInformationVM>();
            var SIList = Ctx.SummaryInformations
                .Where(x => x.DateTo.Date == DateTime.Now.Date && x.DateFrom.Date == DateTime.Now.AddDays(-7).Date)
                .Select(x => new SummaryInformationVM(x)).ToList();
            return SIList;
        }

        public List<SummaryInformationVM> FilteredGet(FilterVM filter)
        {
            if (filter.Platform == "All Platforms") {
             
                var SIList = Ctx.SummaryInformations
                             .Where(x => x.DateTo.Date == filter.DateTo.Date && x.DateFrom.Date == filter.DateFrom.Date)
                             .Select(x => new SummaryInformationVM(x)).ToList();
                return SIList;
            }
            else
            {
                var SIList = Ctx.SummaryInformations
                            .Where(x => x.DateTo.Date == filter.DateTo.Date && x.DateFrom.Date == filter.DateFrom.Date && filter.Platform == x.Platform)
                            .Select(x => new SummaryInformationVM(x)).ToList();
                return SIList;
            }
        }

        //Note this Method has to call a lot of different endpoints and API's so may take some time.
        public async void GenerateData(FilterVM filter, string user)
        {
            user = "KevsterO98";
            Facebook facebook = new Facebook();
            LinkedIn linkedIn = new LinkedIn();
            Twitter twitter = new Twitter(Constants.consumerKey, Constants.consumerKeySecret, Constants.access_token, Constants.access_token_secret);
           
            var fbList = Ctx.FacebookDbs
              .Where(x => x.DatePosted <= filter.DateTo && x.DatePosted >= filter.DateFrom)
              .Select(x => new FacebookDbVM(x)).ToList();

            var LiList = Ctx.LinkedInDbs
               .Where(x => x.DatePosted <= filter.DateTo && x.DatePosted >= filter.DateFrom)
               .Select(x => new LinkedInDbVM(x)).ToList();

            Ctx.SummaryInformations.Add(facebook.GetSummaryInformationForUser(user, filter, fbList));
            Ctx.SummaryInformations.Add(linkedIn.GetSummaryInformationForUser(user, filter,LiList));
            Ctx.SummaryInformations.Add(twitter.GetSummaryInformationForUser(user));
            Ctx.SaveChanges();
        }

        public void DeleteAll() {
            var rows = from o in Ctx.SummaryInformations
                       select o;
            foreach (var row in rows)
            {
                Ctx.SummaryInformations.Remove(row);
            }
            Ctx.SaveChanges();
        }
    }
}
