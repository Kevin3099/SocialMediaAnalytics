using AnalyticsProject.DataModels;
using AnalyticsProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnalyticsProject.Services
{
    public interface ISummaryInformationService
    {
        public int CalculateAverage(List<int> numbers);
        public int CalculateTotal(List<int> numbers);
        public List<SummaryInformationVM> filteredGet(FilterVM filter);
        public List<SummaryInformationVM> GetAll();

    }
    public class SummaryInformation : ServiceBase, ISummaryInformationService
    {
        public SummaryInformation(SMAContext ctx) : base(ctx)
        {
        }


        public int CalculateAverage(List<int> numbers)
        {
            int numCount = numbers.Count();
            int nextNum = 0;
            foreach (int num in numbers)
            {
                nextNum = nextNum + num;
            }
            int average = nextNum / numCount;

            return average;
        }
        public int CalculateTotal(List<int> numbers)
        {
            int numTotal = 0;
            foreach (int num in numbers)
            {
                numTotal = numTotal + num;
            }
            return numTotal;
        }

        public List<SummaryInformationVM> filteredGet(FilterVM filter)
        {
            List<SummaryInformationVM> db = new List<SummaryInformationVM>();
            var SIList = Ctx.SummaryInformations.Where(x => x.DateTo == filter.DateTo && x.DateFrom == filter.DateFrom && filter.Platform == x.Platform).Select(x => new SummaryInformationVM(x)).ToList();
            return SIList;
        }

        public List<SummaryInformationVM> GetAll()
        {

            var fbfilter = new FilterVM()
            {
                Platform = "Facebook",
                DateFrom = DateTime.Now.AddDays(-7),
                DateTo = DateTime.Now
            };

           var fbList = GetFacebookPostStats(fbfilter);

            List<SummaryInformationVM> db = new List<SummaryInformationVM>();
            var SIList = Ctx.SummaryInformations.Select(x => new SummaryInformationVM(x)).ToList();
            return SIList;
        }

        public List<FacebookDbVM> GetFacebookPostStats(FilterVM filter) {
            List<FacebookDbVM> fbDb = new List<FacebookDbVM>();
            var fbList = Ctx.FacebookDbs
                .Where(x => x.DatePosted <= filter.DateTo && x.DatePosted >= filter.DateFrom)
                .Select(x => new FacebookDbVM(x)).ToList();

            var fbSummaryList = new SummaryInformationVM()
            {
                Id = new Guid(),
                DateFrom = filter.DateFrom,
                DateTo = filter.DateTo,
                //   CountOfPosts = CalculateTotal(fbList.)
                // totalLikes = CalculateTotal(fbList.)
                // totalRetweets = CalculateTotal(fbList.)
                // totalComments = CalculateTotal(fbList.)
                // averageLikes = CalculateAverage(fbList.)
                // averageRetweets = CalculateAverage(fbList.)
                // averageComments = CalculateAverage(fbList.)
                followerIncrease = 5,
                totalFollowers = 50
            };

            return fbDb;
        }

        public List<LinkedInDbVM> GetLinkedInPostStats(FilterVM filter)
        {
            List<LinkedInDbVM> liDb = new List<LinkedInDbVM>();
            var liList = Ctx.LinkedInDbs
                .Where(x => x.DatePosted <= filter.DateTo && x.DatePosted >= filter.DateFrom)
                .Select(x => new LinkedInDbVM(x)).ToList();

            return liDb;
        }
    }
}
