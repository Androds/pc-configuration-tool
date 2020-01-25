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
    public class CPUCoolersController : Controller
    {
        private readonly IService<IRepository<CPUCooler>, CPUCooler> cpuCoolerService;

        public CPUCoolersController(IService<IRepository<CPUCooler>, CPUCooler> cpuCoolerService)
        {
            this.cpuCoolerService = cpuCoolerService;
        }

        // GET: CPU
        public async Task<IActionResult> Index()
        {
            return View(await this.cpuCoolerService.GetAllAsync());
        }

        // GET: CPUCoolers/Details/5
        public ActionResult Details(int id)
        {
            return View();
            //return RedirectToAction(nameof(Index));
        }
    }
}