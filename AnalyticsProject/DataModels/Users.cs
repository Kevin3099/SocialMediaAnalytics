using System;
using System.ComponentModel.DataAnnotations;

namespace AnalyticsProject.DataModels
{
    public class Users
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
    } 
}