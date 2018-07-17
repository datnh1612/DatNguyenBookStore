﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreWeb.Models
{
    public class SystemConfigViewModel
    {
        public int ID { get; set; }

        public string Code { get; set; }

        public string ValueString { get; set; }

        public int? ValueInt { get; set; }
    }
}