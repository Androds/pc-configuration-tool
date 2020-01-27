using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using PCConfiguration.Core.Interfaces;
using PCConfiguration.Data.Interfaces.Repositories;
using PCConfiguration.Data.Models;
using PCConfigurationClient.Controllers;
using PCConfigurationClient.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace PCConfiguration.Tests
{
    public class VideoCardControllerTests
    {
        private List<VideoCard> GetTestVideoCards()
        {
            var midTower = new PCItemType() { Name = "ATX Mid Tower" };
            var videoCards = new List<VideoCard>();
            var conInterface1 = new ConnectionInterface() { Name = "PCIe x16" };
            var conInterface2 = new ConnectionInterface() { Name = "PCIe x16" };
            videoCards.Add(new VideoCard() { Name = "MSI VENTUS XS OC", Chipset = "GeForce GTX 1660", MemorySize = 6, CoreSpeed = 1530, BoostSpeed = 1830, Price = 189.99M, Interface = conInterface1 });
            videoCards.Add(new VideoCard() { Name = "Asus ROG Strix Gaming OC", Chipset = "GeForce RTX 2080 Ti", MemorySize = 11, CoreSpeed = 1665, BoostSpeed = 1830, Price = 1229.99M, Interface = conInterface2 });
            return videoCards;
        }

        private VideoCard GetVideoCard()
        {
            var conInterface2 = new ConnectionInterface() { Name = "PCIe x16" };
            return new VideoCard() { Name = "Asus ROG Strix Gaming OC", Chipset = "GeForce RTX 2080 Ti", MemorySize = 11, CoreSpeed = 1665, BoostSpeed = 1830, Price = 1229.99M, Interface = conInterface2 };
        }
        [Fact]
        public async Task Index_ReturnsAViewResult_WithAListOfVideoCards()
        {
            // Arrange
            var mockVideoCardService = new Mock<IService<IRepository<VideoCard>, VideoCard>>();
            mockVideoCardService.Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(GetTestVideoCards());
            var controller = new VideoCardController(mockVideoCardService.Object);

            // Act
            var result = await controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<VideoCard>>(
                viewResult.ViewData.Model);
            Assert.Equal(2, model.Count());
        }

        [Fact]
        public void Add_ReturnsBadRequestResult_WhenModelStateIsInvalid()
        {
            // Arrange
            var mockVideoCardService = new Mock<IService<IRepository<VideoCard>, VideoCard>>();
            var inputModel = new PCItemInputModel() { Id = 0, Quantity = 0 };
            var controller = new VideoCardController(mockVideoCardService.Object);
            controller.ModelState.AddModelError("Quantity", "Required");

            // Act
            var result = controller.Add(inputModel);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestResult>(result.Result);
        }

        [Fact]
        public void Add_AddsEmployeeAndReturnsARedirect_WhenModelStateIsValid()
        {
            //Arrange
            var mockVideoCardService = new Mock<IService<IRepository<VideoCard>, VideoCard>>();
            mockVideoCardService.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(GetVideoCard())
                .Verifiable();
            var httpContext = new DefaultHttpContext();
            var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());
            var controller = new VideoCardController(mockVideoCardService.Object) { TempData = tempData };
            controller.ModelState.AddModelError("Quantity", "Required");
            var inputModel = new PCItemInputModel() { Id = 1, Quantity = 1 };

            // Act
            var result = controller.Add(inputModel);

            // Assert
            Assert.IsType<JsonResult>(result.Result);
            mockVideoCardService.Verify();
        }
    }
}
