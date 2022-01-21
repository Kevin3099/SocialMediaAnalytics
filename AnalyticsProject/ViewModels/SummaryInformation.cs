using AnalyticsProject.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AnalyticsProject.ViewModels
{
    public class SummaryInformationVM
    {
        [Required]
        public virtual TwitterSummary TwitterSummarys { get; set; }
        public virtual FacebookSummary FacebookSummarys { get; set; }
        public virtual LinkedInSummary LinkedInSummarys { get; set; }

        public SummaryInformationVM() {
        }

        public SummaryInformationVM(TwitterSummary twitter,FacebookSummary facebook, LinkedInSummary linkedIn)
        {
            TwitterSummarys = twitter;
            FacebookSummarys = facebook;
            LinkedInSummarys = linkedIn;
        }
    }
}
