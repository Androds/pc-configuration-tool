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
    public class MemoryControllerTests
    {
        private List<Memory> GetTestMemorys()
        {
            var memories = new List<Memory>();
            var casLatency15 = new MemoryLatency() { Name = "15" };
            var modulesType = new PCItemType() { Name = "288-pin DIMM" };
            memories.Add(new Memory() { Name = "Corsair Vengeance LPX 16 GB", Modules = 2, Speed = 3000, Price = 75.98M, CASLatency = casLatency15, Type = modulesType });
            modulesType = new PCItemType() { Name = "288-pin DIMM" };
            var casLatency16 = new MemoryLatency() { Name = "16" };
            memories.Add(new Memory() { Name = "G.Skill Trident Z RGB 16 GB", Modules = 2, Speed = 3000, Price = 93.99M, CASLatency = casLatency16, Type = modulesType });
            return memories;
        }

        private Memory GetMemory()
        {
            var casLatency16 = new MemoryLatency() { Name = "16" };
            var modulesType = new PCItemType() { Name = "288-pin DIMM" };
            return new Memory() { Name = "G.Skill Trident Z RGB 16 GB", Modules = 2, Speed = 3000, Price = 93.99M, CASLatency = casLatency16, Type = modulesType };
        }
        [Fact]
        public async Task Index_ReturnsAViewResult_WithAListOfMemorys()
        {
            // Arrange
            var mockMemoryService = new Mock<IService<IRepository<Memory>, Memory>>();
            mockMemoryService.Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(GetTestMemorys());
            var controller = new MemoryController(mockMemoryService.Object);

            // Act
            var result = await controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Memory>>(
                viewResult.ViewData.Model);
            Assert.Equal(2, model.Count());
        }

        [Fact]
        public void Add_ReturnsBadRequestResult_WhenModelStateIsInvalid()
        {
            // Arrange
            var mockMemoryService = new Mock<IService<IRepository<Memory>, Memory>>();

            var controller = new MemoryController(mockMemoryService.Object);
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
            var mockMemoryService = new Mock<IService<IRepository<Memory>, Memory>>();
            mockMemoryService.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(GetMemory())
                .Verifiable();
            var httpContext = new DefaultHttpContext();
            var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());
            var controller = new MemoryController(mockMemoryService.Object) { TempData = tempData };
            controller.ModelState.AddModelError("Quantity", "Required");

            // Act
            var result = controller.Add(1, 1);

            // Assert
            Assert.IsType<JsonResult>(result.Result);
            mockMemoryService.Verify();
        }
    }
}
