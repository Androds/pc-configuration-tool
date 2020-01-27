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
    public class CPUCoolersController : Controller
    {
        private readonly IService<IRepository<CPUCooler>, CPUCooler> cpuCoolerService;

        /// <summary>
        /// Initializes a new instance of the <see cref="CPUCoolersController"/> class.
        /// </summary>
        /// <param name="cpuCoolerService">The cpu cooler service.</param>
        public CPUCoolersController(IService<IRepository<CPUCooler>, CPUCooler> cpuCoolerService)
        {
            this.cpuCoolerService = cpuCoolerService;
        }

        // GET: CPU
        public async Task<IActionResult> Index()
        {
            return View(await this.cpuCoolerService.GetAllAsync());
        }

        public async Task<IActionResult> Add(int id, int quantity)
        {
            if (id <= 0 && quantity <= 0)
            {
                return BadRequest();
            }

            var cpuCooler = await this.cpuCoolerService.GetByIdAsync(id);
            var cpuCoolerName = cpuCooler.Name;
            var cpuCoolerPrice = await this.cpuCoolerService.CalculatePrice(id, quantity);

            var inputModel = new PCItemInputModel() { Price = cpuCoolerPrice, Name = cpuCoolerName };
            var summaryViewModel = SummaryFactory.CreateSummaryViewModel(inputModel);
            var serialized = JsonConvert.SerializeObject(summaryViewModel);

            var key = "CPUCooler" + id;
            TempData[key] = serialized;
            TempData.Keep();

            return new JsonResult(summaryViewModel);
        }
    }
}