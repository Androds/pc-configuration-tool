using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using PCConfiguration.Client.Factories;
using PCConfiguration.Client.ViewModels;
using PCConfiguration.Core.Interfaces;
using PCConfiguration.Data.Interfaces.Repositories;
using PCConfiguration.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PCConfiguration.Client
{
    public class CaseModel : PageModel
    {
        private readonly IService<IRepository<Case>, Case> caseService;

        /// <summary>
        /// Initializes a new instance of the <see cref="CaseModel"/> class.
        /// </summary>
        /// <param name="caseService">The case service.</param>
        public CaseModel(IService<IRepository<Case>, Case> caseService)
        {
            this.caseService = caseService;
        }

        public IEnumerable<Case> Cases { get; set; }

        public async Task OnGetAsync()
        {
            Cases = await caseService.GetAllAsync();
        }

        
        public async Task<IActionResult> OnPost(PCItemInputModel inputModel)
        {
            if (inputModel != null && inputModel.Id <= 0 && inputModel.Quantity <= 0)
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