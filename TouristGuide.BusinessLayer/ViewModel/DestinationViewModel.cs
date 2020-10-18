using System;
using System.Collections.Generic;
using System.Text;
using TouristGuide.Entities;

namespace TouristGuide.BusinessLayer.ViewModel
{
    public class DestinationViewModel
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public bool OpenInNewWindow { get; set; }
        public string Description { get; set; }
        public ICollection<Place> Places { get; set; }
    }
}
