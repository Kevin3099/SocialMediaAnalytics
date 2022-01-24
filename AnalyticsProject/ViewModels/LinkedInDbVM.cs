using AnalyticsProject.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AnalyticsProject.ViewModels
{
    public class LinkedInDbVM
    {
        [Required]
        public Guid Id { get; set; }
        public DateTimeOffset DatePosted { get; set; }
        public string content { get; set; }
        public int likes { get; set; }
        public int retweets { get; set; }
        public int comments { get; set; }

        public LinkedInDbVM() {
        }

        public LinkedInDbVM(LinkedInDb li)
        {
            Id = li.Id;
            DatePosted = li.DatePosted;
            content = li.content;
            likes = li.likes;
            retweets = li.retweets;
            comments = li.comments;
        }
    }
}
