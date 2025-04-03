using MyBackend.Models.Entity;
using MyBackend.Models.Enums;

namespace MyBackend.Services
{
    public class CarService
    {
        private List<Car> _cars = new List<Car>
    {
        new Car { Id = 1, Brand = "Toyota", Model = "Corolla", Year = 2020, FuelType =FuelTypes.SUPER },
        new Car { Id = 2, Brand = "BMW", Model = "X5", Year = 2019, FuelType =FuelTypes.DIESEL },
        new Car { Id = 3, Brand = "Audi", Model = "A4", Year = 2021 , FuelType =FuelTypes.DIESEL}
    };

        public List<Car> GetAll() => _cars;

        public void AddCar(Car car)
        {
            car.Id = _cars.Max(c => c.Id) + 1;
            _cars.Add(car);
        }

        public void DeleteCar(int id)
        {
            var car = _cars.FirstOrDefault(c => c.Id == id);
            if (car != null) _cars.Remove(car);
        }
    }
}
