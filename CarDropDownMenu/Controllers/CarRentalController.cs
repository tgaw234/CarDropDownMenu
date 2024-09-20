using Microsoft.AspNetCore.Mvc;
using CarRentalService.Models;
using System.Collections.Generic;
using CarDropDownMenu.Models;

namespace CarRentalService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarRentalController : ControllerBase
    {
        // Mock data for Car Brands
        private readonly List<CarBrand> _carBrands = new List<CarBrand>
        {
            new CarBrand { Brand = "Toyota" },
            new CarBrand { Brand = "BMW" },
            new CarBrand { Brand = "Ford" }
        };

        // Mock data for Car Makes
        private readonly List<CarMake> _carMakes = new List<CarMake>
        {
            new CarMake { Brand = "Toyota", Model = "Corolla", },
            new CarMake { Brand = "BMW", Model = "X5" },
            new CarMake { Brand = "Ford", Model = "Mustang" }
        };

        // GET: api/CarRental/GetCarBrand
        [HttpGet("GetCarBrand")]
        public ActionResult<IEnumerable<CarBrand>> GetCarBrand()
        {
            return Ok(_carBrands);
        }

        // GET: api/CarRental/GetCarMake
        [HttpGet("GetCarMake")]
        public ActionResult<IEnumerable<CarMake>> GetCarMake(string brand)
        {
            var carMakes = _carMakes.FindAll(m => m.Brand.ToLower() == brand.ToLower());
            if (carMakes == null || carMakes.Count == 0)
            {
                return NotFound("Car makes not found for the specified brand.");
            }

            return Ok(carMakes);
        }

        // POST: api/CarRental/PostSubmit
        [HttpPost("PostSubmit")]
        public ActionResult PostSubmit([FromBody] RentalSubmission submission)
        {
            if (string.IsNullOrEmpty(submission.Name) ||
                string.IsNullOrEmpty(submission.CarBrand) ||
                string.IsNullOrEmpty(submission.CarMake))
            {
                return BadRequest("Missing required rental submission data.");
            }

            // Here, you'd normally save the data or trigger a process.
            // For the example, we'll just return a success response.

            return Ok(new
            {
                Message = "Rental request submitted successfully",
                Submission = submission
            });
        }
    }
}
