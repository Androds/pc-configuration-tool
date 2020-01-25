using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PCConfiguration.Core.Interfaces;
using PCConfiguration.Data.Interfaces.Repositories;
using PCConfiguration.Data.Models;

namespace PCConfigurationClient.Controllers
{
    public class MemoryController : Controller
    {
        private readonly IGenericService<IGenericRepository<Memory>, Memory> memoryService;

        public MemoryController(IGenericService<IGenericRepository<Memory>, Memory> memoryService)
        {
            this.memoryService = memoryService;
        }

        // GET: CPU
        public async Task<IActionResult> Index()
        {
            return View(await this.memoryService.GetAllAsync());
        }

        // GET: Memory/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
    }
}