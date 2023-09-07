using FoodStuff.Domain.Abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodStuff.DAL
{
    public class FoodVendorRepository : IFoodVendorRepository
    {

        private readonly DataContext _context;
        public FoodVendorRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateFoodVendorAsync(FoodVendor foodVendor)
        {
            // Save the food vendor to the database.
            await _context.FoodVendors.AddAsync(foodVendor);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<FoodVendor>> GetFoodVendorsAsync()
        {
            var foodVendorList = await _context.FoodVendors.ToListAsync();
            return foodVendorList;
        }

        public async Task<bool> RemoveFoodVendorAsync(int id)
        {
            // Delete the food vendor from the database.
            var foodVendor = await _context.FoodVendors.FindAsync(id);
            if (foodVendor != null)
            {
                _context.FoodVendors.Remove(foodVendor);
                await _context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<bool> UpdateFoodVendorAsync(FoodVendor foodVendor)
        {
            // Update the food vendor in the database.
            var foodVendorInDb = await _context.FoodVendors.FindAsync(foodVendor.Id);
            if (foodVendorInDb != null)
            {
                foodVendorInDb.FirstName = foodVendor.FirstName;
                foodVendorInDb.LastName = foodVendor.LastName;

                _context.FoodVendors.Update(foodVendorInDb);
                await _context.SaveChangesAsync();

                return true;
            }

            return false;
        }
    }
}