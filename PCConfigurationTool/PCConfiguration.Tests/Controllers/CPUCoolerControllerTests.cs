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
    public class CPUCoolerControllerTests
    {
        private List<CPUCooler> GetTestCPUCoolers()
        {
            var midTower = new PCItemType() { Name = "ATX Mid Tower" };
            var CPUCoolers = new List<CPUCooler>();
            CPUCoolers.Add(new CPUCooler() { Name = "Cooler Master Hyper 212 EVO", NoiseLevel = 36, Size = 120, FanRPM = 2000, Price = 139.99M });
            CPUCoolers.Add(new CPUCooler() { Name = "Corsair H100i RGB PLATINUM", NoiseLevel = 37, Size = 240, FanRPM = 2400, Price = 34.49M });
            return CPUCoolers;
        }

        private CPUCooler GetCPUCooler()
        {
            var midTower = new PCItemType() { Name = "ATX Mid Tower" };

            return new CPUCooler()
            {
                Name = "Cooler Master Hyper 212 EVO",
                NoiseLevel = 36,
                Size = 120,
                FanRPM = 2000,
                Price = 139.99M
            };
        }
        [Fact]
        public async Task Index_ReturnsAViewResult_WithAListOfCPUCoolers()
        {
            // Arrange
            var mockCPUCoolerService = new Mock<IService<IRepository<CPUCooler>, CPUCooler>>();
            mockCPUCoolerService.Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(GetTestCPUCoolers());
            var controller = new CPUCoolersController(mockCPUCoolerService.Object);

            // Act
            var result = await controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<CPUCooler>>(
                viewResult.ViewData.Model);
            Assert.Equal(2, model.Count());
        }

        [Fact]
        public void Add_ReturnsBadRequestResult_WhenModelStateIsInvalid()
        {
            // Arrange
            var mockCPUCoolerService = new Mock<IService<IRepository<CPUCooler>, CPUCooler>>();

            var controller = new CPUCoolersController(mockCPUCoolerService.Object);
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
            var mockCPUCoolerService = new Mock<IService<IRepository<CPUCooler>, CPUCooler>>();
            mockCPUCoolerService.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(GetCPUCooler())
                .Verifiable();
            var httpContext = new DefaultHttpContext();
            var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());
            var controller = new CPUCoolersController(mockCPUCoolerService.Object) { TempData = tempData };
            controller.ModelState.AddModelError("Quantity", "Required");

            // Act
            var result = controller.Add(1, 1);

            // Assert
            Assert.IsType<JsonResult>(result.Result);
            mockCPUCoolerService.Verify();
        }
    }
}
