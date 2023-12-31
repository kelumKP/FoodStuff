﻿using FoodStuff.Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodStuff.Service.FoodVendors.Queries
{
    public class GetFoodVendorsQuery
    {
        private readonly IFoodVendorRepository _foodVendorRepository;

        public GetFoodVendorsQuery(IFoodVendorRepository foodVendorRepository)
        {
            _foodVendorRepository = foodVendorRepository;
        }

        public async Task<IEnumerable<FoodVendor>> ExecuteAsync()
        {
            // Get the food vendors from the repository.
            var foodVendors = await _foodVendorRepository.GetFoodVendorsAsync();

            // Return the food vendors.
            return foodVendors;
        }
    }
}