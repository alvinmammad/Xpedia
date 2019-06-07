using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Xpedia.Models;
namespace Xpedia.ViewModel
{
    public class VmCarCheckout
    {
        public VmSearchingCar SearchingCar { get; set; }
        public Car SelectedCar { get; set; }
        public CarModel CarModel { get; set; }
        public Brand Brand { get; set; }
        public User User { get; set; }
        public int OrderNumber { get; set; }
    }
}