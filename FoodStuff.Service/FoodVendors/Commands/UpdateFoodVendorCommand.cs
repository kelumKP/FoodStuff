using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodStuff.Service.FoodVendors.Commands
{
    public class UpdateFoodVendorCommand
    {
        private readonly FoodVendorService _foodVendorService;

        public UpdateFoodVendorCommand(FoodVendorService foodVendorService)
        {
            _foodVendorService = foodVendorService;
        }

        public async Task Execute(FoodVendorData foodVendorData)
        {
            // Update the food vendor in the database.
            var foodVendor = await _foodVendorService.GetFoodVendorByIdAsync(foodVendorData.Id);
            foodVendor.FirstName = foodVendorData.FirstName;
            foodVendor.LastName = foodVendorData.LastName;

            await _foodVendorService.UpdateFoodVendorAsync(foodVendor);
        }
    }
}