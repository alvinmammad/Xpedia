using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Xpedia.Models
{
    


    public enum TwoAirs
    {
        Var=1,
        Yoxdur=2
    }
    public enum Fuels
    {
        Benzin=1,
        Dizel=2,
        Qaz=3
    }
    public enum Transmissions
    {
        Avtomat=1,
        Mexanika=2,
        Avtomatlaşdırılmışmexanika=3,
        Davamlıdəyişənötürücü=4
    }
    public enum CarTypes
    {
        Hatchback=1,
        Sedan=2,
        MPV=3,
        SUV=4,
        Crossover=5,
        Coupe=6
    }
    public class Car
    {
        [Required]
        public int ID { get; set; }
        [Column(TypeName ="money")]
        public int PricePerDay { get; set; }
        [Column(TypeName ="ntext")]
        public string Information { get; set; }
        public TwoAirs TwoAir { get; set; }
        public Fuels Fuel { get; set; }
        public Transmissions Transmission { get; set; }
        public CarTypes CarType { get; set; }
        public string Year { get; set; }
        public decimal EngineCapacity { get; set; }
        public decimal EnginePower { get; set; }
        public bool IsRented { get; set; }
        [Column(TypeName ="money")]
        public int Discount { get; set; }
        public int SeatCount { get; set; }
        [Column(TypeName ="ntext")]
        public string Image { get; set; }
        public int CarModelID { get; set; }
        public virtual CarModel CarModel { get; set; }
        public int LocationID { get; set; }
        public Location Location { get; set; }
        public List<Order> Orders { get; set; }
        
    }
    
}