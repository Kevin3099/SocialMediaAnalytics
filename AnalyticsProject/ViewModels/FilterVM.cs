using AnalyticsProject.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AnalyticsProject.ViewModels
{
    public class FilterVM
    {
        [Required]
        public Guid Id { get; set; }
        public DateTimeOffset DateFrom { get; set; }
        public DateTimeOffset DateTo { get; set; }
        public string Platform { get; set; }

        public FilterVM() {
        }

        public FilterVM(SummaryInformation filter)
        {
            Id = filter.Id;
            DateTo = filter.DateTo;
            DateFrom = filter.DateFrom;
            Platform = filter.Platform;
        }
    }
}
