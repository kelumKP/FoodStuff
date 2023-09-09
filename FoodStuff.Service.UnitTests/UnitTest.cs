using NUnit.Framework;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using FoodStuff.Domain;
using FoodStuff.Domain.Abstraction;
using FoodStuff.Service.FoodVendors;
using FoodStuff.Service.FoodVendors.Commands;
using FoodStuff.Service.FoodVendors.Queries;

namespace FoodStuff.Service.UnitTests
{
    [TestFixture]
    public class UnitTest
    {
        [Test]
        public async Task GetFoodVendorsAsync_ShouldReturnVendors()
        {
            // Arrange
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

            // Act
            var vendors = await service.GetFoodVendorsAsync();

            // Convert the IEnumerable<FoodVendor> to a list
            var vendorList = vendors.ToList();

            // Assert
            Assert.AreEqual(2, vendorList.Count);
            Assert.AreEqual("John", vendorList[0].FirstName);
            Assert.AreEqual("Jane", vendorList[1].FirstName);
        }
    }
}