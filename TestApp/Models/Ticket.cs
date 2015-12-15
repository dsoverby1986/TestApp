using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApp.Models
{
    public class Ticket
    {
        public string Project { get; set; }
        public int ClientNumber { get; set; }
        public int OrderNumber { get; set; }
        public string Summary { get; set; }
        public string Reason { get; set; }
        public string Issue { get; set; }
    }
}