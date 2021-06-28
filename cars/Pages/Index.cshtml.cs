using cars.Models;
using cars.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cars.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public CarService car_service;
        public IEnumerable<Car> Cars { get; private set; }

        public IndexModel(ILogger<IndexModel> logger, 
            CarService carService)
        {
            _logger = logger;
            car_service = carService;

        }

        public void OnGet()
        {
            Cars = car_service.GetCars();
        }
    }
}
