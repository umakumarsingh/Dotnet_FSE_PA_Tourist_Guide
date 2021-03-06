﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TouristGuide.BusinessLayer.ViewModel
{
    public class ContactUsViewModel
    {
        public string FullName { get; set; }
        public double Phone { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public DateTime DateofMessage { get; set; }
    }
}
