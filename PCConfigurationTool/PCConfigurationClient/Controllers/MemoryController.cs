using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly IService<IRepository<Memory>, Memory> memoryService;

        public MemoryController(IService<IRepository<Memory>, Memory> memoryService)
        {
            this.memoryService = memoryService;
        }

        // GET: CPU
        public async Task<IActionResult> Index()
        {
            return View(await this.memoryService.GetAllAsync());
        }

        // GET: Memory/Details/5
        public async Task<ActionResult> Add(int id, int quantity)
        {
            var memory = await this.memoryService.GetByIdAsync(id);
            var memoryName = memory.Name;
            var memoryPrice = await this.memoryService.CalculatePrice(id, quantity);

            var inputModel = new PCItemInputModel() { Price = memoryPrice, Name = memoryName, CurrencySymbol = "$" };
            var summaryViewModel = SummaryFactory.CreateSummaryViewModel(inputModel);
            var serialized = JsonConvert.SerializeObject(summaryViewModel);

            var key = "Memory" + id;
            TempData[key] = serialized;
            TempData.Keep();

            return View();
        }
    }
}