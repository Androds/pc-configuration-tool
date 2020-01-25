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
    public class CaseController : Controller
    {
        private readonly IGenericService<IGenericRepository<Case>, Case> caseService;

        public CaseController(IGenericService<IGenericRepository<Case>, Case> caseService)
        {
            this.caseService = caseService;
        }

        // GET: CPU
        public async Task<IActionResult> Index()
        {
            return View(await this.caseService.GetAllAsync());
        }

        // GET: Case/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
    }
}