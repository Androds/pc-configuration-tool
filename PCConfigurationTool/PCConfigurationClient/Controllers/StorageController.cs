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
    public class StorageController : Controller
    {
        private readonly IGenericService<IGenericRepository<Storage>, Storage> storageService;

        public StorageController(IGenericService<IGenericRepository<Storage>, Storage> storageService)
        {
            this.storageService = storageService;
        }

        // GET: CPU
        public async Task<IActionResult> Index()
        
        {
            return View(await this.storageService.GetAllAsync());
        }

        // GET: Storage/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
    }
}