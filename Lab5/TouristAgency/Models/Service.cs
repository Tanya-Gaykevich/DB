﻿using System;
using System.Collections.Generic;

namespace TouristAgency.Models
{
    public partial class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }
    }
}
