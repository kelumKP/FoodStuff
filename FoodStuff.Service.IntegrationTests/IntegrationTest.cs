using Moq;
using Moq.Async;
using FoodStuff.Service.FoodVendors.Queries;

namespace FoodStuff.Service.IntegrationTests
{
    public class IntegrationTest
    {
        [Fact]
        public async void GetFoodVendors_ReturnsEmptyList_IfNoFoodVendorsExist()
        {
            // Arrange
            var mockFoodVendorService = new Mock<FoodVendors.FoodVendorService>();
            mockFoodVendorService.SetupAsync(x => x.GetFoodVendorsAsync()).ReturnsAsync(new List<FoodVendor>());

            var query = new GetFoodVendorsQuery(mockFoodVendorService.Object);

            // Act
            var foodVendors = await query.ExecuteAsync();

            // Assert
            Assert.Empty(foodVendors);
        }
    }
}