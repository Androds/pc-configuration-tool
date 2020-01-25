using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PCConfiguration.Core.Interfaces;
using PCConfiguration.Data.Interfaces.Repositories;
using PCConfiguration.Data.Models;

namespace PCConfigurationClient.Controllers
{
    public class PowerSupplyController : Controller
    {
        private readonly IGenericService<IGenericRepository<PowerSupply>, PowerSupply> powerSupplyService;

        public PowerSupplyController(IGenericService<IGenericRepository<PowerSupply>, PowerSupply> powerSupplyService)
        {
            this.powerSupplyService = powerSupplyService;
        }

        // GET: CPU
        public async Task<IActionResult> Index()
        {
            return View(await this.powerSupplyService.GetAllAsync());
        }

        // GET: PowerSupply/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
    }
}