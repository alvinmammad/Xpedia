using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Xpedia.Models;

namespace Xpedia.ViewModel
{
    public class VmCarDetail
    {
        public Car Car { get; set; }
        public Brand Brand { get; set; }
        public CarModel CarModel { get; set; }
    }
}