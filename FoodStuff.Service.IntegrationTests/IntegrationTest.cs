using Moq;
using Moq.Async;
using FoodStuff.Service.FoodVendors.Queries;
using FoodStuff.Domain.Abstraction;
using FoodStuff.Service.FoodVendors;

namespace FoodStuff.Service.IntegrationTests
{
    public class IntegrationTest
    {
        [Fact]
        public async void GetFoodVendors_ReturnsEmptyList_IfNoFoodVendorsExist()
        {
            // Create a mock of the FoodVendorRepository.
            var foodVendorRepositoryMock = new Mock<IFoodVendorRepository>(MockBehavior.Strict);
            foodVendorRepositoryMock.Setup(x => x.GetFoodVendorsAsync()).Returns(Task.FromResult(new List<FoodVendor>()));

            // Create an instance of the FoodVendorService class.
            var foodVendorService = new FoodVendorService(foodVendorRepositoryMock.Object);

            // Call the GetFoodVendorsAsync() method.
            var foodVendors = await foodVendorService.GetFoodVendorsAsync();

            // Assert that the list of food vendors is empty.
            Assert.Empty(foodVendors);
        }

    }
}