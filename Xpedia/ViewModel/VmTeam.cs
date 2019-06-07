using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Xpedia.Models;
namespace Xpedia.ViewModel
{
    public class VmTeam
    {
        public List<Team> Teams { get; set; }
        public List<LogoSlider> Logos { get; set; }
        public List<Driver> Drivers { get; set; }
    }
}