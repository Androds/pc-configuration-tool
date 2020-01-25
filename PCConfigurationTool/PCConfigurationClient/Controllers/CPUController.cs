using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PCConfiguration.Core.Interfaces;
using PCConfiguration.Data;
using PCConfiguration.Data.Interfaces.Repositories;
using PCConfiguration.Data.Models;

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
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var cPU = await _context.CPUs
            //    .FirstOrDefaultAsync(m => m.Id == id);
            //if (cPU == null)
            //{
            //    return NotFound();
            //}

            return View();
        }
    }
}
