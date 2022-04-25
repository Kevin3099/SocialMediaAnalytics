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
    public interface IMachineLearningService
    {
        void DataGeneration();
        PredictedPostVM PostPrediction(PredictedPostVM myPost);
    }
    public class MachineLearningService : ServiceBase, IMachineLearningService
    {
        public MachineLearningService(SMAContext ctx) : base(ctx)
        {
        }

        public void DataGeneration()
        {
            Twitter twitter = new Twitter(Constants.consumerKey, Constants.consumerKeySecret, Constants.access_token, Constants.access_token_secret);
            // Won't be hardcoded in the future
            List<TwitterMLDb> data = twitter.GetTimeLineTweets("KevsterO98");
            List<TwitterMLDb> moreData = twitter.GetRelatedTweets("KevsterO98","RocketLeague");
            data.AddRange(moreData);
            foreach(var x in data)
            {
                Ctx.TwitterMLDbs.Add(x);
            }
            Ctx.SaveChanges();
        }   

        public PredictedPostVM PostPrediction(PredictedPostVM myPost) {
            // ran out of time - ML in Project - Add ML - Build Model
            return null;
        }
    }
}