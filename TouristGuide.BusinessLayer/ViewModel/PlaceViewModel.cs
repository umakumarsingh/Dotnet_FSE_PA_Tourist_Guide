using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TouristGuide.Entities;

namespace TouristGuide.BusinessLayer.ViewModel
{
    public class PlaceViewModel
    {
        [Required]
        public string Name { get; set; }
        public string Picture { get; set; }
        public string Description { get; set; }
        public string Attraction { get; set; }
        //public int Category { get; set; }
        public string Experiences { get; set; }
        public int Distance { get; set; }
        [Required]
        public string DestinationId { get; set; }
        public Destination Destination { get; set; }
    }
}
