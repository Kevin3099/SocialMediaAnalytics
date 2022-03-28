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
          //  List<TwitterMLDb> data = twitter.GetTimeLineTweets("KevsterO98");
            List<TwitterMLDb> moreData = twitter.GetRelatedTweets("KevsterO98","RocketLeague");
        //    data.AddRange(moreData);
            foreach(var x in moreData)
            {
                Ctx.TwitterMLDbs.Add(x);
            }
            Ctx.SaveChanges();
        }   

        public PredictedPostVM PostPrediction(PredictedPostVM myPost) {
            return null;
        }
    }
}

// STEPS 
// Get Data in, Get Parameters off User - Time planned to post - Hashtags - User - Followers
// Check for sufficient data to make a prediction 
// if yes continue if no stop
// if yes - bring in all data, (All posts using hashtag within time limit by users with similar following) 
// split into train and test
// remove outliers on train
// Check a few models
// Use best predictor
// test all on test data
// return percentage accuracy
// Generate prediction for users post