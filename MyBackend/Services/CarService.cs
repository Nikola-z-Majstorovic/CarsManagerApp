using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.FileIO;
using MyBackend.Models.Entity;
using MyBackend.Models.Enums;
using MyBackend.Repositores.Interfaces;

namespace MyBackend.Services
{
    public class CarService
    {

        private readonly ICarRepository _repository;

        public CarService(ICarRepository repository)
        {
            _repository = repository;
        }
        public List<Car> GetAll() => _repository.GetAll();

        public void AddCar(Car car)
        {
            _repository.AddCar(car);
        }

        public void DeleteCar(int id)
        {
            _repository.DeleteCar(id);
        }

        public List<Car> Filter(int? year, FuelTypes? fuelType)
        {

            if (year.HasValue)
               return GetAll().Where(c => c.Year == year.Value).ToList();

            if (fuelType.HasValue)
                return GetAll().Where(c => c.FuelType == fuelType.Value).ToList();
            return [];
        }
    }
}
