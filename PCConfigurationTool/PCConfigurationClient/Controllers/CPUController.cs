using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PCConfiguration.Core.Interfaces;
using PCConfiguration.Data;
using PCConfiguration.Data.Interfaces.Repositories;
using PCConfiguration.Data.Models;
using PCConfigurationClient.Factories;
using PCConfigurationClient.ViewModels;

namespace PCConfigurationClient.Controllers
{
    public class CPUController : Controller
    {
        private readonly IService<IRepository<CPU>, CPU> cpuService;

        public CPUController(IService<IRepository<CPU>, CPU> cpuService)
        {
            this.cpuService = cpuService;
        }

        // GET: CPU
        public async Task<IActionResult> Index()
        {
            return View(await this.cpuService.GetAllAsync());
        }

        // GET: CPU/Details/5
        public async Task<IActionResult> Add(int id, int quantity)
        {
            if (id <= 0 && quantity <= 0)
            {
                return BadRequest();
            }

            var cpu = await this.cpuService.GetByIdAsync(id);
            var cpuName = cpu.Name;
            var cpuPrice = await this.cpuService.CalculatePrice(id, quantity);

            var inputModel = new PCItemInputModel() { Price = cpuPrice, Name = cpuName, CurrencySymbol = "$" };
            var summaryViewModel = SummaryFactory.CreateSummaryViewModel(inputModel);
            var serialized = JsonConvert.SerializeObject(summaryViewModel);

            var key = "CPU" + id;
            TempData[key] = serialized;
            TempData.Keep();

            return new JsonResult(summaryViewModel);
        }
    }
}
