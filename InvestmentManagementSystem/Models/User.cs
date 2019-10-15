using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InvestmentManagementSystem.Models
{
    public class User
    {
        [Key]
        public int userId { get; set; }
        public int firstLogin { get; set; }
        public int isActive { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string path { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string gender { get; set; }
        public DateTime createdAt { get; set; }
        public int roleId { get; set; }
        public virtual Role Role { get; set; }
        public ICollection<Idea> Ideas { get; set; }
    }
}