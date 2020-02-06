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
    public class CPUModel : PageModel
    {
        private readonly IService<IRepository<CPU>, CPU> cpuService;

        /// <summary>
        /// Initializes a new instance of the <see cref="CPUModel"/> class.
        /// </summary>
        /// <param name="caseService">The cpu service.</param>
        public CPUModel(IService<IRepository<CPU>, CPU> cpuService)
        {
            this.cpuService = cpuService;
        }

        public IEnumerable<CPU> CPUs { get; set; }

        public async Task OnGetAsync()
        {
            CPUs = await cpuService.GetAllAsync();
        }

        
        public async Task<IActionResult> OnPost(PCItemInputModel inputModel)
        {
            if (inputModel != null && inputModel.Id <= 0 && inputModel.Quantity <= 0)
            {
                return BadRequest();
            }

            var cpu = await this.cpuService.GetByIdAsync(inputModel.Id);
            var cpuName = cpu.Name;
            var cpuPrice = await this.cpuService.CalculatePrice(inputModel.Id, inputModel.Quantity);

            var summaryViewModel = SummaryFactory.CreateSummaryViewModel(cpuName, cpuPrice, inputModel.ImageSrc);
            var serialized = JsonConvert.SerializeObject(summaryViewModel);

            var key = "CPU" + inputModel.Id;
            TempData[key] = serialized;
            TempData.Keep();

            return new JsonResult(summaryViewModel);
        }
    }
}