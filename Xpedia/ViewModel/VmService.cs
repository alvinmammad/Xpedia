using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Xpedia.Models;
namespace Xpedia.ViewModel
{
    public class VmService
    {
        public Service Service { get; set; }
        public List<ServiceCard> Cards { get; set; }
        public List<LogoSlider> Logos { get; set; }
        public Testimonial Testimonial { get; set; }
        public List<TestimonialItem> TestimonialItems { get; set; }
        public TestimonialRole TestimonialRole { get; set; }
    }
}