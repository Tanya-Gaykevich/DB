﻿using System;
using System.Collections.Generic;

namespace TouristAgency.Models
{
    public partial class Client
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Gender { get; set; }
        public string Address { get; set; }
        public int Phone { get; set; }
        public string PassportData { get; set; }
        public int Discount { get; set; }

    }
}
