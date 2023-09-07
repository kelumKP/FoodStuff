using FoodStuff.Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodStuff.Service.FoodVendors.Queries
{
    public class GetFoodVendorsQuery
    {
        private readonly FoodVendorService _foodVendorService;

        public GetFoodVendorsQuery(FoodVendorService foodVendorService)
        {
            _foodVendorService = foodVendorService;
        }

        public async Task<IEnumerable<FoodVendor>> ExecuteAsync()
        {
            // Get the food vendors from the service.
            var foodVendors = await _foodVendorService.GetFoodVendorsAsync();

            // Return the food vendors.
            return foodVendors;
        }
    }
}