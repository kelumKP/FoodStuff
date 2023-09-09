using FoodStuff.Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodStuff.Service.FoodVendors.Commands
{
    public class RemoveFoodVendorCommand
    {
        private readonly IFoodVendorRepository _foodVendorRepository;

        public RemoveFoodVendorCommand(IFoodVendorRepository foodVendorRepository)
        {
            _foodVendorRepository = foodVendorRepository;
        }

        public async Task<bool> Execute(int id)
        {
            // Delete the food vendor from the database.
            return await _foodVendorRepository.RemoveFoodVendorAsync(id);
        }
    }
}