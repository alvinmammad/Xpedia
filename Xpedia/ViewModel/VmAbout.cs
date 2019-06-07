using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Xpedia.Models;
namespace Xpedia.ViewModel
{
    public class VmAbout
    {
        public AboutStory About { get; set; }
        public List<Fact> Facts { get; set; }
        public List<Team> Teams { get; set; }
        public List<LogoSlider> Logos { get; set; }
    }
}