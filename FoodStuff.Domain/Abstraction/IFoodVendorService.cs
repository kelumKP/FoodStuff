using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodStuff.Domain.Abstraction
{
    public interface IFoodVendorService
    {
        Task<IEnumerable<FoodVendor>> GetFoodVendorsAsync();
        Task<bool> CreateFoodVendorAsync(FoodVendor foodVendor);
        Task<bool> UpdateFoodVendorAsync(FoodVendor foodVendor);
        Task<bool> RemoveFoodVendorAsync(int id);
        Task<FoodVendor> GetFoodVendorByIdAsync(int id);
    }
}
