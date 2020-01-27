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
    public class StorageControllerTests
    {
        private List<Storage> GetTestStorages()
        {
            var storages = new List<Storage>();
            var formFactor35 = new FormFactor() { Name = "3.5" };
            var conInterface = new ConnectionInterface() { Name = "SATA 6 GB/s" };
            var hdd = new PCItemType() { Name = "7200RPM" };
            storages.Add(new Storage() { Name = "Western Digital Caviar Blue", Capacity = "1TB", Cache = 64, FormFactor = formFactor35, Interface = conInterface, Type = hdd, Price = 44.08M });
            var formFactor25 = new FormFactor() { Name = "M2" };
            var ssd = new PCItemType() { Name = "SSD" };
            conInterface = new ConnectionInterface() { Name = "SATA 6 GB/s" };
            storages.Add(new Storage() { Name = "Samsung 860 Evo", Capacity = "1TB", Cache = 1024, FormFactor = formFactor25, Interface = conInterface, Type = ssd, Price = 149.99M });
            return storages;
        }

        private Storage GetStorage()
        {
            var formFactor25 = new FormFactor() { Name = "M2" };
            var ssd = new PCItemType() { Name = "SSD" };
            var conInterface = new ConnectionInterface() { Name = "SATA 6 GB/s" };
            return new Storage() { Name = "Samsung 860 Evo", Capacity = "1TB", Cache = 1024, FormFactor = formFactor25, Interface = conInterface, Type = ssd, Price = 149.99M };
        }
        [Fact]
        public async Task Index_ReturnsAViewResult_WithAListOfStorages()
        {
            // Arrange
            var mockStorageService = new Mock<IService<IRepository<Storage>, Storage>>();
            mockStorageService.Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(GetTestStorages());
            var controller = new StorageController(mockStorageService.Object);

            // Act
            var result = await controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Storage>>(
                viewResult.ViewData.Model);
            Assert.Equal(2, model.Count());
        }

        [Fact]
        public void Add_ReturnsBadRequestResult_WhenModelStateIsInvalid()
        {
            // Arrange
            var mockStorageService = new Mock<IService<IRepository<Storage>, Storage>>();

            var controller = new StorageController(mockStorageService.Object);
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
            var mockStorageService = new Mock<IService<IRepository<Storage>, Storage>>();
            mockStorageService.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(GetStorage())
                .Verifiable();
            var httpContext = new DefaultHttpContext();
            var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());
            var controller = new StorageController(mockStorageService.Object) { TempData = tempData };
            controller.ModelState.AddModelError("Quantity", "Required");

            // Act
            var result = controller.Add(1, 1);

            // Assert
            Assert.IsType<JsonResult>(result.Result);
            mockStorageService.Verify();
        }
    }
}
