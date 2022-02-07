using AnalyticsProject.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AnalyticsProject.DataModels
{
    public class Event
    {
        public Guid Id { get; set; }
        public string Hashtag { get; set; }
        public virtual FilterVM Filter { get; set; }
        public virtual List<SummaryInformationVM> EventStats { get; set; }

    } 
}