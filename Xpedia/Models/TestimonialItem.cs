using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Xpedia.Models
{
    public class TestimonialItem
    {
        public int ID { get; set; }
        public string Photo { get; set; }
        public string Review { get; set; }
        public string Fullname { get; set; }
        public int TestimonialRoleID { get; set; }
        public TestimonialRole TestimonialRole { get; set; }
    }
}