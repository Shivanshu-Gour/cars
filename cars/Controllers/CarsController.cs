using cars.Models;
using cars.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cars.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        public CarsController(CarService carsService)
        {
            this.CarsService = carsService;
        }

        public CarService CarsService { get; }
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var cars = CarsService.GetCars();
            var models = from car in cars select car.model;
            var prods = models.ToList();
            return prods;
        }

        [Route("addStock")]
        [HttpPost]
        public ActionResult Get(
            [FromQuery] string model,
            [FromQuery] int stock)
        {
            CarsService.AddStock(model, stock);
            return Ok();
        }
    }
}
