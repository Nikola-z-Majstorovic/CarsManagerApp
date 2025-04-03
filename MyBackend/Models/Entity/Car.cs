using MyBackend.Models.Enums;

namespace MyBackend.Models.Entity
{
    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public FuelTypes FuelType { get; set; }
    }
}
