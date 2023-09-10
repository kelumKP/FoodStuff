using FoodStuff.Domain.Abstraction;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodStuff.DAL
{
    public class FoodVendorRepository : IFoodVendorRepository
    {

        private readonly DataContext _context;
        private readonly ILogger<FoodVendorRepository> _logger;

        public FoodVendorRepository(DataContext context, ILogger<FoodVendorRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<bool> CreateFoodVendorAsync(FoodVendor foodVendor)
        {
            try
            {
                // Save the food vendor to the database.
                await _context.FoodVendors.AddAsync(foodVendor);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (DbException e)
            {
                // Handle the database exception.
                _logger.LogError(e, "Error creating food vendor");
                return false;
            }
        }

        public async Task<List<FoodVendor>> GetFoodVendorsAsync()
        {
            try
            {
                // Get the food vendors from the database.
                var foodVendorList = await _context.FoodVendors.ToListAsync();
                return foodVendorList;
            }
            catch (DbException e)
            {
                // Handle the database exception.
                _logger.LogError(e, "Error getting food vendors");
                return null;
            }
        }

        public async Task<FoodVendor> GetFoodVendorByIdAsync(int id)
        {
            try
            {
                // Get the food vendor from the repository.
                var foodVendor = await _context.FoodVendors.FindAsync(id);

                // If the food vendor was found, return it.
                if (foodVendor != null)
                {
                    return foodVendor;
                }

                // Otherwise, return null.
                return null;
            }
            catch (DbException e)
            {
                // Handle the database exception.
                _logger.LogError(e, "Error getting food vendor by id");
                return null;
            }
        }

        public async Task<bool> RemoveFoodVendorAsync(int id)
        {
            try
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
            catch (DbException e)
            {
                // Handle the database exception.
                _logger.LogError(e, "Error removing food vendor");
                return false;
            }
        }

        public async Task<bool> UpdateFoodVendorAsync(FoodVendor foodVendor)
        {
            try
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
            catch (DbException e)
            {
                // Handle the database exception.
                _logger.LogError(e, "Error updating food vendor");
                return false;
            }
        }
    }
}