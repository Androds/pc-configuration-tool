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
    public class VideoCardModel : PageModel
    {
        private readonly IService<IRepository<VideoCard>, VideoCard> videoCardService;

        /// <summary>
        /// Initializes a new instance of the <see cref="VideoCardModel"/> class.
        /// </summary>
        /// <param name="videoCardService">The videoCard service.</param>
        public VideoCardModel(IService<IRepository<VideoCard>, VideoCard> videoCardService)
        {
            this.videoCardService = videoCardService;
        }

        public IEnumerable<VideoCard> VideoCards { get; set; }

        public async Task OnGetAsync()
        {
            VideoCards = await videoCardService.GetAllAsync();
        }

        
        public async Task<IActionResult> OnPost(PCItemInputModel inputModel)
        {
            if (inputModel != null && inputModel.Id <= 0 && inputModel.Quantity <= 0)
            {
                return BadRequest();
            }

            var videoCard = await this.videoCardService.GetByIdAsync(inputModel.Id);
            var videoCardName = videoCard.Name;
            var videoCardPrice = await this.videoCardService.CalculatePrice(inputModel.Id, inputModel.Quantity);

            var summaryViewModel = SummaryFactory.CreateSummaryViewModel(videoCardName, videoCardPrice, inputModel.ImageSrc);
            var serialized = JsonConvert.SerializeObject(summaryViewModel);

            var key = "VideoCard" + inputModel.Id;
            TempData[key] = serialized;
            TempData.Keep();

            return new JsonResult(summaryViewModel);
        }
    }
}