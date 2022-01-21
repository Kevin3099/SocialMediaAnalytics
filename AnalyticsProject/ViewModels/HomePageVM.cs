﻿using AnalyticsProject.DataModels;
using System;
using System.ComponentModel.DataAnnotations;

namespace AnalyticsProject.ViewModels
{
    public class HomePageVM
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }

        public HomePageVM()
        {
        }

        public HomePageVM(HomePage homePage)
        {
            Id = homePage.Id;
            Name = homePage.Name;
        }
    }
}
