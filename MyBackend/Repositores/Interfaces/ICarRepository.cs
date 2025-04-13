using MyBackend.Models.Entity;

namespace MyBackend.Repositores.Interfaces
{
    public interface ICarRepository
    {
        public List<Car> GetAll();
        public void AddCar(Car car);
        public void DeleteCar(int id);
    }
}
