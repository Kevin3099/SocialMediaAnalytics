using AnalyticsProject.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnalyticsProject.Services
{
    public interface ITwitterService
    {
        void GetRecentTweetStats();
        void GetTweetStatsBetweenDates();
        void GetTweetStatsForMatchingTerms();
        void GetTweetBetweenDateForTerm();

    }
    public class TwitterService : ServiceBase, ITwitterService
    {
        public TwitterService(SMAContext ctx) : base(ctx)
        {
        }

        void ITwitterService.GetRecentTweetStats()
        {
            throw new NotImplementedException();
        }

        void ITwitterService.GetTweetStatsBetweenDates()
        {
            throw new NotImplementedException();
        }

        void ITwitterService.GetTweetStatsForMatchingTerms()
        {
            throw new NotImplementedException();
        }

        void ITwitterService.GetTweetBetweenDateForTerm()
        {
            throw new NotImplementedException();
        }
    }
}
