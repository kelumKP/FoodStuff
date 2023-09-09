using FoodStuff.Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodStuff.Service.FoodVendors.Queries
{
    public class GetFoodVendorByIdQuery
    {
        private readonly IFoodVendorRepository _foodVendorRepository;

        public GetFoodVendorByIdQuery(IFoodVendorRepository foodVendorRepository)
        {
            _foodVendorRepository = foodVendorRepository;
        }

        public async Task<FoodVendor> ExecuteAsync(int id)
        {
            // Get the food vendors from the repository.
            var foodVendors = await _foodVendorRepository.GetFoodVendorByIdAsync(id);

            // Return the food vendors.
            return foodVendors;
        }
    }
}