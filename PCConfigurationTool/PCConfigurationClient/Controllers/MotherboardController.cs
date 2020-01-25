﻿using System;
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
    public class MotherboardController : Controller
    {
        private readonly IService<IRepository<Motherboard>, Motherboard> motherboardService;

        public MotherboardController(IService<IRepository<Motherboard>, Motherboard> motherboardService)
        {
            this.motherboardService = motherboardService;
        }

        // GET: CPU
        public async Task<IActionResult> Index()
        {
            return View(await this.motherboardService.GetAllAsync());
        }

        // GET: Motherboard/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
    }
}