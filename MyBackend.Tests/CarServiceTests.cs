using Moq;
using MyBackend.Models.Entity;
using MyBackend.Models.Enums;
using MyBackend.Repositores.Interfaces;
using MyBackend.Services;

namespace MyBackend.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void AddCar_ShouldCallRepositoryAdd()
        {
            // Arrange
            var mockRepo = new Mock<ICarRepository>();
            var service = new CarService(mockRepo.Object);
            var car = new Car { Id = 1, Brand = "BMW", Model = "320", Year = 2020, FuelType = FuelTypes.DIESEL };

            // Act
            service.AddCar(car);

            // Assert
            mockRepo.Verify(r => r.AddCar(It.Is<Car>(c => c == car)), Times.Once);
        }

        [Fact]
        public void DeleteCar_ShouldCallRepositoryDelete()
        {
            // Arrange
            var mockRepo = new Mock<ICarRepository>();
            var service = new CarService(mockRepo.Object);
            int carId = 1;

            // Act
            service.DeleteCar(carId);

            // Assert
            mockRepo.Verify(r => r.DeleteCar(carId), Times.Once);
        }
    }
}
