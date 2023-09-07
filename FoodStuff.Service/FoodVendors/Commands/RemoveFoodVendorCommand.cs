using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodStuff.Service.FoodVendors.Commands
{
    public class RemoveFoodVendorCommand
    {
        private readonly FoodVendorService _foodVendorService;

        public RemoveFoodVendorCommand(FoodVendorService foodVendorService)
        {
            _foodVendorService = foodVendorService;
        }

        public async Task Execute(int id)
        {
            // Delete the food vendor from the database.
            await _foodVendorService.RemoveFoodVendorAsync(id);
        }
    }
}