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
        private readonly FoodVendorService _foodVendorService;

        public CreateFoodVendorCommand(FoodVendorService foodVendorService)
        {
            _foodVendorService = foodVendorService;
        }

        public void Execute(FoodVendorData foodVendorData)
        {
            // Create a new food vendor.
            var foodVendor = new FoodVendor
            {
                FirstName = foodVendorData.FirstName,
                LastName = foodVendorData.LastName,
            };

            // Save the food vendor to the repository.
            _foodVendorService.CreateFoodVendorAsync(foodVendor);
        }
    }
}
