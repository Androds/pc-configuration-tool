using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PCConfiguration.Client.Factories;
using PCConfiguration.Client.ViewModels;
using PCConfiguration.Core.Interfaces;
using PCConfiguration.Data.Interfaces.Repositories;
using PCConfiguration.Data.Models;
using PCConfigurationClient.Factories;
using PCConfigurationClient.ViewModels;

namespace PCConfigurationClient.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
        
        [HttpGet]
        public async Task<IEnumerable<CaseViewModel>> Get()
        {
            
            var cases = await this.caseService.GetAllAsync();
            var caseViewModels = CaseFactory.MapCaseToCaseViewModel(cases);
            return caseViewModels;
        }
        //// GET: CPU
        //public async Task<IActionResult> Index()
        //{
        //    return View(await this.caseService.GetAllAsync());
        //}
        
        [HttpPost]
        public async Task<IActionResult> Add(PCItemInputModel inputModel)
        {
            if(inputModel != null && inputModel.Id <= 0 && inputModel.Quantity <= 0)
            {
                return BadRequest();
            }

            var compCase = await this.caseService.GetByIdAsync(inputModel.Id);
            var caseName = compCase.Name;
            var casePrice = await this.caseService.CalculatePrice(inputModel.Id, inputModel.Quantity);
            
            var summaryViewModel = SummaryFactory.CreateSummaryViewModel(caseName, casePrice, inputModel.ImageSrc);
            var serialized = JsonConvert.SerializeObject(summaryViewModel);

            var key = "Case" + inputModel.Id;
            TempData[key] = serialized;
            TempData.Keep();

            return new JsonResult(summaryViewModel);
        }
    }
}