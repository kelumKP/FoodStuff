using FoodStuff.Domain.Abstraction;
using FoodStuff.Service.FoodVendors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FoodStuff.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FoodVendorController : ControllerBase
    {


        private readonly ILogger<FoodVendorController> _logger;
        private readonly IFoodVendorService _service;

        public FoodVendorController(ILogger<FoodVendorController> logger, IFoodVendorService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FoodVendor>>> GetFoodVendors()
        {
            // Get the food vendors from the service.
            var foodVendors = await _service.GetFoodVendorsAsync();

            // Return the food vendors.
            return Ok(foodVendors);
        }

        [HttpPost]
        public async Task<ActionResult<FoodVendor>> CreateFoodVendor(FoodVendor foodVendor)
        {

            // Create the food vendor.
            var createdFoodVendor = await _service.CreateFoodVendorAsync(foodVendor);

            if (createdFoodVendor == null)
            {
                return BadRequest("Failed to create food vendor");
            }

            // Return the list of food vendors.
            return Ok(await _service.GetFoodVendorsAsync());
        }

        [HttpPut]
        public async Task<ActionResult<FoodVendor>> UpdateFoodVendor(FoodVendor foodVendor)
        {

            // Update the food vendor.
            var updatedFoodVendor = await _service.UpdateFoodVendorAsync(foodVendor);

            if (updatedFoodVendor == null)
            {
                return BadRequest("Failed to update food vendor");
            }

            return Ok(updatedFoodVendor);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<FoodVendor>> RemoveFoodVendor(int id)
        {
            var foodVendor = await _service.GetFoodVendorByIdAsync(id);

            if (foodVendor == null)
            {
                return NotFound("Food vendor with id {id} not found");
            }

            await _service.RemoveFoodVendorAsync(id);

            return Ok(foodVendor);
        }
    }
}