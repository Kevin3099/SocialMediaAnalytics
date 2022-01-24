using AnalyticsProject.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AnalyticsProject.ViewModels
{
    public class FacebookDbVM
    {
        [Required]
        public Guid Id { get; set; }
        public DateTimeOffset DatePosted { get; set; }
        public string content { get; set; }
        public int likes { get; set; }
        public int retweets { get; set; }
        public int comments { get; set; }

        public FacebookDbVM() {
        }

        public FacebookDbVM(FacebookDb fb)
        {
            Id = fb.Id;
            DatePosted = fb.DatePosted;
            content = fb.content;
            likes = fb.likes;
            retweets = fb.retweets;
            comments = fb.comments;
        }
    }
}
