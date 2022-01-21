using AnalyticsProject.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AnalyticsProject.ViewModels
{
    public class MachineLearningVM
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }

        public MachineLearningVM() {
        }

        public MachineLearningVM(HomePage homePage)
        {
            Id = homePage.Id;
            Name = homePage.Name;
        }
    }
}
