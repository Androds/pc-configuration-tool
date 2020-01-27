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
    public class VideoCardController : Controller
    {
        private readonly IGenericService<IGenericRepository<VideoCard>, VideoCard> videoCardService;

        /// <summary>
        /// Initializes a new instance of the <see cref="VideoCardController"/> class.
        /// </summary>
        /// <param name="videoCardService">The video card service.</param>
        public VideoCardController(IGenericService<IGenericRepository<VideoCard>, VideoCard> videoCardService)
        {
            this.videoCardService = videoCardService;
        }

        // GET: CPU
        public async Task<IActionResult> Index()
        {
            return View(await this.videoCardService.GetAllAsync());
        }

        public async Task<IActionResult> Add(PCItemInputModel inputModel)
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