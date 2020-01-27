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
    public class PowerSupplyController : Controller
    {
        private readonly IService<IRepository<PowerSupply>, PowerSupply> powerSupplyService;

        /// <summary>
        /// Initializes a new instance of the <see cref="PowerSupplyController"/> class.
        /// </summary>
        /// <param name="powerSupplyService">The power supply service.</param>
        public PowerSupplyController(IService<IRepository<PowerSupply>, PowerSupply> powerSupplyService)
        {
            this.powerSupplyService = powerSupplyService;
        }

        // GET: CPU
        public async Task<IActionResult> Index()
        {
            return View(await this.powerSupplyService.GetAllAsync());
        }

        public async Task<IActionResult> Add(PCItemInputModel inputModel)
        {
            if (inputModel != null && inputModel.Id <= 0 && inputModel.Quantity <= 0)
            {
                return BadRequest();
            }

            var powerSupply = await this.powerSupplyService.GetByIdAsync(inputModel.Id);
            var powerSupplyName = powerSupply.Name;
            var powerSupplyPrice = await this.powerSupplyService.CalculatePrice(inputModel.Id, inputModel.Id);

            var summaryViewModel = SummaryFactory.CreateSummaryViewModel(powerSupplyName, powerSupplyPrice);
            var serialized = JsonConvert.SerializeObject(summaryViewModel);

            var key = "PowerSupply" + inputModel.Id;
            TempData[key] = serialized;
            TempData.Keep();

            return new JsonResult(summaryViewModel);
        }
    }
}