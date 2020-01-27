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
        private readonly IGenericService<IGenericRepository<CPU>, CPU> cpuService;

        /// <summary>
        /// Initializes a new instance of the <see cref="CPUController"/> class.
        /// </summary>
        /// <param name="cpuService">The cpu service.</param>
        public CPUController(IGenericService<IGenericRepository<CPU>, CPU> cpuService)
        {
            this.cpuService = cpuService;
        }

        // GET: CPU
        public async Task<IActionResult> Index()
        {
            return View(await this.cpuService.GetAllAsync());
        }

        public async Task<IActionResult> Add(PCItemInputModel inputModel)
        {
            if (inputModel != null && inputModel.Id <= 0 && inputModel.Quantity <= 0)
            {
                return BadRequest();
            }

            var cpu = await this.cpuService.GetByIdAsync(inputModel.Id);
            var cpuName = cpu.Name;
            var cpuPrice = await this.cpuService.CalculatePrice(inputModel.Id, inputModel.Quantity);

            var summaryViewModel = SummaryFactory.CreateSummaryViewModel(cpuName, cpuPrice, inputModel.ImageSrc);
            var serialized = JsonConvert.SerializeObject(summaryViewModel);

            var key = "CPU" + inputModel.Id;
            TempData[key] = serialized;
            TempData.Keep();

            return new JsonResult(summaryViewModel);
        }
    }
}
