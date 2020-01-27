using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PCConfiguration.Core.Interfaces;
using PCConfiguration.Data.Interfaces.Repositories;
using PCConfiguration.Data.Models;
using PCConfigurationClient.Factories;
using PCConfigurationClient.ViewModels;

namespace PCConfigurationClient.Controllers
{
    public class StorageController : Controller
    {
        private readonly IService<IRepository<Storage>, Storage> storageService;

        /// <summary>
        /// Initializes a new instance of the <see cref="StorageController"/> class.
        /// </summary>
        /// <param name="storageService">The storage service.</param>
        public StorageController(IService<IRepository<Storage>, Storage> storageService)
        {
            this.storageService = storageService;
        }

        // GET: CPU
        public async Task<IActionResult> Index()
        
        {
            return View(await this.storageService.GetAllAsync());
        }

        public async Task<IActionResult> Add(PCItemInputModel inputModel)
        {
            if (inputModel != null && inputModel.Id <= 0 && inputModel.Quantity <= 0)
            {
                return BadRequest();
            }

            var storage = await this.storageService.GetByIdAsync(inputModel.Id);
            var storageName = storage.Name;
            var storagePrice = await this.storageService.CalculatePrice(inputModel.Id, inputModel.Id);

            var summaryViewModel = SummaryFactory.CreateSummaryViewModel(storageName, storagePrice);
            var serialized = JsonConvert.SerializeObject(summaryViewModel);

            var key = "Storage" + inputModel.Id;
            TempData[key] = serialized;
            TempData.Keep();

            return new JsonResult(summaryViewModel);
        }
    }
}