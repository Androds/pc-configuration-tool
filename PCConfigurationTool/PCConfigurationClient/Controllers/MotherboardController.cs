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

        public async Task<IActionResult> Add(int id, int quantity)
        {
            if (id <= 0 || quantity <= 0)
            {
                return BadRequest();
            }

            var motherboard = await this.motherboardService.GetByIdAsync(id);
            var motherboardName = motherboard.Name;
            var motherboardPrice = await this.motherboardService.CalculatePrice(id, quantity);

            var inputModel = new PCItemInputModel() { Price = motherboardPrice, Name = motherboardName };
            var summaryViewModel = SummaryFactory.CreateSummaryViewModel(inputModel);
            var serialized = JsonConvert.SerializeObject(summaryViewModel);

            var key = "Motherboard" + id;
            TempData[key] = serialized;
            TempData.Keep();

            return new JsonResult(summaryViewModel);
        }
    }
}