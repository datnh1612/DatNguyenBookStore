﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreWeb.Models
{
    public class SupportOnlineViewModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Department { get; set; }

        public string Skype { get; set; }

        public string Mobile { get; set; }

        public string Email { get; set; }

        public string Yahoo { get; set; }

        public string Facebook { get; set; }

        public bool Status { get; set; }

        public int? DisplayOrder { get; set; }
    }
}