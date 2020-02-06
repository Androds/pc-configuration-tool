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
    public class StorageModel : PageModel
    {
        private readonly IService<IRepository<Storage>, Storage> storageService;

        /// <summary>
        /// Initializes a new instance of the <see cref="StorageModel"/> class.
        /// </summary>
        /// <param name="storageService">The storage service.</param>
        public StorageModel(IService<IRepository<Storage>, Storage> storageService)
        {
            this.storageService = storageService;
        }

        public IEnumerable<Storage> Storages { get; set; }

        public async Task OnGetAsync()
        {
            Storages = await storageService.GetAllAsync();
        }

        
        public async Task<IActionResult> OnPost(PCItemInputModel inputModel)
        {
            if (inputModel != null && inputModel.Id <= 0 && inputModel.Quantity <= 0)
            {
                return BadRequest();
            }

            var storage = await this.storageService.GetByIdAsync(inputModel.Id);
            var storageName = storage.Name;
            var storagePrice = await this.storageService.CalculatePrice(inputModel.Id, inputModel.Quantity);

            var summaryViewModel = SummaryFactory.CreateSummaryViewModel(storageName, storagePrice, inputModel.ImageSrc);
            var serialized = JsonConvert.SerializeObject(summaryViewModel);

            var key = "Storage" + inputModel.Id;
            TempData[key] = serialized;
            TempData.Keep();

            return new JsonResult(summaryViewModel);
        }
    }
}