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
    public class MotherboardModel : PageModel
    {
        private readonly IService<IRepository<Motherboard>, Motherboard> motherboardService;

        /// <summary>
        /// Initializes a new instance of the <see cref="MotherboardModel"/> class.
        /// </summary>
        /// <param name="motherboardService">The motherboard service.</param>
        public MotherboardModel(IService<IRepository<Motherboard>, Motherboard> motherboardService)
        {
            this.motherboardService = motherboardService;
        }

        public IEnumerable<Motherboard> Motherboards { get; set; }

        public async Task OnGetAsync()
        {
            Motherboards = await motherboardService.GetAllAsync();
        }

        
        public async Task<IActionResult> OnPost(PCItemInputModel inputModel)
        {
            if (inputModel != null && inputModel.Id <= 0 && inputModel.Quantity <= 0)
            {
                return BadRequest();
            }

            var motherboard = await this.motherboardService.GetByIdAsync(inputModel.Id);
            var motherboardName = motherboard.Name;
            var motherboardPrice = await this.motherboardService.CalculatePrice(inputModel.Id, inputModel.Quantity);

            var summaryViewModel = SummaryFactory.CreateSummaryViewModel(motherboardName, motherboardPrice, inputModel.ImageSrc);
            var serialized = JsonConvert.SerializeObject(summaryViewModel);

            var key = "Motherboard" + inputModel.Id;
            TempData[key] = serialized;
            TempData.Keep();

            return new JsonResult(summaryViewModel);
        }
    }
}