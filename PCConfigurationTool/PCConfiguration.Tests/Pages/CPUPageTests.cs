using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;
using Moq;
using PCConfiguration.Client;
using PCConfiguration.Client.ViewModels;
using PCConfiguration.Core.Interfaces;
using PCConfiguration.Data.Interfaces.Repositories;
using PCConfiguration.Data.Models;
using System.Threading.Tasks;
using Xunit;

namespace PCConfiguration.Tests
{
    public class CPUPageTests
    {
        private CPU GetCPU()
        {
            return new CPU() { Name = "AMD Ryzen 5 3600", CoreClock = "3.6GHz", BoostClock = "4.2GHz", CoresCount = 6, IntegratedGPU = false, Price = 179.99M };
        }

        [Fact]
        public async Task Add_ReturnsBadRequestResult_WhenModelStateIsInvalid()
        {
            var mockCaseService = new Mock<IService<IRepository<CPU>, CPU>>();
            mockCaseService.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(GetCPU())
                .Verifiable();
            var httpContext = new DefaultHttpContext();
            var modelState = new ModelStateDictionary();
            var actionContext = new ActionContext(httpContext, new RouteData(), new PageActionDescriptor(), modelState);
            var modelMetadataProvider = new EmptyModelMetadataProvider();
            var viewData = new ViewDataDictionary(modelMetadataProvider, modelState);
            var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());
            var pageContext = new PageContext(actionContext)
            {
                ViewData = viewData
            };

            var inputModel = new PCItemInputModel() { Id = 0, Quantity = 0 };
            var pageModel = new CPUModel(mockCaseService.Object)
            {
                PageContext = pageContext,
                TempData = tempData,
                Url = new UrlHelper(actionContext)
            };

            // Act
            var result = await pageModel.OnPost(inputModel);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task Add_AddsCPUAndReturnsAResult_WhenModelStateIsValid()
        {
            //Arrange
            var mockCaseService = new Mock<IService<IRepository<CPU>, CPU>>();
            mockCaseService.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(GetCPU())
                .Verifiable();
            var httpContext = new DefaultHttpContext();
            var modelState = new ModelStateDictionary();
            var actionContext = new ActionContext(httpContext, new RouteData(), new PageActionDescriptor(), modelState);
            var modelMetadataProvider = new EmptyModelMetadataProvider();
            var viewData = new ViewDataDictionary(modelMetadataProvider, modelState);
            var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());
            var pageContext = new PageContext(actionContext)
            {
                ViewData = viewData
            };

            var inputModel = new PCItemInputModel() { Id = 1, Quantity = 1 };
            var pageModel = new CPUModel(mockCaseService.Object)
            {
                PageContext = pageContext,
                TempData = tempData,
                Url = new UrlHelper(actionContext)
            };

            // Act
            var result = await pageModel.OnPost(inputModel);

            // Assert
            Assert.IsType<JsonResult>(result);
        }
    }
}
