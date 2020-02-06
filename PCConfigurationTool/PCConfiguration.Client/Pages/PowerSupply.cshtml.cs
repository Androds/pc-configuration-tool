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
    public class PowerSupplyModel : PageModel
    {
        private readonly IService<IRepository<PowerSupply>, PowerSupply> powerSupplyService;

        /// <summary>
        /// Initializes a new instance of the <see cref="PowerSupplyModel"/> class.
        /// </summary>
        /// <param name="powerSupplyService">The powerSupply service.</param>
        public PowerSupplyModel(IService<IRepository<PowerSupply>, PowerSupply> powerSupplyService)
        {
            this.powerSupplyService = powerSupplyService;
        }

        public IEnumerable<PowerSupply> PowerSupplies { get; set; }

        public async Task OnGetAsync()
        {
            PowerSupplies = await powerSupplyService.GetAllAsync();
        }

        
        public async Task<IActionResult> OnPost(PCItemInputModel inputModel)
        {
            if (inputModel != null && inputModel.Id <= 0 && inputModel.Quantity <= 0)
            {
                return BadRequest();
            }

            var powerSupply = await this.powerSupplyService.GetByIdAsync(inputModel.Id);
            var powerSupplyName = powerSupply.Name;
            var powerSupplyPrice = await this.powerSupplyService.CalculatePrice(inputModel.Id, inputModel.Quantity);

            var summaryViewModel = SummaryFactory.CreateSummaryViewModel(powerSupplyName, powerSupplyPrice, inputModel.ImageSrc);
            var serialized = JsonConvert.SerializeObject(summaryViewModel);

            var key = "PowerSupply" + inputModel.Id;
            TempData[key] = serialized;
            TempData.Keep();

            return new JsonResult(summaryViewModel);
        }
    }
}