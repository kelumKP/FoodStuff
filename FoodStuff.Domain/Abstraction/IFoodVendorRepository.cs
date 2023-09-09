using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodStuff.Domain.Abstraction
{
    public interface IFoodVendorRepository
    {
        Task<List<FoodVendor>> GetFoodVendorsAsync();

        Task<FoodVendor> GetFoodVendorByIdAsync(int id);

        Task<bool> CreateFoodVendorAsync(FoodVendor foodVendor);

        Task<bool> RemoveFoodVendorAsync(int id);

        Task<bool> UpdateFoodVendorAsync(FoodVendor foodVendor);
    }
}
