using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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

        public PowerSupplyController(IService<IRepository<PowerSupply>, PowerSupply> powerSupplyService)
        {
            this.powerSupplyService = powerSupplyService;
        }

        // GET: CPU
        public async Task<IActionResult> Index()
        {
            return View(await this.powerSupplyService.GetAllAsync());
        }

        // GET: PowerSupply/Details/5
        public async Task<JsonResult> Add(int id, int quantity)
        {
            var powerSupply = await this.powerSupplyService.GetByIdAsync(id);
            var powerSupplyName = powerSupply.Name;
            var powerSupplyPrice = await this.powerSupplyService.CalculatePrice(id, quantity);

            PCItemInputModel inputModel = new PCItemInputModel() { Price = powerSupplyPrice, Name = powerSupplyName, CurrencySymbol = "$" };
            var summaryViewModel = SummaryFactory.CreateSummaryViewModel(inputModel);
            var serialized = JsonConvert.SerializeObject(summaryViewModel);

            var key = "PowerSupply" + id;
            TempData[key] = serialized;
            TempData.Keep();

            return new JsonResult(summaryViewModel);
        }
    }
}