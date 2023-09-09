using FoodStuff.Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FoodStuff.Service.FoodVendors.Commands
{
    public class CreateFoodVendorCommand
    {
        private readonly IFoodVendorRepository _foodVendorRepository;

        public CreateFoodVendorCommand(IFoodVendorRepository foodVendorRepository)
        {
            _foodVendorRepository = foodVendorRepository;
        }

        public async Task<bool> Execute(FoodVendor foodVendorData)
        {
            // Create a new food vendor.
            var foodVendor = new FoodVendor
            {
                FirstName = foodVendorData.FirstName,
                LastName = foodVendorData.LastName,
            };

            return await _foodVendorRepository.CreateFoodVendorAsync(foodVendor);
        }
    }
}
