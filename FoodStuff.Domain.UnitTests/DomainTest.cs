using Xunit;
using FoodStuff.Domain;

namespace FoodStuff.Domain.UnitTests
{
    public class DomainTest
    {
        [Fact]
        public void FoodVendor_Constructor_SetsProperties()
        {
            // Arrange
            var id = 1;
            var firstName = "John";
            var lastName = "Doe";

            // Act
            var foodVendor = new FoodVendor
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName
            };

            // Assert
            Assert.Equal(id, foodVendor.Id);
            Assert.Equal(firstName, foodVendor.FirstName);
            Assert.Equal(lastName, foodVendor.LastName);
        }
    }
}