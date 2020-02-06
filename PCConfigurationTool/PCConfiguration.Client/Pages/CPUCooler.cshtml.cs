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
    public class CPUCoolerModel : PageModel
    {
        private readonly IService<IRepository<CPUCooler>, CPUCooler> cpuCoolerService;

        /// <summary>
        /// Initializes a new instance of the <see cref="CPUCoolerModel"/> class.
        /// </summary>
        /// <param name="cpuCoolerService">The CPUCooler service.</param>
        public CPUCoolerModel(IService<IRepository<CPUCooler>, CPUCooler> cpuCoolerService)
        {
            this.cpuCoolerService = cpuCoolerService;
        }

        public IEnumerable<CPUCooler> CPUCoolers { get; set; }

        public async Task OnGetAsync()
        {
            CPUCoolers = await cpuCoolerService.GetAllAsync();
        }

        
        public async Task<IActionResult> OnPost(PCItemInputModel inputModel)
        {
            if (inputModel != null && inputModel.Id <= 0 && inputModel.Quantity <= 0)
            {
                return BadRequest();
            }

            var cpuCooler = await this.cpuCoolerService.GetByIdAsync(inputModel.Id);
            var cpuCoolerName = cpuCooler.Name;
            var cpuCoolerPrice = await this.cpuCoolerService.CalculatePrice(inputModel.Id, inputModel.Quantity);

            var summaryViewModel = SummaryFactory.CreateSummaryViewModel(cpuCoolerName, cpuCoolerPrice, inputModel.ImageSrc);
            var serialized = JsonConvert.SerializeObject(summaryViewModel);

            var key = "CPUCooler" + inputModel.Id;
            TempData[key] = serialized;
            TempData.Keep();

            return new JsonResult(summaryViewModel);
        }
    }
}