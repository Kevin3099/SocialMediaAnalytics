using AnalyticsProject.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AnalyticsProject.ViewModels
{
    public class ComparedStatsVM
    {
        public Guid Id { get; set; }
        public int averageFollowerIncrease { get; set; }
        public int averageLikesIncrease { get; set; }
        public int averageRetweetsIncrease { get; set; }
        public int averageCommentsIncrease { get; set; }
        public List<DateTime> bestPostTime { get; set; }
        public List<string> mostCommonEffectiveWords { get; set; }
        public List<FacebookDbVM> top5Posts { get; set; }
        public List<EventsVM> EventsUsed { get; set; }
        
        public ComparedStatsVM() {
        }
    }
}
