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
            var carBrands = await _context.CarBrands.ToListAsync();

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
            if (string.IsNullOrEmpty(brand))
            {
                return BadRequest("Brand name is required.");
            }

            var carBrand = await _context.CarBrands
                .FirstOrDefaultAsync(b => b.BrandName.ToLower() == brand.ToLower());

            if (carBrand == null)
            {
                return NotFound($"Car brand '{brand}' not found.");
            }

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

            // Business logic or save data to the database can be added here

            return Ok(new
            {
                Message = "Rental request submitted successfully",
                Submission = submission
            });
        }
    }
}
