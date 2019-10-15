using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace InvestmentManagementSystem.Models
{
    public class DataContext:DbContext
    {
        public DataContext()
        {

        }
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Idea> Idea { get; set; }
        public DbSet<Request> Request { get; set; }
        public DbSet<Appointment> Appointment { get; set; }
    }
}