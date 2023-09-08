using FoodStuff.Domain.Abstraction;
using FoodStuff.Service.FoodVendors.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodStuff.Service.FoodVendors
{
    public class FoodVendorService : IFoodVendorService
    {

        private readonly IFoodVendorRepository _foodVendorRepository;

        public FoodVendorService(IFoodVendorRepository foodVendorRepository)
        {
            _foodVendorRepository = foodVendorRepository;
        }

        public async Task<IEnumerable<FoodVendor>> GetFoodVendorsAsync()
        {
            // Get the food vendors from the repository.
            var foodVendors = await _foodVendorRepository.GetFoodVendorsAsync();

            return foodVendors;
        }

        public async Task<FoodVendor> CreateFoodVendorAsync(FoodVendor foodVendor)
        {
            // Create a new food vendor.
            var createdFoodVendor = await _foodVendorRepository.CreateFoodVendorAsync(foodVendor);

            // Create a new FoodVendor object.
            var foodVendorObj = new FoodVendor();
            foodVendor.Id = foodVendor.Id;
            foodVendor.FirstName = foodVendor.FirstName;
            foodVendor.LastName = foodVendor.LastName;


            return foodVendorObj;
        }

        public async Task<bool> UpdateFoodVendorAsync(FoodVendor foodVendor)
        {
            // Update the food vendor in the database.
            var updatedFoodVendor = await _foodVendorRepository.UpdateFoodVendorAsync(foodVendor);

            return updatedFoodVendor;
        }

        public async Task<bool> RemoveFoodVendorAsync(int id)
        {
            // Delete the food vendor from the database.
            var removedFoodVendor = await _foodVendorRepository.RemoveFoodVendorAsync(id);

            return removedFoodVendor;
        }

        public async Task<FoodVendor> GetFoodVendorByIdAsync(int id)
        {
            // Get the food vendor from the repository.
            var foodVendors = await _foodVendorRepository.GetFoodVendorsAsync();
            var foodVendor = foodVendors.FirstOrDefault(x => x.Id == id);

            return foodVendor;
        }

    }
}
