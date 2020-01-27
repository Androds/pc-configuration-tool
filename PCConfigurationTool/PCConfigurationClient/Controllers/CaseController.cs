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
    public class CaseController : Controller
    {
        private readonly IService<IRepository<Case>, Case> caseService;

        /// <summary>
        /// Initializes a new instance of the <see cref="CaseController"/> class.
        /// </summary>
        /// <param name="caseService">The case service.</param>
        public CaseController(IService<IRepository<Case>, Case> caseService)
        {
            this.caseService = caseService;
        }
       
        // GET: CPU
        public async Task<IActionResult> Index()
        {
            return View(await this.caseService.GetAllAsync());
        }
        
        [HttpPost]
        public async Task<IActionResult> Add(int id, int quantity)
        {
            if(id <= 0 && quantity <=0)
            {
                return BadRequest();
            }

            var compCase = await this.caseService.GetByIdAsync(id);
            var caseName = compCase.Name;
            var casePrice = await this.caseService.CalculatePrice(id, quantity);
            
            var inputModel = new PCItemInputModel() { Price = casePrice, Name = caseName };
            var summaryViewModel = SummaryFactory.CreateSummaryViewModel(inputModel);
            var serialized = JsonConvert.SerializeObject(summaryViewModel);

            var key = "Case" + id;
            TempData[key] = serialized;
            TempData.Keep();

            return new JsonResult(summaryViewModel);
        }
    }
}