using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using cars.Models;
using Microsoft.AspNetCore.Hosting;

namespace cars.Services
{
    public class CarService
    {
        // Constructor
        public CarService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "cars.json"); }
        }

        public IEnumerable<Car> GetCars()
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<Car[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }

        public void AddStock(string model, int quantity)
        {
            var cars = GetCars();
            var query = cars.First(x => x.model == model);

            query.quantity = quantity;

            using (var outputStream = File.OpenWrite(JsonFileName))
            {
                JsonSerializer.Serialize<IEnumerable<Car>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    {
                        SkipValidation = true,
                        Indented = true
                    }),
                    cars
                    );
            }
        }
    }
}
