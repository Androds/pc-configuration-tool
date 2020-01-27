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
    public class CaseControllerTests
    {
        private List<Case> GetTestCases()
        {
            var midTower = new PCItemType() { Name = "ATX Mid Tower" };
            var cases = new List<Case>();
            cases.Add(new Case()
            {
                Name = "NZXT H510",
                Color = "Black",
                PowerSupply = "None",
                ExternalBays = 0,
                InternalBays = 2,
                Window = true,
                Price = 69.98M,
                Type = midTower
            });
            cases.Add(new Case()
            {
                Name = "Phanteks P300",
                Color = "Black",
                PowerSupply = "None",
                ExternalBays = 0,
                InternalBays = 2,
                Window = false,
                Price = 49.99M,
                Type = midTower
            });
            return cases;
        }

        private Case GetCase()
        {
            var midTower = new PCItemType() { Name = "ATX Mid Tower" };

            return new Case()
            {
                Id = 1,
                Name = "NZXT H510",
                Color = "Black",
                PowerSupply = "None",
                ExternalBays = 0,
                InternalBays = 2,
                Window = true,
                Price = 69.98M,
                Type = midTower
            };
        }
        [Fact]
        public async Task Index_ReturnsAViewResult_WithAListOfCases()
        {
            // Arrange
            var mockCaseService = new Mock<IService<IRepository<Case>, Case>>();
            mockCaseService.Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(GetTestCases());
            var controller = new CaseController(mockCaseService.Object);

            // Act
            var result = await controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Case>>(
                viewResult.ViewData.Model);
            Assert.Equal(2, model.Count());
        }

        [Fact]
        public void Add_ReturnsBadRequestResult_WhenModelStateIsInvalid()
        {
            // Arrange
            var mockCaseService = new Mock<IService<IRepository<Case>, Case>>();
            var inputModel = new PCItemInputModel() { Id = 0, Quantity = 0 };
            var controller = new CaseController(mockCaseService.Object);
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
            var mockCaseService = new Mock<IService<IRepository<Case>, Case>>();
            mockCaseService.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(GetCase())
                .Verifiable();
            var httpContext = new DefaultHttpContext();
            var inputModel = new PCItemInputModel() { Id = 1, Quantity = 1 };
            var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());
            var controller = new CaseController(mockCaseService.Object) { TempData = tempData };
            controller.ModelState.AddModelError("Quantity", "Required");

            // Act
            var result = controller.Add(inputModel);

            // Assert
            Assert.IsType<JsonResult>(result.Result);
            mockCaseService.Verify();
        }
    }
}
