﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TouristAgency.ViewModels.Client
{
    public class FilterClientViewModel
    {
        public string SelectedLastName { get; set; }

        public FilterClientViewModel(string selectedLastName)
        {
            SelectedLastName = selectedLastName;
        }
    }
}
