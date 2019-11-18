using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvestmentManagementSystem.Models
{
    public class EventDTO
    {
        public string title = "";
        public string description = "";
        public string start = DateTime.Now.ToShortDateString();
        public string className = "m-fc-event--light m-fc-event--solid-warning";
        
    }
}