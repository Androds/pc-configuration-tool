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
    public class CPUController : Controller
    {
        private readonly IService<IRepository<CPU>, CPU> cpuService;

        /// <summary>
        /// Initializes a new instance of the <see cref="CPUController"/> class.
        /// </summary>
        /// <param name="cpuService">The cpu service.</param>
        public CPUController(IService<IRepository<CPU>, CPU> cpuService)
        {
            this.cpuService = cpuService;
        }

        // GET: CPU
        public async Task<IActionResult> Index()
        {
            return View(await this.cpuService.GetAllAsync());
        }

        public async Task<IActionResult> Add(int id, int quantity)
        {
            if (id <= 0 && quantity <= 0)
            {
                return BadRequest();
            }

            var cpu = await this.cpuService.GetByIdAsync(id);
            var cpuName = cpu.Name;
            var cpuPrice = await this.cpuService.CalculatePrice(id, quantity);

            var inputModel = new PCItemInputModel() { Price = cpuPrice, Name = cpuName };
            var summaryViewModel = SummaryFactory.CreateSummaryViewModel(inputModel);
            var serialized = JsonConvert.SerializeObject(summaryViewModel);

            var key = "CPU" + id;
            TempData[key] = serialized;
            TempData.Keep();

            return new JsonResult(summaryViewModel);
        }
    }
}
