using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Xpedia.Models;
namespace Xpedia.ViewModel
{
    public class VmCar
    {
        public List<Car> Cars { get; set; }
        public List<Order> Orders { get; set; }
        public CarModel CarModel { get; set; }
        public List<CarModel> CarModels { get; set; }
        public List<Brand> Brands { get; set; }
        public int TotalPage { get; set; }
        public int Page { get; set; }
    }
}