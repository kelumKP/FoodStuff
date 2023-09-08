using FoodStuff.Domain.Abstraction;
using FoodStuff.Service.FoodVendors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FoodStuff.WebAPI.Controllers
{
    [ApiController]
    [Route("API/[controller]")]
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
            try
            {
                // Validate the input data.
                if (ModelState.IsValid)
                {
                    // Create the food vendor.
                    var createdFoodVendor = await _service.CreateFoodVendorAsync(foodVendor);

                    // Return the list of food vendors.
                    return Ok(await _service.GetFoodVendorsAsync());
                }

                // Return errors.
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                // Log the exception.
                _logger.LogError(ex, "Failed to create food vendor");

                // Return an error message.
                return BadRequest("Failed to create food vendor");
            }
        }

        [HttpPut]
        public async Task<ActionResult<FoodVendor>> UpdateFoodVendor(FoodVendor foodVendor)
        {
            try
            {
                // Validate the input data.
                if (ModelState.IsValid)
                {
                    // Update the food vendor.
                    var updatedFoodVendor = await _service.UpdateFoodVendorAsync(foodVendor);

                    if (updatedFoodVendor == null)
                    {
                        return BadRequest("Failed to update food vendor");
                    }

                    // Return the list of food vendors.
                    return Ok(await _service.GetFoodVendorsAsync());
                }

                // Return errors.
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                // Log the exception.
                _logger.LogError(ex, "Failed to update food vendor");

                // Return an error message.
                return BadRequest("Failed to update food vendor");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<FoodVendor>> RemoveFoodVendor(int id)
        {
            try
            {
                var foodVendor = await _service.GetFoodVendorByIdAsync(id);

                if (foodVendor == null)
                {
                    return NotFound("Food vendor with id {id} not found");
                }

                await _service.RemoveFoodVendorAsync(id);

                // Return the list of food vendors.
                return Ok(await _service.GetFoodVendorsAsync());
            }
            catch (Exception ex)
            {
                // Log the exception.
                _logger.LogError(ex, "Failed to remove food vendor");

                // Return an error message.
                return BadRequest("Failed to remove food vendor");
            }
        }
    }
}