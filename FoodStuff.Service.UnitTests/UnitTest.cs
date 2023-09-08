using FoodStuff.DAL;
using FoodStuff.Domain.Abstraction;
using FoodStuff.Service.FoodVendors;
using FoodStuff.Service.UnitTests;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace FoodStuff.Service.UnitTests
{
    [TestFixture]
    public class UnitTest
    {
        private readonly IFoodVendorService _service;

        public UnitTest(IFoodVendorService service)
        {
            _service = service;
        }

        [Test]
        public async Task GetFoodVendorsAsync_ShouldFoodVendorInDatabase()
        {
        }

    }
}