using Microsoft.AspNetCore.Mvc;
using MyBackend.Models.Entity;
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
