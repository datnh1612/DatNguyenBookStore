using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreWeb.Models
{
    public class VisitorStatisticViewModel
    {
        public Guid ID { get; set; }

        public DateTime VisitedDate { get; set; }

        public string IPAddress { get; set; }
    }
}