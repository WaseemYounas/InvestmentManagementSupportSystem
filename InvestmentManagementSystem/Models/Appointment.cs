using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InvestmentManagementSystem.Models
{
    public class Appointment
    {
        [Key]
        public int appId { get; set; }
        public DateTime appDate { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public int ideaId { get; set; }
        public virtual Idea Idea { get; set; }
        public DateTime createdAt { get; set; }
        public int senderId { get; set; }
    }
}