using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Xpedia.Models;

namespace Xpedia.ViewModel
{
    public class VmSearchingCar
    {
        public int? PickUpLocation { get; set; }
        public int? DropOffLocation { get; set; }
        public DateTime PickUpDate { get; set; }
        public DateTime DropOffDate { get; set; }
    }
}