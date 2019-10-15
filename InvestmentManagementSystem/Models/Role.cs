using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InvestmentManagementSystem.Models
{
    public class Role
    {
        [Key]
        public int roleId { get; set; }
        public string roleName { get; set; }
        public ICollection<User> Users { get; set; }
    }
}