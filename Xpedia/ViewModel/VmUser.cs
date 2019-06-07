using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Xpedia.Models;

namespace Xpedia.ViewModel
{
    public class VmUser
    {
        public User User { get; set; }
        public List<Order> Orders { get; set; }
        public List<Car> Cars { get; set; }
        public List<CarModel> CarModels { get; set; }
        public List<Brand> Brands { get; set; }
    }
}