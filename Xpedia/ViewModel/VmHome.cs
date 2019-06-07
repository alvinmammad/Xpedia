using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Xpedia.Models;
namespace Xpedia.ViewModel
{
    public class VmHome
    {
        public List<ServiceCard> ServiceCards { get; set; }
        public List<Car> Cars { get; set; }
        public CarModel CarModel { get; set; }
        public List<TestimonialItem> TestimonialItems { get; set; }
        public List<LogoSlider> LogoSliders { get; set; }
        public List<Blog> Blogs { get; set; }
        public List<Location> Locations { get; set; }
        public Setting Setting { get; set; }
        public Testimonial Testimonial { get; set; }
        public TestimonialRole TestimonialRole { get; set; }
    }
}