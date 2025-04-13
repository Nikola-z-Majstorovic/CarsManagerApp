using Microsoft.AspNetCore.Mvc;
using MyBackend.Models.Entity;
using MyBackend.Models.Enums;
using MyBackend.Services;

namespace MyBackend.Controllers
{
    [Route("api/cars")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly CarService _carService;

        public CarsController(CarService carService)
        {
            _carService = carService;
        }

        [HttpGet("filter")]
        public ActionResult<List<Car>> Filter([FromQuery] int? year, [FromQuery] FuelTypes? fuelType)
        {
           var filteredCars = _carService.Filter(year, fuelType);
            return Ok(filteredCars);
        }

        [HttpGet("", Name = "Get Cars")]
        public ActionResult<List<Car>> GetAll()
        {
            var cars = _carService.GetAll();            
            return Ok(cars);
        }
        [HttpPost("", Name = "Create Car")]
        public IActionResult AddCar([FromBody] Car car)
        {
            _carService.AddCar(car);
            return Ok();
        }

        [HttpDelete("{id}", Name = "Delete Car")]
        public IActionResult DeleteCar(int id)
        {
            _carService.DeleteCar(id);
            return Ok();
        }
    }
}
