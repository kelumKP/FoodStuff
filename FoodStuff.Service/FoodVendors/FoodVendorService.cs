using FoodStuff.Domain.Abstraction;
using FoodStuff.Service.FoodVendors.Commands;
using FoodStuff.Service.FoodVendors.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodStuff.Service.FoodVendors
{
    public class FoodVendorService : IFoodVendorService
    {
        private readonly CreateFoodVendorCommand _createFoodVendorCommand;
        private readonly GetFoodVendorsQuery _getFoodVendorsQuery;
        private readonly RemoveFoodVendorCommand _removeFoodVendorCommand;
        private readonly UpdateFoodVendorCommand _updateFoodVendorCommand;
        private readonly GetFoodVendorByIdQuery _getFoodVendorByIdQuery;
        

        public FoodVendorService(
            CreateFoodVendorCommand createFoodVendorCommand,
            GetFoodVendorsQuery getFoodVendorsQuery,
            RemoveFoodVendorCommand removeFoodVendorCommand,
            UpdateFoodVendorCommand updateFoodVendorCommand,
            GetFoodVendorByIdQuery getFoodVendorByIdQuery)
        {
            _createFoodVendorCommand = createFoodVendorCommand;
            _getFoodVendorsQuery = getFoodVendorsQuery;
            _removeFoodVendorCommand = removeFoodVendorCommand;
            _updateFoodVendorCommand = updateFoodVendorCommand;
            _getFoodVendorByIdQuery = getFoodVendorByIdQuery;
        }

        public async Task<IEnumerable<FoodVendor>> GetFoodVendorsAsync()
        {
            // Get the food vendors from the commands.
            return await _getFoodVendorsQuery.ExecuteAsync();
        }

        public async Task<bool> CreateFoodVendorAsync(FoodVendor foodVendor)
        {
            // Create a new food vendor using the command.
            return await _createFoodVendorCommand.Execute(foodVendor);
        }

        public async Task<bool> UpdateFoodVendorAsync(FoodVendor foodVendor)
        {
            // Update the food vendor using the command.
            return await _updateFoodVendorCommand.Execute(foodVendor);
        }

        public async Task<bool> RemoveFoodVendorAsync(int id)
        {
            // Remove the food vendor using the command.
            return await _removeFoodVendorCommand.Execute(id);
        }

        public async Task<FoodVendor> GetFoodVendorByIdAsync(int id)
        {
            // Get the food vendor from the commands.
            return await _getFoodVendorByIdQuery.ExecuteAsync(id);
        }
    }
}
