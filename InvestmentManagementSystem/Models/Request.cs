using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InvestmentManagementSystem.Models
{
    public class Request
    {
        [Key]
        public int reqId { get; set; }
        
        public int ideaId { get; set; }
        public virtual Idea Idea { get; set; }
        public DateTime createdAt { get; set; }
        public int senderId { get; set; }
        public int incubatorId { get; set; }

    }
}