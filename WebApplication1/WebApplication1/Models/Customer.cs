﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Customer
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public bool IsVip { get; set; }
    }
}
