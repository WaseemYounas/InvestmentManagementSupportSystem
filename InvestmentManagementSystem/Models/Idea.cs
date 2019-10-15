using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InvestmentManagementSystem.Models
{
    public class Idea
    {
        [Key]
        public int ideaId { get; set; }
        public double amount { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public DateTime createdAt { get; set; }
        public int incubatorId { get; set; }
        public int userId { get; set; }
        public virtual User User { get; set; }
        

    }
}