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
    public class MotherboardController : Controller
    {
        private readonly IService<IRepository<Motherboard>, Motherboard> motherboardService;

        /// <summary>
        /// Initializes a new instance of the <see cref="MotherboardController"/> class.
        /// </summary>
        /// <param name="motherboardService">The motherboard service.</param>
        public MotherboardController(IService<IRepository<Motherboard>, Motherboard> motherboardService)
        {
            this.motherboardService = motherboardService;
        }

        // GET: CPU
        public async Task<IActionResult> Index()
        {
            return View(await this.motherboardService.GetAllAsync());
        }

        public async Task<IActionResult> Add(PCItemInputModel inputModel)
        {
            if (inputModel != null && inputModel.Id <= 0 && inputModel.Quantity <= 0)
            {
                return BadRequest();
            }

            var motherboard = await this.motherboardService.GetByIdAsync(inputModel.Id);
            var motherboardName = motherboard.Name;
            var motherboardPrice = await this.motherboardService.CalculatePrice(inputModel.Id, inputModel.Id);

            var summaryViewModel = SummaryFactory.CreateSummaryViewModel(motherboardName, motherboardPrice);
            var serialized = JsonConvert.SerializeObject(summaryViewModel);

            var key = "Motherboard" + inputModel.Id;
            TempData[key] = serialized;
            TempData.Keep();

            return new JsonResult(summaryViewModel);
        }
    }
}