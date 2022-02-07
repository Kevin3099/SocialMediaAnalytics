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
        public List<SummaryInformationVM> filteredGet(FilterVM filter);
        public List<SummaryInformationVM> GetAll();

    }
    public class SummaryInformationService : ServiceBase, ISummaryInformationService
    {
        public SummaryInformationService(SMAContext ctx) : base(ctx)
        {
        }
        public List<SummaryInformationVM> filteredGet(FilterVM filter)
        {
           
            if (filter.Platform == "All Platforms") {
             
                var SIList = Ctx.SummaryInformations
                             .Where(x => x.DateTo == filter.DateTo && x.DateFrom == filter.DateFrom)
                             .Select(x => new SummaryInformationVM(x)).ToList();
                return SIList;
            }
            else
            {
                var SIList = Ctx.SummaryInformations
                            .Where(x => x.DateTo == filter.DateTo && x.DateFrom == filter.DateFrom && filter.Platform == x.Platform)
                            .Select(x => new SummaryInformationVM(x)).ToList();
                return SIList;
            }
        }

        public List<SummaryInformationVM> GetAll()
        {

            List<SummaryInformationVM> db = new List<SummaryInformationVM>();
            var SIList = Ctx.SummaryInformations
                .Where(x => x.DateTo == DateTime.Now.Date && x.DateFrom == DateTime.Now.AddDays(-7).Date)
                .Select(x => new SummaryInformationVM(x)).ToList();
            return SIList;
        }
        public void GenerateData()
        {
            FilterVM filter = new FilterVM
            {
                DateFrom = DateTime.Now.AddDays(-7).Date,
                DateTo = DateTime.Now.Date
            };
            clearDB();
            GetTwitterList();

            List<FacebookDbVM> fbList = new List<FacebookDbVM>();
            fbList = GetFBList(filter);
            CreateFBSummaryInformation(filter,fbList);

            List<LinkedInDbVM> LiList = new List<LinkedInDbVM>();
            LiList = GetLiList(filter);
            CreateLISummaryInformation(filter,LiList);
        }

        public void CreateFBSummaryInformation(FilterVM filter, List<FacebookDbVM> fbList) {
            int totalLikes = 0;
            int totalRetweets = 0;
            int totalComments = 0;
            int averageLikes = 0;
            int averageRetweets = 0;
            int averageComments = 0;

            foreach (FacebookDbVM post in fbList)
            {
                totalLikes = post.likes + totalLikes;
                totalRetweets = totalRetweets + post.retweets;
                totalComments = totalComments + post.comments;
                averageLikes = totalLikes / fbList.Count;
                averageRetweets = totalRetweets / fbList.Count;
                averageComments = totalComments / fbList.Count;
            }
            var Summary = new SummaryInformation()
            {
                Platform = "Facebook",
                Id = new Guid(),
                DateFrom = filter.DateFrom,
                DateTo = filter.DateTo,
                CountOfPosts = fbList.Count,
                totalLikes = totalLikes,
                totalRetweets = totalRetweets,
                totalComments = totalComments,
                averageLikes = averageLikes,
                averageRetweets = averageRetweets,
                averageComments = averageComments,
                followerIncrease = 5,
                totalFollowers = 50
            };

            Ctx.SummaryInformations.Add(Summary);
            Ctx.SaveChanges();
        }

        public void CreateLISummaryInformation(FilterVM filter, List<LinkedInDbVM> LiList)
        {

            int totalLikes = 0;
            int totalRetweets = 0;
            int totalComments = 0;
            int averageLikes = 0;
            int averageRetweets = 0;
            int averageComments = 0;

            foreach (LinkedInDbVM post in LiList)
            {
                totalLikes = post.likes + totalLikes;
                totalRetweets = totalRetweets + post.retweets;
                totalComments = totalComments + post.comments;
                averageLikes = totalLikes / LiList.Count;
                averageRetweets = totalRetweets / LiList.Count;
                averageComments = totalComments / LiList.Count;
            }
            var Summary = new SummaryInformation()
            {
                Id = new Guid(),
                Platform = "LinkedIn",
                DateFrom = filter.DateFrom,
                DateTo = filter.DateTo,
                CountOfPosts = LiList.Count,
                totalLikes = totalLikes,
                totalRetweets = totalRetweets,
                totalComments = totalComments,
                averageLikes = averageLikes,
                averageRetweets = averageRetweets,
                averageComments = averageComments,
                followerIncrease = 5,
                totalFollowers = 50
            };

            Ctx.SummaryInformations.Add(Summary);
            Ctx.SaveChanges();
        }

        public List<LinkedInDbVM> GetLiList(FilterVM filter)
        {

            List<LinkedInDbVM> liDb = new List<LinkedInDbVM>();
            liDb = Ctx.LinkedInDbs
                .Where(x => x.DatePosted <= filter.DateTo && x.DatePosted >= filter.DateFrom)
                .Select(x => new LinkedInDbVM(x)).ToList();
            return liDb;
        }

        public List<FacebookDbVM> GetFBList(FilterVM filter) {

            List<FacebookDbVM> fbDb = new List<FacebookDbVM>();
            fbDb = Ctx.FacebookDbs
                .Where(x => x.DatePosted <= filter.DateTo && x.DatePosted >= filter.DateFrom)
                .Select(x => new FacebookDbVM(x)).ToList();
            return fbDb;
        }

        public void GetTwitterList()
        {
                  Twitter twitter = new Twitter(Constants.consumerKey, Constants.consumerKeySecret, Constants.access_token, Constants.access_token_secret);
                  Ctx.SummaryInformations.Add(twitter.GetSummaryInformation("rlcs"));
                  Ctx.SaveChanges();
        }


        public void clearDB() {
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
