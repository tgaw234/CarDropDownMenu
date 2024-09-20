using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarDropDownMenu.Models;
using CarDropDownMenu.Data;
using Microsoft.EntityFrameworkCore;

namespace CarDropDownMenu.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarRentalController : ControllerBase
    {
        private readonly CarRentalDbContext _context;

        public CarRentalController(CarRentalDbContext context)
        {
            _context = context;
        }

        // GET: api/CarRental/GetCarBrand
        [HttpGet("GetCarBrand")]
        public async Task<ActionResult<IEnumerable<CarBrand>>> GetCarBrands()
        {
            // Fetch car brands from the CarDb database
            var carBrands = await _context.Carbrands.ToListAsync();

            if (carBrands == null || carBrands.Count == 0)
            {
                return NotFound("No car brands found.");
            }

            return Ok(carBrands);
        }

        // GET: api/CarRental/GetCarMake/{brand}
        [HttpGet("GetCarMake/{brand}")]
        public async Task<ActionResult<IEnumerable<CarMake>>> GetCarMake(string brand)
        {
            // Find the car brand by name from the CarDb database
            var carBrand = await _context.Carbrands
                .FirstOrDefaultAsync(b => b.BrandName.ToLower() == brand.ToLower());

            if (carBrand == null)
            {
                return NotFound($"Car brand '{brand}' not found.");
            }

            // Fetch car makes associated with the car brand from the CarDb database
            var carMakes = await _context.CarMakes
                .Where(make => make.CarBrandId == carBrand.Id)
                .ToListAsync();

            if (carMakes == null || carMakes.Count == 0)
            {
                return NotFound($"No car makes found for the brand '{brand}'.");
            }

            return Ok(carMakes);
        }

        // POST: api/CarRental/PostSubmit
        [HttpPost("PostSubmit")]
        public async Task<ActionResult> PostSubmit([FromBody] RentalSubmission submission)
        {
            if (string.IsNullOrEmpty(submission.CarBrand) || string.IsNullOrEmpty(submission.CarMake))
            {
                return BadRequest("Missing required rental submission data.");
            }

            // Additional logic to process or save the submission to CarDb could go here

            return Ok(new
            {
                Message = "Rental request submitted successfully",
                Submission = submission
            });
        }
    }
}
