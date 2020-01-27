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
    public class MemoryController : Controller
    {
        private readonly IGenericService<IGenericRepository<Memory>, Memory> memoryService;

        /// <summary>
        /// Initializes a new instance of the <see cref="MemoryController"/> class.
        /// </summary>
        /// <param name="memoryService">The memory service.</param>
        public MemoryController(IGenericService<IGenericRepository<Memory>, Memory> memoryService)
        {
            this.memoryService = memoryService;
        }

        // GET: CPU
        public async Task<IActionResult> Index()
        {
            return View(await this.memoryService.GetAllAsync());
        }

        public async Task<IActionResult> Add(PCItemInputModel inputModel)
        {
            if (inputModel != null && inputModel.Id <= 0 && inputModel.Quantity <= 0)
            {
                return BadRequest();
            }

            var memory = await this.memoryService.GetByIdAsync(inputModel.Id);
            var memoryName = memory.Name;
            var memoryPrice = await this.memoryService.CalculatePrice(inputModel.Id, inputModel.Quantity);

            var summaryViewModel = SummaryFactory.CreateSummaryViewModel(memoryName, memoryPrice, inputModel.ImageSrc);
            var serialized = JsonConvert.SerializeObject(summaryViewModel);

            var key = "Memory" + inputModel.Id;
            TempData[key] = serialized;
            TempData.Keep();

            return new JsonResult(summaryViewModel);
        }
    }
}