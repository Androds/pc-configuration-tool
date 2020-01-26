using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using PCConfiguration.Core.Interfaces;
using PCConfiguration.Data.Interfaces.Repositories;
using PCConfiguration.Data.Models;
using PCConfigurationClient.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace PCConfiguration.Tests
{
    public class PowerSupplyControllerTests
    {
        private List<PowerSupply> GetTestPowerSupplys()
        {
            var powerSupplies = new List<PowerSupply>();
            var formFactor = new FormFactor() { Name = "ATX" };
            powerSupplies.Add(new PowerSupply() { Name = "Corsair RM(2019)", Modular = true, Wattage = 750, Price = 119.99M, Efficiency = 80, FormFactor = formFactor });
            formFactor = new FormFactor() { Name = "ATX" };
            powerSupplies.Add(new PowerSupply() { Name = "EVGA BR", Modular = false, Wattage = 500, Price = 40.98M, Efficiency = 80, FormFactor = formFactor });
            return powerSupplies;
        }

        private PowerSupply GetPowerSupply()
        {
            var formFactor = new FormFactor() { Name = "ATX" };
            return new PowerSupply() { Name = "EVGA BR", Modular = false, Wattage = 500, Price = 40.98M, Efficiency = 80, FormFactor = formFactor };
        }
        [Fact]
        public async Task Index_ReturnsAViewResult_WithAListOfPowerSupplys()
        {
            // Arrange
            var mockPowerSupplyService = new Mock<IService<IRepository<PowerSupply>, PowerSupply>>();
            mockPowerSupplyService.Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(GetTestPowerSupplys());
            var controller = new PowerSupplyController(mockPowerSupplyService.Object);

            // Act
            var result = await controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<PowerSupply>>(
                viewResult.ViewData.Model);
            Assert.Equal(2, model.Count());
        }

        [Fact]
        public void Add_ReturnsBadRequestResult_WhenModelStateIsInvalid()
        {
            // Arrange
            var mockPowerSupplyService = new Mock<IService<IRepository<PowerSupply>, PowerSupply>>();

            var controller = new PowerSupplyController(mockPowerSupplyService.Object);
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
            var mockPowerSupplyService = new Mock<IService<IRepository<PowerSupply>, PowerSupply>>();
            mockPowerSupplyService.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(GetPowerSupply())
                .Verifiable();
            var httpContext = new DefaultHttpContext();
            var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());
            var controller = new PowerSupplyController(mockPowerSupplyService.Object) { TempData = tempData };
            controller.ModelState.AddModelError("Quantity", "Required");

            // Act
            var result = controller.Add(1, 1);

            // Assert
            Assert.IsType<JsonResult>(result.Result);
            mockPowerSupplyService.Verify();
        }
    }
}
