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
    public class MemoryModel : PageModel
    {
        private readonly IService<IRepository<Memory>, Memory> memoryService;

        /// <summary>
        /// Initializes a new instance of the <see cref="MemoryModel"/> class.
        /// </summary>
        /// <param name="memoryService">The memory service.</param>
        public MemoryModel(IService<IRepository<Memory>, Memory> memoryService)
        {
            this.memoryService = memoryService;
        }

        public IEnumerable<Memory> Memories { get; set; }

        public async Task OnGetAsync()
        {
            Memories = await memoryService.GetAllAsync();
        }

        
        public async Task<IActionResult> OnPost(PCItemInputModel inputModel)
        {
            if (inputModel != null && inputModel.Id <= 0 && inputModel.Quantity <= 0)
            {
                return BadRequest();
            }

            var memory = await this.memoryService.GetByIdAsync(inputModel.Id);
            var memoryName = memory.Name;
            var memoryPrice = await this.memoryService.CalculatePrice(inputModel.Id, inputModel.Quantity);

            var summaryViewModel = SummaryFactory.CreateSummaryViewModel(memoryName, memoryPrice, inputModel.ImageSrc);
            var serialized = JsonConvert.SerializeObject(summaryViewModel);

            var key = "Memory" + inputModel.Id;
            TempData[key] = serialized;
            TempData.Keep();

            return new JsonResult(summaryViewModel);
        }
    }
}