using Moq;
using Moq.Async;
using FoodStuff.Service.FoodVendors.Queries;
using FoodStuff.Domain.Abstraction;
using FoodStuff.Service.FoodVendors;
using Castle.Core.Logging;
using FoodStuff.Service.FoodVendors.Commands;

namespace FoodStuff.Service.IntegrationTests
{
    public class IntegrationTest
    {
        [Fact]
        public async Task GetFoodVendorsAsync_ShouldReturnCorrectNumberOfVendors()
        {
            // Arrange: Create a mock repository with sample data
            var mockRepository = new Mock<IFoodVendorRepository>();
            mockRepository.Setup(repo => repo.GetFoodVendorsAsync())
                .ReturnsAsync(new List<FoodVendor>
                {
                    new FoodVendor { Id = 1, FirstName = "John", LastName = "Doe" },
                    new FoodVendor { Id = 2, FirstName = "Jane", LastName = "Smith" }
                });

            // Create the FoodVendorService with the mock repository
            var service = new FoodVendorService(
                new CreateFoodVendorCommand(mockRepository.Object),
                new GetFoodVendorsQuery(mockRepository.Object),
                new RemoveFoodVendorCommand(mockRepository.Object),
                new UpdateFoodVendorCommand(mockRepository.Object),
                new GetFoodVendorByIdQuery(mockRepository.Object)
            );

            // Act: Call the method you want to test
            var vendors = await service.GetFoodVendorsAsync();

            // Assert: Check if the method returned the expected result
            Assert.Equal(2, vendors.Count()); // Assuming you added 2 vendors in Arrange
        }
    }
}