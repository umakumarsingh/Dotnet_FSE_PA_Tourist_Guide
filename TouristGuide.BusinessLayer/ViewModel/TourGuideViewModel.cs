using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TouristGuide.BusinessLayer.ViewModel
{
    public class TourGuideViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public long Phone { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        public string Experience { get; set; }
        public string Remark { get; set; }
    }
}
