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

        public async Task<IActionResult> Add(int id, int quantity)
        {
            if (id <= 0 && quantity <= 0)
            {
                return BadRequest();
            }

            var storage = await this.storageService.GetByIdAsync(id);
            var storageName = storage.Name;
            var storagePrice = await this.storageService.CalculatePrice(id, quantity);

            var inputModel = new PCItemInputModel() { Price = storagePrice, Name = storageName };
            var summaryViewModel = SummaryFactory.CreateSummaryViewModel(inputModel);
            var serialized = JsonConvert.SerializeObject(summaryViewModel);

            var key = "Storage" + id;
            TempData[key] = serialized;
            TempData.Keep();

            return new JsonResult(summaryViewModel);
        }
    }
}