using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using PCConfiguration.Core.Interfaces;
using PCConfiguration.Data.Interfaces.Repositories;
using PCConfiguration.Data.Models;
using PCConfigurationClient.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace PCConfiguration.Tests
{
    public class MotherboardControllerTests
    {
        private List<Motherboard> GetTestMotherboards()
        {
            var motherboards = new List<Motherboard>();
            var am4SocketType = new PCItemType() { Name = "AM4" };
            var motherboardFormFactor = new FormFactor() { Name = "ATX" };
            motherboards.Add(new Motherboard() { Name = "MSI B450 TOMAHAWK", MaxRam = 64, RamSlots = 4, Price = 111.99M, FormFactor = motherboardFormFactor, SocketType = am4SocketType });
            motherboardFormFactor = new FormFactor() { Name = "ATX" };
            am4SocketType = new PCItemType() { Name = "AM4" };
            motherboards.Add(new Motherboard() { Name = "Asus ROG STRIX B450-F GAMING", MaxRam = 64, RamSlots = 4, Price = 129.99M, FormFactor = motherboardFormFactor, SocketType = am4SocketType });
            return motherboards;
        }

        private Motherboard GetMotherboard()
        {
            var am4SocketType = new PCItemType() { Name = "AM4" };
            var motherboardFormFactor = new FormFactor() { Name = "ATX" };
            return new Motherboard() { Name = "Asus ROG STRIX B450-F GAMING", MaxRam = 64, RamSlots = 4, Price = 129.99M, FormFactor = motherboardFormFactor, SocketType = am4SocketType };
        }
        [Fact]
        public async Task Index_ReturnsAViewResult_WithAListOfMotherboards()
        {
            // Arrange
            var mockMotherboardService = new Mock<IService<IRepository<Motherboard>, Motherboard>>();
            mockMotherboardService.Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(GetTestMotherboards());
            var controller = new MotherboardController(mockMotherboardService.Object);

            // Act
            var result = await controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Motherboard>>(
                viewResult.ViewData.Model);
            Assert.Equal(2, model.Count());
        }

        [Fact]
        public void Add_ReturnsBadRequestResult_WhenModelStateIsInvalid()
        {
            // Arrange
            var mockMotherboardService = new Mock<IService<IRepository<Motherboard>, Motherboard>>();

            var controller = new MotherboardController(mockMotherboardService.Object);
            controller.ModelState.AddModelError("Quantity", "Required");

            // Act
            var result = controller.Add(0, 0);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestResult>(result.Result);
        }

        [Fact]
        public void Add_AddsEmployeeAndReturnsARedirect_WhenModelStateIsValid()
        {
            //Arrange
            var mockMotherboardService = new Mock<IService<IRepository<Motherboard>, Motherboard>>();
            mockMotherboardService.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(GetMotherboard())
                .Verifiable();
            var httpContext = new DefaultHttpContext();
            var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());
            var controller = new MotherboardController(mockMotherboardService.Object) { TempData = tempData };
            controller.ModelState.AddModelError("Quantity", "Required");

            // Act
            var result = controller.Add(1, 1);

            // Assert
            Assert.IsType<JsonResult>(result.Result);
            mockMotherboardService.Verify();
        }
    }
}
