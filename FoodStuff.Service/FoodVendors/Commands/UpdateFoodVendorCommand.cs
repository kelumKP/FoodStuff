using FoodStuff.Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodStuff.Service.FoodVendors.Commands
{
    public class UpdateFoodVendorCommand
    {
        private readonly IFoodVendorRepository _foodVendorRepository;

        public UpdateFoodVendorCommand(IFoodVendorRepository foodVendorRepository)
        {
            _foodVendorRepository = foodVendorRepository;
        }

        public async Task<bool> Execute(FoodVendor foodVendorData)
        {
            // Update the food vendor in the database.
            var foodVendor = await _foodVendorRepository.GetFoodVendorByIdAsync(foodVendorData.Id);
            foodVendor.FirstName = foodVendorData.FirstName;
            foodVendor.LastName = foodVendorData.LastName;

            return await _foodVendorRepository.UpdateFoodVendorAsync(foodVendor);
        }
    }
}