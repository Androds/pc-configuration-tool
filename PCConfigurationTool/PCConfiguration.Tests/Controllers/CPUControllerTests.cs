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
    public class CPUControllerTests
    {
        private List<CPU> GetTestCPUs()
        {            
            var CPUs = new List<CPU>();
            CPUs.Add(new CPU() { Name = "AMD Ryzen 5 3600", CoreClock = "3.6GHz", BoostClock = "4.2GHz", CoresCount = 6, IntegratedGPU = false, Price = 179.99M });
            CPUs.Add(new CPU() { Name = "AMD Ryzen 5 2600", CoreClock = "3.4GHz", BoostClock = "3.9GHz", CoresCount = 6, IntegratedGPU = false, Price = 119.99M });
            return CPUs;
        }

        private CPU GetCPU()
        {
            return new CPU() { Name = "AMD Ryzen 5 3600", CoreClock = "3.6GHz", BoostClock = "4.2GHz", CoresCount = 6, IntegratedGPU = false, Price = 179.99M };
        }

        [Fact]
        public async Task Index_ReturnsAViewResult_WithAListOfCPUs()
        {
            // Arrange
            var mockCPUService = new Mock<IService<IRepository<CPU>, CPU>>();
            mockCPUService.Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(GetTestCPUs());
            var controller = new CPUController(mockCPUService.Object);

            // Act
            var result = await controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<CPU>>(
                viewResult.ViewData.Model);
            Assert.Equal(2, model.Count());
        }

        [Fact]
        public void Add_ReturnsBadRequestResult_WhenModelStateIsInvalid()
        {
            // Arrange
            var mockCPUService = new Mock<IService<IRepository<CPU>, CPU>>();

            var controller = new CPUController(mockCPUService.Object);
            controller.ModelState.AddModelError("Quantity", "Required");

            // Act
            var result = controller.Add(0, 0);

            // Assert
            Assert.IsType<BadRequestResult>(result.Result);
        }

        [Fact]
        public void Add_AddsEmployeeAndReturnsARedirect_WhenModelStateIsValid()
        {
            //Arrange
            var mockCPUService = new Mock<IService<IRepository<CPU>, CPU>>();
            mockCPUService.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(GetCPU())
                .Verifiable();
            var httpContext = new DefaultHttpContext();
            var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());
            var controller = new CPUController(mockCPUService.Object) { TempData = tempData };
            controller.ModelState.AddModelError("Quantity", "Required");

            // Act
            var result = controller.Add(1, 1);

            // Assert
            Assert.IsType<JsonResult>(result.Result);
            mockCPUService.Verify();
        }
    }
}
